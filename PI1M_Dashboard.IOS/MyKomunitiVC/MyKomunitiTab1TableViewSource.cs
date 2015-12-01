
using System;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace PI1M_Dashboard.IOS
{
	public class MyKomunitiTab1TableViewSource : UITableViewSource
	{
		
		ObservableCollection<MyKomunitiAccessors> tableItems;

		public MyKomunitiTab1TableViewSource (ObservableCollection<MyKomunitiAccessors> tableItems)
		{
			this.tableItems = tableItems;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			// TODO: return the actual number of items in the section
			return tableItems.Count;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 145;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (MyKomunitiTab1Cell.Key) as MyKomunitiTab1Cell;
			if (cell == null)
				cell = MyKomunitiTab1Cell.Create();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.Update(tableItems[indexPath.Row].ContentTitle,tableItems[indexPath.Row].ContentDesc);
			
			return cell;
		}
	}
}

