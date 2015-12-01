using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FlipNumbers.Android.Sample
{
	[Activity (Label = "FlipNumbers.Android.Sample", MainLauncher = true)]
	public class Activity1 : Activity
	{
		readonly int maxNumber = 10000;
		readonly Random rnd = new Random();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var flipNumbers = FindViewById<FlipNumbers.FlipNumbersView>(Resource.Id.flipNumbers1);

			/*
			 * Also you can add flip numbers manually, if you want
			 *
			 * var layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
			 * layoutParams.Weight = 2;
			 * layoutParams.Gravity = GravityFlags.CenterHorizontal;
			 * var flipNumbers = new Xamarin.Controls.FlipNumbersView(this, 5);
			 * flipNumbers.LayoutParameters = layoutParams;
			 * FindViewById<LinearLayout>(Resource.Id.rootLayout).AddView (flipNumbers);
			 */

			flipNumbers.Value = GetNextNumber ();

			Button button = FindViewById<Button> (Resource.Id.button1);
			
			button.Click += (s, e) => flipNumbers.SetValue (GetNextNumber (), animated: true);
		}

		int GetNextNumber ()
		{
			return rnd.Next (maxNumber);
		}
	}
}


