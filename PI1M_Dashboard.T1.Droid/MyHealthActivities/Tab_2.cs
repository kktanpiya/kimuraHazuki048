
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
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using Android.Support.V4.Widget;
using System.ComponentModel;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyHealth_Tab_2 : Android.Support.V4.App.Fragment 
	{
		//private ExpandableListAdapter mExpandAdapter;
		//private ExpandableListView myList;
		//List<string> groupList;
		MyHealth_BodyWeight_ListDataHolderList listDataBW;
		MyHealth_BodyWeight_RecyclerViewAdapter recyclerAdapterBW;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		//List<MyHealth_BodyWeight_ListData> myHealthBWListData = new List<MyHealth_BodyWeight_ListData>();
		List<string> myHealthBWDateList = new List<string> ();
		List<string> myHealthBWTimeList = new List<string> ();
		List<string> myHealthBWWeightList = new List<string> ();
		List<string> myHealthBWBMIList = new List<string> ();
		List<string> myHealthBWFatList = new List<string> ();
		List<string> myHealthBWLeanWeightList = new List<string> ();
		List<string> myHealthBWBoneMassList = new List<string> ();
		List<string> myHealthBWStatusList = new List<string> ();

		LinearLayout llMHeT2ErrorLayout;
		TextView tvMHeT2ErrorStatus;

		ProgressDialog progressDialog;
		SwipeRefreshLayout mSlideRefreshLayout;

		View footerViewUL;

		string tokenWBS = "";
		int page = 1;
		int lastPage;
		public static bool isRefreshing = false;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		List<MyHealth_BodyWeight_ListData> listData = new List<MyHealth_BodyWeight_ListData> ();

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MyHealth_tab_2 ,container ,false);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerViewTakwim);
			//mListView = v.FindViewById <ListView> (Resource.Id.listViewContainer);
			//mListView = v.FindViewById <ListView> (Android.Resource.Id.List);

			llMHeT2ErrorLayout = (LinearLayout)v.FindViewById (Resource.Id.llMHeT2ErrorLayout);
			tvMHeT2ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMHeT2ErrorStatus);

			mSlideRefreshLayout = v.FindViewById<SwipeRefreshLayout> (Resource.Id.swipelayout);
			mSlideRefreshLayout.SetColorScheme (Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark, Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
			mSlideRefreshLayout.Refresh += mSlideRefreshLayout_Refresh;

			if (recyclerView != null) {
				recyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (Activity);
				var onScrollListener = new MyHealthBWRecyclerViewOnScrollListener (layoutManager);

				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					Console.Error.WriteLine ("isRefeshing" + isRefreshing);
					page++;
					if (page <= lastPage && isRefreshing == false) {
						Console.Error.WriteLine ("masuk");

						ThreadPool.QueueUserWorkItem (o => {
							setupMyHealthData (page);
						});
					}
				};
				recyclerView.AddOnScrollListener (onScrollListener);
				recyclerView.SetLayoutManager (layoutManager);
			}


			return v;
		}
			
		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			ThreadPool.QueueUserWorkItem(o => setupMyHealthData (page));

		}

		private void setupMyHealthData(int page){

			WebServices wbs = new WebServices ();

			string tokenData = Activity.Intent.GetStringExtra ("Token");

			string tokenWBSRaw = wbs.getMyHealthBWRecords(tokenData,page);

			int totalPage = 0;

			Console.WriteLine ("Raw Data: {0}",tokenWBSRaw);

			try {

				var tokenWBSjson = JsonConvert.DeserializeObject<WebServices.MyHealthBodyWeightData> (tokenWBSRaw);

				totalPage = tokenWBSjson.W_data.total;
				lastPage = tokenWBSjson.W_data.last_page;

				Console.WriteLine("[Tab 2] Total BloodPressure: {0}",totalPage);

				if(totalPage != 0)
				{
					if(isRefreshing == true){
						listData.Clear ();
					}
					
					Activity.RunOnUiThread (() => {
						llMHeT2ErrorLayout.Visibility = ViewStates.Gone;
					});

					foreach(var GetData in tokenWBSjson.W_data.data)
					{
						Console.WriteLine("[Tab2] Data MDateTime: {0}",GetData.MdateTime);
						listData.Add(new MyHealth_BodyWeight_ListData() {

							mDateTime = DateTime.ParseExact(GetData.MdateTime.ToString(), "yyyy-MM-dd HH:mm:ss", 
								CultureInfo.InvariantCulture).ToString("dd MMM. yyyy, h:mm:ss tt"),
							mWeight = float.Parse (GetData.WeightValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.###### kg"),
							mNettWeight = GetData.LeanWeight,
							mBMI = float.Parse (GetData.BMI, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######"),
							mBoneMass = float.Parse (GetData.BoneValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######"),
							mFat = float.Parse (GetData.FatValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######")+" %"

						});
						myHealthBWDateList.Add(DateTime.ParseExact(GetData.Mdatef.ToString(), "yyyy-MM-dd", 
							CultureInfo.InvariantCulture).ToString("dd MMM. yyyy"));
						myHealthBWTimeList.Add(DateTime.ParseExact(GetData.Mtimef.ToString(), "HH:mm:ss", 
							CultureInfo.InvariantCulture).ToString("h:mm:ss tt"));
						myHealthBWWeightList.Add(float.Parse (GetData.WeightValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.###### kg"));
						myHealthBWBMIList.Add(float.Parse (GetData.BMI, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######"));
						myHealthBWFatList.Add(float.Parse (GetData.FatValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######")+" %");
						myHealthBWLeanWeightList.Add(float.Parse (GetData.LeanWeight, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######"));
						myHealthBWBoneMassList.Add(float.Parse (GetData.BoneValue, CultureInfo.InvariantCulture.NumberFormat).ToString("0.######"));
						myHealthBWStatusList.Add(getBMIStatus(GetData.BMI));
					}
				}
				else
				{
					Activity.RunOnUiThread (() => {
						llMHeT2ErrorLayout.Visibility = ViewStates.Visible;
						tvMHeT2ErrorStatus.Text = "Anda belum melakukan sebarang pemeriksaan berat badan di PI1M.";
					});
				}
			}
			catch(Exception e) {

				Console.WriteLine ("[Tab_2] Error on inserting data: {0} ",e);

				string eLimit = string.Format ("{0}", e).Substring (0, 20);

				Activity.RunOnUiThread (() => {

					AlertDialog alertDialog;
					AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder (Activity);

					alertDialogBuilder
						.SetTitle ("Masalah")
					//.SetMessage (string.Format ("Maaf. Sila cuba sekali lagi ({0}...).", eLimit))
						.SetMessage (string.Format ("Tiada data ditemui. Anda mungkin belum membuat sebarang pemeriksaan berat badan di PI1M. Sila hubungi Pengurus PI1M berdekatan dengan anda untuk pertanyaan."))
						.SetCancelable (true)
						.SetPositiveButton ("OK", delegate {
							
					});

					alertDialog = alertDialogBuilder.Create ();

					alertDialog.Show ();

					llMHeT2ErrorLayout.Visibility = ViewStates.Visible;
					tvMHeT2ErrorStatus.Text = "Anda belum melakukan sebarang pemeriksaan berat badan di PI1M.";

				});

			}

			if (Activity != null) {

				Activity.RunOnUiThread (() => {
					
					if (page == 1) {
						
						listDataBW = new MyHealth_BodyWeight_ListDataHolderList (listData);

						mLayoutManager = new LinearLayoutManager (Activity);
						recyclerView.SetLayoutManager (mLayoutManager);

						recyclerAdapterBW = new MyHealth_BodyWeight_RecyclerViewAdapter (Activity, listDataBW, totalPage);
						recyclerView.SetAdapter (recyclerAdapterBW);

						recyclerAdapterBW.ItemClick += ItemClicked;

					} else {
						
						recyclerAdapterBW.NotifyDataSetChanged ();

					}

				});

			}
			//return listData;
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
			recyclerAdapterBW.NotifyDataSetChanged ();
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
			setupMyHealthData (page);

		}

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent MyHealthBWDetails = new Intent (Activity, typeof(BWDetails));

			MyHealthBWDetails.PutExtra ("MHBWDate",myHealthBWDateList[e]);
			MyHealthBWDetails.PutExtra ("MHBWTime",myHealthBWTimeList[e]);
			MyHealthBWDetails.PutExtra ("MHBWWeight",myHealthBWWeightList[e]);
			MyHealthBWDetails.PutExtra ("MHBWBMI",myHealthBWBMIList[e]);
			MyHealthBWDetails.PutExtra ("MHBWFat",myHealthBWFatList[e]);
			MyHealthBWDetails.PutExtra ("MHBWLeanWeight",myHealthBWLeanWeightList[e]);
			MyHealthBWDetails.PutExtra ("MHBWBoneMass",myHealthBWBoneMassList[e]);
			MyHealthBWDetails.PutExtra ("MHBWStatus",myHealthBWStatusList[e]);
			StartActivity (MyHealthBWDetails);
			Activity.OverridePendingTransition (0, 0);
		}

		private string getBMIStatus(string BMIValue)
		{
			float BMIConvert = float.Parse (BMIValue, CultureInfo.InvariantCulture.NumberFormat);
			Console.WriteLine ("[GetBMIStatus] BMIConverted: {0}",BMIConvert);
			if (BMIConvert <= 18.50) {
				return "Kurang Berat";
			}
			else if (BMIConvert <= 24.99) {
				return "Normal";
			}
			else if (BMIConvert <= 29.99) {
				return "Lebih Berat";
			}
			else if (BMIConvert >= 30.00) {
				return "Obesiti";
			}
			else {
				return "Tidak Diketahui";
			}
		}
	}
}

