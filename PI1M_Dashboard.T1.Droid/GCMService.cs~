using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.Util;
using Gcm.Client;
using Android.Media;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.OS;

namespace PI1M_Dashboard.T1.Droid
{
	//You must subclass this!
	[BroadcastReceiver(Permission=Constants.PERMISSION_GCM_INTENTS)]
	[IntentFilter(new string[] { Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "@PACKAGE_NAME@" })]
	[IntentFilter(new string[] { Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "@PACKAGE_NAME@" })]
	[IntentFilter(new string[] { Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "@PACKAGE_NAME@" })]
	public class GcmBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
	{
		//IMPORTANT: Change this to your own Sender ID!
		//The SENDER_ID is your Google API Console App Project ID.
		//  Be sure to get the right Project ID from your Google APIs Console.  It's not the named project ID that appears in the Overview,
		//  but instead the numeric project id in the url: eg: https://code.google.com/apis/console/?pli=1#project:785671162406:overview
		//  where 785671162406 is the project id, which is the SENDER_ID to use!
		public static string[] SENDER_IDS = new string[] {"804617856400"};

		public const string TAG = "ingeniworks@gmail.com";
	}

	[Service] //Must use the service tag
	public class PushHandlerService : GcmServiceBase
	{
		public PushHandlerService() : base(GcmBroadcastReceiver.SENDER_IDS) { }

		const string TAG = "ingeniworks@gmail.com";

		int notificationID = 0;

		protected override void OnRegistered (Context context, string registrationId)
		{
			Log.Verbose(TAG, "GCM Registered: " + registrationId);
			//Eg: Send back to the server
			//	var result = wc.UploadString("http://your.server.com/api/register/", "POST", 
			//		"{ 'registrationId' : '" + registrationId + "' }");

			//createNotification("GCM Registered...", "The device has been Registered, Tap to View!");
		}

		protected override void OnUnRegistered (Context context, string registrationId)
		{
			Log.Verbose(TAG, "GCM Unregistered: " + registrationId);
			//Remove from the web service
			//	var wc = new WebClient();
			//	var result = wc.UploadString("http://your.server.com/api/unregister/", "POST",
			//		"{ 'registrationId' : '" + lastRegistrationId + "' }");

			//createNotification("GCM Unregistered...", "The device has been unregistered, Tap to View!");
		}

		protected override void OnMessage (Context context, Intent intent)
		{
			Log.Info(TAG, "GCM Message Received!");

			var msg = new StringBuilder();
			string gcmFrom = "";
			string gcmMessage = "";
			string gcmAppName = "";

			List<GCMMessageItems> items = new List<GCMMessageItems> ();

			if (intent != null && intent.Extras != null)
			{
				foreach (var key in intent.Extras.KeySet()) {

					Console.WriteLine ("Deserialized data: {0}",key);

					if (key == "from") {
						gcmFrom = intent.Extras.Get (key).ToString ();
					}

					if (key == "message") {
						gcmMessage = intent.Extras.Get (key).ToString ();
					}

					if (key == "appName") {
						gcmAppName = intent.Extras.Get (key).ToString ();
					}
					msg.AppendLine (key + "=" + intent.Extras.Get (key).ToString ());
				}

				Console.WriteLine ("Deserialized data GCM Message: {0}",gcmAppName);

				//var deserialized = JsonConvert.DeserializeObject<GCMMessageItems> (gcmMessage);

				createNotificationSE ("PI1M Dashboard",
					gcmAppName,
					gcmMessage);

				/*
				foreach (var key in intent.Extras.KeySet()) {
					var deserialized = JsonConvert.DeserializeObject<GCMMessageItems> (key);
					gcmFrom = deserialized.title;
					//if (key == "launchImage") {
					//	gcmFrom = intent.Extras.Get (key).ToString ();
					//}
					//if (key == "message") {
					//	gcmMessage = intent.Extras.Get (key).ToString ();
					//}
					//msg.AppendLine (key + "=" + intent.Extras.Get (key).ToString ());
				}
				*/
			}

			//Store the message
			var prefs = GetSharedPreferences(context.PackageName, FileCreationMode.Private);
			var edit = prefs.Edit();
			edit.PutString("last_msg", msg.ToString());
			edit.Commit();

			//createNotification(gcmFrom,gcmMessage);
			//createNotificationSE ("Dato' Shahaniza","Sadiy Kuat Berak",gcmFrom);
		}

		protected override bool OnRecoverableError (Context context, string errorId)
		{
			Log.Warn(TAG, "Recoverable Error: " + errorId);

			return base.OnRecoverableError (context, errorId);
		}

		protected override void OnError (Context context, string errorId)
		{
			Log.Error(TAG, "GCM Error: " + errorId);
		}

		void createNotification(string title, string desc)
		{
			//Create notification
			var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

			//Create an intent to show ui
			var uiIntent = new Intent(this, typeof(MainActivity));

			//Create the notification
			var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title);

			//Auto cancel will remove the notification once the user touches it
			notification.Flags = NotificationFlags.AutoCancel;

			//Set the notification info
			//we use the pending intent, passing our ui intent over which will get called
			//when the notification is tapped.
			notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

			//Show the notification
			notificationManager.Notify(1, notification);
		}

		void createNotificationSE(string tickerTitle, string contentTitle, string contentText)
		{
			//Create notification
			NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);

			//Create an intent to show ui
			//var uiIntent = new Intent(this, typeof(Activity1));

			//Create the notification
			//var notification = new Notification(Resource.Drawable.ic_icon, title);

			Intent notificationIntent = new Intent (this, typeof(InitialStartup));
			notificationIntent.PutExtra ("GCMModuleNotified", contentTitle);


			PendingIntent pIntent = PendingIntent.GetActivity (this, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);


			Notification.Builder builder = new Notification.Builder (this);

			Notification notifycation = builder
				.SetContentIntent (pIntent)
				.SetTicker (tickerTitle)
				.SetContentTitle (contentTitle)
				.SetContentText (contentText)
				.SetSmallIcon (Resource.Drawable.ic_notification_20px)
				//.SetLargeIcon(Resource.Drawable.ic_notification_38px)
				.Build();
			notifycation.Flags = NotificationFlags.AutoCancel;

			//Auto cancel will remove the notification once the user touches it
			//notification.Flags = NotificationFlags.AutoCancel;

			//Set the notification info
			//we use the pending intent, passing our ui intent over which will get called
			//when the notification is tapped.
			//notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

			//Show the notification
			notificationManager.Notify(notificationID, notifycation);

			//AudioManager audMan = (AudioManager)GetSystemService (Context.AudioService);
			//audMan.SetStreamVolume (AudioManager., Volume.Max, 50);

			Android.Net.Uri notify = RingtoneManager.GetDefaultUri (RingtoneType.Notification);
			Ringtone rt = RingtoneManager.GetRingtone (ApplicationContext, notify);

			//Context context2 = this.ApplicationContext;
			Vibrator vibrator = (Vibrator)ApplicationContext.GetSystemService (Context.VibratorService);
			long[] vibrationpattern = { 0, 2000, 1000 };

			rt.Play ();
			vibrator.Vibrate (vibrationpattern, -1);

			notificationID++;

			//MediaPlayer mplayer = MediaPlayer.Create (Context, notify);
			//mplayer.Start ();

		}
	}

	public class GCMMessageItems
	{
		public string title { get; set; }
		public string image { get; set; }
	}
}

