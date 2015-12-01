
using System;

using Android.App;
using Android.Content;
using Android.Util;
using System.Threading.Tasks;
using Android.Widget;
using Square.Picasso;
using Android.Graphics;

namespace MyVote
{		
	public class MyVote_YesOrNoDialog
	{
		readonly Activity context;
		readonly string imageId;
		ImageView imageView;
		MyVote_ChangeButton changeButton;
		bool voteStat;
		int position;

		public MyVote_YesOrNoDialog(Activity context, string imgId, ImageView imgView,int position)
		{
			this.context = context;
			imageId = imgId;
			imageView = imgView;
			this.position = position;
		}

		public async void CheckStatus()
		{

			changeButton = new MyVote_ChangeButton (context, imageId, imageView, position);
			var checkStatus = await Task.Factory.StartNew (() => MyVote_Webservices.GetCheckLikeStatus (imageId));

			if (checkStatus == "false") {
				VoteDialog ();
			} else {
				UnvoteDialog ();
			}
		}
		//keluar bila poster tk kena vote lagi
		public void VoteDialog()
		{
			var builder = new AlertDialog.Builder (context);
			builder.SetMessage ("Anda pasti ingin teruskan undi?");
			builder.SetPositiveButton ("Yes", LikeOkClicked);
			builder.SetNegativeButton ("No", (s, e) => Log.Debug ("Vote Cancel", "You have cancel your vote"));
			builder.Create ().Show ();
		}
		//keluar bila poster da kena vote
		public void UnvoteDialog()
		{
			var builder = new AlertDialog.Builder (context);
			builder.SetMessage ("Batalkan undi?");
			builder.SetPositiveButton ("Yes", UnlikeOkClicked);
			builder.SetNegativeButton ("No", (s, e) => Log.Debug ("Vote Cancel", "You have cancel your vote"));
			builder.Create ().Show ();
		}

		//confirm the like clicked
		private void LikeOkClicked(object sender, DialogClickEventArgs args)
		{
			var like = MyVote_Webservices.GetLikeStatus (imageId);
			Log.Debug ("Vote status", like);
			changeButton.CallChangeButton ();
		}
		//confirm the unlike clicked
		private void UnlikeOkClicked (object sender, DialogClickEventArgs args)
		{
			var unlike = MyVote_Webservices.GetUnlikeStatus(imageId);
			Log.Debug ("Vote status", unlike);
			changeButton.CallChangeButton ();
		}

	}
}

