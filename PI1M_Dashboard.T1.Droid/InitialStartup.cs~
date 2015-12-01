
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
using PI1M_Dashboard.Lib.DLayer.SQLite;
using System.IO;
using Android.Content.PM;
using System.Threading;
using Gcm.Client;


namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Dashboard Komuniti", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class InitialStartup : Activity
	{
		private SQLite.SQLiteConnection dbConn;
		private string sqliteFile;
		private string libraryPath;
		private string dbPath;
		private string dbFile;
		private string folderPath;
		private string existingUserId;
		private string existingEmail;
		private string existingFullName;
		private string existingSiteName;
		private string existingSiteCode;
		private string existingSiteID;
		private string existingIcNo;
		private string existingToken;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = Path.Combine (folderPath , sqliteFile);
			Console.WriteLine ("[InitialStartup] Checking database path: {0}",dbPath);

		}

		protected override void OnStart ()
		{
			base.OnStart ();

			//get intent from splash screen
			bool myQuizOpen = Intent.GetBooleanExtra ("myQuizOpen",false);

			//RunOnUiThread (() => {

				if (CheckDatabaseAvailability () == false) {

					Console.WriteLine ("[InitialStartup] Database not yet created. Creating...");
					Console.WriteLine ("[InitialStartup] Creating DB File...");

					if (CreateDatabaseFile () == true) {

						Console.WriteLine ("[InitialStartup] Creating DB File success.");
						Console.WriteLine ("[InitialStartup] Creating MySoal Sent Items table...");

						if (CreateTableMySoalSentItems () == true) {

							Console.WriteLine ("[InitialStartup] MySoal Sent Items table created.");

						} else {

							Console.WriteLine ("[InitialStartup] Error creating MySoal Sent Items table. Already exists or errors?");
						}

						if (CreateTableLogin () == true) {

							Console.WriteLine ("[InitialStartup] Login Info account table created.");

						} else {

							Console.WriteLine ("[InitialStartup] Error creating Login Info account table. Already exists or errors?");
						}

						if (CreateTableUserSettings () == true) {

							Console.WriteLine ("[InitialStartup] User Settings table created.");

						} else {

							Console.WriteLine ("[InitialStartup] Error creating Login Info account table. Already exists or errors?");
						}

					}
				} else {

					Console.WriteLine ("[InitialStartup] Database already created.");

					if (CreateTableUserSettings () == true) {

						Console.WriteLine ("[InitialStartup] User Settings table created.");

					} else {

						Console.WriteLine ("[InitialStartup] Error creating Login Info account table. Already exists or errors?");
					}

					/*
				Console.WriteLine ("[InitialStartup] Deleting database...");

				if (deleteDBFile () == true) {
					
					Console.WriteLine ("[InitialStartup] Deleting database success.");

				} else {
					
					Console.WriteLine ("[InitialStartup] Deleting database failed.");

				}
				*/
				}
				
				Console.WriteLine ("[InitialStartup] Login Existed: {0}", CheckExistingAndDataLogin ());


				if (CheckExistingAndDataLogin () == true) {

					Console.WriteLine ("[InitialStartup] Module Notified?: {0}", Intent.GetStringExtra ("GCMModuleNotified"));
				
					Intent mainActivity = new Intent (this, typeof(MainActivity));
					mainActivity.PutExtra ("UserID", existingUserId);
					mainActivity.PutExtra ("Email", existingEmail);
					mainActivity.PutExtra ("FullName", existingFullName);
					mainActivity.PutExtra ("SiteName", existingSiteName);
					mainActivity.PutExtra ("SiteCode", existingSiteCode);
					mainActivity.PutExtra ("ICNo", existingIcNo);
					mainActivity.PutExtra ("Token", existingToken);
					mainActivity.PutExtra ("ModuleNotified", Intent.GetStringExtra ("GCMModuleNotified"));
					mainActivity.PutExtra ("myQuizOpen", myQuizOpen);
					StartActivityForResult (mainActivity, 0);
					this.Finish ();

				} else if (CheckExistingAndDataLogin () == false) {
					StartActivity (typeof(LoginActivity));
					this.Finish ();
				}

			//});
		}

		public bool createDBFile()
		{
			Java.IO.File dbFile = new Java.IO.File (dbPath);
			bool fileExistsStatus = dbFile.Exists ();

			return fileExistsStatus;
		}

		public bool CheckDatabaseAvailability()
		{
			Console.WriteLine ("[InitialStartup] Initiating DB...");

			bool dbFileCheck = File.Exists (dbPath);

			Console.WriteLine ("[InitialStartup] Checking Database Availability: {0}",dbFileCheck);

			return dbFileCheck;
		}

		public bool CreateDatabaseFile()
		{
			try
			{
				Directory.CreateDirectory(folderPath);
				new FileStream(dbPath,FileMode.CreateNew);

				Console.WriteLine ("[InitialStartup] DB File Creation Success.");
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine ("[InitialStartup] DB File Creation Failed with exception: {0}",e);
				return false;
			}
		}

		public bool CreateTableLogin()
		{
			try
			{
				dbConn = new SQLite.SQLiteConnection (dbPath);
				var creatingTable = dbConn.CreateTable<MMenu_LoginInfo> ();
				Console.WriteLine("[InitialStartup] Table creating LoginInfo with status: {0}",creatingTable);
				Console.WriteLine("[InitialStartup] Table creating LoginInfo success");

				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("[InitialStartup] Table creating LoginInfo error with status: {0}",e);
				return false;
			}
		}

		public bool CreateTableMySoalSentItems()
		{
			try
			{
				dbConn = new SQLite.SQLiteConnection (dbPath);
				var creatingTable = dbConn.CreateTable<MySoal_SentItems> ();
				Console.WriteLine("[InitialStartup] Table creating MySoalSentItems with status: {0}",creatingTable);
				Console.WriteLine("[InitialStartup] Table creating MySoalSentItems success");

				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("[InitialStartup] Table creating MySoalSentItems error with status: {0}",e);
				return false;
			}
		}

		public bool CreateTableUserSettings()
		{
			try
			{
				dbConn = new SQLite.SQLiteConnection (dbPath);
				var creatingTable = dbConn.CreateTable<UserSettings> ();
				Console.WriteLine("[InitialStartup] Table creating UserSettings with status: {0}",creatingTable);
				Console.WriteLine("[InitialStartup] Table creating UserSettings success");

				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("[InitialStartup] Table creating UserSettings error with status: {0}",e);
				return false;
			}
		}

		public bool CheckExistingAndDataLogin()
		{
			try
			{
				dbConn = new SQLite.SQLiteConnection (dbPath);

				var existStatus = from s in dbConn.Table<MMenu_LoginInfo>() where s.li_loginstate.Equals("1") select s;

				//var existStatus = dbConn.Query<MMenu_LoginInfo> ("SELECT * FROM MMenu_LoginInfo WHERE li_loginstate = ?", "1");
				string loginExisted = "0";

				foreach(var status in existStatus)
				{
					loginExisted = status.li_loginstate;
					Console.WriteLine("[InitialStartup] Checking data: {0} ",loginExisted);
				}

				Console.WriteLine("[InitialStartup] Check Existing with status: {0}",existStatus);
				Console.WriteLine("[InitialStartup] Check success.");

				if(loginExisted == "1")
				{
					foreach(var status in existStatus)
					{
						Console.WriteLine("[InitialStartup] Checking data: {0} ",loginExisted);
						existingUserId = status.li_userid;
						existingEmail = status.li_email;
						existingFullName = status.li_fullname;
						existingSiteName = status.li_sitename;
						existingSiteCode = status.li_sitecode;
						existingSiteID = status.li_siteid;
						existingIcNo = status.li_icno;
						existingToken = status.li_dashtoken;

						MyVote.Const.tokenData = existingToken;
						MyVote.Const.siteID = existingSiteID;
					}
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("[InitialStartup] Error checking existing login with status: {0}",e);
				return false;
			}
		}

		public bool deleteDBFile()
		{
			Java.IO.File dbFile = new Java.IO.File (dbPath);
			bool deleteStatus = dbFile.Delete ();

			return deleteStatus;
		}

		private string GetAndroidDeviceToken()
		{
			GcmClient.CheckDevice (this);
			GcmClient.CheckManifest (this);
			var registrationID = GcmClient.GetRegistrationId (this);

			if (string.IsNullOrEmpty (registrationID)) {
				GcmClient.Register (this, GcmBroadcastReceiver.SENDER_IDS);
				registrationID = GcmClient.GetRegistrationId (this);
			} else {
				Console.WriteLine ("Already registered with ID {0} ",registrationID);
			}

			return registrationID;
		}
	}
}

