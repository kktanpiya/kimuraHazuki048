
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
using Android.Content.PM;
using PI1M_Dashboard;
using System.Net;
using System.IO;
using Android.Telephony;
using Newtonsoft.Json;
using Gcm.Client;
using System.Threading;
//using Xamarin.Forms;
using Android.Graphics;
using Android.Provider;
using Android.Net;
using PI1M_Dashboard.Lib.DLayer.SQLite;
using Android.Support.Design.Widget;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "LoginActivity", Theme = "@style/NoActionBarLayout", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	[BroadcastReceiver(Permission = "com.google.android.c2dm.permission.SEND")]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RETRY" })]

	public class LoginActivity : Activity
	{
		private ProgressDialog loadingDialog;
		private SQLite.SQLiteConnection dbConn;
		private string dbPath;
		private string sqliteFile;
		private string libraryPath;
		private string dbFile;
		private string folderPath;

		private Android.Widget.Button btnLLLoginAuthBtn;
		private EditText etLLLoginUsername;
		private EditText etLLLoginPassword;
		private string deviceTokenGCM = "";

		private Android.Widget.ProgressBar mProgressBar;

		private ProgressDialog progressDialog;

		private int retryTimes = 0;

		protected override void OnStart ()
		{
			base.OnStart ();

			deviceTokenGCM = getAndroidDeviceToken ();
		}
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.Login_Layout);

			btnLLLoginAuthBtn = (Android.Widget.Button)FindViewById (Resource.Id.btnLLLoginAuthBtn);
			etLLLoginUsername = (EditText)FindViewById (Resource.Id.etLLLoginUsername);
			etLLLoginPassword = (EditText)FindViewById (Resource.Id.etLLLoginPassword);

			//TextView tvLLUserNameLabel = (TextView)FindViewById (Resource.Id.tvLLUserNameLabel);
			//TextView tvLLPassLabel = (TextView)FindViewById (Resource.Id.tvLLPassLabel);

			//TextView tvLLCopyrightText = (TextView)FindViewById (Resource.Id.tvLLCopyrightText);
			//TextView tvLLTermsText = (TextView)FindViewById (Resource.Id.tvLLTermsText);

			//progressDialog = ProgressDialog.Show(this,"Sila tunggu","Sedang memuatkan...");

			mProgressBar = FindViewById<Android.Widget.ProgressBar> (Resource.Id.progressBar1);

			//etLLLoginUsername.Text = "860815435145";
			//etLLLoginUsername.Text = "850408115989";
			etLLLoginUsername.Hint = Resources.GetString(Resource.String.login_username_hint);
			//etLLLoginPassword.Text = "password";
			etLLLoginPassword.Hint = Resources.GetString(Resource.String.login_password_hint);

			mProgressBar.Visibility = ViewStates.Invisible;
				
			//string deviceToken = getAndroidDeviceToken ();

			

			/*
			if (getAndroidDeviceToken () != "") {
				
				deviceTokenGCM = deviceToken;
				progressDialog.Hide ();

			} else {

				getAndroidDeviceToken ();
				OnCreate (bundle);

			}
			*/
			//GetIMEIID ();

			btnLLLoginAuthBtn.Click += (object sender, EventArgs e) => {

				if(etLLLoginUsername.Text != "")
				{
					if(etLLLoginPassword.Text != "") {
						
						mProgressBar.Visibility = ViewStates.Visible;
						btnLLLoginAuthBtn.Enabled = false;
						etLLLoginUsername.Enabled = false;
						etLLLoginPassword.Enabled = false;
						//loadingDialog = ProgressDialog.Show (this, "Sila Tunggu", "Sedang Memuatkan...");
						//Thread.Sleep (2000);
						ThreadPool.QueueUserWorkItem(o => processTheLogin(etLLLoginUsername.Text,etLLLoginPassword.Text,deviceTokenGCM,GetIMEIID ()));
				
					}
					else
					{
						//Log.Error
						Snackbar
							.Make(FindViewById(Android.Resource.Id.Content),Resource.String.login_password_warning,Snackbar.LengthLong)
							.SetAction(Resource.String.generallabel_okbtn,delegate {})
							.Show();
						//Toast.MakeText (this, "Sila isikan Kata Laluan anda...", ToastLength.Short).Show();
					}
				}
				else
				{
					Snackbar
						.Make(FindViewById(Android.Resource.Id.Content),Resource.String.login_username_warning,Snackbar.LengthLong)
						.SetAction(Resource.String.generallabel_okbtn,delegate {})
						.Show();
					//Toast.MakeText (this, "Sila isikan Nama Pengguna...", ToastLength.Short).Show();
				}
					
			};

			/*
			Typeface fontface = Typeface.CreateFromAsset (Assets, "Fonts/Roboto-Regular.ttf");
			tvLLUserNameLabel.SetTypeface (fontface,TypefaceStyle.Normal);
			tvLLUserNameLabel.SetTextColor (Android.Graphics.Color.ParseColor("#FF212121"));
			tvLLPassLabel.SetTypeface (fontface,TypefaceStyle.Normal);
			tvLLPassLabel.SetTextColor (Android.Graphics.Color.ParseColor("#FF212121"));
			etLLLoginUsername.SetTypeface (fontface,TypefaceStyle.Normal);
			etLLLoginUsername.SetTextColor (Android.Graphics.Color.ParseColor("#FF212121"));
			etLLLoginPassword.SetTypeface (fontface,TypefaceStyle.Normal);
			etLLLoginPassword.SetTextColor (Android.Graphics.Color.ParseColor("#FF212121"));
			btnLLLoginAuthBtn.SetTypeface (fontface,TypefaceStyle.Normal);
			tvLLCopyrightText.SetTypeface (fontface,TypefaceStyle.Normal);
			tvLLTermsText.SetTypeface (fontface,TypefaceStyle.Normal);
			*/

		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			GcmClient.UnRegister (this);
		}

		private string GetIMEIID()
		{
			//Check Internet Connectivity
			ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService (Context.ConnectivityService);
			NetworkInfo netInfo = connectivityManager.ActiveNetworkInfo;
			string andID = "";

			if (netInfo == null || !netInfo.IsConnected) {
				Console.WriteLine ("[LoginActivity] Internet is NOT CONNECTED!");

				AlertDialog.Builder alertBuild = new AlertDialog.Builder(this);
				alertBuild
					.SetTitle(Resource.String.login_internetconnfail_title)
					.SetMessage(Resource.String.login_internetconnfail_details)
					.SetNegativeButton(Resource.String.generallabel_okbtn,delegate {
						//this.Finish();
					});
				
				RunOnUiThread (() => {

				AlertDialog alertDialog = alertBuild.Create();
				alertDialog.Show();

				});

			}
			else if (netInfo.Type == ConnectivityType.Wifi)
			{
				andID = Settings.Secure.GetString (ContentResolver,Settings.Secure.AndroidId);
				Console.WriteLine ("[LoginActivity] Internet is connected using WIFI");
			}
			else if (netInfo.Type == ConnectivityType.Mobile)
			{
				TelephonyManager telephonyManager = (TelephonyManager)GetSystemService (Context.TelephonyService);
				andID = telephonyManager.DeviceId;
				Console.WriteLine ("[LoginActivity] Internet is connected using Cellular");
			}

			return andID;
		}

		private string getAndroidDeviceToken()
		{
			GcmClient.CheckDevice (this);
			GcmClient.CheckManifest (this);
			var registrationID = ""; //= GcmClient.GetRegistrationId (this);

			if (string.IsNullOrEmpty (registrationID)) {
				GcmClient.Register (this, GcmBroadcastReceiver.SENDER_IDS);
				registrationID = GcmClient.GetRegistrationId (this);
			} else {
				Console.WriteLine ("Already registered with ID {0} ",registrationID);
			}

			return registrationID;
		}



		public void processTheLogin(string username, string password, string deviceToken, string imei)
		{
			//Looper.Prepare ();
			//loadingDialog = ProgressDialog.Show (this, "Sila Tunggu", "Sedang Mengesahkan...");
			//Looper.Loop ();

			WebServices wbs = new WebServices ();

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = System.IO.Path.Combine (folderPath, sqliteFile);

			dbConn = new SQLite.SQLiteConnection (dbPath);
			Console.WriteLine ("[LoginActivity] Checking database path: {0}", dbPath);

			string loginDataRAW = "";

			Console.WriteLine ("[LoginActivity] GCM Token retrieved: {0}", deviceToken);
			//Console.WriteLine ("[LoginActivity] GCM Token recheck: {0}", getAndroidDeviceToken());

			if (retryTimes != 3) {

				if (deviceToken == "") {

					//deviceToken = getAndroidDeviceToken ();
					Thread.Sleep (2000);
					ThreadPool.QueueUserWorkItem(o => processTheLogin(etLLLoginUsername.Text,etLLLoginPassword.Text,GcmClient.GetRegistrationId(this),imei));
					
				} else {
					
					loginDataRAW = wbs.getLoginData2 (username, password, deviceToken, imei, "and");

					var loginData = JsonConvert.DeserializeObject<WebServices.LoginData_TableItems> (loginDataRAW);

					Console.WriteLine ("[LoginActivity] RAW Login Data: {0}", loginDataRAW);
					Console.WriteLine ("[LoginActivity] Status: {0}", loginData.success);

					if (loginData.success == 1) {

						try {

							//check if data exists
							var queryStatus = dbConn.Query<MMenu_LoginInfo> ("SELECT * FROM MMenu_LoginInfo WHERE li_userid = ?", loginData.user_id);
							int existsUserId = 0;

							foreach (var status in queryStatus) {
								Console.WriteLine ("[LoginActivity] User id {0} is detected, login state to {1}", status.li_userid, status.li_loginstate);
								existsUserId = Convert.ToInt32 (status.li_userid.ToString ());
							}

							if (existsUserId != Convert.ToInt32 (loginData.user_id.ToString ())) {
								Console.WriteLine ("[LoginActivity] Insert data...");

								dbConn.Insert (new MMenu_LoginInfo () {
									li_userid = loginData.user_id,
									li_email = loginData.email,
									li_fullname = loginData.full_name,
									li_sitename = loginData.site_name,
									li_sitecode = loginData.sitecode,
									li_siteid = loginData.site_id,
									li_icno = loginData.ic_no,
									li_dashtoken = loginData.token,
									li_loginstate = "1"
								});

								Console.WriteLine ("[LoginActivity] Data Inserted");
							} else {
								Console.WriteLine ("[LoginActivity] Data is existed. Set loginstate to userid {0}...", loginData.user_id);
								var s = dbConn.Query<MMenu_LoginInfo> ("UPDATE MMenu_LoginInfo SET li_loginstate = '1' WHERE li_userid = ?;", loginData.user_id);
								Console.WriteLine ("[MainActivity] Check if logging out is success: {0}", s);
							}

						} catch (Exception e) {

							Console.WriteLine ("[LoginActivity] Error in inserting data: {0}", e);

						}

						Intent mainActivity = new Intent (this, typeof(Splash));
						mainActivity.PutExtra ("UserID", loginData.user_id);
						mainActivity.PutExtra ("Email", loginData.email);
						mainActivity.PutExtra ("FullName", loginData.full_name);
						mainActivity.PutExtra ("SiteName", loginData.site_name);
						mainActivity.PutExtra ("SiteCode", loginData.sitecode);
						mainActivity.PutExtra ("ICNo", loginData.ic_no);
						mainActivity.PutExtra ("Token", loginData.token);
						StartActivity (mainActivity);

						MyVote.Const.tokenData = loginData.token;
						MyVote.Const.siteID = loginData.site_id;

						this.Finish ();
					} else {
					
						//Looper.Prepare ();
						RunOnUiThread (() => {
						
							//loadingDialog.Hide();
							mProgressBar.Visibility = ViewStates.Invisible;
							btnLLLoginAuthBtn.Enabled = true;
							etLLLoginUsername.Enabled = true;
							etLLLoginPassword.Enabled = true;
							Snackbar
								.Make(FindViewById(Android.Resource.Id.Content),Resource.String.login_failed_warning,Snackbar.LengthLong)
								.SetAction(Resource.String.generallabel_okbtn,delegate {})
								.Show();
							//Toast.MakeText (this, "Nama Pengguna dan/atau Kata Laluan tidak sah.", ToastLength.Long).Show ();

						});
						//Looper.Loop ();
						//loadingDialog.Hide ();

					}

				}

				retryTimes++;

			} else {

				RunOnUiThread (() => {

					//loadingDialog.Hide();
					mProgressBar.Visibility = ViewStates.Invisible;
					btnLLLoginAuthBtn.Enabled = true;
					etLLLoginUsername.Enabled = true;
					etLLLoginPassword.Enabled = true;
					Snackbar
						.Make(FindViewById(Android.Resource.Id.Content),Resource.String.login_unknownfailure_warning,Snackbar.LengthLong)
						.SetAction(Resource.String.generallabel_okbtn,delegate {})
						.Show();
					//Toast.MakeText (this, "Terdapat masalah. Sila cuba sekali lagi.", ToastLength.Long).Show ();

				});

				//GcmClient.UnRegister (this);
				retryTimes = 0;

			}
		}

	}
}

