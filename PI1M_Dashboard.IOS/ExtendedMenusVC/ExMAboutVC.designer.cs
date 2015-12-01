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
	[Register ("ExMAboutVC")]
	partial class ExMAboutVC
	{
		[Outlet]
		UIKit.UIButton ubAVCOKBtn { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCAppTitle { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCBuildNo { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCCopy { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCSurfTo { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCVersion { get; set; }

		[Outlet]
		UIKit.UILabel ulAVCWebsiteTo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ulAVCAppTitle != null) {
				ulAVCAppTitle.Dispose ();
				ulAVCAppTitle = null;
			}

			if (ulAVCVersion != null) {
				ulAVCVersion.Dispose ();
				ulAVCVersion = null;
			}

			if (ulAVCBuildNo != null) {
				ulAVCBuildNo.Dispose ();
				ulAVCBuildNo = null;
			}

			if (ulAVCCopy != null) {
				ulAVCCopy.Dispose ();
				ulAVCCopy = null;
			}

			if (ulAVCSurfTo != null) {
				ulAVCSurfTo.Dispose ();
				ulAVCSurfTo = null;
			}

			if (ulAVCWebsiteTo != null) {
				ulAVCWebsiteTo.Dispose ();
				ulAVCWebsiteTo = null;
			}

			if (ubAVCOKBtn != null) {
				ubAVCOKBtn.Dispose ();
				ubAVCOKBtn = null;
			}
		}
	}
}
