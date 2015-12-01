
using System;

using Foundation;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	public partial class MyKomunitiTab1Cell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("MyKomunitiTab1Cell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("MyKomunitiTab1Cell");

		public MyKomunitiTab1Cell (IntPtr handle) : base (handle)
		{
		}

		public static MyKomunitiTab1Cell Create ()
		{
			return (MyKomunitiTab1Cell)Nib.Instantiate (null, null) [0];
		}

		public void Update(string contentTitle, string contentDesc)
		{
			ulMKT1CContentTitle.Text = contentTitle;
			ulMKT1CContentDesc.Text = contentDesc;
			ulMKT1CContentDesc.SizeToFit ();
		}
	}
}

