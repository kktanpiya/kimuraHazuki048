
using System;

using Foundation;
using UIKit;
using System.Drawing;

namespace PI1M_Dashboard.IOS
{
	public partial class ExMSettingsVC : UIViewController
	{
		public ExMSettingsVC () : base ("ExMSettingsVC", null)
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

			EdgesForExtendedLayout = UIRectEdge.None;

			NavigationController.NavigationBar.BarTintColor = CustomLibs.ColorFromHexString(Colors.SideMenuProfileBackgroundColor,1.0f);
			UILabel titleLabel = new UILabel (new RectangleF(0,0,50,50));
			titleLabel.TextColor = UIColor.White;
			titleLabel.Font = UIFont.BoldSystemFontOfSize (16);
			titleLabel.Text = Strings.SLMExSettingsString;
			this.NavigationItem.TitleView = titleLabel;
		}
	}
}

