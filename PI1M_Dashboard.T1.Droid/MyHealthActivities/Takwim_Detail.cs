
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

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Takwim_Detail")]			
	public class MyHealth_Takwim_Detail : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MyHealth_Takwim_Detail);

			String data = Intent.GetStringExtra ("detail");
			TextView tvDetail = FindViewById <TextView> (Resource.Id.tvData);
			TextView tvTextDetail = FindViewById <TextView>(Resource.Id.tvTextData);

			tvDetail.Text = data;
			tvTextDetail.Text = "Stark and Banner discover an artificial intelligence within the scepter's gem," +
				" and secretly use it to complete Stark's \"Ultron\" global defense program." +
				" The unexpectedly sentient Ultron, believing he must eradicate humanity to save Earth," +
				" eliminates Stark's A.I. J.A.R.V.I.S. and attacks the Avengers during a victory party at their headquarters." +
				" Escaping with the scepter, Ultron uses the resources in Strucker's Sokovia base to upgrade his rudimentary body" +
				" and build an army of robot drones. He recruits the Maximoff twins," +
				" who harbor a grudge against Stark for weapons responsible for their parents' deaths, and together," +
				" they visit the South African shipyard base of arms dealer Ulysses Klaue to obtain vibranium." +
				" The Avengers battle them, but Wanda subdues the heroes with haunting visions, causing the Hulk to run amok and" +
				" forcing Stark to use his powerful \"Veronica\" armor to stop him.";
		}
	}
}

