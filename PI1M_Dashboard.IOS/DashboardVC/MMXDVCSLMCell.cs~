
using System;
using System.Globalization;

using Foundation;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	public partial class MMXDVCSLMCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("MMXDVCSLMCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("MMXDVCSLMCell");

		public MMXDVCSLMCell (IntPtr handle) : base (handle)
		{
		}

		public static MMXDVCSLMCell Create ()
		{
			return (MMXDVCSLMCell)Nib.Instantiate (null, null) [0];
		}

		public void UpdateCell (string titleString, string menuType)
		{
			if (menuType == "DASHBOARD_MENU") {
				if (titleString == Strings.SLMDashboardString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("home3.png");
				} else if (titleString == Strings.SLMMyKomunitiString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("people2.png");
				} else if (titleString == Strings.SLMMySoalString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("cup2.png");
				} else if (titleString == Strings.SLMMyHealthString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("heart2.png");
				} else if (titleString == Strings.SLMMySkoolString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("shield2.png");
				} else if (titleString == Strings.SLMMyShopString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("cart2.png");
				}
			} else if (menuType == "EXTENDED_MENU") {
				if (titleString == Strings.SLMExSettingsString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("ic_gear_grey.png");
				} else if (titleString == Strings.SLMExAboutString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("ic_about_48dp.png");
				} else if (titleString == Strings.SLMExCommentString) {
					uivSLMCMenuIcon.Image = UIImage.FromBundle ("ic_review_48dp.png");
				}
			}
			ulSLMCMenuTitle.Text = titleString;
		}
	}
}

