using Android.Widget;
using Android.Support.V7.Widget;
using System;
using Android.Views;
using PI1M_Dashboard.T1.Droid;
using System.Collections.Generic;

namespace MyVote
{
	public class MyVote_ViewHolder : RecyclerView.ViewHolder
	{
		public ImageView IVPoster { get; set; }
		public TextView TVLike { get; set; }
		public ImageView IVDetail { get; set; }
		public ImageButton IVVote { get; set; }
		public ProgressBar PBimgVote { get; set; }
		public ProgressBar PBimgPoster { get; set; }

		public MyVote_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			IVPoster = itemView.FindViewById <ImageView>(Resource.Id.ivPoster);
			TVLike = itemView.FindViewById <TextView>(Resource.Id.tvLike);
			IVDetail = itemView.FindViewById <ImageView> (Resource.Id.ivDetails);
			IVVote = itemView.FindViewById <ImageButton> (Resource.Id.ivVote);
			PBimgVote = itemView.FindViewById <ProgressBar> (Resource.Id.PBLoadingImage);
			PBimgPoster = itemView.FindViewById <ProgressBar> (Resource.Id.PBLoadingPoster);

			IVPoster.Click += (sender, e) => listener (base.Position);
		}
	}
}

