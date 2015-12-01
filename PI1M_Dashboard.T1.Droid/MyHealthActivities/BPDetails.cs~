
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
	[Activity (Label = "Tekanan Darah", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class BPDetails : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.MyHealth_BPDetails);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#009688"));
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			string getMHBPDate = Intent.GetStringExtra ("MHBPDate");
			string getMHBPTime = Intent.GetStringExtra ("MHBPTime");
			string getMHBPPulse = Intent.GetStringExtra ("MHBPPulse");
			string getMHBPBPM = Intent.GetStringExtra ("MHBPBPM");
			string getMHBPStatus = Intent.GetStringExtra ("MHBPStatus");

			TextView tvMHBPDDate = (TextView)FindViewById (Resource.Id.tvMHBPDDate);
			TextView tvMHBPDTime = (TextView)FindViewById (Resource.Id.tvMHBPDTime);
			TextView tvMHBPDPulse = (TextView)FindViewById (Resource.Id.tvMHBPDPulse);
			TextView tvMHBPDBPM = (TextView)FindViewById (Resource.Id.tvMHBPDBPM);
			TextView tvMHBPDStatus = (TextView)FindViewById (Resource.Id.tvMHBPDStatus);

			ImageView ivMHBPDStatIcon = (ImageView)FindViewById (Resource.Id.ivMHBPDStatIcon);

			tvMHBPDDate.Text = getMHBPDate;
			tvMHBPDTime.Text = getMHBPTime;
			tvMHBPDPulse.Text = getMHBPPulse;
			tvMHBPDBPM.Text = getMHBPBPM;
			tvMHBPDStatus.Text = getMHBPStatus;
			setIcon (getMHBPStatus,tvMHBPDStatus,ivMHBPDStatIcon);

		}
		public void setIcon(string status, TextView statusTV, ImageView statIconIV)
		{
			ImageView ivMHBPDStatIcon = statIconIV;
			TextView tvMHBPDStatus = statusTV;

			if (status == "Optimal") {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_optimal);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FF699A2D"));
			} else if (status == "Normal") {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_norm);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FF98CE60"));
			} else if (status == "Tinggi-Normal") {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_hinorm);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FFFFCD00"));
			} else if (status == "Gred 1 Hipertensi") {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_g1);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FFFF8000"));
			} else if (status == "Gred 2 Hipertensi") {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_g2);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FFE63E00"));
			} else {
				ivMHBPDStatIcon.SetImageResource(Resource.Drawable.ic_bp_g3);
				tvMHBPDStatus.SetTextColor(Color.ParseColor("#FF9B0000"));
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

