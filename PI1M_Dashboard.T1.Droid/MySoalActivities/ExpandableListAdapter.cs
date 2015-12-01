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

namespace PI1M_Dashboard.T1.Droid
{
	
	public class MySoal_ExpandableListAdapter : BaseExpandableListAdapter
	{
		public Activity context;
		public List<string> month = new List<string>();
		public List<MySoal_Child_Data> mData;
		public ChildViewHolder cHolder;
		public HeaderViewHolder hHolder;
		//private List<HeaderInfo> mHeader;

		public MySoal_ExpandableListAdapter(Activity context, List<string> month, List<MySoal_Child_Data> data)
		{
			this.context = context;
			this.month = month;
			this.mData = data;
		}

		#region implemented abstract members of BaseExpandableListAdapter

		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			throw new NotImplementedException ();
		}

		public override long GetChildId (int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public override int GetChildrenCount (int groupPosition)
		{
			string header = (string)GetGroup (groupPosition);
			List<MySoal_Child_Data> result = mData.FindAll (((MySoal_Child_Data obj) => obj.mMonth.Equals (header)));
			return result.Count;
			//return monthList [month[groupPosition]].Count;
		}

		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			string childData = "";
			string date = "";
			cHolder = new ChildViewHolder ();
			if (convertView == null) {
				convertView = context.LayoutInflater.Inflate (Resource.Layout.MySoal_list_item, null);

				cHolder.childHolder = convertView.FindViewById<TextView> (Resource.Id.expItem);
				GetChildViewHelper (groupPosition, childPosition, out childData, out date);
				string data = childData + " " + date;
				cHolder.childHolder.Text = data;
				cHolder.childHolder.Click += delegate {

					//Intent intent = new Intent (context, typeof(MySoal_Takwim_Detail));
					//intent.PutExtra ("detail", data);
					//context.StartActivity (intent);
					Toast.MakeText (context, data, ToastLength.Short).Show ();
				};
				convertView.Tag = cHolder;
			} else {
				
				cHolder = convertView.Tag as ChildViewHolder;
			}
			return convertView;
		}

		public void GetChildViewHelper (int groupPosition, int childPosition, out string childData, out string date)
		{
			string header = (string)GetGroup (groupPosition);
			List<MySoal_Child_Data> result = mData.FindAll (((MySoal_Child_Data obj) => obj.mMonth.Equals (header)));
			childData = result [childPosition].mDetail;
			date = result [childPosition].mDate;
		}

		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return month [groupPosition];
		}

		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		}

		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			string monthName = (string) GetGroup (groupPosition);
			hHolder = new HeaderViewHolder ();

			if (convertView == null) {
				convertView = context.LayoutInflater.Inflate (Resource.Layout.MySoal_list_group, null);
				convertView.Tag = hHolder;
			} else {
				hHolder = convertView.Tag as HeaderViewHolder;
			}

			hHolder.headHolder = convertView.FindViewById <TextView> (Resource.Id.expHeader);
			hHolder.headHolder.SetTypeface (null, Android.Graphics.TypefaceStyle.Bold);
			hHolder.headHolder.Text = monthName;

			return convertView;
		}

		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		}

		public override int GroupCount {
			get {
				return month.Count;
			}
		}

		public override bool HasStableIds {
			get {
				return true;
			}
		}

		#endregion

		public class ChildViewHolder : Java.Lang.Object
		{
			public TextView childHolder;
		}

		public class HeaderViewHolder : Java.Lang.Object
		{
			public TextView headHolder;
		}
	}
}

