using System;
using System.Collections.Generic;
using MyVote;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;

namespace MyVote
{
	public class Const
	{
		public static string tokenData ="";
		public static string siteID ="";

		public class ProgressViewHolder : RecyclerView.ViewHolder
		{
			public ProgressBar progressBar { get; private set; }

			public ProgressViewHolder (View itemView) : base(itemView)
			{
				progressBar = itemView.FindViewById <ProgressBar> (PI1M_Dashboard.T1.Droid.Resource.Id.progress_bar);

			}
		}
	}
}

