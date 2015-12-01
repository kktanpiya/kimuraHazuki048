using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Animation;
using Android.Views.Animations;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "RecyclerViewAdapter")]			
	public class MySoal_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MySoal_PetiMasuk_ListDataHolderList mData;
		Activity context;
		//for animation

		//foranimation
		public event EventHandler<int> ItemClick;
		int totalPage = 0;

		public MySoal_RecyclerViewAdapter (Activity context, MySoal_PetiMasuk_ListDataHolderList data, int totalPage)
		{
			this.context = context;
			mData = data;
			this.totalPage = totalPage;
		}

		protected class VIEW_TYPES {
			public static  int NORMAL = 0;
			public static  int FOOTER = 1;
			public static  int ENDOFLIST = 2;

		}

		public override int GetItemViewType (int position)
		{
			int type=-1;

			if (position < mData.DataNum - 1) {
				type = 0;
			} else if (totalPage == mData.DataNum) {
				type = 2;

			} else if (position == mData.DataNum - 1) {
				type = 1;
			}
			return type;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			/*
			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MySoal_ViewListItem, parent, false);
			MySoal_PetiMasuk_ViewHolder vh = new MySoal_PetiMasuk_ViewHolder (itemView, OnClick);
			*/
			RecyclerView.ViewHolder vh;
			Console.Error.WriteLine ("viewType"+viewType);
			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MySoal_ViewListItem, parent, false);
				vh = new MySoal_PetiMasuk_ViewHolder (itemView, OnClick);
				return vh;
			} 
			else{
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.bottom_progressbar, parent, false);
				vh = new ProgressViewHolder (itemView);
				return vh;
			}

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			
			if (holder.GetType () == typeof(MySoal_PetiMasuk_ViewHolder)) {
				MySoal_PetiMasuk_ViewHolder vh = holder as MySoal_PetiMasuk_ViewHolder;
				vh.tvTitle.Text = mData [position].title;
				vh.tvContent.Text = mData [position].content;
			}



		//vh.IVLike.SetImageResource (mData[position].like);
		}


		public override int ItemCount{
			get { return mData.DataNum; }
		}

		void OnClick (int position)
		{
			if (ItemClick != null)
				ItemClick (this, position);
		}
		
	}

	public class MySoal_PetiMasuk_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvTitle { get; private set; }
		public TextView tvContent { get; private set;}
		public View mMainView { get; set; }
		public MySoal_PetiMasuk_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvTitle);
			tvContent = itemView.FindViewById <TextView> (Resource.Id.tvContent);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MySoal_PetiMasuk_ListData
	{
		public string mTitle;
		public string mContent;

		public string title
		{
			get { return mTitle; }
		}

		public string content
		{
			get { return mContent; }
		}

	}

	public class  MySoalRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
	{
		public delegate void LoadMoreEventHandler(object sender, EventArgs e);
		public event LoadMoreEventHandler LoadMoreEvent;

		private LinearLayoutManager LayoutManager;

		public MySoalRecyclerViewOnScrollListener (LinearLayoutManager layoutManager)
		{
			LayoutManager = layoutManager;
		}

		public static bool testvar=false;
		public override void OnScrolled (RecyclerView recyclerView, int dx, int dy)
		{

			base.OnScrolled (recyclerView, dx, dy);

			var visibleItemCount = recyclerView.ChildCount;
			//			Console.Error.WriteLine ("isRefeshing"+MySoal_Tab_1.isRefeshing);
			//
			if (MySoal_Tab_1.isRefreshing) {
				Console.Error.WriteLine ("masuk");
				MySoal_Tab_1.worker.CancelAsync ();

				if (MySoal_Tab_1.worker.CancellationPending) { 
					if (MySoal_Tab_1.worker.IsBusy == true)
					{

					}				
				}			
			}

			var totalItemCount = recyclerView.GetAdapter().ItemCount;
			var lastVisibleItem = ((LinearLayoutManager)recyclerView.GetLayoutManager()).FindLastCompletelyVisibleItemPosition();

			if ((lastVisibleItem+1) == totalItemCount) {
				Console.Error.WriteLine ("scrolll222");

				LoadMoreEvent (this, null);
			}
		}
	}
		
}

