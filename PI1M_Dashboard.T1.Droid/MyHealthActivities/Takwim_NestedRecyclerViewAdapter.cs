
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
	public class MyHealth_Takwim_NestedRecyclerViewAdapter : RecyclerView.Adapter
	{
		public Activity mContent;
		private readonly List<MyHealth_Child_Data> mlistData;
		public string headerData;

		public MyHealth_Takwim_NestedRecyclerViewAdapter(Activity content, List<MyHealth_Child_Data> listData, string hData)
		{
			this.mContent = content;
			mlistData = listData;
			headerData = hData;
		}
			
		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MyHealth_TakwimListItem, parent, false);

			ViewHolder vh = new ViewHolder (v);

			vh.mText.Tag = vh;

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			string data = "";

			ViewHolder vh = holder as ViewHolder;

			List<MyHealth_Child_Data> result = mlistData.FindAll ((obj => obj.mMonth.Equals (headerData)));
			data = result [position].mDetail;

			vh.mText.Text = data;
		}

		public override int ItemCount{
			get { List<MyHealth_Child_Data> result = mlistData.FindAll ((obj => obj.mMonth.Equals (headerData)));
				return result.Count; }
		}

		private class ViewHolder : RecyclerView.ViewHolder
		{

			public TextView mText { get; private set;}

			public ViewHolder (View view) : base(view){
				mText = view.FindViewById<TextView> (Resource.Id.tvListItem);
			}
		}
	}
}

