﻿using System;

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
using Android.Support.V4.View;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "My Skool", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MySkool_MainActivityDW : ActionBarActivity
	{
		DrawerLayout mDrawerLayout;
		Android.Support.V7.App.ActionBarDrawerToggle mDrawerToggle;
		ViewPager pager;
		MySkool_ViewPagerAdapter adapter;
		MySkool_SlidingTabScrollView tabs;
		private Android.Support.V7.Widget.Toolbar toolbar;

		ListView lvMMLListed;
		ListView lvMMLListedEx2;
		List<MySkool_LeftMenuListItemsDW> MenuListItem;
		List<MySkool_LeftMenuListItemsDW> ExMenuListItem;

		LinearLayout llMMLLogout;

		TextView tvMMLUserEmail;

		LinearLayout leftListView;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MySkool_MainPager);

			adapter = new MySkool_ViewPagerAdapter (SupportFragmentManager);

			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.mySkool_Drawer);
			mDrawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle (this, mDrawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);
			mDrawerLayout.SetDrawerListener (mDrawerToggle);

			leftListView = (LinearLayout)FindViewById (Resource.Id.mySkool_leftListView);
			lvMMLListed = (ListView)FindViewById (Resource.Id.lvMSKMMLListed);
			lvMMLListedEx2 = (ListView)FindViewById (Resource.Id.lvMSKMMLListedEx2);
			tvMMLUserEmail = (TextView)FindViewById (Resource.Id.tvMSKMMLUserEmail);

			pager = FindViewById <ViewPager> (Resource.Id.pager);
			pager.Adapter = adapter;
		
			tabs = FindViewById<MySkool_SlidingTabScrollView> (Resource.Id.tabs);
			tabs.ViewPager = pager;

			string UserName = Intent.GetStringExtra ("Email");
			tvMMLUserEmail.Text = UserName;

			ImageView ivMMLShowSecondMenu = (ImageView)FindViewById (Resource.Id.ivMSKMMLShowSecondMenu);
			LinearLayout llMMLShowSecondMenu = (LinearLayout)FindViewById (Resource.Id.llMSKMMLShowSecondMenu);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F8A015"));

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeButtonEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled (true);


			MenuListItem = new List<MySkool_LeftMenuListItemsDW> ();

			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "Dashboard",
				LeftMenuDrawerIconID = Resource.Drawable.home3 });
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Komuniti",
				LeftMenuDrawerIconID = Resource.Drawable.people2 });
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Soal",
				LeftMenuDrawerIconID = Resource.Drawable.cup2 });
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Health",
				LeftMenuDrawerIconID = Resource.Drawable.heart2 });
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Skool",
				LeftMenuDrawerIconID = Resource.Drawable.shield2 });
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Shop",
				LeftMenuDrawerIconID = Resource.Drawable.cart2 });
			/*
			MenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "My Vote",
				LeftMenuDrawerIconID = Resource.Drawable.ic_myposter });
			*/

			lvMMLListed.Adapter = new MySkool_MainActivityAdaptersDW (this, MenuListItem);
			lvMMLListed.ItemClick += menuItemClicked;

			ExMenuListItem = new List<MySkool_LeftMenuListItemsDW> ();

			//ExMenuListItem.Add (new LeftMenuListItems(){ 
			//	LeftMenuDrawerLabel = "Tetapan",
			//	LeftMenuDrawerIconID = Resource.Drawable.ic_gear_grey });

			ExMenuListItem.Add (new MySkool_LeftMenuListItemsDW(){ 
				LeftMenuDrawerLabel = "Berkenaan PI1M",
				LeftMenuDrawerIconID = Resource.Drawable.ic_about_48dp });

			lvMMLListedEx2.Adapter = new MySkool_MainActivityAdaptersDW (this, ExMenuListItem);
			lvMMLListedEx2.ItemClick += ItemExClicked;

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

			llMMLLogout = (LinearLayout)FindViewById (Resource.Id.llMSKMMLLogout);
			llMMLLogout.Click += (object sender, EventArgs e) => {

				this.Finish();

			};
		}
		private void ItemExClicked(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			//if (e.Position == 0) {

			//	Intent mySoalAct = new Intent (this,typeof(MySoal_MainActivity));
			//	StartActivity (mySoalAct);

			//}
			if (e.Position == 0) {

				Intent aboutAct = new Intent (this,typeof(AboutActivity));

				StartActivity (aboutAct);

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
			string emailAcquired = Intent.GetStringExtra ("Email");
			string siteCodeAcquired = Intent.GetStringExtra ("SiteCode");

			if (e.Position == 0) {

				this.Finish ();

			}
			if (e.Position == 1) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myKomunitiAct = new Intent (this,typeof(MyKomuniti_MainActivityDW));
				myKomunitiAct.PutExtra("Token",tokenAcquired);
				myKomunitiAct.PutExtra ("Email", emailAcquired);
				myKomunitiAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myKomunitiAct);
				this.Finish ();

			}
			if (e.Position == 2) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent mySoalAct = new Intent (this,typeof(MySoal_MainActivityDW));
				mySoalAct.PutExtra("Token",tokenAcquired);
				mySoalAct.PutExtra ("Email", emailAcquired);
				mySoalAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (mySoalAct);
				this.Finish ();

			}
			if (e.Position == 3) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myHealthAct = new Intent (this,typeof(MyHealth_MainActivityDW));
				myHealthAct.PutExtra("Token",tokenAcquired);
				myHealthAct.PutExtra ("Email", emailAcquired);
				myHealthAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myHealthAct);
				this.Finish ();

			}
			if (e.Position == 4) {

				mDrawerLayout.CloseDrawer (leftListView);

			}

			if (e.Position == 5) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myShopAct = new Intent (this,typeof(MyShop_MainActivityDW));
				myShopAct.PutExtra("Token",tokenAcquired);
				myShopAct.PutExtra ("Email", emailAcquired);
				myShopAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myShopAct);
				this.Finish ();
			}
			/*
			if (e.Position == 5) {

				mDrawerLayout.CloseDrawer (leftListView);
				Intent myVoteAct = new Intent (this,typeof(MyVote.MyVote_MainActivityPO));
				myVoteAct.PutExtra("Token",tokenAcquired);
				myVoteAct.PutExtra ("Email", emailAcquired);
				myVoteAct.PutExtra ("SiteCode", siteCodeAcquired);

				StartActivity (myVoteAct);
				this.Finish ();
			}
			*/
		}

	}
	public class MySkool_MainActivityAdaptersDW : BaseAdapter<MySkool_LeftMenuListItemsDW>
	{
		List<MySkool_LeftMenuListItemsDW> dwListItems;
		Activity context;
		public MySkool_MainActivityAdaptersDW(Activity context, List<MySkool_LeftMenuListItemsDW> dwListItems)
		{
			this.context = context;
			this.dwListItems = dwListItems;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override MySkool_LeftMenuListItemsDW this[int position]
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


	public class MySkool_LeftMenuListItemsDW
	{
		public MySkool_LeftMenuListItemsDW () {}
		public int LeftMenuDrawerIconID { get; set; }
		public string LeftMenuDrawerLabel { get; set; }
	}


}

