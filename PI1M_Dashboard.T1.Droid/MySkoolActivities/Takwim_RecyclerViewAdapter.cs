
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
	public class MySkool_Takwim_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MySkool_ListTakwimDataHolder mData;
		Activity context;
		MySkool_Takwim_NestedRecyclerViewAdapter mRViewAdapter;
		RecyclerView.LayoutManager mLayoutManager;

		public event EventHandler<int> ItemClick;

		public MySkool_Takwim_RecyclerViewAdapter (Activity context, MySkool_ListTakwimDataHolder data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{

			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MySkool_TakwimRecyclerViewList, parent, false);
			MySkool_TakwimViewHolder vh = new MySkool_TakwimViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MySkool_TakwimViewHolder vh = holder as MySkool_TakwimViewHolder;

			string tempData = mData[position].title;
			vh.tvTitle.Text = tempData;

			mLayoutManager = new MySkool_MyLinearLayoutManager (context);
			vh.mRViewList.SetLayoutManager (mLayoutManager);

			mRViewAdapter = new MySkool_Takwim_NestedRecyclerViewAdapter (context, MySkool_Child_Data.childData(), tempData);
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

	public class MySkool_TakwimViewHolder : RecyclerView.ViewHolder
	{
		public TextView tvTitle { get; private set; }
		public RecyclerView mRViewList { get; private set;}

		public MySkool_TakwimViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvCardHeader);
			mRViewList = itemView.FindViewById <RecyclerView> (Resource.Id.takwimRecyclerViewList);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MySkool_ListDataTakwim
	{
		public string mTitle;

		public string title
		{
			get { return mTitle; }
		}

	}

	public class MySkool_ListTakwimDataHolder
	{ 
		MySkool_ListDataTakwim[] listData = { new MySkool_ListDataTakwim { mTitle = "Januari" },
			new MySkool_ListDataTakwim { mTitle = "Februari" },
			new MySkool_ListDataTakwim { mTitle = "Mac" },
			new MySkool_ListDataTakwim { mTitle = "April" },
			new MySkool_ListDataTakwim { mTitle = "Mei" },
			new MySkool_ListDataTakwim { mTitle = "Jun" },
			new MySkool_ListDataTakwim { mTitle = "Julai" },
			new MySkool_ListDataTakwim { mTitle = "Ogos" },
			new MySkool_ListDataTakwim { mTitle = "September" },
			new MySkool_ListDataTakwim { mTitle = "Oktober" },
			new MySkool_ListDataTakwim { mTitle = "November" },
			new MySkool_ListDataTakwim { mTitle = "Disember" }
		};

		private readonly MySkool_ListDataTakwim[] mListData;

		public MySkool_ListTakwimDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MySkool_ListDataTakwim this [int i]
		{
			get { return mListData[i];}
		}
	}
}

