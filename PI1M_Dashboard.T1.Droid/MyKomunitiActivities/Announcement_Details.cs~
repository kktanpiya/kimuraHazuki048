
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
using Android.Webkit;
using Android.Support.V7.App;
using Android.Support.V4.App;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "")]			
	public class MyKomuniti_Announcement_Details : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;

		TextView mainTitle;
		WebView infoDetails;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.MyKomuniti_AnnounceDetailsLayout);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#FA5725"));
			//toolbar.SetNavigationIcon (Resource.Drawable.ic_arrow_up);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			string getArticleTitle = Intent.GetStringExtra ("ArticleTitle");
			string getArticleContent = Intent.GetStringExtra ("ArticleContent");

			mainTitle = FindViewById<TextView> (Resource.Id.tvMKADLMainTitle);
			mainTitle.Text = getArticleTitle.ToString();

			infoDetails = FindViewById<WebView> (Resource.Id.wvMKADLDetails);
			infoDetails.Settings.JavaScriptEnabled = true;
			infoDetails.LoadDataWithBaseURL ("", 
				getArticleContent.ToString(), 
				"text/html", 
				"UTF-8", "");
			infoDetails.Settings.BuiltInZoomControls = true;

		}
		public override void OnBackPressed ()
		{
			base.OnBackPressed ();

			this.OverridePendingTransition (0, 0);
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{

			switch (item.ItemId)
			{
			case Android.Resource.Id.Home:
				this.Finish ();
				this.OverridePendingTransition (0, 0);
				break;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

