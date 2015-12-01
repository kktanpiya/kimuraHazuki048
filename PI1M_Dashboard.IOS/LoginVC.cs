
using System;

using Foundation;
using UIKit;
using System.Drawing;
using PI1M_Dashboard;
using System.Diagnostics;

namespace PI1M_Dashboard.IOS
{
	public partial class LoginVC : UIViewController
	{
		public LoginVC (IntPtr handle) : base (handle)
		{
		}

		NSObject keyboardWillShowObserver;
		NSObject keyboardWillHideObserver;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
			UnregisterObserverKeyboardNotifications ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			//Console.WriteLine ("[LoginVC] Keyboard Showing Up");
			Debug.WriteLine ("[LoginVC] Keyboard Showing Up");

			NSUuid regVendor = UIDevice.CurrentDevice.IdentifierForVendor;
			string VendorID = regVendor.AsString();

			Console.WriteLine ("[LoginVC] Regvendor: {0}",VendorID);

			uitfUsername.ShouldReturn += (textField) => {
				uitfPass.BecomeFirstResponder();
				return true;
			};

			uitfPass.ShouldReturn += (textField) => {
				textField.ResignFirstResponder();
				return true;
			};

			uibLoginBtn.TouchUpInside += (object sender, EventArgs e) => {

				Console.WriteLine ("[LoginVC] CheckLogin");

				uitfUsername.ResignFirstResponder();
				uitfPass.ResignFirstResponder();

				if(uitfUsername.Text != "")
				{
					if(uitfPass.Text != "")
					{
						loginFormView.Hidden = true;
						vLoginIndicator.Hidden = false;
						uiaivLoadIndicator.StartAnimating();
						ProcessLogin(uitfUsername.Text,uitfPass.Text,VendorID);
					}
					else
					{
						UIAlertView alertFillUp = new UIAlertView ("Maklumat tidak lengkap",
							"Sila isi kata laluan anda.", null, "OK");
						alertFillUp.Show();
					}
				}
				else
				{
					UIAlertView alertFillUp = new UIAlertView ("Maklumat tidak lengkap",
						"Sila isi nama pengguna anda.", null, "OK");
					alertFillUp.Show();
				}
					


			};

			RegisterObserverKeyboardNotifications ();

			//UIAlertView alertView = new UIAlertView ("", "", null, "", null);

			//alertView.Show ();
		}
			
		private void ProcessLogin(string username, string password, string vendorID)
		{
			Debug.WriteLine ("[LoginVC] Logging In...");
			WebServices wbs = new WebServices ();
			//wbs.getLoginData (username, password, "", vendorID, "ios");
			loginFormView.Hidden = false;
			vLoginIndicator.Hidden = true;
			uiaivLoadIndicator.StopAnimating();
			MainMenuXDVC mmNonDrawerVC = (MainMenuXDVC)Storyboard.InstantiateViewController("mainmenuxdvcontroller");
			PresentViewController (mmNonDrawerVC, true, null);

		}

		protected virtual void RegisterObserverKeyboardNotifications ()
		{
			keyboardWillShowObserver = NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillShowNotification,KeyboardWillShowNotification);
			keyboardWillHideObserver = NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillHideNotification,KeyboardWillHideNotification);
		}

		protected virtual void UnregisterObserverKeyboardNotifications ()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver (keyboardWillShowObserver);
			NSNotificationCenter.DefaultCenter.RemoveObserver (keyboardWillHideObserver);
		}

		protected virtual void KeyboardWillShowNotification(NSNotification notification)
		{
			Console.WriteLine ("[LoginVC] Keyboard Showing Up");

			//[UIView beginAnimations:nil context:NULL];
			//[UIView setAnimationBeginsFromCurrentState:YES];
			//[UIView setAnimationDuration:0.5];      
			//yourView.frame = CGRectMake(yourView.frame.origin.x, yourView.frame.origin.y-100, yourView.frame.size.width, yourView.frame.size.height);

			//[UIView commitAnimations];

		
			CoreGraphics.CGRect layoutChanges = new CoreGraphics.CGRect (
				this.View.Bounds.X,
				-200,
				this.View.Bounds.Width,
				this.View.Bounds.Height);

			UIView.BeginAnimations(null,IntPtr.Zero);
			UIView.SetAnimationBeginsFromCurrentState (true);
			UIView.SetAnimationDuration (0.2);
			this.View.Frame = layoutChanges;

			UIView.CommitAnimations ();

		}

		protected virtual void KeyboardWillHideNotification(NSNotification notification)
		{
			Console.WriteLine ("[LoginVC] Keyboard Closed");

			CoreGraphics.CGRect layoutChanges = new CoreGraphics.CGRect (
				this.View.Bounds.X,
				0,
				this.View.Bounds.Width,
				this.View.Bounds.Height);

			UIView.BeginAnimations(null,IntPtr.Zero);
			UIView.SetAnimationBeginsFromCurrentState (true);
			UIView.SetAnimationDuration (0.2);
			this.View.Frame = layoutChanges;

			UIView.CommitAnimations ();
		}
	}
}

