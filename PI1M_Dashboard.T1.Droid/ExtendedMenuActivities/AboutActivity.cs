
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
using Android.Support.V7.App;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Berkenaan PI1M", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class AboutActivity : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.About_Main);

			Button btnAMExit = (Button)FindViewById (Resource.Id.btnAMExit);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);

			SetSupportActionBar (toolbar);

			TextView tvAMVerInfo = (TextView)FindViewById (Resource.Id.tvAMVerInfo);
			TextView tvAMBuildNumberInfo = (TextView)FindViewById (Resource.Id.tvAMBuildNumberinfo);

			PackageInfo pacMan = PackageManager.GetPackageInfo (PackageName, 0);

			string setVerInfo = string.Format ("Version {0}",pacMan.VersionName);
			tvAMVerInfo.Text = setVerInfo;

			//System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
			//dtDateTime = dtDateTime.AddSeconds( pacMan.LastUpdateTime ).ToLocalTime();

			string setBuildNumberInfo = string.Format ("(Build Number {0}, {1})",pacMan.VersionCode,pacMan.LastUpdateTime);
			tvAMBuildNumberInfo.Text = setBuildNumberInfo;

			btnAMExit.Click += delegate {

				this.Finish();

			};
		}
	}
}

