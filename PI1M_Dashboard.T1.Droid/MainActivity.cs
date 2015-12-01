using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Views.Animations;
using SQLite;
using PI1M_Dashboard.Lib.DLayer.SQLite;
using Gcm.Client;
using MyQuiz;
using Newtonsoft.Json;
using DataAccess;
using System.Threading.Tasks;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Dashboard", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : ActionBarActivity, AbsListView.IOnScrollListener
	{
		private SQLiteConnection dbConn;
		private string sqliteFile;
		private string libraryPath;
		private string dbPath;
		private string dbFile;
		private string folderPath;

		DrawerLayout mDrawerLayout;
		Android.Support.V7.App.ActionBarDrawerToggle mDrawerToggle;
		private Android.Support.V7.Widget.Toolbar toolbar;
		int count = 1;

		ListView lvMMLListed;
		ListView lvMMLListedEx2;
		List<LeftMenuListItems> MenuListItem;
		List<LeftMenuListItems> ExMenuListItem;

		ListView lvDFLMainLayout;
		List<DashboardFeedListItem> DFListItem;

		LinearLayout llMMLLogout;

		TextView tvMMLUserEmail;

		LinearLayout leftListView;

		Typeface fontface;

		View lvDFLMainLayoutHeaderView;
		int lvDFLMainLayoutHeaderHeight { get; set; }
		int lvDFLMainLayoutMinHeaderTranslation { get; set; }

		public void OnScroll (AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
		{
			int scrollY = getScrollY(view);

			// This will collapse the header when scrolling, until its height reaches
			// the toolbar height
			lvDFLMainLayoutHeaderView.TranslationY = Math.Max(0, scrollY + lvDFLMainLayoutMinHeaderTranslation);

			// Scroll ratio (0 <= ratio <= 1). 
			// The ratio value is 0 when the header is completely expanded, 
			// 1 when it is completely collapsed
			float offset = 1 - Math.Max(
				(float) (-lvDFLMainLayoutMinHeaderTranslation - scrollY) / -lvDFLMainLayoutMinHeaderTranslation, 0f);

			// Update items alpha from offset
			UpdateItemsAlpha(offset);
		}

		public void OnScrollStateChanged (AbsListView view, ScrollState scrollState)
		{
			//throw new NotImplementedException ();
		}

		void UpdateItemsAlpha(float offset)
		{
			// Alpha 255=100%, 0=0%
			//toolbar.Background.Alpha = (int)((offset)*255);

			// Alpha 1=100%, 0=0%
			//HeaderFab.Alpha = 1 - offset;
			//HeaderTitle.Alpha = 1 - offset;
			//HeaderSubtitle.Alpha = 1 - offset;
		}

		public int getScrollY(AbsListView view)
		{
			View c = view.GetChildAt(0);
			if (c == null)
				return 0;
			int firstVisiblePosition = view.FirstVisiblePosition;
			int top = c.Top;
			int headerHeight = 0;
			if (firstVisiblePosition >= 1)
				headerHeight = this.lvDFLMainLayoutHeaderHeight;
			return -top + firstVisiblePosition * c.Height + headerHeight;
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			Console.WriteLine ("[MainActivity] Starting app. Checking database...");

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = System.IO.Path.Combine (folderPath , sqliteFile);
			Console.WriteLine ("[MainActivity] Checking database path: {0}",dbPath);
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			//this.Finish ();
		}

		protected override void OnStop ()
		{
			base.OnStop ();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			dbConn = new SQLiteConnection (dbPath);

			var checkRememberMeItem = dbConn.Query<UserSettings> ("SELECT * FROM UserSettings WHERE settingsCode = ?", "US_REMEMBERME");

			foreach (var query in checkRememberMeItem) {
				Console.WriteLine ("[MainActivity] Check Remember Me Settings: {0}",query.settingsChecked1Boolean);
				if (query.settingsChecked1Boolean == true) {

				} else if (query.settingsChecked1Boolean == false) {
					LogoutFromApp();
				}
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			string ns = Context.NotificationService;
			NotificationManager nm = (NotificationManager)this.GetSystemService (ns);
			nm.CancelAll ();

		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//StartActivity (typeof(Dashboard_MainActivityPX));

			SetContentView (Resource.Layout.Dashboard_MainLayout);

			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.myDrawer);
			mDrawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle (this, mDrawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);
			mDrawerLayout.SetDrawerListener (mDrawerToggle);

			lvDFLMainLayout = (ListView)FindViewById (Resource.Id.lvDFLMainLayout);
			leftListView = (LinearLayout)FindViewById (Resource.Id.leftListView);
			lvMMLListed = (ListView)FindViewById (Resource.Id.lvMMLListed);
			lvMMLListedEx2 = (ListView)FindViewById (Resource.Id.lvMMLListedEx2);
			tvMMLUserEmail = (TextView)FindViewById (Resource.Id.tvMMLUserEmail);

			string UserName = Intent.GetStringExtra ("FullName");
			tvMMLUserEmail.Text = UserName;

			ImageView ivMMLShowSecondMenu = (ImageView)FindViewById (Resource.Id.ivMMLShowSecondMenu);

			//ImageView ivDFTITransImage = (ImageView)FindViewById (Resource.Id.ivDFTITransImage);

			//TransitionDrawable td = new TransitionDrawable (new Drawable [] {
			//	Resources.GetDrawable(Resource.Drawable.d_commpic_one),
			//	Resources.GetDrawable(Resource.Drawable.d_commpic_two),
			//	Resources.GetDrawable(Resource.Drawable.d_commpic_three)
			//});

			//ivDFTITransImage.SetImageDrawable (td);
			//td.StartTransition (2000);

			LinearLayout llMMLShowSecondMenu = (LinearLayout)FindViewById (Resource.Id.llMMLShowSecondMenu);

			//Button button = FindViewById<Button> (Resource.Id.myButton);
			//button.Click += delegate { button.Text = string.Format ("{0} clicks!", count++); };

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			int titleID = toolbar.Resources.GetIdentifier ("action_bar_title", "id", "android");
			fontface = Typeface.CreateFromAsset (Assets, "Fonts/Roboto-Regular.ttf");
			//TextView titleTV = (TextView)FindViewById (titleID);
			//titleTV.SetTypeface (fontface,TypefaceStyle.Normal);

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeButtonEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled (true);

			lvDFLMainLayoutHeaderHeight = Resources.GetDimensionPixelSize(Resource.Dimension.header_height);

			lvDFLMainLayoutMinHeaderTranslation = -lvDFLMainLayoutHeaderHeight + 
				Resources.GetDimensionPixelOffset(Resource.Dimension.action_bar_height);

			lvDFLMainLayoutHeaderView = LayoutInflater.Inflate (Resource.Layout.Dashboard_FeedListViewHeader, lvMMLListed, false);


			View decorView = Window.DecorView;

			MenuListItem = new List<LeftMenuListItems> ();

			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "Dashboard",
				LeftMenuDrawerIconID = Resource.Drawable.home3 });
			
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Komuniti",
				LeftMenuDrawerIconID = Resource.Drawable.people2 });

			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Soal",
				LeftMenuDrawerIconID = Resource.Drawable.cup2 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Health",
				LeftMenuDrawerIconID = Resource.Drawable.heart2 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Skool",
				LeftMenuDrawerIconID = Resource.Drawable.shield2 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Shop",
				LeftMenuDrawerIconID = Resource.Drawable.cart2 });
			/*
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Vote",
				LeftMenuDrawerIconID = Resource.Drawable.ic_myposter });
				*/

			lvMMLListed.Adapter = new MainActivityAdapters (this, MenuListItem);
			lvMMLListed.ItemClick += menuItemClicked;

			//Extended Menu

			ExMenuListItem = new List<LeftMenuListItems> ();

			ExMenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "Tetapan",
				LeftMenuDrawerIconID = Resource.Drawable.ic_gear_grey });

			ExMenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "Berkenaan PI1M",
				LeftMenuDrawerIconID = Resource.Drawable.ic_about_48dp });

			ExMenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "Kata anda",
				LeftMenuDrawerIconID = Resource.Drawable.ic_review_48dp });

			lvMMLListedEx2.Adapter = new MainActivityAdapters (this, ExMenuListItem);
			lvMMLListedEx2.ItemClick += ItemExClicked;


			DFListItem = new List<DashboardFeedListItem> ();

			//if myquiz is open, show menu
			if(Intent.GetBooleanExtra ("myQuizOpen", false) ==true)
			{
				DFListItem.Add (new DashboardFeedListItem(){ 
					DashboardFeedTitleLabel = "My Quiz",
					DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
					DashboardFeedDescLabel = "Jawab dan menang",
					DashboardFeedDrawerIconID = Resource.Drawable.quizicon2,
					DashboardFeedType = "Normal-Type"
				});
			}

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Komuniti",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Dapatkan maklumat masyarakat setempat disini.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_mykomuniti,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Soal",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Sampaikan pertanyaan anda kepada Penguasa.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_mysoal,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Health",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Maklumat berkenaan keadaan kesihatan anda.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myhealth,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Skool",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Memberikan maklumat berkenaan perkembangan sekolah anak anda.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myskool,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Shop",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Pelbagai barangan dan perkhidmatan tempatan untuk dijual.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myshop_front,
				DashboardFeedType = "Normal-Type"
			});

			/*
			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "My Vote",
				DashboardFeedDateLabel = "Sentuh untuk membuka aplikasi ini.",
				DashboardFeedDescLabel = "Undi poster pilihan anda.",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myposter,
				DashboardFeedType = "Normal-Type"
			});
			*/
			/*
			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "KEPUTUSAN STPM 2013",
				DashboardFeedDateLabel = "23 Januari 2015",
				DashboardFeedDescLabel = "Untuk makluman, keputusan SPM bagi tahun 2013 akan ...",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myskool,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedHealthBPStatus = "Normal",
				DashboardFeedHealthBPDate = "25 Januari 2015",
				DashboardFeedHealthBPPressure = "122 mm / 78 Hg.",
				DashboardFeedHealthBPPulse = "80 Bpm",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myhealth,
				DashboardFeedType = "HealthBP-Type"

			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "Isu Semasa",
				DashboardFeedDateLabel = "25 Januari 2015",
				DashboardFeedDescLabel = "Menangani isu-isu sosial yang berbangkit di Bandar Utama ...",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_mysoal,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedHealthWSStatus = "Normal",
				DashboardFeedHealthWSDate = "25 Januari 2015",
				DashboardFeedHealthWSWeight = "56.60 Kg",
				DashboardFeedHealthWSBMI = "BMI: 18.76",
				DashboardFeedHealthWSFat = "Lemak: 18.50 %",
				DashboardFeedHealthWSNettWeight = "46.3 Kg",
				DashboardFeedHealthWSBoneMass = "3.8 Kg",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myhealth,
				DashboardFeedType = "HealthWS-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedShopPrice = "RM500",
				DashboardFeedShopDate = "25 Januari 2015",
				DashboardFeedShopProduct = "Tas tangan berjenama!",
				DashboardFeedShopLocation = "Felda Jengka 3, Pahang",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myshop,
				DashboardFeedType = "Shop-Type"

			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedTitleLabel = "Isu Semasa",
				DashboardFeedDateLabel = "25 Januari 2015",
				DashboardFeedDescLabel = "Beberapa jalan di Bandar Puteri ditutup ...",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_mykomuniti,
				DashboardFeedType = "Normal-Type"
			});

			DFListItem.Add (new DashboardFeedListItem(){ 
				DashboardFeedShopPrice = "RM500",
				DashboardFeedShopDate = "25 Januari 2015",
				DashboardFeedShopProduct = "Jam murah! Jam murah! Jam murah!",
				DashboardFeedShopLocation = "Felda Jengka 3, Pahang",
				DashboardFeedDrawerIconID = Resource.Drawable.ic_myshop,
				DashboardFeedType = "Shop-Type"
			});
			*/

			lvDFLMainLayout.AddHeaderView (lvDFLMainLayoutHeaderView, null, false);

			lvDFLMainLayout.Adapter = new DashboardFeedAdapters (this, DFListItem, fontface);
			lvDFLMainLayout.ItemClick += ItemClicked;
			lvDFLMainLayout.SetOnScrollListener (this);

			//LayoutParams

			//WindowManagerLayoutParams layoutParams = new WindowManagerLayoutParams(

			/* Hiding Status Bar
			Window.SetFlags (
				WindowManagerFlags.Fullscreen,
				WindowManagerFlags.Fullscreen
			);
			*/

			int btnToggle = 1;

			Console.WriteLine ("[MenuItemClicked] Ready..");

			//llMMLShowSecondMenu.Visibility = ViewStates.Gone;

			llMMLShowSecondMenu.Click += delegate {

				if(btnToggle == 0)
				{
					ivMMLShowSecondMenu.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.ic_arrow_down));
					btnToggle = 1;
					lvMMLListed.Visibility = ViewStates.Visible;
					lvMMLListedEx2.Visibility = ViewStates.Gone;
				}
				else if(btnToggle == 1)
				{
					ivMMLShowSecondMenu.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.ic_arrow_up));
					btnToggle = 0;
					lvMMLListed.Visibility = ViewStates.Gone;
					lvMMLListedEx2.Visibility = ViewStates.Visible;
				}

			};

			//Android.Views.ViewGroup.LayoutParams parames = lvDFLMainLayout.LayoutParameters;
			//parames.Height = 1000;

			//NotificationCheck (Intent.GetStringExtra ("ModuleNotified"));

			llMMLLogout = (LinearLayout)FindViewById (Resource.Id.llMMLLogout);
			llMMLLogout.Click += (object sender, EventArgs e) => {

				LogoutFromApp();

				StartActivity(typeof(LoginActivity));
				this.Finish();

			};
		}

		private void NotificationCheck(string notification)
		{
			Console.WriteLine ("[MainActivity] Check notification detected: {0}",notification);
			string tokenAcquired = Intent.GetStringExtra ("Token");
			string emailAcquired = Intent.GetStringExtra ("FullName");
			string siteCodeAcquired = Intent.GetStringExtra ("SiteCode");

			switch (notification) {

			case "MySoal":
				
				Console.WriteLine ("[MainActivity] Redirect to MySoal.");

				Intent mySoalAct = new Intent (this,typeof(MySoal_MainActivityDW));
				mySoalAct.PutExtra ("Token", tokenAcquired);
				mySoalAct.PutExtra ("Email", emailAcquired);
				mySoalAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (mySoalAct);
				break;

			case "MySkool":
				
				Console.WriteLine ("[MainActivity] Redirect to MySkool.");

				Intent mySkoolAct = new Intent (this,typeof(MySkool_MainActivityDW));
				mySkoolAct.PutExtra("Token",tokenAcquired);
				mySkoolAct.PutExtra ("Email", emailAcquired);
				mySkoolAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (mySkoolAct);
				break;

			default:
				
				Console.WriteLine ("[MainActivity] No need to redirect.");

				break;
			}
		}

		private void ItemClicked(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			//Toast.MakeText (this, string.Format ("Sedang memuatkan...", e.Position), ToastLength.Short).Show ();

			string tokenAcquired = Intent.GetStringExtra ("Token");
			string emailAcquired = Intent.GetStringExtra ("FullName");
			string siteCodeAcquired = Intent.GetStringExtra ("SiteCode");
			string UserID = Intent.GetStringExtra ("UserID");
			Boolean myQuizOpen = Intent.GetBooleanExtra ("myQuizOpen", false);


			int pos = e.Position - 1;

			switch (myQuizOpen) 
			{
			case true:

				if (pos == 0) {

					Intent myKomunitiAct = new Intent (this,typeof(MyQuiz_MainActivity));
					myKomunitiAct.PutExtra ("Token", tokenAcquired);
					myKomunitiAct.PutExtra ("Email", emailAcquired);
					myKomunitiAct.PutExtra ("SiteCode", siteCodeAcquired);
					myKomunitiAct.PutExtra ("UserID", UserID);
					StartActivity (myKomunitiAct);

				}

				if (pos == 1) {

					Intent mySoalAct = new Intent (this,typeof(MyKomuniti_MainActivityDW));
					mySoalAct.PutExtra ("Token", tokenAcquired);
					mySoalAct.PutExtra ("Email", emailAcquired);
					mySoalAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (mySoalAct);

				}
				if (pos == 2) {

					Intent myHealthAct = new Intent (this,typeof(MySoal_MainActivityDW));
					myHealthAct.PutExtra("Token",tokenAcquired);
					myHealthAct.PutExtra ("Email", emailAcquired);
					myHealthAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myHealthAct);

				}
				if (pos == 3) {

					Intent mySkoolAct = new Intent (this,typeof(MyHealth_MainActivityDW));
					mySkoolAct.PutExtra("Token",tokenAcquired);
					mySkoolAct.PutExtra ("Email", emailAcquired);
					mySkoolAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (mySkoolAct);
				}
				if (pos == 4) {

					Intent myShopAct = new Intent (this,typeof(MySkool_MainActivityDW));
					myShopAct.PutExtra("Token",tokenAcquired);
					myShopAct.PutExtra ("Email", emailAcquired);
					myShopAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myShopAct);
				}
				if (pos == 5) {

					Intent myShopAct = new Intent (this,typeof(MyShop_MainActivityDW));
					myShopAct.PutExtra("Token",tokenAcquired);
					myShopAct.PutExtra ("Email", emailAcquired);
					myShopAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myShopAct);
				}
				/*
				if (pos == 4) {

					Intent myVoteAct = new Intent (this,typeof(MyVote.MyVote_MainActivityPO));
					myVoteAct.PutExtra("Token",tokenAcquired);
					myVoteAct.PutExtra ("Email", emailAcquired);
					myVoteAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myVoteAct);
				}
				*/
				break;

			case false:

				if (pos == 0) {

					Intent myKomunitiAct = new Intent (this,typeof(MyKomuniti_MainActivityDW));
					myKomunitiAct.PutExtra ("Token", tokenAcquired);
					myKomunitiAct.PutExtra ("Email", emailAcquired);
					myKomunitiAct.PutExtra ("SiteCode", siteCodeAcquired);
					myKomunitiAct.PutExtra ("UserID", UserID);
					StartActivity (myKomunitiAct);

				}

				if (pos == 1) {

					Intent mySoalAct = new Intent (this,typeof(MySoal_MainActivityDW));
					mySoalAct.PutExtra ("Token", tokenAcquired);
					mySoalAct.PutExtra ("Email", emailAcquired);
					mySoalAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (mySoalAct);

				}
				if (pos == 2) {

					Intent myHealthAct = new Intent (this,typeof(MyHealth_MainActivityDW));
					myHealthAct.PutExtra("Token",tokenAcquired);
					myHealthAct.PutExtra ("Email", emailAcquired);
					myHealthAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myHealthAct);

				}
				if (pos == 3) {

					Intent mySkoolAct = new Intent (this,typeof(MySkool_MainActivityDW));
					mySkoolAct.PutExtra("Token",tokenAcquired);
					mySkoolAct.PutExtra ("Email", emailAcquired);
					mySkoolAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (mySkoolAct);
				}
				if (pos == 4) {

					Intent myShopAct = new Intent (this,typeof(MyShop_MainActivityDW));
					myShopAct.PutExtra("Token",tokenAcquired);
					myShopAct.PutExtra ("Email", emailAcquired);
					myShopAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myShopAct);
				}
				/*
				if (pos == 4) {

					Intent myVoteAct = new Intent (this,typeof(MyVote.MyVote_MainActivityPO));
					myVoteAct.PutExtra("Token",tokenAcquired);
					myVoteAct.PutExtra ("Email", emailAcquired);
					myVoteAct.PutExtra ("SiteCode", siteCodeAcquired);

					StartActivity (myVoteAct);
				}
				*/
				break;
			}
		}
		private void ItemExClicked(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{

			if (e.Position == 0) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent settingsAct = new Intent (this,typeof(Settings_MainActivity));

				StartActivity (settingsAct);

			}
			if (e.Position == 1) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent aboutAct = new Intent (this,typeof(AboutActivity));

				StartActivity (aboutAct);

			}
			if (e.Position == 2) {

				mDrawerLayout.CloseDrawer (leftListView);
				//Intent reportAct = new Intent (this,typeof(Report_MainActivity));

				//StartActivity (reportAct);

				PackageInfo pacMan = PackageManager.GetPackageInfo (PackageName, 0);

				Android.App.AlertDialog.Builder alertBuild = new Android.App.AlertDialog.Builder (this);
				alertBuild
					.SetTitle ("Kata Anda!")
					.SetMessage (Resource.String.rate_message)
					.SetPositiveButton ("Ya",delegate {
						string appPackage = pacMan.PackageName;
						//Android.Net.Uri playstoreURI = new Android.Net.Uri(string.Format("market://details?id={0}",appPackage));
						Intent playstore = new Intent(Intent.ActionView, Android.Net.Uri.Parse(string.Format("market://details?id={0}",appPackage)));
						StartActivity(playstore);
					})
					.SetNegativeButton("Tidak",delegate{
						
					});

				Android.App.AlertDialog alertShow = alertBuild.Create();
				alertShow.Show ();

			}

		}
		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			mDrawerToggle.SyncState ();
		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			//MenuInflater.Inflate(Resource.Menu.menu_main, menu);
			return base.OnCreateOptionsMenu(menu);
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.action_settings:
				Toast.MakeText (Application.Context, "Setting has been clicked", ToastLength.Short).Show ();
				break;
			case Resource.Id.navigate:
				//StartActivity (typeof(subActivity));
				break;
			}
			if (mDrawerToggle.OnOptionsItemSelected (item)) {
				//mDrawerLayout.CloseDrawer (lvMMLListed);
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		private void menuItemClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			Console.WriteLine ("[MenuItemClicked] Position: {0}",e.Position);
			//Toast.MakeText (this, string.Format ("Sedang memuatkan...", e.Position), ToastLength.Short).Show ();

			string tokenAcquired = Intent.GetStringExtra ("Token");
			string emailAcquired = Intent.GetStringExtra ("FullName");
			string siteCodeAcquired = Intent.GetStringExtra ("SiteCode");

			if (e.Position == 0) {

				mDrawerLayout.CloseDrawer (leftListView);

			}

			if (e.Position == 1) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myKomunitiAct = new Intent (this,typeof(MyKomuniti_MainActivityDW));
				myKomunitiAct.PutExtra ("Token",tokenAcquired);
				myKomunitiAct.PutExtra ("Email", emailAcquired);
				myKomunitiAct.PutExtra ("SiteCode", siteCodeAcquired);
				StartActivity (myKomunitiAct);

			}

			if (e.Position == 2) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent mySoalAct = new Intent (this,typeof(MySoal_MainActivityDW));
				mySoalAct.PutExtra ("Token",tokenAcquired);
				mySoalAct.PutExtra ("Email", emailAcquired);
				mySoalAct.PutExtra ("SiteCode", siteCodeAcquired);
				StartActivity (mySoalAct);

			}
			if (e.Position == 3) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myHealthAct = new Intent (this,typeof(MyHealth_MainActivityDW));
				myHealthAct.PutExtra("Token",tokenAcquired);
				myHealthAct.PutExtra ("Email", emailAcquired);
				myHealthAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myHealthAct);

			}
			if (e.Position == 4) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent mySkoolAct = new Intent (this,typeof(MySkool_MainActivityDW));
				mySkoolAct.PutExtra("Token",tokenAcquired);
				mySkoolAct.PutExtra ("Email", emailAcquired);
				mySkoolAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (mySkoolAct);
			}

			if (e.Position == 5) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myShopAct = new Intent (this,typeof(MyShop_MainActivityDW));
				myShopAct.PutExtra("Token",tokenAcquired);
				myShopAct.PutExtra ("Email", emailAcquired);
				myShopAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myShopAct);
			}
			/*
			if (e.Position == 5) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myVoteAct = new Intent (this,typeof(MyVote.MyVote_MainActivityPO));
				myVoteAct.PutExtra("Token",tokenAcquired);
				myVoteAct.PutExtra ("Email", emailAcquired);
				myVoteAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myVoteAct);
			}
			if (e.Position == 5) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myKomunitiAct = new Intent (this,typeof(MyKomuniti_MainActivityDW));
				myKomunitiAct.PutExtra("Token",tokenAcquired);
				myKomunitiAct.PutExtra ("Email", emailAcquired);
				myKomunitiAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myKomunitiAct);
			}
			*/

		}
		public void LogoutFromApp()
		{
			
			Console.WriteLine ("[MainActivity] Trying to logging out...");

			try {
				
				dbConn = new SQLiteConnection (dbPath);
				var s = dbConn.Query<MMenu_LoginInfo> ("UPDATE MMenu_LoginInfo SET li_loginstate = '0' WHERE li_loginstate = '1';");
				GcmClient.UnRegister(this);
				Console.WriteLine ("[MainActivity] Check if logging out is success: {0}",s);

			}
			catch(Exception e) {
				
				Console.WriteLine ("[MainActivity] Logging out failed with exception: {0}",e);
			
			}
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();

			FinishActivity (0);
			/*
			Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder (this);
			builder
				.SetTitle ("Keluar dari Aplikasi")
				.SetMessage ("Anda pasti?")
				.SetCancelable(false)
				.SetPositiveButton("Ya",delegate {
					this.Finish ();
				})
				.SetNegativeButton("Tidak",delegate {

				});

			Android.App.AlertDialog alertDialog = builder.Create();
			alertDialog.Show ();
			*/
		}

	}
	public class MainActivityAdapters : BaseAdapter<LeftMenuListItems>
	{
		List<LeftMenuListItems> dwListItems;
		Activity context;
		public MainActivityAdapters(Activity context, List<LeftMenuListItems> dwListItems)
		{
			this.context = context;
			this.dwListItems = dwListItems;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override LeftMenuListItems this[int position]
		{
			get { return dwListItems[position]; }
		}
		public override int Count
		{
			get { return dwListItems.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = dwListItems[position];

			View view = convertView;
			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.MainMenu_ListCell, null);

			view.FindViewById<TextView>(Resource.Id.ivMLMenu).Text = item.LeftMenuDrawerLabel;
			view.FindViewById<ImageView>(Resource.Id.ivMLicon).SetImageResource(item.LeftMenuDrawerIconID);



			return view;
		}
	}

	public class DashboardFeedAdapters : BaseAdapter<DashboardFeedListItem>
	{
		List<DashboardFeedListItem> dwListItems;
		Activity context;
		Typeface fontface;
		public DashboardFeedAdapters(Activity context, List<DashboardFeedListItem> dwListItems, Typeface fontface)
		{
			this.context = context;
			this.dwListItems = dwListItems;
			this.fontface = fontface;
		}
		public override long GetItemId(int position)
		{
			Console.WriteLine ("GetItemId Pos: {0}",position);
			return position;
		}
		public override DashboardFeedListItem this[int position]
		{
			get { return dwListItems[position]; }
		}
		public override int Count
		{
			get { 
				return dwListItems.Count; 
			}
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			int rowType = GetItemViewType (position);

			//Console.WriteLine ("Viewtype: {0}, DWLISTITEM: {1}, Position: {2}",rowType,dwListItems.Count,position);

			View view = convertView;
			/*
			if (position == 1) {

				if (view == null)  // no view to re-use, create new
					view = context.LayoutInflater.Inflate (Resource.Layout.Dashboard_FeedTransImage, null);

			} else {
			*/
			var item = dwListItems[position];

			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate (Resource.Layout.Dashboard_FeedCell, null);

			if(item.DashboardFeedType == "Pic"){

				view.FindViewById<LinearLayout> (Resource.Id.llDFCNormalFeed).Visibility = ViewStates.Visible;

			} else if (item.DashboardFeedType == "Normal-Type") {
				view.FindViewById<LinearLayout> (Resource.Id.llDFCNormalFeed).Visibility = ViewStates.Visible;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthBPFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthWSFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCShopFeed).Visibility = ViewStates.Gone;

				//fontface

				view.FindViewById<TextView> (Resource.Id.ivDFCFeedTitle).Text = item.DashboardFeedTitleLabel;
				view.FindViewById<TextView> (Resource.Id.ivDFCFeedTitle).SetTypeface(fontface,TypefaceStyle.Bold);
				view.FindViewById<TextView> (Resource.Id.ivDFCFeedDate).Text = item.DashboardFeedDateLabel;
				view.FindViewById<TextView> (Resource.Id.ivDFCFeedDate).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.ivDFCFeedDesc).Text = item.DashboardFeedDescLabel;
				view.FindViewById<TextView> (Resource.Id.ivDFCFeedDesc).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<ImageView> (Resource.Id.ivDFCFeedIcon).SetImageResource (item.DashboardFeedDrawerIconID);

			} else if (item.DashboardFeedType == "HealthBP-Type") {
				view.FindViewById<LinearLayout> (Resource.Id.llDFCNormalFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthBPFeed).Visibility = ViewStates.Visible;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthWSFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCShopFeed).Visibility = ViewStates.Gone;

				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFTitle).Text = item.DashboardFeedHealthBPStatus;
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFTitle).SetTypeface(fontface,TypefaceStyle.Bold);
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFDate).Text = item.DashboardFeedHealthBPDate;
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFDate).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFBloodPressure).Text = item.DashboardFeedHealthBPPressure;
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFBloodPressure).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFPulseBeat).Text = item.DashboardFeedHealthBPPulse;
				view.FindViewById<TextView> (Resource.Id.tvDFCHBPFPulseBeat).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<ImageView> (Resource.Id.ivDFCFeedIcon).SetImageResource (item.DashboardFeedDrawerIconID);

			} else if (item.DashboardFeedType == "HealthWS-Type") {
				view.FindViewById<LinearLayout> (Resource.Id.llDFCNormalFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthBPFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthWSFeed).Visibility = ViewStates.Visible;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCShopFeed).Visibility = ViewStates.Gone;

				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFTitle).Text = item.DashboardFeedHealthWSStatus;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFTitle).SetTypeface(fontface,TypefaceStyle.Bold);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFDate).Text = item.DashboardFeedHealthWSDate;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFDate).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFWeight).Text = item.DashboardFeedHealthWSWeight;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFWeight).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFBMI).Text = item.DashboardFeedHealthWSBMI;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFBMI).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFFat).Text = item.DashboardFeedHealthWSFat;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFFat).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFMassWeight).Text = item.DashboardFeedHealthWSNettWeight;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFMassWeight).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFBoneWeight).Text = item.DashboardFeedHealthWSBoneMass;
				view.FindViewById<TextView> (Resource.Id.tvDFCHWSFBoneWeight).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<ImageView> (Resource.Id.ivDFCFeedIcon).SetImageResource (item.DashboardFeedDrawerIconID);

			} else if (item.DashboardFeedType == "Shop-Type") {
				view.FindViewById<LinearLayout> (Resource.Id.llDFCNormalFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthBPFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCHealthWSFeed).Visibility = ViewStates.Gone;
				view.FindViewById<LinearLayout> (Resource.Id.llDFCShopFeed).Visibility = ViewStates.Visible;

				view.FindViewById<TextView> (Resource.Id.tvDFCSPrice).Text = item.DashboardFeedShopPrice;
				view.FindViewById<TextView> (Resource.Id.tvDFCSPrice).SetTypeface(fontface,TypefaceStyle.Bold);
				view.FindViewById<TextView> (Resource.Id.tvDFCSDate).Text = item.DashboardFeedShopDate;
				view.FindViewById<TextView> (Resource.Id.tvDFCSDate).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCSDesc).Text = item.DashboardFeedShopProduct;
				view.FindViewById<TextView> (Resource.Id.tvDFCSDesc).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<TextView> (Resource.Id.tvDFCSLocation).Text = item.DashboardFeedShopLocation;
				view.FindViewById<TextView> (Resource.Id.tvDFCSLocation).SetTypeface(fontface,TypefaceStyle.Normal);
				view.FindViewById<ImageView> (Resource.Id.ivDFCFeedIcon).SetImageResource (item.DashboardFeedDrawerIconID);
			}
			//}		
			return view;
		}
	}
	public class LeftMenuListItems
	{
		public LeftMenuListItems ()
		{
		}
		public int LeftMenuDrawerIconID { get; set; }
		public string LeftMenuDrawerLabel { get; set; }
	}

	public class DashboardFeedListItem
	{
		public DashboardFeedListItem ()
		{
		}

		public int DashboardFeedDrawerIconID { get; set; }

		public string DashboardFeedTitleLabel { get; set; }
		public string DashboardFeedDateLabel { get; set; }
		public string DashboardFeedDescLabel { get; set; }

		public string DashboardFeedHealthBPStatus { get; set; }
		public string DashboardFeedHealthBPDate { get; set; }
		public string DashboardFeedHealthBPPressure { get; set; }
		public string DashboardFeedHealthBPPulse { get; set; }

		public string DashboardFeedHealthWSStatus { get; set; }
		public string DashboardFeedHealthWSDate { get; set; }
		public string DashboardFeedHealthWSWeight { get; set; }
		public string DashboardFeedHealthWSBMI { get; set; }
		public string DashboardFeedHealthWSFat { get; set; }
		public string DashboardFeedHealthWSNettWeight { get; set; }
		public string DashboardFeedHealthWSBoneMass { get; set; }

		public string DashboardFeedShopPrice { get; set; }
		public string DashboardFeedShopDate { get; set; }
		public string DashboardFeedShopProduct { get; set; }
		public string DashboardFeedShopLocation { get; set; }

		public string DashboardFeedType { get; set; }
	}

	[Activity (Label = "Layered", Theme = "@style/TranslucentLayout")]
	public class TutorialOverlay_MainMenu : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.TutorialOverlay_MainMenu);


		}
	}
}

