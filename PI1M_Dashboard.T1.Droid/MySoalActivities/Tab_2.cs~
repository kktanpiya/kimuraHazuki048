
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
using PI1M_Dashboard.Lib.DLayer.SQLite;

namespace PI1M_Dashboard.T1.Droid
{
	public class MySoal_Tab_2 : Android.Support.V4.App.Fragment 
	{
		//private ExpandableListAdapter mExpandAdapter;
		//private ExpandableListView myList;
		//List<string> groupList;
		//MySoal_Takwim_ListTakwimDataHolder listData;
		MySoal_MesejDihantar_ListDataHolderList listDataRA;
		//MySoal_Takwim_RecyclerViewAdapter takwimRecyclerAdapter;
		MySoal_MesejDihantar_RecyclerViewAdapter mesejDihantarRA;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		Connection dbConn;
		public string sqliteFile;
		public string libraryPath;
		public string dbPath;
		string folderPath;

		List<MySoal_MesejDihantar_ListData> mySoalSIListData = new List<MySoal_MesejDihantar_ListData>();
		List<string> mySoalToData = new List<string>();
		List<string> mySoalSubjectData = new List<string>();
		List<string> mySoalContentData = new List<string>();

		LinearLayout llMST2ErrorLayout;
		TextView tvMST2ErrorStatus;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MySoal_tab_2,container, false);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerViewTakwim);
			//mListView = v.FindViewById <ListView> (Resource.Id.listViewContainer);
			//mListView =
			v.FindViewById <ListView> (Android.Resource.Id.List);
			//recyclerView.AddOnItemTouchListener(new TabOnTouchListener());

			llMST2ErrorLayout = (LinearLayout)v.FindViewById (Resource.Id.llMST2ErrorLayout);
			tvMST2ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMST2ErrorStatus);

			sqliteFile = "PI1Mv2DB.db3";
			libraryPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			folderPath = libraryPath + "/data/";
			dbPath = System.IO.Path.Combine (folderPath , sqliteFile);
			Console.WriteLine ("[ComposeMessage] Checking database path: {0}",dbPath);
			dbConn = new Connection (dbPath);

			GetSentItemDataDB ();

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
			listDataRA = new MySoal_MesejDihantar_ListDataHolderList (mySoalSIListData);

			mLayoutManager = new LinearLayoutManager (Activity);
			recyclerView.SetLayoutManager (mLayoutManager);

			mesejDihantarRA = new MySoal_MesejDihantar_RecyclerViewAdapter (Activity, listDataRA);
			recyclerView.SetAdapter (mesejDihantarRA);

			mesejDihantarRA.ItemClick += ItemClicked;

			//Takwim_NestedRecyclerViewAdapter mRViewAdapter = new Takwim_NestedRecyclerViewAdapter (Activity);
			//recyclerView.SetAdapter(mRViewAdapter);

			//listViewAdapter = new Takwim_ListViewAdapter (Activity, Child_Data.childData());
			//mListView.Adapter = listViewAdapter;


		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent MesejDihantarDetails = new Intent (Activity, typeof(MesejDihantar_Details));
			MesejDihantarDetails.PutExtra ("SITo",mySoalToData[e]);
			MesejDihantarDetails.PutExtra ("SISubject",mySoalSubjectData[e]);
			MesejDihantarDetails.PutExtra ("SIContent",mySoalContentData[e]);
			StartActivityForResult (MesejDihantarDetails,0);
			Activity.OverridePendingTransition (0, 0);
		}

		public override void OnActivityResult(int RequestCode, int ResultCode, Intent Data)
		{
			if (RequestCode == 0) {
				if (ResultCode.Equals(Result.Ok)) {
					
					mesejDihantarRA.NotifyDataSetChanged ();
					Console.WriteLine ("[MySoalTab1] Refreshing Sent Items.");

				} else {
					
				}
			}
		}

		public override void OnResume ()
		{
			base.OnResume ();
			Console.WriteLine ("[Tab2] Resumed");
			Console.WriteLine ("[Tab2] Refreshing Sent Items.");
			GetSentItemDataDB ();

			mesejDihantarRA.NotifyDataSetChanged ();

		}

		public void GetSentItemDataDB()
		{
			mySoalSIListData.Clear ();
			mySoalToData.Clear ();
			mySoalSubjectData.Clear ();
			mySoalContentData.Clear ();

			Console.WriteLine ("[Tab 2] Retrieved Email: {0}",Activity.Intent.GetStringExtra("Email"));
			/*
			var checkQuery = dbConn.Table<MySoal_SentItems> ()
				.Where(m => m.si_from.Equals(Activity.Intent.GetStringExtra("Email")))
				.OrderByDescending(m => m.id);
			*/
			//var checkQuery = from s in dbConn.Table<MySoal_SentItems> () 
			//		where s.si_from.Equals(this.Activity.Intent.GetStringExtra("Email")) select s;
			var checkQuery = dbConn.Query<MySoal_SentItems> ("SELECT * FROM MySoal_SentItems WHERE si_from = ? ORDER BY id DESC", Activity.Intent.GetStringExtra("Email"));

			Console.WriteLine ("[Tab 2] SentItems Count: {0}",checkQuery.Count());

			if (checkQuery.Count() != 0) {

				llMST2ErrorLayout.Visibility = ViewStates.Gone;
				recyclerView.Visibility = ViewStates.Visible;

				foreach (var queryline in checkQuery) {

					Console.WriteLine ("[ComposeMessage] Checking all subjects sent {0} from {1}", queryline.si_subject, queryline.si_from);
					mySoalSIListData.Add (new MySoal_MesejDihantar_ListData () {

						mTitle = queryline.si_subject, 
						mContent = "Mesej dihantar pada " + queryline.si_sentAt

					});

					mySoalToData.Add (queryline.si_to);
					mySoalSubjectData.Add (queryline.si_subject);
					mySoalContentData.Add (queryline.si_content);
				}
			} else {

				llMST2ErrorLayout.Visibility = ViewStates.Visible;
				recyclerView.Visibility = ViewStates.Gone;
				tvMST2ErrorStatus.Text = "Tiada mesej dihantar telah dibuat.";

			}
		}

		public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
			return dtDateTime;
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

	public class MySoal_MesejDihantar_ListDataHolderList
	{
		private readonly List<MySoal_MesejDihantar_ListData> mListData = new List<MySoal_MesejDihantar_ListData>();

		public MySoal_MesejDihantar_ListDataHolderList(List<MySoal_MesejDihantar_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { 

				return mListData.Count; 

			}
		}

		public MySoal_MesejDihantar_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}

}

