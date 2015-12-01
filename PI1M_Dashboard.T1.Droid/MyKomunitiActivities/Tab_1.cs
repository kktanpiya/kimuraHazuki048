
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
using Newtonsoft.Json;
using System.Threading;
using Android.Support.V4.Widget;
using System.ComponentModel;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyKomuniti_Tab_1 : Android.Support.V4.App.Fragment 
	{
		//MySkool_ListDataHolder listData;
		MyKomuniti_ListDataHolderList listData;
		MyKomuniti_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		LinearLayout llMKkT1ErrorStatus;
		TextView tvMKkT1ErrorStatus;

		List<MyKomuniti_ListData> myKomunitiListdata = new List<MyKomuniti_ListData>();
		List<string> myKomunitiTitleList = new List<string> ();
		List<string> myKomunitiContentList = new List<string> ();

		ProgressDialog progressDialog;
		SwipeRefreshLayout mSlideRefreshLayout;

		string tokenData = "";
		int page = 1;
		int lastPage;
		public static bool isRefreshing = false;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			tokenData = Activity.Intent.GetStringExtra ("Token");
			
			View v = inflater.Inflate(Resource.Layout.MyKomuniti_tab_1 ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);

			progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			llMKkT1ErrorStatus = (LinearLayout)v.FindViewById (Resource.Id.llMKkT1ErrorStatus);
			tvMKkT1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMKkT1ErrorStatus);

			mSlideRefreshLayout = v.FindViewById<SwipeRefreshLayout> (Resource.Id.swipelayout);
			mSlideRefreshLayout.SetColorScheme (Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark, Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
			mSlideRefreshLayout.Refresh += mSlideRefreshLayout_Refresh;

			if (recyclerView != null) {
				recyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (Activity);
				var onScrollListener = new MyKomunitiRecyclerViewOnScrollListener (layoutManager);

				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					Console.Error.WriteLine ("isRefeshing" + isRefreshing);
					page++;
					if (page <= lastPage && isRefreshing == false) {
						Console.Error.WriteLine ("masuk");

						ThreadPool.QueueUserWorkItem (o => {
							InitialSetup (tokenData, page);
						});
					}
				};
				recyclerView.AddOnScrollListener (onScrollListener);
				recyclerView.SetLayoutManager (layoutManager);
			}
				
			return v;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			ThreadPool.QueueUserWorkItem (o => { InitialSetup(tokenData,page); });

		}

		private void InitialSetup(string tokenData, int page)
		{
			//string tokenData = Activity.Intent.GetStringExtra ("Token");

			string myKomunitiRawData = GetMyKomunitiJSONData(tokenData.ToString(), page);
			var myKomunitiJSONed = JsonConvert.DeserializeObject<WebServices.MyKomunitiFRObj> (myKomunitiRawData);

			int totalPage = 0;

			totalPage = myKomunitiJSONed.total;
			lastPage = myKomunitiJSONed.last_page;
			Console.WriteLine ("[MyKomuniti Feed] Paging: {0}",totalPage);


			if (totalPage != 0) {

				if(isRefreshing == true){
					myKomunitiListdata.Clear ();	
				}

				Activity.RunOnUiThread (() => {
					llMKkT1ErrorStatus.Visibility = ViewStates.Gone;
					recyclerView.Visibility = ViewStates.Visible;
				});

				foreach (var msjsoned in myKomunitiJSONed.data) {
					myKomunitiListdata.Add (new MyKomuniti_ListData { 
						mTitle = msjsoned.title, 
						mContent = msjsoned.content.ToString ()//.Substring (0, 50) + "..."
					});

					myKomunitiTitleList.Add (msjsoned.title);
					myKomunitiContentList.Add (msjsoned.content);
				}

			} else {

				Activity.RunOnUiThread (() => {
					llMKkT1ErrorStatus.Visibility = ViewStates.Visible;
					recyclerView.Visibility = ViewStates.Gone;
					tvMKkT1ErrorStatus.Text = "Tiada maklumat tersedia buat masa ini.";
					progressDialog.Hide();
				});

			}

			if (Activity != null) {
				
				Activity.RunOnUiThread (() => {
					if (page == 1) {
						listData = new MyKomuniti_ListDataHolderList (myKomunitiListdata);

						mLayoutManager = new LinearLayoutManager (Activity);
						recyclerView.SetLayoutManager (mLayoutManager);

						recyclerAdapter = new MyKomuniti_RecyclerViewAdapter (Activity, listData, totalPage);
						recyclerView.SetAdapter (recyclerAdapter);

						recyclerAdapter.ItemClick += ItemClicked;

						progressDialog.Hide ();

						if (isRefreshing == true) { 
							Toast.MakeText (Activity, "Data terkini telah dimuatkan..", ToastLength.Short).Show ();
						}
					} else {
						recyclerAdapter.NotifyDataSetChanged ();
					}
				});
			}
		}

		void mSlideRefreshLayout_Refresh (object sender, EventArgs e)
		{
			//set to true to indicate refresh action
			isRefreshing = true;

			worker = new BackgroundWorker ();
			worker.DoWork += worker_DoWork;
			worker.WorkerSupportsCancellation = true;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			worker.RunWorkerAsync ();

		}

		void worker_RunWorkerCompleted (object sender, EventArgs e)
		{
			//after completed task
			recyclerAdapter.NotifyDataSetChanged ();
			mSlideRefreshLayout.Refreshing = false;


			//refreshing done
			isRefreshing = false;
		}

		void worker_DoWork (object sender, DoWorkEventArgs ea)
		{
			//will do separate task here
			//			if (worker.IsBusy) {
			//				Console.Error.WriteLine ("masuk");
			//				worker.CancelAsync ();
			//
			if (worker.CancellationPending) { 
				Console.Error.WriteLine ("masukiniii");
				return;
			}
			//			}

			page = 1;
			InitialSetup (tokenData,page);

		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent AnnouncementDetails = new Intent (Activity, typeof(MyKomuniti_Announcement_Details));

			AnnouncementDetails.PutExtra ("ArticleTitle",myKomunitiTitleList[e]);
			AnnouncementDetails.PutExtra ("ArticleContent",myKomunitiContentList[e]);
			StartActivity (AnnouncementDetails);
			Activity.OverridePendingTransition (0, 0);
		}

		private string SetupMyKomunitiData(){

			WebServices wbs = new WebServices ();

			string tokenData = Activity.Intent.GetStringExtra ("Token");

			string tokenWBSRaw = wbs.setMySkoolAuth(tokenData);

			string tokenWBS = "";

			Console.WriteLine ("Raw Data: {0}",tokenWBSRaw);

			try {

				var tokenWBSjson = JsonConvert.DeserializeObject<WebServices.mySkoolAuthToken> (tokenWBSRaw);

				tokenWBS = tokenWBSjson.token.ToString();

			}
			catch(Exception e) {

				string eLimit = string.Format ("{0}", e).Substring (0, 20);

				AlertDialog alertDialog;
				AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder (Activity);

				alertDialogBuilder
					.SetTitle ("Masalah")
					.SetMessage (string.Format("Maaf. Sila cuba sekali lagi ({0}...).",eLimit))
					.SetCancelable (true)
					.SetPositiveButton ("OK", exitHandler);

				alertDialog = alertDialogBuilder.Create ();

				alertDialog.Show ();

			}

			return tokenWBS;
		}

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}

		public string GetMyKomunitiJSONData(string token, int paging)
		{
			WebServices wbs = new WebServices ();
			return wbs.GetMyKomunitiFeed (token,paging);
		}

	}

	public class MyKomuniti_ListDataHolderList
	{

		private readonly List<MyKomuniti_ListData> mListData = new List<MyKomuniti_ListData>();

		public MyKomuniti_ListDataHolderList(List<MyKomuniti_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { 
				
				return mListData.Count; 
			
			}
		}

		public MyKomuniti_ListData this [int i]
		{
			get { return mListData[i];}
		}

	}
}

