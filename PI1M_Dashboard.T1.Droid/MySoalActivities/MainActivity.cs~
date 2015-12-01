using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Graphics;
using Android.Content.PM;
using Android.Support.V4.Widget;
using System.Collections.Generic;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "My Soal", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MySoal_MainActivity : ActionBarActivity
	{
		//Toolbar toolbar;
		/*ListDataHolder listData;
		RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;*/

		ViewPager pager;
		MySoal_ViewPagerAdapter adapter;
		MySoal_SlidingTabScrollView tabs;
		private Android.Support.V7.Widget.Toolbar toolbar;

		DrawerLayout mDrawerLayout;
		Android.Support.V7.App.ActionBarDrawerToggle mDrawerToggle;
		ListView lvMMLListed;
		LinearLayout leftListView;
		List<LeftMenuListItems> MenuListItem;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MySoal_MainPager);

			adapter = new MySoal_ViewPagerAdapter (SupportFragmentManager);

			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.myDrawer);
			mDrawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle (this, mDrawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);
			mDrawerLayout.SetDrawerListener (mDrawerToggle);

			leftListView = (LinearLayout)FindViewById (Resource.Id.leftListView);
			lvMMLListed = (ListView)FindViewById (Resource.Id.lvMMLListed);

			pager = FindViewById <ViewPager> (Resource.Id.pager);
			pager.Adapter = adapter;

			tabs = FindViewById<MySoal_SlidingTabScrollView> (Resource.Id.tabs);
			tabs.ViewPager = pager;

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F44336"));

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeButtonEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled (true);

			MenuListItem = new List<LeftMenuListItems> ();

			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "Dashboard",
				LeftMenuDrawerIconID = Resource.Drawable.home3 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Soal",
				LeftMenuDrawerIconID = Resource.Drawable.cup2 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Health",
				LeftMenuDrawerIconID = Resource.Drawable.heart2 });
			MenuListItem.Add (new LeftMenuListItems(){ 
				LeftMenuDrawerLabel = "My Skool",
				LeftMenuDrawerIconID = Resource.Drawable.shield2 });

			lvMMLListed.Adapter = new MainActivityAdapters (this, MenuListItem);

		}
	}
}


