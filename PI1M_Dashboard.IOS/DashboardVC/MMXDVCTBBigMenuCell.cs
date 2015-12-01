
using System;

using Foundation;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	public partial class MMXDVCTBBigMenuCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("MMXDVCTBBigMenuCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("MMXDVCTBBigMenuCell");

		public MMXDVCTBBigMenuCell (IntPtr handle) : base (handle)
		{
		}

		public static MMXDVCTBBigMenuCell Create ()
		{
			return (MMXDVCTBBigMenuCell)Nib.Instantiate (null, null) [0];
		}

		public void UpdateCell(string titleString, string subTitleString, string descString)
		{
			if (titleString.ToLower () == "my komuniti") {
				uivTBBMCIconMenu.Image = UIImage.FromBundle ("ic_mykomuniti.png");
			} else if (titleString.ToLower () == "my soal") {
				uivTBBMCIconMenu.Image = UIImage.FromBundle ("ic_mysoal.png");
			} else if (titleString.ToLower () == "my health") {
				uivTBBMCIconMenu.Image = UIImage.FromBundle ("ic_myhealth.png");
			} else if (titleString.ToLower () == "my skool") {
				uivTBBMCIconMenu.Image = UIImage.FromBundle ("ic_myskool.png");
			} else if (titleString.ToLower () == "my shop") {
				uivTBBMCIconMenu.Image = UIImage.FromBundle ("ic_myshop_front.png");
			}
			ulTBBMCMenuTitle.Text = titleString;
			ulTBBMCMenuSubTitle.Text = subTitleString;
			ulTBBMCMenuDesc.Text = descString;
		}

	}
		
}

