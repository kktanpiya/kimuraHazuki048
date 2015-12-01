
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
using Android.Support.V7.Widget;
using Newtonsoft.Json;
using System.Threading;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyShop_Tab_2 : Android.Support.V4.App.Fragment 
	{
		//MySkool_ListDataHolder listData;
		MyShop_ListDataHolderList listData;
		MyShop_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		LinearLayout llMSkT1ErrorStatus;
		TextView tvMSkT1ErrorStatus;

		List<MyShop_ListData> mySkoolListData = new List<MyShop_ListData>();
		List<string> mySkoolTitleList = new List<string> ();
		List<string> mySkoolContentList = new List<string> ();

		ProgressDialog progressDialog;

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MySoal_tab_1 ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);

			//progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			//llMSkT1ErrorStatus = (LinearLayout)v.FindViewById (Resource.Id.llMSPT1ErrorStatus);
			//tvMSkT1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMSPT1ErrorStatus);

			return v;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			//ThreadPool.QueueUserWorkItem (o => { InitialSetup(); });

		}

		private void InitialSetup()
		{
			string mySkoolToken = setupMySkoolData ();

			string mySkoolRawData = getMySkoolJSONData(mySkoolToken.ToString(), 1);
			var mySkoolJSONed = JsonConvert.DeserializeObject<WebServices.MySkoolPetiMasukData> (mySkoolRawData);

			int totalPage = 0;

			foreach (var mySkoolPaging in mySkoolJSONed.paging) {
				Console.WriteLine ("[MySoal - Peti Masuk] Paging: {0}",mySkoolPaging.count);
				totalPage = mySkoolPaging.count;
			}

			if (totalPage != 0) {

				Activity.RunOnUiThread (() => {
					llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
					recyclerView.Visibility = ViewStates.Visible;
				});

				foreach (var msjsoned in mySkoolJSONed.data) {
					mySkoolListData.Add (new MyShop_ListData { 
						mTitle = msjsoned.title, 
						mContent = msjsoned.text.ToString ()//.Substring (0, 50) + "..."
					});

					mySkoolTitleList.Add (msjsoned.title);
					mySkoolContentList.Add (msjsoned.content);
				}

			} else {

				Activity.RunOnUiThread (() => {
					llMSkT1ErrorStatus.Visibility = ViewStates.Visible;
					recyclerView.Visibility = ViewStates.Gone;
					tvMSkT1ErrorStatus.Text = "Tiada maklumat tersedia buat masa ini.";
					progressDialog.Hide();
				});

			}

			Activity.RunOnUiThread (() => {
				listData = new MyShop_ListDataHolderList (mySkoolListData);

				mLayoutManager = new LinearLayoutManager (Activity);
				recyclerView.SetLayoutManager (mLayoutManager);

				recyclerAdapter = new MyShop_RecyclerViewAdapter (Activity, listData);
				recyclerView.SetAdapter (recyclerAdapter);

				recyclerAdapter.ItemClick += ItemClicked;

				progressDialog.Hide();
			});
		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent AnnouncementDetails = new Intent (Activity, typeof(Announcement_Details));

			AnnouncementDetails.PutExtra ("ArticleTitle",mySkoolTitleList[e]);
			AnnouncementDetails.PutExtra ("ArticleContent",mySkoolContentList[e]);
			StartActivity (AnnouncementDetails);
			Activity.OverridePendingTransition (0, 0);
		}

		private string setupMySkoolData(){

			WebServices wbs = new WebServices ();

			string tokenData = Activity.Intent.GetStringExtra ("Token");

			string tokenWBSRaw = wbs.setMySkoolAuth(tokenData);

			string tokenWBS = "";

			Console.WriteLine ("Raw Data: {0}",tokenWBSRaw);

			try {

				var tokenWBSjson = JsonConvert.DeserializeObject<WebServices.mySkoolAuthToken> (tokenWBSRaw);

				tokenWBS = tokenWBSjson.token.ToString();

			}
			catch(Exception e) {

				string eLimit = string.Format ("{0}", e).Substring (0, 20);

				AlertDialog alertDialog;
				AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder (Activity);

				alertDialogBuilder
					.SetTitle ("Masalah")
					.SetMessage (string.Format("Maaf. Sila cuba sekali lagi ({0}...).",eLimit))
					.SetCancelable (true)
					.SetPositiveButton ("OK", exitHandler);

				alertDialog = alertDialogBuilder.Create ();

				alertDialog.Show ();

			}

			return tokenWBS;
		}

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}

		public string getMySkoolJSONData(string token, int page)
		{
			WebServices wbs = new WebServices ();
			return wbs.getMySkoolPetiMasuk (token, page);
		}

	}
		
}

