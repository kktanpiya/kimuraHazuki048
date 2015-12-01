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
using System.Threading;
using Newtonsoft.Json;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Support.V4.View;
using System.Threading.Tasks;
using PI1M_Dashboard.T1.Droid;

namespace drawer_navigation
{
	[Activity (Label = "Produk Popular")]
	public class Product_Listing : AppCompatActivity
	{        
		DrawerLayout drawerLayout;


		protected override void OnCreate(Bundle savedInstanceState) 
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.MyShop_listall_main);


			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#9C27B0"));

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowHomeEnabled (true);
//			SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
//			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
//			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
//
//			var navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
//			if (navigationView != null)
//				setupDrawerContent(navigationView);

			var viewPager = FindViewById<ViewPager> (Resource.Id.viewpager);
			if (viewPager != null) {
				setupViewPager (viewPager);
				int tab = Intent.GetIntExtra ("tab",-1);
				viewPager.SetCurrentItem (tab, true);
				viewPager.OffscreenPageLimit = 3;
			}

//			var tabs = FindViewById<com.refractored.PagerSlidingTabStrip> (Resource.Id.tabs);
//			tabs.SetViewPager (viewPager);


			//			var fab = FindViewById<FloatingActionButton> (Resource.Id.fab);
			//			fab.Click += (sender, e) => {
			//					Snackbar.Make (fab, "Here's a snackbar!", Snackbar.LengthLong).SetAction ("Action",
			//						new ClickListener (v => {
			//							Console.WriteLine ("Action handler");
			//						})).Show ();
			//		
			//
			//			}; 
		
		}
			
//		public override bool OnCreateOptionsMenu (IMenu menu) 
//		{
//			MenuInflater.Inflate(Resource.Menu.sample_actions, menu);
//			return true;
//		}

		public override bool OnOptionsItemSelected (IMenuItem item) 
		{
//			switch (item.ItemId) {
//			case Android.Resource.Id.Home:
//				drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
//				return true;
//			}
//			return base.OnOptionsItemSelected (item);
			switch (item.ItemId) {

			case Android.Resource.Id.Home:
				this.Finish ();
				this.OverridePendingTransition (0, 0);
				return true;

			default:
				return base.OnOptionsItemSelected (item);

			}

		}

		void setupViewPager (Android.Support.V4.View.ViewPager viewPager) 
		{
			var adapter = new Adapter (SupportFragmentManager);
			int tab = Intent.GetIntExtra ("tab",-1);

			switch(tab){

			case 0:
				adapter.AddFragment (new List_Fragment_latestProd (this), "Produk Terbaru");
				SupportActionBar.Title = "Produk Terbaru";

				break;
			case 1:
				adapter.AddFragment (new List_Fragment_popularProd (this), "");
				SupportActionBar.Title = "Produk Popular";
				break;

			case 2:
				adapter.AddFragment (new List_Fragment_localProd (this), "Produk Setempat");
				SupportActionBar.Title = "Produk Setempat";
				break;

			case 3:
				adapter.AddFragment (new List_Fragment_reviewProd (this), "Produk Paling Tinggi Komen");
				SupportActionBar.Title = "Produk Paling Tinggi Komen";
				break;


			}
//			adapter.AddFragment (new List_Fragment_reviewProd (this), "Produk Komen Tertinggi");

			viewPager.Adapter = adapter;
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


