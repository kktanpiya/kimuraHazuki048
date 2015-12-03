using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Graphics;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ImageSlider_oriImage : AppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.popup);


			// Create your application here
			string url = Intent.GetStringExtra ("url") ?? "Data not available";
			string css = "<style>html, body, #wrapper {height:100%; width: 100%; margin: 0; padding: 0; border: 0;} #wrapper td {vertical-align: middle; text-align: center;} </style>";
			url = css+"<html><body><table id=\"wrapper\"><tr><td><img src='"+url+"'  /></td></tr></table></body></html>";
			//url="<html><br><br><br><br><img src='"+url+"' /></html>";
			WebView webView = FindViewById<WebView> (Resource.Id.LocalWebView);
			webView.SetWebViewClient (new WebViewClient ());

			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#9C27B0"));

			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowHomeEnabled (true);

			//webView.LoadUrl ("http://www.xamarin.com");

			// Some websites will require Javascript to be enabled
			webView.Settings.JavaScriptEnabled = true;
//			webView.LoadDataWithBaseURL(url);
			webView.LoadDataWithBaseURL ("", 
				url, 
				"text/html", 
				"UTF-8", "");
			// allow zooming/panning            
			webView.Settings.BuiltInZoomControls = true;
			webView.Settings.UseWideViewPort = true;	
			webView.SetInitialScale (1);

			webView.Settings.SetSupportZoom (true);

			// scrollbar stuff            
			webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay; 
			// so there's no 'white line'            
			webView.ScrollbarFadingEnabled = false;
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
