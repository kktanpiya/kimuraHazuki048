
using System;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

using JASidePanels;

namespace PI1M_Dashboard.IOS
{
	public class MMXDVCSLMListViewSource : UITableViewSource
	{
		ObservableCollection<MainMenuListItem> MenuItems;
		string MenuType;
		UIViewController MenuViewController;
		UIStoryboard StoryboardController;

		public MMXDVCSLMListViewSource (ObservableCollection<MainMenuListItem> MenuItems, string MenuType, UIViewController MenuViewController, UIStoryboard StoryboardController)
		{
			this.MenuItems = MenuItems;
			this.MenuType = MenuType;
			this.MenuViewController = MenuViewController;
			this.StoryboardController = StoryboardController;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			// TODO: return the actual number of items in the section
			return MenuItems.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			if (MenuType == "DASHBOARD_MENU" && indexPath.Row == 0) {
				MenuViewController.GetSidePanelController ().CenterPanel = new UINavigationController (new MyKomunitiCenterVC ());
			} 
			else if (MenuType == "EXTENDED_MENU" && indexPath.Row == 0) {
				MenuViewController.GetSidePanelController ().CenterPanel = new UINavigationController (new ExMSettingsVC ());
			} else if (MenuType == "EXTENDED_MENU" && indexPath.Row == 1) {
				MenuViewController.PresentModalViewController (new UINavigationController (new ExMAboutVC ()), true);
				//MenuViewController.GetSidePanelController ().CenterPanel = new UINavigationController (new ExMAboutVC ());
			} 
			else {
				MenuViewController.GetSidePanelController ().CenterPanel = new UINavigationController (new MMXDVCTopBar ());
			}
		}
		/*
		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return "Header";
		}

		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return "Footer";
		}
		*/
		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (MMXDVCSLMCell.Key) as MMXDVCSLMCell;
			if (cell == null)
				cell = MMXDVCSLMCell.Create ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.UpdateCell(MenuItems[indexPath.Row].MenuTitleName,MenuType);

			return cell;
		}
	}

}

