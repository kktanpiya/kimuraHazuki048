
using System;

using Foundation;
using UIKit;
using System.Drawing;
using System.Collections.ObjectModel;

namespace PI1M_Dashboard.IOS
{
	public partial class MMXDVCTopBar : UIViewController
	{
		
		ObservableCollection<BigMainMenuListItem> BigMenuList;

		public MMXDVCTopBar () : base ("MMXDVCTopBar", null)
		{
			//Title = "PI1M Dashboard";

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			EdgesForExtendedLayout = UIRectEdge.None;

			//View.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleBottomMargin;
			//View.SizeThatFits ();

			NavigationController.NavigationBar.BarTintColor = CustomLibs.ColorFromHexString(Colors.DashboardNaviBarColor,1.0f);
			UILabel titleLabel = new UILabel (new RectangleF(0,0,50,50));
			titleLabel.TextColor = UIColor.White;
			titleLabel.Font = UIFont.BoldSystemFontOfSize (16);
			titleLabel.Text = Strings.SLMDashboardString;
			this.NavigationItem.TitleView = titleLabel;

			uitvTBBigMenu.Source = new MMXDVCTBListViewSource (AppMenus.BigMainMenuLists,this);
			uitvTBBigMenu.SeparatorColor = UIColor.Clear;

		}

	}
}

