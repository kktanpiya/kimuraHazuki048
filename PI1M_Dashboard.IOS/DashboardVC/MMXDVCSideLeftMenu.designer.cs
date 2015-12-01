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
	[Register ("MMXDVCSideLeftMenu")]
	partial class MMXDVCSideLeftMenu
	{
		[Outlet]
		UIKit.UIImageView uivSLMUPic { get; set; }

		[Outlet]
		UIKit.UILabel ulSLMUName { get; set; }

		[Outlet]
		UIKit.UITableView utvSLMMenuList { get; set; }

		[Outlet]
		UIKit.UIView uvSLMExMenu { get; set; }

		[Outlet]
		UIKit.UIImageView uvSLMExMenuIcon { get; set; }

		[Outlet]
		UIKit.UIView uvSLMLogoutPart { get; set; }

		[Outlet]
		UIKit.UIView uvSLMMenuPart { get; set; }

		[Outlet]
		UIKit.UIView uvSLMProfilePart { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (uivSLMUPic != null) {
				uivSLMUPic.Dispose ();
				uivSLMUPic = null;
			}

			if (ulSLMUName != null) {
				ulSLMUName.Dispose ();
				ulSLMUName = null;
			}

			if (utvSLMMenuList != null) {
				utvSLMMenuList.Dispose ();
				utvSLMMenuList = null;
			}

			if (uvSLMLogoutPart != null) {
				uvSLMLogoutPart.Dispose ();
				uvSLMLogoutPart = null;
			}

			if (uvSLMMenuPart != null) {
				uvSLMMenuPart.Dispose ();
				uvSLMMenuPart = null;
			}

			if (uvSLMProfilePart != null) {
				uvSLMProfilePart.Dispose ();
				uvSLMProfilePart = null;
			}

			if (uvSLMExMenu != null) {
				uvSLMExMenu.Dispose ();
				uvSLMExMenu = null;
			}

			if (uvSLMExMenuIcon != null) {
				uvSLMExMenuIcon.Dispose ();
				uvSLMExMenuIcon = null;
			}
		}
	}
}
