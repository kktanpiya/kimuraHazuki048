
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
using Android.Support.V7.App;
using SQLite;
using Android.Database;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Tetapan", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Settings_MainActivity : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;

		private SQLiteConnection dbConn;
		private string sqliteFile;
		private string libraryPath;
		private string dbPath;
		private string dbFile;
		private string folderPath;

		private bool rememberMeSettings = false;

		Button btnSettingsRememberMe;

		protected override void OnStart ()
		{
			base.OnStart ();

		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.Settings_MainPager);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			LinearLayout llSMPModulDb = (LinearLayout)FindViewById (Resource.Id.llSMPModulDb);

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayShowTitleEnabled (true);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			btnSettingsRememberMe = (Button)FindViewById (Resource.Id.btnSMPRememberMe);

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = System.IO.Path.Combine (folderPath , sqliteFile);
			Console.WriteLine ("[Settings_MainActivity] Checking database path: {0}",dbPath);
			dbConn = new SQLiteConnection (dbPath);

			CreateRememberMeItem ();

			PopulateAllSettings ();

			btnSettingsRememberMe.Click += RememberMeSettings;

			llSMPModulDb.Click += (object sender, EventArgs e) => {

				StartActivity(typeof(ModuleSet_MainActivity));

			};


		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {

			case Android.Resource.Id.Home:
				this.Finish ();
				return true;

			default:
				return base.OnOptionsItemSelected (item);

			}


		}

		public bool PopulateAllSettings()
		{
			//Remember Me Settings
			var checkRememberMeItem = dbConn.Query<UserSettings> ("SELECT * FROM UserSettings WHERE settingsCode = ?", "US_REMEMBERME");

			foreach (var query in checkRememberMeItem) {
				Console.WriteLine ("[Settings_MainActivity] Check Remember Me Settings: {0}",query.settingsChecked1Boolean);
				if (query.settingsChecked1Boolean == true) {
					rememberMeSettings = true;
					btnSettingsRememberMe.Text = Resources.GetString (Resource.String.settings_btn_deactivatelabel);
				} else if (query.settingsChecked1Boolean == false) {
					rememberMeSettings = false;
					btnSettingsRememberMe.Text = Resources.GetString (Resource.String.settings_btn_activatelabel);
				}
			}

			return true;
		}

		public bool CreateRememberMeItem()
		{
			var checkRememberMeItem = dbConn.Query<UserSettings> ("SELECT * FROM UserSettings WHERE settingsCode = ?", "US_REMEMBERME");
			Console.WriteLine ("[Settings_MainActivity] Check RememberMe Query: {0}",checkRememberMeItem.Count);
			if (checkRememberMeItem.Count == 0) {
				var createRMI = new UserSettings();
				createRMI.settingsCode = "US_REMEMBERME";
				createRMI.settingsName = "Remember Me";
				createRMI.settingsChecked1Boolean = true;

				dbConn.Insert (createRMI);
			}


			return true;
		}

		public void RememberMeSettings(object sender, EventArgs e)
		{
			var existingQuery = dbConn.Query<UserSettings> ("SELECT * FROM UserSettings WHERE settingsCode = ?", "US_REMEMBERME");
			Console.WriteLine ("[Settings_MainActivity] Existed or not: {0}",existingQuery.Count);

			if (rememberMeSettings == true) {
				var checkQuery = dbConn.Query<UserSettings> ("UPDATE UserSettings SET settingsChecked1Boolean = ? WHERE settingsCode = ?", false, "US_REMEMBERME");
				foreach (var query in checkQuery) {
					Console.WriteLine ("[Settings_MainActivity] Check Remember Me Settings: {0}",query.settingsChecked1Boolean);
				}
				rememberMeSettings = false;
				btnSettingsRememberMe.Text = Resources.GetString (Resource.String.settings_btn_activatelabel);
				Console.WriteLine ("[Settings_MainActivity] Remember Me Disabled");
			} else if (rememberMeSettings == false) {
				var checkQuery = dbConn.Query<UserSettings> ("UPDATE UserSettings SET settingsChecked1Boolean = ? WHERE settingsCode = ?", true, "US_REMEMBERME");
				foreach (var query in checkQuery) {
					Console.WriteLine ("[Settings_MainActivity] Check Remember Me Settings: {0}",query.settingsChecked1Boolean);
				}
				rememberMeSettings = true;
				btnSettingsRememberMe.Text = Resources.GetString (Resource.String.settings_btn_deactivatelabel);
				Console.WriteLine ("[Settings_MainActivity] Remember Me Enabled");
			}



		}
	}
}

