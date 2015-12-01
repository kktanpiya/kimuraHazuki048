﻿using System;

using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.App;
using Android.Widget;
using Android.Util;
using Square.Picasso;
using System.Threading.Tasks;
using Android.Graphics;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{			
	public class MyVoteMAPOAdapter : RecyclerView.Adapter
	{
		public static List<dummyData> mVoteData;
		private Activity context;
		public event EventHandler<int> ItemClick;
		public int vote_value = 0;
		private MyVote_YesOrNoDialog YesOrNo;

		int totalItem;
		public MyVoteMAPOAdapter (Activity context, List<dummyData> data,int totalItem)
		{
			this.context = context;
			mVoteData = data;
			this.totalItem = totalItem;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			RecyclerView.ViewHolder vh;
	
			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyVote_ItemList, parent, false);
				vh = new MyVote_ViewHolder (itemView, OnClick);
				
				return vh;
			} else {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyVote_BottomProgressBar, parent, false);
				vh = new Const.ProgressViewHolder (itemView);

				return vh;
			}
		}

		protected class VIEW_TYPES {
			public static  int NORMAL = 0;
			public static  int FOOTER = 1;
			public static  int ENDOFLIST = 2;

		}

		public override int GetItemViewType (int position)
		{
			int type=-1;


			if (position < mVoteData.Count - 1) {
				type = 0;
			} else if (totalItem == mVoteData.Count) {
				type = 2;

			} else if (position == mVoteData.Count - 1) {
				type = 1;
			}
			return type;
		}

		private async void intialButton(ImageButton vote, ProgressBar imgVoteLoading,bool voteStat){
			
			if (voteStat == false) {
					Picasso.With (context).CancelRequest (vote);
					Picasso.With(context).Load(Resource.Drawable.undi2).Into(vote);
					vote.SetBackgroundColor (Color.Rgb (103, 155, 251));
			} else 	if (voteStat == true) {
					Picasso.With (context).CancelRequest (vote);
					Picasso.With(context).Load(Resource.Drawable.batalundi).Into(vote);
					vote.SetBackgroundColor (Color.Rgb (227, 100, 100));
			}
		}

		public  override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			if (holder.GetType () == typeof(MyVote_ViewHolder)) {
				
				var vh = holder as MyVote_ViewHolder;
				string tempURL = mVoteData [position].imageString;

				//call the local picasso function
			
				//set a tag for the button to the current clicked position
				vh.IVDetail.SetTag (Resource.Id.ivDetails, position);
				vh.IVPoster.SetTag (Resource.Id.ivPoster, position);
				vh.IVVote.SetTag (Resource.Id.ivVote, position);

				vh.PBimgVote.Visibility = ViewStates.Invisible;
				intialButton (vh.IVVote, vh.PBimgVote, mVoteData [position].voteStat); 
			
				PicassoSetImage (tempURL, vh.IVPoster, vh);

				//define a handle click
				vh.IVVote.Click += IVVote_Click;
				vh.IVDetail.Click += IVDetail_Click;
				vh.IVPoster.Click += IVPoster_Click;
				vh.TVLike.Visibility = ViewStates.Invisible;

				vh.IVDetail.Visibility = ViewStates.Invisible;
			}
		}

		public void PicassoSetImage(string url, ImageView poster, RecyclerView.ViewHolder holder)
		{
			MyVote_ViewHolder vh = holder as MyVote_ViewHolder;
		
			vh.PBimgPoster.Visibility = ViewStates.Visible;
			//Picasso handling image from api url
			Picasso.With (context)
				.Load (url)
				.Placeholder (Resource.Drawable.placeholder_poster)
				.Transform (new CropSquareTransformation())
				.Into(poster, delegate { vh.PBimgPoster.Visibility = ViewStates.Invisible; }, null);
		}
			
		public void IVVote_Click (object sender, EventArgs e)
		{
			int position = (int) (((ImageView) sender).GetTag(Resource.Id.ivVote));
			ImageButton imagebutton =  sender as ImageButton;

			YesOrNo = new MyVote_YesOrNoDialog (context, mVoteData [position].imageId, imagebutton, position);
			YesOrNo.CheckStatus ();
		}

		public void IVPoster_Click (object sender, EventArgs e)
		{
			int position = (int) (((ImageView) sender).GetTag(Resource.Id.ivPoster));

			var trans = context.FragmentManager.BeginTransaction();
			FullImageView fImage = FullImageView.newInstance(mVoteData[position].imageString);

			Log.Debug ("Poster Click", "Okay its in..");

			trans.AddToBackStack("new fragment");
			trans.Replace(Resource.Id.place_holder, fImage);
			trans.Commit();
		}
			
		public void IVDetail_Click (object sender, EventArgs e)
		{
			int position = (int) (((ImageView) sender).GetTag(Resource.Id.ivDetails));
			var imgId = mVoteData [position].imageId;
			var imgString = mVoteData [position].imageString;

			dialogShow (imgId, imgString);
		}

		public void dialogShow(string imgId, string imgString)
		{
			Android.App.FragmentTransaction transaction = context.FragmentManager.BeginTransaction();

			//instantiate a fragment
			DetailDialogFragment dialogFragment = DetailDialogFragment.newInstance (imgId, imgString);
			dialogFragment.Show (transaction, "dialog_Fragment");
		}

		public override int ItemCount
		{
			get { return mVoteData.Count; }
		}

		void OnClick (int position)
		{
			if (ItemClick != null)
				ItemClick (this, position);
		}

		public override void OnViewRecycled (Java.Lang.Object holder)
		{
			if (holder.GetType () == typeof(MyVote_ViewHolder)) {
				
				var vh = holder as MyVote_ViewHolder;

				//untuk clear balik += time mula2 declare
				vh.IVDetail.Click -= IVDetail_Click;
				vh.IVPoster.Click -= IVPoster_Click;
				vh.IVVote.Click -= IVVote_Click;

				Log.Debug ("Recycled Debug", "OnViewRecycled entered...");
				base.OnViewRecycled (holder);
			}
		}

		public class  MyvoteRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
		{
			public delegate void LoadMoreEventHandler(object sender, EventArgs e);
			public event LoadMoreEventHandler LoadMoreEvent;

			private LinearLayoutManager LayoutManager;

			public MyvoteRecyclerViewOnScrollListener (LinearLayoutManager layoutManager)
			{
				LayoutManager = layoutManager;
			}

			public override void OnScrolled (RecyclerView recyclerView, int dx, int dy)
			{
				base.OnScrolled (recyclerView, dx, dy);

				var visibleItemCount = recyclerView.ChildCount;

				var totalItemCount = recyclerView.GetAdapter().ItemCount;
				var lastVisibleItem = ((LinearLayoutManager)recyclerView.GetLayoutManager()).FindLastCompletelyVisibleItemPosition();

				if ((lastVisibleItem+1) == totalItemCount) {
					LoadMoreEvent (this, null);
				}
			}
		}


	}
		
}
