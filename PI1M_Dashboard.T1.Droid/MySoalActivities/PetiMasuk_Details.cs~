
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
using Android.Graphics;
using Android.Support.V7.App;
using Android.Webkit;
using Android.Support.V4.App;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class PetiMasuk_Details : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;

		TextView mainTitle;
		WebView infoDetails;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.MySoal_MessageDetailsLayout);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F44336"));
			//toolbar.SetNavigationIcon (Resource.Drawable.ic_next);
			//toolbar.
			//toolbar.SetNavigationOnClickListener ();

			mainTitle = FindViewById<TextView> (Resource.Id.tvMSMDLMainTitle);
			mainTitle.Text = Intent.GetStringExtra ("PMDTitle");

			infoDetails = FindViewById<WebView> (Resource.Id.wvMSMDLDetails);
			infoDetails.Settings.JavaScriptEnabled = true;
			infoDetails.LoadDataWithBaseURL ("", 
				Intent.GetStringExtra ("PMDContent"), 
				"text/html", 
				"UTF-8", "");
			infoDetails.Settings.BuiltInZoomControls = true;

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();

			this.OverridePendingTransition (0, 0);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {

			case Android.Resource.Id.Home:
				this.Finish ();
				this.OverridePendingTransition (0, 0);
				return true;

			default:
				return base.OnOptionsItemSelected (item);

			}
			

		}

	}
		
}

