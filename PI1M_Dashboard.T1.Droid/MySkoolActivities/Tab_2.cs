
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
using Android.Util;
using Android.Support.V7.Widget;

namespace PI1M_Dashboard.T1.Droid
{
	public class MySkool_Tab_2 : Android.Support.V4.App.Fragment 
	{
		//private ExpandableListAdapter mExpandAdapter;
		//private ExpandableListView myList;
		//List<string> groupList;
		MySkool_ListTakwimDataHolder listData;
		MySkool_Takwim_RecyclerViewAdapter takwimRecyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MySkool_tab_2 ,container ,false);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerViewTakwim);
			//mListView = v.FindViewById <ListView> (Resource.Id.listViewContainer);
			//mListView = v.FindViewById <ListView> (Android.Resource.Id.List);
			return v;
		}
			
		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			//createGroupList ();

			//myList = view.FindViewById<ExpandableListView> (Resource.Id.expView);
			//mExpandAdapter = new ExpandableListAdapter (Activity, groupList, Child_Data.childData());
			//myList.SetAdapter (mExpandAdapter);
			//SetGroupIndicatorToRight ();
			listData = new MySkool_ListTakwimDataHolder ();

			mLayoutManager = new LinearLayoutManager (Activity);
			recyclerView.SetLayoutManager (mLayoutManager);

			takwimRecyclerAdapter = new MySkool_Takwim_RecyclerViewAdapter (Activity, listData);
			recyclerView.SetAdapter (takwimRecyclerAdapter);

			//Takwim_NestedRecyclerViewAdapter mRViewAdapter = new Takwim_NestedRecyclerViewAdapter (Activity);
			//recyclerView.SetAdapter(mRViewAdapter);

			//listViewAdapter = new Takwim_ListViewAdapter (Activity, Child_Data.childData());
			//mListView.Adapter = listViewAdapter;

		}

		/*private void createGroupList()
		{
			groupList = new List<string> ();
			groupList.Add ("January");
			groupList.Add ("February");
			groupList.Add ("Mac");
			groupList.Add ("April");
			groupList.Add ("May");
			groupList.Add ("June");
			groupList.Add ("July");
			groupList.Add ("August");
		}

		private void SetGroupIndicatorToRight()
		{
			DisplayMetrics dm = new DisplayMetrics ();
			IWindowManager windowManager = Activity.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

			windowManager.DefaultDisplay.GetMetrics (dm);

			int width = dm.WidthPixels;

			myList.SetIndicatorBounds (width - GetDipsFromPixel (35), width - GetDipsFromPixel(5));
		}

		public int GetDipsFromPixel(float pixels)
		{
			float scale = Resources.DisplayMetrics.Density;

			return (int)(pixels * scale + 0.5f);
		}*/
	}
}

