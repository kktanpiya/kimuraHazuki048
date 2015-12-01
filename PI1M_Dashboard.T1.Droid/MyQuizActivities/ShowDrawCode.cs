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
using DataAccess;
using MyQuiz;
using PI1M_Dashboard.T1.Droid;
using Android.Content.PM;

namespace MyQuiz
{
	[Activity (Label = "ShowDrawCode", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class ShowDrawCode : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.showdrawcode);

		//	TextView tv_drawCode = FindViewById<TextView> (Resource.Id.tv_drawCode);

			int drawNo = Intent.GetIntExtra ("drawNo",0000);
			string user_id = Intent.GetStringExtra ("user_id");
			bool animate_condition = Intent.GetBooleanExtra ("animate",false);
	
			var flipNumbers = FindViewById<FlipNumbers.FlipNumbersView>(Resource.Id.flipNumbers1);
			flipNumbers.SetValue (drawNo,animated:animate_condition);

//			DB_access.updateCompletionStat (drawNo, user_id);
			// Create your application here
		}
	}
}

