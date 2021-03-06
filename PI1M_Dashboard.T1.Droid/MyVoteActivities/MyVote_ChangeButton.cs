﻿
using System;

using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;
using Square.Picasso;
using Android.App;
using System.Threading;
using Android.OS;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{		
	public class MyVote_ChangeButton
	{
		private readonly ImageView imageView;
		private readonly string imageID;
		Activity context;
		int position;

		public MyVote_ChangeButton(Activity context, string imgId, ImageView imgView,int position)
		{
			this.context = context;
			imageID = imgId;
			imageView = imgView;
			this.position = position;
		}

		public async void CallChangeButton()
		{
			//check like status
			var checkStatus = await Task.Factory.StartNew(() => MyVote_Webservices.GetCheckLikeStatus(imageID));
			if (checkStatus == "false") 
			{
				Picasso.With(context).Load(Resource.Drawable.undi2).Into(imageView);
				MyVoteMAPOAdapter.mVoteData [position].voteStat = false;
				imageView.SetBackgroundColor (Color.Rgb (103, 155, 251));
				Console.Error.WriteLine ("ImageID Changed color to blue{0}",imageID);
				Toast.MakeText (context, "Undi anda telah berjaya dibatalkan.", ToastLength.Short).Show ();

			} else if(checkStatus == "true") 
			{
				Picasso.With(context).Load(Resource.Drawable.batalundi).Into(imageView);
				MyVoteMAPOAdapter.mVoteData [position].voteStat = true;
				imageView.SetBackgroundColor (Color.Rgb (227, 100, 100));
				Console.Error.WriteLine ("ImageID Changed color to red{0}",imageID);
				Toast.MakeText (context, "Terima kasih.Undian anda telah diterima.", ToastLength.Short).Show ();

			}
		}
	}
}

