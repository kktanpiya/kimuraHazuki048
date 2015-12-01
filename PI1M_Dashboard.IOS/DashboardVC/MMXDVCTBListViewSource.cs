
using System;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;
using System.Diagnostics;
using JASidePanels;

namespace PI1M_Dashboard.IOS
{
	public class MMXDVCTBListViewSource : UITableViewSource
	{
		ObservableCollection<BigMainMenuListItem> listItem;
		UIViewController TopBarViewController;

		public MMXDVCTBListViewSource (ObservableCollection<BigMainMenuListItem> listItem, UIViewController TopBarViewController)
		{
			this.listItem = listItem;
			this.TopBarViewController = TopBarViewController;
		}
			
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			// TODO: return the actual number of items in the section
			return listItem.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			TopBarViewController.GetSidePanelController().CenterPanel = new UINavigationController(new ExMSettingsVC());
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine ("[MMXDVCTBListViewSource] Screen Size Detected: {0}",CustomLibs.iOSScreenSize) ;
			Console.WriteLine ("[MMXDVCTBListViewSource] Detect Iphone: {0}",CustomLibs.iOSDeviceModel);

			if (CustomLibs.iOSDeviceModel == "I_PHONE_4_OR_LESS" || CustomLibs.iOSDeviceModel == "I_PHONE_5") 
			{
				return 105;
			} 
			else if (CustomLibs.iOSDeviceModel == "I_PHONE_6") 
			{
				return 110;
			}
			else if (CustomLibs.iOSDeviceModel == "I_PHONE_6_PLUS") 
			{
				return 120;
			}
			else
			{
				return 105;
			}

		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (MMXDVCTBBigMenuCell.Key) as MMXDVCTBBigMenuCell;
			if (cell == null)
				cell = MMXDVCTBBigMenuCell.Create ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.UpdateCell(listItem[indexPath.Row].MenuTitle,listItem[indexPath.Row].MenuSubTitle,listItem[indexPath.Row].MenuDesc);
			
			return cell;
		}
	}


}

