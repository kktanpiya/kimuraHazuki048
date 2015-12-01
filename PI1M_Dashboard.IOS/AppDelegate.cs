using Foundation;
using UIKit;
using System;
using JASidePanels;

namespace PI1M_Dashboard.IOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		private string APNSID = "";
		private string VendorID = "";

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			Version checkVersion = new Version (UIDevice.CurrentDevice.SystemVersion);
			Version setVersion8 = new Version (8, 0);

			Console.WriteLine ("[AppDelegate] IOS Version: {0}",checkVersion);

			if (checkVersion < setVersion8) {
				UIRemoteNotificationType notifyTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notifyTypes);
			} else {
				var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, new NSSet());
				UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications();
			}

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}


		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			Console.WriteLine ("[AppDelegate] Registered APNS: {0}",deviceToken.ToString());

			// code to register with your server application goes here

			NSUuid regVendor = UIDevice.CurrentDevice.IdentifierForVendor;

			Console.WriteLine ("[AppDelegate] Registered Vendor: {0}",regVendor);

			VendorID = regVendor.AsString();
			APNSID = deviceToken.ToString ().Replace ("<", "").Replace (">", "").Replace (" ", "");

			Console.WriteLine ("[AppDelegate] Registered APNS Replaced: {0}",APNSID);
			Console.WriteLine ("[AppDelegate] Registered Vendor Replaced: {0}",VendorID);

			WebServices wbs = new WebServices ();
			//var registerAPNS = wbs.setAPNSRegistration (VendorID, APNSID);

			//Console.WriteLine ("[AppDelegate] APNS Registration Status: {0}",registerAPNS);


		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			Console.WriteLine ("[AppDelegate] APNS Registration Failed: {0}",error.LocalizedDescription);
		}
	}
}


