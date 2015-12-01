
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
	[Activity (Label = "Takwim_NestedRecyclerViewAdapter")]			
	public class MyKomuniti_Takwim_NestedRecyclerViewAdapter : RecyclerView.Adapter
	{
		public Activity mContent;
		private readonly List<MyKomuniti_Child_Data> mlistData;
		public string headerData;

		public MyKomuniti_Takwim_NestedRecyclerViewAdapter(Activity content, List<MyKomuniti_Child_Data> listData, string hData)
		{
			this.mContent = content;
			mlistData = listData;
			headerData = hData;
		}
			
		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MyKomuniti_TakwimListItem, parent, false);

			ViewHolder vh = new ViewHolder (v);

			vh.mText.Tag = vh;

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			string data = "";

			ViewHolder vh = holder as ViewHolder;

			List<MyKomuniti_Child_Data> result = mlistData.FindAll ((obj => obj.mMonth.Equals (headerData)));
			//data = result [position].mDetail;

			vh.mText.Text = result [position].mTitle;
			vh.mDay.Text = result [position].mDay;
			vh.mDesc.Text = result [position].mDetail;
			vh.mMonthShort.Text = result [position].mMonthShort;
		}

		public override int ItemCount{
			get { List<MyKomuniti_Child_Data> result = mlistData.FindAll ((obj => obj.mMonth.Equals (headerData)));
				return result.Count; }
		}

		private class ViewHolder : RecyclerView.ViewHolder
		{

			public TextView mDay { get; private set; }
			public TextView mMonthShort { get; private set; }
			public TextView mText { get; private set; }
			public TextView mDesc { get; private set; }

			public ViewHolder (View view) : base(view) {

				mDay = view.FindViewById<TextView> (Resource.Id.tvMKTLIDay);
				mMonthShort = view.FindViewById<TextView> (Resource.Id.tvMKTLIMonth);
				mText = view.FindViewById<TextView> (Resource.Id.tvMKTLIListItem);
				mDesc = view.FindViewById<TextView> (Resource.Id.tvMKTLIListItemDetails);

			}
		}
	}
}

