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
	[Register ("MMXDVCTopBar")]
	partial class MMXDVCTopBar
	{
		[Outlet]
		UIKit.UITableView uitvTBBigMenu { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (uitvTBBigMenu != null) {
				uitvTBBigMenu.Dispose ();
				uitvTBBigMenu = null;
			}
		}
	}
}
