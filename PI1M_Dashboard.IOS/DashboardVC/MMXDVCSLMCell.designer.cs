// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PI1M_Dashboard.IOS
{
	[Register ("MMXDVCSLMCell")]
	partial class MMXDVCSLMCell
	{
		[Outlet]
		UIKit.UIImageView uivSLMCMenuIcon { get; set; }

		[Outlet]
		UIKit.UILabel ulSLMCMenuTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ulSLMCMenuTitle != null) {
				ulSLMCMenuTitle.Dispose ();
				ulSLMCMenuTitle = null;
			}

			if (uivSLMCMenuIcon != null) {
				uivSLMCMenuIcon.Dispose ();
				uivSLMCMenuIcon = null;
			}
		}
	}
}
