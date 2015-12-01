using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace signupTest
{
	[Activity (Label = "signupTest", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button sbutton = FindViewById<Button> (Resource.Id.button2);
			
			sbutton.Click += (object sender, EventArgs args) => {

				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_signup dialogus = new dialog_signup();
				dialogus.Show(transaction, "dialog fragment");
			};
		}
	}
}


