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
using Newtonsoft.Json;
using Android.Text;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "RecyclerViewAdapter")]			
	public class MyKomuniti_RecyclerViewAdapter : RecyclerView.Adapter
	{
		//public MySkool_ListDataHolder mData;
		public MyKomuniti_ListDataHolderList mData;
		Activity context;
		//for animation

		//foranimation
		public event EventHandler<int> ItemClick;
		int totalPage = 0;

		//public MySkool_RecyclerViewAdapter (Activity context, MySkool_ListDataHolder data)
		public MyKomuniti_RecyclerViewAdapter (Activity context, MyKomuniti_ListDataHolderList data, int totalPage)
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
			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyKomuniti_ViewListItem, parent, false);
			MyKomuniti_ViewHolder vh = new MyKomuniti_ViewHolder (itemView, OnClick);
			*/

			RecyclerView.ViewHolder vh;
			Console.Error.WriteLine ("viewType"+viewType);
			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyKomuniti_ViewListItem, parent, false);
				vh = new MyKomuniti_ViewHolder (itemView, OnClick);
				//return vh;
			} 
			else{
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.bottom_progressbar, parent, false);
				vh = new ProgressViewHolder (itemView);
				//return vh;
			}

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			//MyKomuniti_ViewHolder vh = holder as MyKomuniti_ViewHolder;

				/*//calculate the phone screen
				DisplayMetrics dm = new DisplayMetrics ();
				windowManager.DefaultDisplay.GetMetrics (dm);
				int width = dm.WidthPixels;
				int height = dm.HeightPixels;
				int dens = (int)dm.DensityDpi;
				double wi = (double)width / (double)dens;
				double hi = (double)height / (double)dens;
				double x = Math.Pow (wi,2);
				double y = Math.Pow (hi,2);
				double screenInches = Math.Sqrt (x + y);*/
			//vh.tvTitle.Text = mData[position].title;
			//vh.tvContent.Text = mData[position].content;


			//vh.IVLike.SetImageResource (mData[position].like);
			if (holder.GetType () == typeof(MyKomuniti_ViewHolder)) {
				MyKomuniti_ViewHolder vh = holder as MyKomuniti_ViewHolder;
				vh.tvTitle.Text = mData[position].title;
				//vh.tvContent.Text = mData[position].content;
				vh.tvDescription.Text = Html.FromHtml(mData[position].content).ToString();
				//vh.tvDescription.Text = mData[position].content.Replace("s/<(.*?)>//g","");
				vh.tvMKVLIDate.Text = mData [position].date;
				vh.tvMKVLISender.Text = mData [position].sender;
			}
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

	public class MyKomuniti_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvTitle { get; private set; }
		public TextView tvContent { get; private set; }
		public View mMainView { get; set; }
		public TextView tvDescription { get; set; }
		public TextView tvMKVLIDate { get; set; }
		public TextView tvMKVLISender { get; set; }

		public MyKomuniti_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvTitle);
			tvContent = itemView.FindViewById <TextView> (Resource.Id.tvContent);

			tvDescription = itemView.FindViewById<TextView> (Resource.Id.announceDescription);
			tvMKVLIDate = itemView.FindViewById<TextView> (Resource.Id.announceDate);
			tvMKVLISender = itemView.FindViewById<TextView> (Resource.Id.tvMKVLISender);



			itemView.Click += (sender, e) => listener (base.AdapterPosition);
		}
	}

	public class MyKomuniti_ListData
	{
		public string mTitle;
		public string mContent;
		public string mDescrip;
		public string mDate;
		public string mSender;

		public string sender
		{
			get { return mSender; }
		}

		public string date
		{
			get { return mDate; }
		}

		public string description
		{
			get { return mDescrip; }
		}

		public string title
		{
			get { return mTitle; }
		}

		public string content
		{
			get { return mContent; }
		}

	}

	public class  MyKomunitiRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
	{
		public delegate void LoadMoreEventHandler(object sender, EventArgs e);
		public event LoadMoreEventHandler LoadMoreEvent;

		private LinearLayoutManager LayoutManager;

		public MyKomunitiRecyclerViewOnScrollListener (LinearLayoutManager layoutManager)
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
			if (MyKomuniti_Tab_1.isRefreshing) {
				Console.Error.WriteLine ("masuk");
				MyKomuniti_Tab_1.worker.CancelAsync ();

				if (MyKomuniti_Tab_1.worker.CancellationPending) { 
					if (MyKomuniti_Tab_1.worker.IsBusy == true)
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

