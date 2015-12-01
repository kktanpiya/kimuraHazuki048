
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
	public class MyHealth_Takwim_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MyHealth_ListTakwimDataHolder mData;
		Activity context;
		MyHealth_Takwim_NestedRecyclerViewAdapter mRViewAdapter;
		RecyclerView.LayoutManager mLayoutManager;

		public event EventHandler<int> ItemClick;

		public MyHealth_Takwim_RecyclerViewAdapter (Activity context, MyHealth_ListTakwimDataHolder data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{

			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyHealth_TakwimRecyclerViewList, parent, false);
			MyHealth_TakwimViewHolder vh = new MyHealth_TakwimViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MyHealth_TakwimViewHolder vh = holder as MyHealth_TakwimViewHolder;

			string tempData = mData[position].title;
			vh.tvTitle.Text = tempData;

			mLayoutManager = new MyHealth_MyLinearLayoutManager (context);
			vh.mRViewList.SetLayoutManager (mLayoutManager);

			mRViewAdapter = new MyHealth_Takwim_NestedRecyclerViewAdapter (context, MyHealth_Child_Data.childData(), tempData);
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

	public class MyHealth_TakwimViewHolder : RecyclerView.ViewHolder
	{
		public TextView tvTitle { get; private set; }
		public RecyclerView mRViewList { get; private set;}

		public MyHealth_TakwimViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvCardHeader);
			mRViewList = itemView.FindViewById <RecyclerView> (Resource.Id.takwimRecyclerViewList);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MyHealth_ListDataTakwim
	{
		public string mTitle;

		public string title
		{
			get { return mTitle; }
		}

	}

	public class  MyHealthBWRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
	{
		public delegate void LoadMoreEventHandler(object sender, EventArgs e);
		public event LoadMoreEventHandler LoadMoreEvent;

		private LinearLayoutManager LayoutManager;

		public MyHealthBWRecyclerViewOnScrollListener (LinearLayoutManager layoutManager)
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
			if (MyHealth_Tab_2.isRefreshing) {
				Console.Error.WriteLine ("masuk");
				MyHealth_Tab_2.worker.CancelAsync ();

				if (MyHealth_Tab_2.worker.CancellationPending) { 
					if (MyHealth_Tab_2.worker.IsBusy == true)
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

	public class MyHealth_ListTakwimDataHolder
	{ 
		MyHealth_ListDataTakwim[] listData = { new MyHealth_ListDataTakwim { mTitle = "January" },
			new MyHealth_ListDataTakwim { mTitle = "February" },
			new MyHealth_ListDataTakwim { mTitle = "Mac" },
			new MyHealth_ListDataTakwim { mTitle = "April" },
			new MyHealth_ListDataTakwim { mTitle = "May" },
			new MyHealth_ListDataTakwim { mTitle = "June" },
			new MyHealth_ListDataTakwim { mTitle = "July" }
		};

		private readonly MyHealth_ListDataTakwim[] mListData;

		public MyHealth_ListTakwimDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MyHealth_ListDataTakwim this [int i]
		{
			get { return mListData[i];}
		}
	}
}

