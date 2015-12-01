
using System;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;
using JASidePanels;

namespace PI1M_Dashboard.IOS
{
	public partial class MMXDVCSideLeftMenu : UIViewController
	{
		nint menuSwitch = 1;

		public MMXDVCSideLeftMenu () : base ("MMXDVCSideLeftMenu", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			View.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleBottomMargin;
			View.SizeToFit ();

			uvSLMProfilePart.BackgroundColor = CustomLibs.ColorFromHexString (Colors.SideMenuProfileBackgroundColor,1.0f);
			uvSLMLogoutPart.BackgroundColor = CustomLibs.ColorFromHexString (Colors.SideMenuLogoutBackgroundColor, 1.0f);
			utvSLMMenuList.Source = new MMXDVCSLMListViewSource (AppMenus.LeftSideMenuList,"DASHBOARD_MENU",this,Storyboard);
			utvSLMMenuList.SeparatorColor = UIColor.Clear;

			UITapGestureRecognizer menuSwitchTapper = new UITapGestureRecognizer (() => {

				if (menuSwitch == 0) {
					
					uvSLMExMenuIcon.Image = UIImage.FromBundle ("ic_arrow_down.png");
					utvSLMMenuList.Source = new MMXDVCSLMListViewSource (AppMenus.LeftSideMenuList,"DASHBOARD_MENU",this,Storyboard);
					utvSLMMenuList.ReloadData();
					menuSwitch = 1;

				} else if (menuSwitch == 1) {
					
					uvSLMExMenuIcon.Image = UIImage.FromBundle ("ic_arrow_up.png");
					utvSLMMenuList.Source = new MMXDVCSLMListViewSource (AppMenus.LeftSideMenuExList,"EXTENDED_MENU",this,Storyboard);
					utvSLMMenuList.ReloadData();
					menuSwitch = 0;

				}

			});

			uvSLMExMenu.AddGestureRecognizer (menuSwitchTapper);


			UITapGestureRecognizer loggedOutTapper = new UITapGestureRecognizer (() => {

				this.DismissViewController(true,null);
				this.GetSidePanelController().CenterPanel = new UINavigationController(new MMXDVCTopBar());

			}) ;

			uvSLMLogoutPart.AddGestureRecognizer (loggedOutTapper);

		}
	}
}

