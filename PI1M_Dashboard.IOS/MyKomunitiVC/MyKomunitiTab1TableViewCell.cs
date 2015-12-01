
using System;

using Foundation;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	public class MyKomunitiTab1TableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MyKomunitiTab1TableViewCell");

		public MyKomunitiTab1TableViewCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

