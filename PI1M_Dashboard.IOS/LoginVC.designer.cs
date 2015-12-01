// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	[Register ("LoginVC")]
	partial class LoginVC
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView loginFormView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView uiaivLoadIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton uibLoginBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField uitfPass { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField uitfUsername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView vLoginIndicator { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (loginFormView != null) {
				loginFormView.Dispose ();
				loginFormView = null;
			}
			if (uiaivLoadIndicator != null) {
				uiaivLoadIndicator.Dispose ();
				uiaivLoadIndicator = null;
			}
			if (uibLoginBtn != null) {
				uibLoginBtn.Dispose ();
				uibLoginBtn = null;
			}
			if (uitfPass != null) {
				uitfPass.Dispose ();
				uitfPass = null;
			}
			if (uitfUsername != null) {
				uitfUsername.Dispose ();
				uitfUsername = null;
			}
			if (vLoginIndicator != null) {
				vLoginIndicator.Dispose ();
				vLoginIndicator = null;
			}
		}
	}
}
