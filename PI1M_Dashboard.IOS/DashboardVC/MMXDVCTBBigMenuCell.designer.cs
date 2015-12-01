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
	[Register ("MMXDVCTBBigMenuCell")]
	partial class MMXDVCTBBigMenuCell
	{
		[Outlet]
		UIKit.UIImageView uivTBBMCIconMenu { get; set; }

		[Outlet]
		UIKit.UILabel ulTBBMCMenuDesc { get; set; }

		[Outlet]
		UIKit.UILabel ulTBBMCMenuSubTitle { get; set; }

		[Outlet]
		UIKit.UILabel ulTBBMCMenuTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (uivTBBMCIconMenu != null) {
				uivTBBMCIconMenu.Dispose ();
				uivTBBMCIconMenu = null;
			}

			if (ulTBBMCMenuTitle != null) {
				ulTBBMCMenuTitle.Dispose ();
				ulTBBMCMenuTitle = null;
			}

			if (ulTBBMCMenuSubTitle != null) {
				ulTBBMCMenuSubTitle.Dispose ();
				ulTBBMCMenuSubTitle = null;
			}

			if (ulTBBMCMenuDesc != null) {
				ulTBBMCMenuDesc.Dispose ();
				ulTBBMCMenuDesc = null;
			}
		}
	}
}
