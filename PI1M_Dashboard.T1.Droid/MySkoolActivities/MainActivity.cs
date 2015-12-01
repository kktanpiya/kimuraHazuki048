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
using Newtonsoft.Json;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Register ("com.ingeniworks.dashboarda.PI1M_Dashboard.T1.Droid.MainActivity")]
	[Activity (Label = "My Skool", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MySkool_MainActivity : ActionBarActivity
	{
		//Toolbar toolbar;
		/*ListDataHolder listData;
		RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;*/

		ViewPager pager;
		MySkool_ViewPagerAdapter adapter;
		MySkool_SlidingTabScrollView tabs;
		private Android.Support.V7.Widget.Toolbar toolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MySkool_Main);

			//toolbar = (Toolbar)FindViewById (Resource.Id.tool_bar);
			//SetActionBar (toolbar);

			/*listData = new ListDataHolder ();

			recyclerView = FindViewById <RecyclerView> (Resource.Id.recyclerView);
			mLayoutManager = new LinearLayoutManager (this);
			recyclerView.SetLayoutManager (mLayoutManager);

			recyclerAdapter = new RecyclerViewAdapter (this, listData);
			recyclerView.SetAdapter (recyclerAdapter);*/

			adapter = new MySkool_ViewPagerAdapter (SupportFragmentManager);

			pager = FindViewById <ViewPager> (Resource.Id.pager);
			pager.Adapter = adapter;

			tabs = FindViewById<MySkool_SlidingTabScrollView> (Resource.Id.tabs);
			tabs.ViewPager = pager;

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F8A015"));
			SetSupportActionBar (toolbar);

		}
			
	}
}


