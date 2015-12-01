
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
	public class MySkool_Tab_1 : Android.Support.V4.App.Fragment 
	{
		//MySkool_ListDataHolder listData;
		MySkool_ListDataHolderList listData;
		MySkool_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		LinearLayout llMSkT1ErrorStatus;
		TextView tvMSkT1ErrorStatus;

		List<MySkool_ListData> mySkoolListData = new List<MySkool_ListData>();
		List<string> mySkoolTitleList = new List<string> ();
		List<string> mySkoolContentList = new List<string> ();

		ProgressDialog progressDialog;
		SwipeRefreshLayout mSlideRefreshLayout;

		string tokenWBS = "";
		int page = 1;
		int lastPage = 0;
		public static bool isRefreshing = false;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MySkool_tab_1 ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);

			progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			llMSkT1ErrorStatus = (LinearLayout)v.FindViewById (Resource.Id.llMSkT1ErrorStatus);
			tvMSkT1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMSkT1ErrorStatus);

			mSlideRefreshLayout = v.FindViewById<SwipeRefreshLayout> (Resource.Id.swipelayout);
			mSlideRefreshLayout.SetColorScheme (Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark, Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
			mSlideRefreshLayout.Refresh += mSlideRefreshLayout_Refresh;

			if (recyclerView != null) {
				recyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (Activity);
				var onScrollListener = new MySkoolRecyclerViewOnScrollListener (layoutManager);

				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					Console.Error.WriteLine ("isRefeshing" + isRefreshing);
					page++;
					if (page <= lastPage && isRefreshing == false) {
						Console.Error.WriteLine ("masuk");

						ThreadPool.QueueUserWorkItem (o => {
							InitialSetup (page);
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

			ThreadPool.QueueUserWorkItem (o => { InitialSetup(page); });

		}

		private void InitialSetup(int page)
		{
			try {
				
				string mySkoolToken = setupMySkoolData ();

				string mySkoolRawData = getMySkoolJSONData(mySkoolToken.ToString(), page);
				var mySkoolJSONed = JsonConvert.DeserializeObject<WebServices.MySkoolPetiMasukData> (mySkoolRawData);

				int totalPage = 0;

				foreach (var mySkoolPaging in mySkoolJSONed.paging) {
					Console.WriteLine ("[MySoal - Peti Masuk] Paging: {0}",mySkoolPaging.count);
					totalPage = mySkoolPaging.count;
					lastPage = mySkoolPaging.pageCount;
				}

				if (totalPage != 0) {

					if(isRefreshing==true){
						mySkoolListData.Clear ();	
					}

					Activity.RunOnUiThread (() => {
						llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
						recyclerView.Visibility = ViewStates.Visible;
					});

					foreach (var msjsoned in mySkoolJSONed.data) {
						mySkoolListData.Add (new MySkool_ListData { 
							mTitle = msjsoned.title, 
							mContent = msjsoned.text.ToString ()//.Substring (0, 50) + "..."
						});

						mySkoolTitleList.Add (msjsoned.title);
						mySkoolContentList.Add (msjsoned.content);
					}

				} else {

					Activity.RunOnUiThread (() => {
						llMSkT1ErrorStatus.Visibility = ViewStates.Visible;
						recyclerView.Visibility = ViewStates.Gone;
						tvMSkT1ErrorStatus.Text = "Tiada maklumat tersedia buat masa ini.";
						progressDialog.Hide();
					});

				}

				if (Activity != null) {

					Activity.RunOnUiThread (() => {
						if( page ==1)
						{
							listData = new MySkool_ListDataHolderList (mySkoolListData);

							mLayoutManager = new LinearLayoutManager (Activity);
							recyclerView.SetLayoutManager (mLayoutManager);

							recyclerAdapter = new MySkool_RecyclerViewAdapter (Activity, listData, totalPage);
							recyclerView.SetAdapter (recyclerAdapter);

							recyclerAdapter.ItemClick += ItemClicked;

							progressDialog.Hide();

							if(isRefreshing == true)
							{
								Toast.MakeText(Activity, "Data terkini telah dimuatkan", ToastLength.Short).Show();
							}
						}
						else
						{
							recyclerAdapter.NotifyDataSetChanged();
						}
					});
				}

			}
			catch(Exception e)
			{

				Console.WriteLine ("[Tab 1 MySkool] Error while retrieving Peti Masuk data: {0}",e);

				Activity.RunOnUiThread (() => {
					tvMSkT1ErrorStatus.Visibility = ViewStates.Visible;
					recyclerView.Visibility = ViewStates.Gone;
					tvMSkT1ErrorStatus.Text = "Terdapat ralat pada akaun anda. Sila hubungi pihak PI1M untuk tindakan.";
					progressDialog.Hide();
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
			InitialSetup (page);

		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent AnnouncementDetails = new Intent (Activity, typeof(Announcement_Details));

			AnnouncementDetails.PutExtra ("ArticleTitle",mySkoolTitleList[e]);
			AnnouncementDetails.PutExtra ("ArticleContent",mySkoolContentList[e]);
			StartActivity (AnnouncementDetails);
			Activity.OverridePendingTransition (0, 0);
		}

		private string setupMySkoolData(){

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

				Activity.RunOnUiThread (() => {

					alertDialog = alertDialogBuilder.Create ();

					alertDialog.Show ();

				});



			}

			return tokenWBS;
		}

		public void exitHandler(object sender, EventArgs e)
		{
			//Activity.Finish ();
		}

		public string getMySkoolJSONData(string token, int page)
		{
			WebServices wbs = new WebServices ();
			return wbs.getMySkoolPetiMasuk (token, page);
		}

	}

	public class MySkool_ListDataHolderList
	{

		private readonly List<MySkool_ListData> mListData = new List<MySkool_ListData>();

		public MySkool_ListDataHolderList(List<MySkool_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { 
				
				return mListData.Count; 
			
			}
		}

		public MySkool_ListData this [int i]
		{
			get { return mListData[i];}
		}

	}
}

