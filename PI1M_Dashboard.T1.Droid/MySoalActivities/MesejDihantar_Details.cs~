
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
	[Activity (Label = "", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class MesejDihantar_Details : ActionBarActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;
		TextView tvMSMDDKepada;
		TextView tvMSMDDSubjek;
		TextView tvMSMDDIsi;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.MySoal_MesejDihantarDetails);

			tvMSMDDKepada = (TextView)FindViewById (Resource.Id.tvMSMDDKepada);
			tvMSMDDSubjek = (TextView)FindViewById (Resource.Id.tvMSMDDSubjek);
			tvMSMDDIsi = (TextView)FindViewById (Resource.Id.tvMSMDDIsi);

			tvMSMDDKepada.Text = Intent.GetStringExtra ("SITo");
			tvMSMDDSubjek.Text = Intent.GetStringExtra ("SISubject");
			tvMSMDDIsi.Text = Intent.GetStringExtra ("SIContent");

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F44336"));
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

