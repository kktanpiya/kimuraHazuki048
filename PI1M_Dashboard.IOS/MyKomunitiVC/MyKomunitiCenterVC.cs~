
using System;

using Foundation;
using UIKit;
using System.Drawing;
using System.Collections.ObjectModel;

namespace PI1M_Dashboard.IOS
{
	public partial class MyKomunitiCenterVC : UIViewController
	{
		ObservableCollection<MyKomunitiAccessors> tableItem = new ObservableCollection<MyKomunitiAccessors>();
		public MyKomunitiCenterVC () : base ("MyKomunitiCenterVC", null)
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

			NavigationController.NavigationBar.BarTintColor = CustomLibs.ColorFromHexString(Colors.MyKomunitiNaviBarColor,1.0f);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UILabel titleLabel = new UILabel (new RectangleF(0,0,50,50));
			titleLabel.TextColor = UIColor.White;
			titleLabel.Font = UIFont.BoldSystemFontOfSize (16);
			titleLabel.Text = Strings.SLMMyKomunitiString;
			this.NavigationItem.TitleView = titleLabel;

			uvMKCVCTabs.BackgroundColor = CustomLibs.ColorFromHexString (Colors.MyKomunitiNaviBarColor);

			//SegmentedTabs
			uscMKCVCTabs.SetTitle(Strings.MyKomunitiFirstTabLabel,0);
			uscMKCVCTabs.SetTitle(Strings.MyKomunitiSecondTabLabel,1);
			tableItem.Add (new MyKomunitiAccessors() { 
				ContentTitle = "Yasser makan kuat", 
				ContentDesc = "Yasser memang suka makan kuat. Hari-hari dia makan kuat. Dia suka pergi belanga. Makanan kegemaran dia adalah nasi berlaukkan ayam goreng."}
			);
			tableItem.Add (new MyKomunitiAccessors() { 
				ContentTitle = "Adlil makan kuat", 
				ContentDesc = "Adlil memang suka makan kuat. Hari-hari dia makan kuat. Dia suka pergi belanga. Makanan kegemaran dia adalah nasi berlaukkan ayam goreng."}
			);
			tableItem.Add (new MyKomunitiAccessors() { 
				ContentTitle = "Aidil makan kuat", 
				ContentDesc = "Aidil memang suka makan kuat. Hari-hari dia makan kuat. Dia suka pergi belanga. Makanan kegemaran dia adalah nasi berlaukkan ayam goreng."}
			);
			utvMKCVCTableViews.Source = new MyKomunitiTab1TableViewSource (tableItem);
		}
	}
}

