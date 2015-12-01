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
	public class MySoal_MesejDihantar_RecyclerViewAdapter : RecyclerView.Adapter
	{
		public MySoal_MesejDihantar_ListDataHolderList mData;
		Activity context;
		//for animation

		//foranimation
		public event EventHandler<int> ItemClick;

		public MySoal_MesejDihantar_RecyclerViewAdapter (Activity context, MySoal_MesejDihantar_ListDataHolderList data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{

			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MySoal_ViewListItem, parent, false);
			MySoal_MesejDihantar_ViewHolder vh = new MySoal_MesejDihantar_ViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MySoal_MesejDihantar_ViewHolder vh = holder as MySoal_MesejDihantar_ViewHolder;

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
			vh.tvTitle.Text = mData[position].title;
			vh.tvContent.Text = mData[position].content;



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

	public class MySoal_MesejDihantar_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvTitle { get; private set; }
		public TextView tvContent { get; private set;}
		public View mMainView { get; set; }
		public MySoal_MesejDihantar_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvTitle);
			tvContent = itemView.FindViewById <TextView> (Resource.Id.tvContent);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MySoal_MesejDihantar_ListData
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


}

