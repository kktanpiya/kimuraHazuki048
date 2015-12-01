
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Graphics;
using PI1M_Dashboard.Lib.DLayer.SQLite;
using Newtonsoft.Json;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Tulis Aduan", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class ComposeMsg : ActionBarActivity
	{
		Connection dbConn;
		public string sqliteFile;
		public string libraryPath;
		public string dbPath;
		string folderPath;
		private Android.Support.V7.Widget.Toolbar toolbar;

		EditText etMSCMTTo;
		EditText etMSCMTSubject;
		EditText etMSCMTPesanan;

		ImageView ivMSCMTGetPBT;
		LinearLayout llMSCMTGetPBT;
		Button btnMSCMTGetPBT;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = System.IO.Path.Combine (folderPath , sqliteFile);
			Console.WriteLine ("[ComposeMessage] Checking database path: {0}",dbPath);
			dbConn = new Connection (dbPath);

			//SetContentView (Resource.Layout.MySoal_ComposeMsg);
			SetContentView (Resource.Layout.MySoal_ComposeMsgTwo);

			//etMSCMTo = (EditText)FindViewById (Resource.Id.etMSCMTo);
			//etMSCMSubject = (EditText)FindViewById (Resource.Id.etMSCMSubject);
			//etMSCMMessage = (EditText)FindViewById (Resource.Id.etMSCMMessage);

			etMSCMTTo = (EditText)FindViewById (Resource.Id.etMSCMTTo);
			etMSCMTSubject = (EditText)FindViewById (Resource.Id.etMSCMTSubject);
			etMSCMTPesanan = (EditText)FindViewById (Resource.Id.etMSCMTPesanan);

			//ivMSCMTGetPBT = (ImageView)FindViewById (Resource.Id.ivMSCMTGetPBT);
			llMSCMTGetPBT = (LinearLayout)FindViewById (Resource.Id.llMSCMTGetPBT);
			btnMSCMTGetPBT = (Button)FindViewById (Resource.Id.btnMSCMTGetPBT);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F44336"));
			SetSupportActionBar (toolbar);

			btnMSCMTGetPBT.Click += delegate {

				Intent dataPass = new Intent(ApplicationContext,typeof(ComposeMsg_ListPBT));
				dataPass.PutExtra("SiteCode", Intent.GetStringExtra ("SiteCode"));
				StartActivityForResult(dataPass,0);
				this.OverridePendingTransition (0, 0);

			};

		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_composemsg, menu);
			return base.OnCreateOptionsMenu(menu);
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId){

			case Resource.Id.send_message:
				if (CheckFieldIsFilled () == true) {
					if (SendIntoServer () == true) {
						StoreIntoSendMessageDB ();
					} else {
						Toast.MakeText (Application.Context, "Pesanan gagal dihantar. Sila cuba sekali lagi.", ToastLength.Short).Show ();
					}
					Toast.MakeText (Application.Context, "Pesanan telah berjaya dihantar.", ToastLength.Short).Show ();
					this.Finish ();
				}
				break;

			}
			return base.OnOptionsItemSelected(item);
		}

		public bool CheckFieldIsFilled()
		{
			if (etMSCMTTo.Text == "" || etMSCMTSubject.Text == "" || etMSCMTPesanan.Text == "") {

				Toast.MakeText (Application.Context, "Sila penuhkan semua tempat kosong.", ToastLength.Long).Show ();

				return false;
			} else {
				return true;
			}
		}

		public bool SendIntoServer()
		{
			WebServices wbs = new WebServices ();
			string sendMessageStatus = wbs.setMySoalSentMessage (Intent.GetStringExtra("MySoalToken"), etMSCMTTo.Text, etMSCMTSubject.Text, etMSCMTPesanan.Text);
			WebServices.MySoalSentMessageRootObj statusRootObj = JsonConvert.DeserializeObject<WebServices.MySoalSentMessageRootObj> (sendMessageStatus);

			if (statusRootObj.status == 1) {
				return true;
			} else {
				return false;
			}
		}

		public void StoreIntoSendMessageDB()
		{
			
			var mySoalSentItems = new MySoal_SentItems ();

			mySoalSentItems.si_from = Intent.GetStringExtra("UserEmail");
			mySoalSentItems.si_to = etMSCMTTo.Text;
			mySoalSentItems.si_subject = etMSCMTSubject.Text;
			mySoalSentItems.si_content = etMSCMTPesanan.Text;
			mySoalSentItems.si_sentAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

			dbConn.Insert (mySoalSentItems);

			var checkQuery = dbConn.Table<MySoal_SentItems> ();

			foreach (var queryline in checkQuery) {

				Console.WriteLine ("[ComposeMessage] Checking all subjects sent {0} from {1}",
					queryline.si_subject,
					queryline.si_from);
			}
		}

		public static String GetTimestamp(DateTime value) {
			return value.ToString("yyyyMMddHHmmss");
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent intentData)
		{
			base.OnActivityResult (requestCode, resultCode, intentData);

			if (resultCode == Result.Ok) {

				Console.WriteLine ("[MySoalPR_PBTAnnounce] OnActivityResult called");

				var PBT_Name = intentData.GetStringExtra ("PBT_Name") ?? "";
				//PBT_Sender = intentData.GetStringExtra ("PBT") ?? "";
				var PBT_ID = intentData.GetStringExtra ("PBT_ID") ?? "";

				Console.WriteLine ("[MySoalPR_PBTAnnounce] OnActivityResult called: PBT Name is {0}",PBT_Name);
				Console.WriteLine ("[MySoalPR_PBTAnnounce] OnActivityResult called: PBT ID is {0}",PBT_ID);

				//Pbt_ID_selected = PBT_ID + ",";

				Console.WriteLine ("[MySoalPR_PBTAnnounce] Senarai PBT :" + PBT_Name );
				Console.WriteLine ("[MySoalPR_PBTAnnounce] PBT ID :" + PBT_ID );


				TextView txt_PBT_Name = FindViewById<TextView> (Resource.Id.etMSCMTTo);

				txt_PBT_Name.Text = PBT_Name;
				//etToAddressee.Text = intentData.GetStringExtra("addresseeStrExt");
			}


		}

	}
}

