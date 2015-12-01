//************ BEGIN-ORICODE ********-// 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using System.Threading;
//using Java.Lang;
//using Android.Content.PM;
//
//namespace PI1M_Dashboard.T1.Droid
//{
//	[Activity (Label = "PI1M Dashboard", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]			
//	public class Splash : Activity
//	{
//		protected override void OnCreate (Bundle bundle)
//		{
//			base.OnCreate (bundle);
//
//			// Create your application here
//			SetContentView(Resource.Layout.InitialStartup);
//
//			new Handler ().PostDelayed (new Running(this),1000);
//
//		}
//		protected override void OnStart ()
//		{
//			base.OnStart ();
//			//new Handler ().PostDelayed (new Running(this),1000);
//			//StartActivity (typeof(InitialStartup));
//		}
//
//	}
//
//	public class Running : Java.Lang.Object, IRunnable
//	{
//		Activity activity;
//		public Running (Activity activity) {
//			this.activity = activity;
//		}
//
//		public void Run() {
//			Console.WriteLine ("[Splash] Running....");
//			activity.StartActivity (typeof(InitialStartup));
//			activity.OverridePendingTransition (0, 0);
//			activity.Finish ();
//		}
//
//	}
//}
//
//************ END-ORICODE ********-// 


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
using System.Threading;
using Java.Lang;
using Android.Content.PM;
using System.Threading.Tasks;
using MyQuiz;
using Newtonsoft.Json;
using DataAccess;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Dashboard Komuniti", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Splash : Activity
	{
		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.InitialStartup);

			bool myQuizOpen = false;
			var isOnline = await Task.Factory.StartNew(() => Commonlib.IsOnline (this));

			if (isOnline == true) {
				try {

					string json_eventOpen = await Task.Factory.StartNew (() => Webservice.ws_validateEventOpen ());

					Webservice.validateEventOpen data = JsonConvert.DeserializeObject<Webservice.validateEventOpen> (json_eventOpen);

					myQuizOpen = data.permission;

					if (myQuizOpen == true) {
						Console.Error.WriteLine ("bukak: " + myQuizOpen);
					} else {
						DB_access.DeleteQuiz ();
					}

				} catch {
					Toast.MakeText (this, "MyQuiz tidak dapat dimuatkan. Semak internet.", ToastLength.Short).Show ();

				}
			} else {

				try {
					QuizDB myquizDB = DB_access.getCompletionStat ("10349");
					int completionStat = myquizDB.completion_Stat;
					int drawNo = myquizDB.draw_No;

					//check if user already answer,override myQuizOpen,  let menu appear
					if(completionStat == 1)
					{
						myQuizOpen = true;
					}
					else
					{
						Toast.MakeText (this, "MyQuiz tidak dapat dimuatkan. Semak internet.", ToastLength.Short).Show ();
					}
				} catch {
					Toast.MakeText (this, "MyQuiz tidak dapat dimuatkan. Semak internet.", ToastLength.Short).Show ();

				}
			}

			new Handler ().PostDelayed (new Running(this, myQuizOpen),1000);


		}
		protected override void OnStart ()
		{
			base.OnStart ();
			//new Handler ().PostDelayed (new Running(this),1000);
			//StartActivity (typeof(InitialStartup));
		}

	}

	public class Running : Java.Lang.Object, IRunnable
	{
		Activity activity;
		bool myQuizOpen;

		public Running (Activity activity, bool myQuizOpen) {
			this.activity = activity;
			this.myQuizOpen = myQuizOpen;
		}

		public void Run() {
			Intent mainActivity = new Intent (activity, typeof(InitialStartup));
			mainActivity.PutExtra ("myQuizOpen", myQuizOpen);
			Console.WriteLine ("[Splash] Running....");
			activity.StartActivity (mainActivity);
			activity.OverridePendingTransition (0, 0);
			activity.Finish ();
		}

	}
}

