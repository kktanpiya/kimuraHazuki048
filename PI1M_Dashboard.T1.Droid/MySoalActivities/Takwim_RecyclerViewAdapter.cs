
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
	public class MySoal_Takwim_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MySoal_Takwim_ListTakwimDataHolder mData;
		Activity context;
		MySoal_Takwim_NestedRecyclerViewAdapter mRViewAdapter;
		RecyclerView.LayoutManager mLayoutManager;

		public event EventHandler<int> ItemClick;

		public MySoal_Takwim_RecyclerViewAdapter (Activity context, MySoal_Takwim_ListTakwimDataHolder data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MySoal_TakwimRecyclerViewList, parent, false);
			MySoal_Takwim_TakwimViewHolder vh = new MySoal_Takwim_TakwimViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MySoal_Takwim_TakwimViewHolder vh = holder as MySoal_Takwim_TakwimViewHolder;

			string tempData = mData[position].title;
			vh.tvTitle.Text = tempData;

			mLayoutManager = new MySoal_MyLinearLayoutManager (context);
			vh.mRViewList.SetLayoutManager (mLayoutManager);

			mRViewAdapter = new MySoal_Takwim_NestedRecyclerViewAdapter (context, MySoal_Child_Data.childData(), tempData);
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

	public class MySoal_Takwim_TakwimViewHolder : RecyclerView.ViewHolder
	{
		public TextView tvTitle { get; private set; }
		public RecyclerView mRViewList { get; private set;}

		public MySoal_Takwim_TakwimViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvCardHeader);
			mRViewList = itemView.FindViewById <RecyclerView> (Resource.Id.takwimRecyclerViewList);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MySoal_Takwim_ListDataTakwim
	{
		public string mTitle;

		public string title
		{
			get { return mTitle; }
		}

	}

	public class MySoal_Takwim_ListTakwimDataHolder
	{ 
		MySoal_Takwim_ListDataTakwim[] listData = { 
			new MySoal_Takwim_ListDataTakwim { mTitle = "January" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "February" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "Mac" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "April" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "May" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "June" },
			new MySoal_Takwim_ListDataTakwim { mTitle = "July" }
		};

		private readonly MySoal_Takwim_ListDataTakwim[] mListData;

		public MySoal_Takwim_ListTakwimDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MySoal_Takwim_ListDataTakwim this [int i]
		{
			get { return mListData[i];}
		}
	}
}

