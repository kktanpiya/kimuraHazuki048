
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
using Android.Graphics;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Berat Badan", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class BWDetails : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.MyHealth_BWDetails);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#009688"));
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			string getMHWPDate = Intent.GetStringExtra ("MHBWDate");
			string getMHWPTime = Intent.GetStringExtra ("MHBWTime");
			string getMHBWWeight = Intent.GetStringExtra ("MHBWWeight");
			string getMHBWBMI = Intent.GetStringExtra ("MHBWBMI");
			string getMHBWFat = Intent.GetStringExtra ("MHBWFat");
			string getMHBWLeanWeight = Intent.GetStringExtra ("MHBWLeanWeight");
			string getMHBWBoneMass = Intent.GetStringExtra ("MHBWBoneMass");
			string getMHBWStatus = Intent.GetStringExtra ("MHBWStatus");

			TextView tvMHBWDDate = (TextView)FindViewById (Resource.Id.tvMHBWDDate);
			TextView tvMHBWDTime = (TextView)FindViewById (Resource.Id.tvMHBWDTime);
			TextView tvMHBWDWeight = (TextView)FindViewById (Resource.Id.tvMHBWDWeight);
			TextView tvMHBWDBMI = (TextView)FindViewById (Resource.Id.tvMHBWDBMI);
			TextView tvMHBWDFat = (TextView)FindViewById (Resource.Id.tvMHBWDFat);
			TextView tvMHBWDLeanWeight = (TextView)FindViewById (Resource.Id.tvMHBWDLeanWeight);
			TextView tvMHBWDBoneMass = (TextView)FindViewById (Resource.Id.tvMHBWDBoneMass);
			TextView tvMHBWDStatus = (TextView)FindViewById (Resource.Id.tvMHBWDStatus);

			ImageView ivMHBWDStatIcon = (ImageView)FindViewById (Resource.Id.ivMHBWDStatIcon);

			tvMHBWDDate.Text = getMHWPDate;
			tvMHBWDTime.Text = getMHWPTime;
			tvMHBWDWeight.Text = getMHBWWeight;
			tvMHBWDBMI.Text = getMHBWBMI;
			tvMHBWDFat.Text = getMHBWFat;
			tvMHBWDLeanWeight.Text = getMHBWLeanWeight;
			tvMHBWDBoneMass.Text = getMHBWBoneMass;
			tvMHBWDStatus.Text = getMHBWStatus;
			setIcon (getMHBWStatus, tvMHBWDStatus, ivMHBWDStatIcon);


		}

		public void setIcon(string status, TextView statusTV, ImageView statIconIV)
		{
			ImageView ivMHBWDStatIcon = statIconIV;
			TextView tvMHBWDStatus = statusTV;

			if (status == "Kurang Berat") {
				ivMHBWDStatIcon.SetImageResource(Resource.Drawable.ic_bp_optimal);
				tvMHBWDStatus.SetTextColor(Color.ParseColor("#FF699A2D"));
			} else if (status == "Normal") {
				ivMHBWDStatIcon.SetImageResource(Resource.Drawable.ic_bp_hinorm);
				tvMHBWDStatus.SetTextColor(Color.ParseColor("#FFFFCD00"));
			} else if (status == "Lebih Berat") {
				ivMHBWDStatIcon.SetImageResource(Resource.Drawable.ic_bp_g1);
				tvMHBWDStatus.SetTextColor(Color.ParseColor("#FFE63E00"));
			} else if (status == "Obesiti") {
				ivMHBWDStatIcon.SetImageResource(Resource.Drawable.ic_bp_g2);
				tvMHBWDStatus.SetTextColor(Color.ParseColor("#FF9B0000"));
			} else {
				ivMHBWDStatIcon.SetImageResource(Resource.Drawable.ic_heartrate);
				tvMHBWDStatus.SetTextColor(Color.ParseColor("#FF000000"));
			}
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

