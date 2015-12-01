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

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "My Health", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MyHealth_MainActivity : ActionBarActivity
	{
		//Toolbar toolbar;
		/*ListDataHolder listData;
		RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;*/

		ViewPager pager;
		MyHealth_ViewPagerAdapter adapter;
		MyHealth_SlidingTabScrollView tabs;
		private Android.Support.V7.Widget.Toolbar toolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MyHealth_Main);

			//toolbar = (Toolbar)FindViewById (Resource.Id.tool_bar);
			//SetActionBar (toolbar);

			/*listData = new ListDataHolder ();

			recyclerView = FindViewById <RecyclerView> (Resource.Id.recyclerView);
			mLayoutManager = new LinearLayoutManager (this);
			recyclerView.SetLayoutManager (mLayoutManager);

			recyclerAdapter = new RecyclerViewAdapter (this, listData);
			recyclerView.SetAdapter (recyclerAdapter);*/

			adapter = new MyHealth_ViewPagerAdapter (SupportFragmentManager);

			pager = FindViewById <ViewPager> (Resource.Id.pager);
			pager.Adapter = adapter;

			tabs = FindViewById<MyHealth_SlidingTabScrollView> (Resource.Id.tabs);
			tabs.ViewPager = pager;

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#009688"));
			SetSupportActionBar (toolbar);

		}
	}
}


