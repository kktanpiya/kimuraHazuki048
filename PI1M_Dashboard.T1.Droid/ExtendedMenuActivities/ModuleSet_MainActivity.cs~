
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

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Module Set")]			
	public class ModuleSet_MainActivity : AppCompatActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.Settings_ModuleSelect);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayShowTitleEnabled (true);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}
	}
}