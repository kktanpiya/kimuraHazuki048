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
using Android.Graphics;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "RecyclerViewAdapter")]			
	public class MyHealth_BodyWeight_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MyHealth_BodyWeight_ListDataHolderList mData;
		Activity context;
	//for animation

	//foranimation
		public event EventHandler<int> ItemClick;

		int totalPage=0;
		public MyHealth_BodyWeight_RecyclerViewAdapter (Activity context, MyHealth_BodyWeight_ListDataHolderList data, int totalPage)
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
			RecyclerView.ViewHolder vh;

			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyHealth_ViewListItem, parent, false);
				vh = new MyHealth_BodyWeight_ViewHolder (itemView, OnClick);
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
			if (holder.GetType () == typeof(MyHealth_BodyWeight_ViewHolder)) {
				MyHealth_BodyWeight_ViewHolder vh = holder as MyHealth_BodyWeight_ViewHolder;
				vh.tvMHBWCLIDateTime.Text = mData [position].mDateTime;
				vh.tvMHBWCLIWeight.Text = mData [position].mWeight;
				vh.tvMHBWCLINettWeight.Text = mData [position].mNettWeight;
				vh.tvMHBWCLIBMI.Text = mData [position].mBMI;
				vh.tvMHBWCLIBoneMass.Text = mData [position].mBoneMass;
				vh.tvMHBWCLIFat.Text = mData [position].mFat;
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

	public class MyHealth_BodyWeight_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvMHBWCLIDateTime { get; private set; }
		public TextView tvMHBWCLIWeight { get; private set; }
		public TextView tvMHBWCLINettWeight { get; private set; }
		public TextView tvMHBWCLIBMI { get; private set; } 
		public TextView tvMHBWCLIBoneMass { get; private set; }
		public TextView tvMHBWCLIFat { get; private set; }
		public View mMainView { get; set; }

		public MyHealth_BodyWeight_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvMHBWCLIDateTime = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLIDateTime);
			tvMHBWCLIWeight = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLIWeight);
			tvMHBWCLINettWeight = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLINettWeight);
			tvMHBWCLIBMI = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLIBMI);
			tvMHBWCLIBoneMass = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLIBoneMass);
			tvMHBWCLIFat = itemView.FindViewById <TextView> (Resource.Id.tvMHBWCLIFat);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MyHealth_BodyWeight_ListData
	{
		public string mDateTime;
		public string mWeight;
		public string mNettWeight;
		public string mBMI;
		public string mBoneMass;
		public string mFat;

		public string dateTime { get { return mDateTime; } }
		public string weight { get { return mWeight; } }
		public string nettWeight { get { return mNettWeight; } }
		public string BMI { get { return mBMI; } }
		public string BoneMass { get { return mBoneMass; } }
		public string Fat { get { return mFat; } }
	}

	public class MyHealth_BodyWeight_ListDataHolder
	{
		MyHealth_BodyWeight_ListData[] listData = { 
			new MyHealth_BodyWeight_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mWeight = "78.4kg",
				mNettWeight = "63.19",
				mBMI = "25.9",
				mBoneMass = "3.1",
				mFat = "19.4%"
			},
			new MyHealth_BodyWeight_ListData { 
				mDateTime = "2014-10-19 09:40:12", 
				mWeight = "80.6kg",
				mNettWeight = "59",
				mBMI = "26.62",
				mBoneMass = "2.9",
				mFat = "26.8%"
			},
			new MyHealth_BodyWeight_ListData { 
				mDateTime = "2015-03-09 19:31:23", 
				mWeight = "78.4kg",
				mNettWeight = "63.19",
				mBMI = "25.9",
				mBoneMass = "3.9",
				mFat = "19.4%"
			},
			new MyHealth_BodyWeight_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mWeight = "78.4kg",
				mNettWeight = "63.19",
				mBMI = "25.9",
				mBoneMass = "3.9",
				mFat = "19.4%"
			},
		};

		private readonly MyHealth_BodyWeight_ListData[] mListData;

		public MyHealth_BodyWeight_ListDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MyHealth_BodyWeight_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}

	public class MyHealth_BodyWeight_ListDataHolderList
	{
		private readonly List<MyHealth_BodyWeight_ListData> mListData = new List<MyHealth_BodyWeight_ListData>();

		public MyHealth_BodyWeight_ListDataHolderList(List<MyHealth_BodyWeight_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Count; }
		}

		public MyHealth_BodyWeight_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}

	/* ======================================= */
	/* ======================================= */
	/* ======================================= */

	public class MyHealth_BloodPressure_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MyHealth_BloodPressure_ListDataHolderList mData;
		Activity context;
		//for animation

		//foranimation
		public event EventHandler<int> ItemClick;
		int totalPage = 0;

		public MyHealth_BloodPressure_RecyclerViewAdapter (Activity context, MyHealth_BloodPressure_ListDataHolderList data, int totalPage)
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
			RecyclerView.ViewHolder vh;
			Console.Error.WriteLine ("viewType"+viewType);
			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyHealth_BPViewListItem, parent, false);
				vh = new MyHealth_BloodPressure_ViewHolder (itemView, OnClick);
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
			if (holder.GetType () == typeof(MyHealth_BloodPressure_ViewHolder)) {
				MyHealth_BloodPressure_ViewHolder vh = holder as MyHealth_BloodPressure_ViewHolder;
				vh.tvMHBPCLIDateTime.Text = mData[position].mDateTime;
				vh.tvMHBPCLIPressure.Text = mData[position].mPressure;
				vh.tvMHBPCLIPulse.Text = mData[position].mPulse;
				vh.llMHBWCLIBgColor.SetBackgroundColor(Color.ParseColor(mData[position].mBgColor.ToString()));
				vh.tvMHBPCLIStatus.Text = mData [position].mStatus;
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

	public class MyHealth_BloodPressure_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvMHBPCLIDateTime { get; private set; }
		public TextView tvMHBPCLIPressure { get; private set; }
		public TextView tvMHBPCLIPulse { get; private set; }
		public LinearLayout llMHBWCLIBgColor { get; private set; }
		public TextView tvMHBPCLIStatus { get; private set; }
		public View mMainView { get; set; }

		public MyHealth_BloodPressure_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvMHBPCLIDateTime = itemView.FindViewById <TextView> (Resource.Id.tvMHBPCLIDateTime);
			tvMHBPCLIPressure = itemView.FindViewById <TextView> (Resource.Id.tvMHBPCLIPressure);
			tvMHBPCLIPulse = itemView.FindViewById <TextView> (Resource.Id.tvMHBPCLIPulse);
			llMHBWCLIBgColor = itemView.FindViewById <LinearLayout> (Resource.Id.llMHBPCLIBgColor);
			tvMHBPCLIStatus = itemView.FindViewById <TextView> (Resource.Id.tvMHBPCLIStatus);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MyHealth_BloodPressure_ListData
	{
		public string mDateTime;
		public string mPressure;
		public string mPulse;
		public string mBgColor;
		public string mStatus;

		public string dateTime { get { return mDateTime; } }
		public string pressure { get { return mPressure; } }
		public string pulse { get { return mPulse; } }
		public string bgColor { get { return mBgColor; } }
		public string status { get { return mStatus; } }
	}

	public class  MyHealthRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
	{
		public delegate void LoadMoreEventHandler(object sender, EventArgs e);
		public event LoadMoreEventHandler LoadMoreEvent;

		private LinearLayoutManager LayoutManager;

		public MyHealthRecyclerViewOnScrollListener (LinearLayoutManager layoutManager)
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
			if (MyHealth_Tab_1.isRefreshing) {
				Console.Error.WriteLine ("masuk");
				MyHealth_Tab_1.worker.CancelAsync ();

				if (MyHealth_Tab_1.worker.CancellationPending) { 
					if (MyHealth_Tab_1.worker.IsBusy == true)
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
		
	public class MyHealth_BloodPressure_ListDataHolder
	{
		MyHealth_BloodPressure_ListData[] listData = { 
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mPressure = "78.4kg",
				mPulse = "63.19",
				mBgColor = "#FF277A3B",
				mStatus = "3.1"
			},
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2014-10-19 09:40:12", 
				mPressure = "80.6kg",
				mPulse = "59",
				mBgColor = "#FF9ACD62",
				mStatus = "2.9"
			},
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2015-03-09 19:31:23", 
				mPressure = "78.4kg",
				mPulse = "63.19",
				mBgColor = "#FFFECE07",
				mStatus = "3.9"
			},
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mPressure = "78.4kg",
				mPulse = "63.19",
				mBgColor = "#FFF57E20",
				mStatus = "3.9"
			},
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mPressure = "78.4kg",
				mPulse = "63.19",
				mBgColor = "#FFE64025",
				mStatus = "3.9"
			},
			new MyHealth_BloodPressure_ListData { 
				mDateTime = "2015-03-23 19:31:23", 
				mPressure = "78.4kg",
				mPulse = "63.19",
				mBgColor = "#FF9B1B1E",
				mStatus = "3.9"
			}
		};

		private readonly MyHealth_BloodPressure_ListData[] mListData;

		public MyHealth_BloodPressure_ListDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MyHealth_BloodPressure_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}

	public class MyHealth_BloodPressure_ListDataHolderList
	{
		private readonly List<MyHealth_BloodPressure_ListData> mListData = new List<MyHealth_BloodPressure_ListData>();

		public MyHealth_BloodPressure_ListDataHolderList(List<MyHealth_BloodPressure_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Count; }
		}

		public MyHealth_BloodPressure_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}
}

