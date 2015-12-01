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
	[Register ("MyKomunitiTab1Cell")]
	partial class MyKomunitiTab1Cell
	{
		[Outlet]
		UIKit.UILabel ulMKT1CContentDesc { get; set; }

		[Outlet]
		UIKit.UILabel ulMKT1CContentTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ulMKT1CContentDesc != null) {
				ulMKT1CContentDesc.Dispose ();
				ulMKT1CContentDesc = null;
			}

			if (ulMKT1CContentTitle != null) {
				ulMKT1CContentTitle.Dispose ();
				ulMKT1CContentTitle = null;
			}
		}
	}
}
