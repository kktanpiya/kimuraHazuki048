
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

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Takwim_RecyclerViewAdapter")]			
	public class MyKomuniti_Takwim_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MyKomuniti_ListTakwimDataHolder mData;
		Activity context;
		MyKomuniti_Takwim_NestedRecyclerViewAdapter mRViewAdapter;
		RecyclerView.LayoutManager mLayoutManager;

		public event EventHandler<int> ItemClick;

		public MyKomuniti_Takwim_RecyclerViewAdapter (Activity context, MyKomuniti_ListTakwimDataHolder data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{

			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyKomuniti_TakwimRecyclerViewList, parent, false);
			MyKomuniti_TakwimViewHolder vh = new MyKomuniti_TakwimViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MyKomuniti_TakwimViewHolder vh = holder as MyKomuniti_TakwimViewHolder;

			string tempData = mData[position].title;
			vh.tvTitle.Text = tempData;

			mLayoutManager = new MyKomuniti_MyLinearLayoutManager (context);
			vh.mRViewList.SetLayoutManager (mLayoutManager);

			mRViewAdapter = new MyKomuniti_Takwim_NestedRecyclerViewAdapter (context, MyKomuniti_Child_Data.childData(), tempData);
			vh.mRViewList.SetAdapter(mRViewAdapter);
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

	public class MyKomuniti_TakwimViewHolder : RecyclerView.ViewHolder
	{
		public TextView tvTitle { get; private set; }
		public RecyclerView mRViewList { get; private set;}

		public MyKomuniti_TakwimViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvCardHeader);
			mRViewList = itemView.FindViewById <RecyclerView> (Resource.Id.takwimRecyclerViewList);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MyKomuniti_ListDataTakwim
	{
		public string mTitle;

		public string title
		{
			get { return mTitle; }
		}

	}

	public class MyKomuniti_ListTakwimDataHolder
	{ 
		MyKomuniti_ListDataTakwim[] listData = { new MyKomuniti_ListDataTakwim { mTitle = "Januari" },
			new MyKomuniti_ListDataTakwim { mTitle = "Februari" },
			new MyKomuniti_ListDataTakwim { mTitle = "Mac" },
			new MyKomuniti_ListDataTakwim { mTitle = "April" },
			new MyKomuniti_ListDataTakwim { mTitle = "Mei" },
			new MyKomuniti_ListDataTakwim { mTitle = "Jun" },
			new MyKomuniti_ListDataTakwim { mTitle = "Julai" },
			new MyKomuniti_ListDataTakwim { mTitle = "Ogos" },
			new MyKomuniti_ListDataTakwim { mTitle = "September" },
			new MyKomuniti_ListDataTakwim { mTitle = "Oktober" },
			new MyKomuniti_ListDataTakwim { mTitle = "November" },
			new MyKomuniti_ListDataTakwim { mTitle = "Disember" }
		};

		private readonly MyKomuniti_ListDataTakwim[] mListData;

		public MyKomuniti_ListTakwimDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MyKomuniti_ListDataTakwim this [int i]
		{
			get { return mListData[i];}
		}
	}
}

