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
	[Register ("MyKomunitiCenterVC")]
	partial class MyKomunitiCenterVC
	{
		[Outlet]
		UIKit.UISegmentedControl uscMKCVCTabs { get; set; }

		[Outlet]
		UIKit.UITableView utvMKCVCTableViews { get; set; }

		[Outlet]
		UIKit.UIView uvMKCVCTabs { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (uvMKCVCTabs != null) {
				uvMKCVCTabs.Dispose ();
				uvMKCVCTabs = null;
			}

			if (uscMKCVCTabs != null) {
				uscMKCVCTabs.Dispose ();
				uscMKCVCTabs = null;
			}

			if (utvMKCVCTableViews != null) {
				utvMKCVCTableViews.Dispose ();
				utvMKCVCTableViews = null;
			}
		}
	}
}
