using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Collections.Generic;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "parallax", Theme="@style/Theme.DesignDemo", Icon = "@drawable/icon")]
	public class Dashboard_MainActivityPX : AppCompatActivity
	{
		DrawerLayout drawerLayout;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.DashboardP_MainLayout);

			// Get our button from the layout resource,
			// and attach an event to it
			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			//SupportActionBar.SetHomeAsUpIndicator();
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);

			var navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			if (navigationView != null)
				setupDrawerContent (navigationView);

			var collapsingToolbar = FindViewById<CollapsingToolbarLayout> (Resource.Id.collapsing_toolbar);
			//collapsingToolbar.SetTitle ("Mizuno Yui");
			//loadBackdrop ();
		}
		public override bool OnCreateOptionsMenu (IMenu menu) 
		{
			MenuInflater.Inflate(Resource.Menu.drawer_settings, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item) 
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

		void setupDrawerContent(NavigationView navigationView) 
		{
			navigationView.NavigationItemSelected += (sender, e) => {
				//e.P0.SetChecked (true);
				drawerLayout.CloseDrawers ();
			};
		}

		class Adapter : Android.Support.V4.App.FragmentPagerAdapter 
		{
			List<V4Fragment> fragments = new List<V4Fragment> ();
			List<string> fragmentTitles = new List<string> ();

			public Adapter (V4FragmentManager fm) : base (fm)
			{
			}

			public void AddFragment (V4Fragment fragment, String title) 
			{
				fragments.Add(fragment);
				fragmentTitles.Add(title);
			}

			public override V4Fragment GetItem(int position) 
			{
				return fragments [position];
			}

			public override int Count {
				get { return fragments.Count; }
			}

			public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
			{
				return new Java.Lang.String (fragmentTitles [position]);
			}

		} 
	}

	public class ClickListener : Java.Lang.Object, View.IOnClickListener
	{
		public ClickListener (Action<View> handler)
		{
			Handler = handler;
		}

		public Action<View> Handler { get; set; }

		public void OnClick (View v)
		{
			var h = Handler;
			if (h != null)
				h (v);
		}
	} 
}




