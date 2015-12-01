
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
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using Android.Support.V4.Widget;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyHealth_Tab_1 : Android.Support.V4.App.Fragment 
	{
		MyHealth_BloodPressure_ListDataHolderList listDataHL;
		MyHealth_BloodPressure_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		List<string> myHealthDateList = new List<string> ();
		List<string> myHealthTimeList = new List<string> ();
		List<string> myHealthPulseList = new List<string> ();
		List<string> myHealthBPMList = new List<string> ();
		List<string> myHealthStatusList = new List<string> ();

		LinearLayout llMHeT1ErrorLayout;
		TextView tvMHeT1ErrorStatus;

		ProgressDialog progressDialog;
		SwipeRefreshLayout mSlideRefreshLayout;

		View footerViewUL;

		string tokenWBS = "";
		int page = 1;
		int lastPage;
		public static bool isRefreshing = false;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		List<MyHealth_BloodPressure_ListData> listData = new List<MyHealth_BloodPressure_ListData> ();

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MyHealth_tab_1 ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);

			progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			llMHeT1ErrorLayout = (LinearLayout)v.FindViewById (Resource.Id.llMHeT1ErrorLayout);
			tvMHeT1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMHeT1ErrorStatus);

			tvMHeT1ErrorStatus.Text = "Sedang memeriksa data...";

			mSlideRefreshLayout = v.FindViewById<SwipeRefreshLayout> (Resource.Id.swipelayout);
			mSlideRefreshLayout.SetColorScheme (Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark, Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
			mSlideRefreshLayout.Refresh += mSlideRefreshLayout_Refresh;

			if (recyclerView != null) {
				recyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (Activity);
				var onScrollListener = new MyHealthRecyclerViewOnScrollListener (layoutManager);

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

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			ThreadPool.QueueUserWorkItem (o => { setupMyHealthData (page); });

		}

		private void setupMyHealthData(int page){

			WebServices wbs = new WebServices ();

			string tokenData = Activity.Intent.GetStringExtra ("Token");

			string tokenWBSRaw = wbs.getMyHealthBPRecords(tokenData,page);

			int totalPage = 0;


			Console.WriteLine ("Raw Data: {0}",tokenWBSRaw);

			try {

				var tokenWBSjson = JsonConvert.DeserializeObject<WebServices.MyHealthBloodPressureData> (tokenWBSRaw);

				totalPage = tokenWBSjson.BP_data.total;
				lastPage = tokenWBSjson.BP_data.last_page;

				if (totalPage != 0)
				{
					if(isRefreshing == true){
						listData.Clear ();
					}
					
					foreach(var GetData in tokenWBSjson.BP_data.data)
					{
						Console.WriteLine("[Tab2] Data MDateTime: {0}",GetData.MdateTime);
						myHealthDateList.Add(GetData.Mdatef);
						myHealthTimeList.Add(GetData.Mtimef);
						myHealthPulseList.Add(GetData.HR);
						myHealthBPMList.Add(GetData.HP+" / "+GetData.LP+" "+GetData.BPUnitText);
						myHealthStatusList.Add(setStatus(GetData.color));
						listData.Add(new MyHealth_BloodPressure_ListData() {

							mDateTime = DateTime.ParseExact(GetData.MdateTime.ToString(), "yyyy-MM-dd HH:mm:ss", 
								CultureInfo.InvariantCulture
							).ToString("dd MMM. yyyy, h:mm:ss tt"),
							mPressure = GetData.HP+" / "+GetData.LP+" "+GetData.BPUnitText,
							mPulse = GetData.HR+" BPM",
							mBgColor = "#FF"+GetData.color,
							mStatus = setStatus(GetData.color)

						});
					}

					Activity.RunOnUiThread (() => {
						llMHeT1ErrorLayout.Visibility = ViewStates.Gone;
						progressDialog.Hide();
					});
				}
				else
				{
					Activity.RunOnUiThread (() => {
						llMHeT1ErrorLayout.Visibility = ViewStates.Visible;
						tvMHeT1ErrorStatus.Text = "Anda belum membuat sebarang pemeriksaan tekanan darah di PI1M.";
						progressDialog.Hide();
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
						.SetMessage (string.Format ("Tiada data ditemui. Anda mungkin belum membuat sebarang pemeriksaan tekanan darah di PI1M. Sila hubungi Pengurus PI1M berdekatan dengan anda untuk pertanyaan."))
						.SetCancelable (true)
						.SetPositiveButton ("OK", delegate {
							
					});

					alertDialog = alertDialogBuilder.Create ();

					alertDialog.Show ();

					llMHeT1ErrorLayout.Visibility = ViewStates.Visible;
					tvMHeT1ErrorStatus.Text = "Anda belum membuat sebarang pemeriksaan tekanan darah di PI1M.";

				});

			}

			if (Activity != null) {

				Activity.RunOnUiThread (() => {
					if (page == 1) {
						listDataHL = new MyHealth_BloodPressure_ListDataHolderList (listData);

						mLayoutManager = new LinearLayoutManager (Activity);
						recyclerView.SetLayoutManager (mLayoutManager);

						recyclerAdapter = new MyHealth_BloodPressure_RecyclerViewAdapter (Activity, listDataHL, totalPage);
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
			setupMyHealthData (page);

		}

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}

		public string setStatus(string hexColor)
		{
			if (hexColor == "699A2D") {
				return "Optimal";
			} else if (hexColor == "98CE60") {
				return "Normal";
			} else if (hexColor == "FFCD00") {
				return "Tinggi-Normal";
			} else if (hexColor == "FF8000") {
				return "Gred 1 Hipertensi";
			} else if (hexColor == "E63E00") {
				return "Gred 2 Hipertensi";
			} else {
				// if (hexColor == "9B0000")
				return "Gred 3 Hipertensi";
			}
		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent MyHealthDetails = new Intent (Activity, typeof(BPDetails));

			MyHealthDetails.PutExtra ("MHBPDate",myHealthDateList[e]);
			MyHealthDetails.PutExtra ("MHBPTime",myHealthTimeList[e]);
			MyHealthDetails.PutExtra ("MHBPPulse",myHealthPulseList[e]);
			MyHealthDetails.PutExtra ("MHBPBPM",myHealthBPMList[e]);
			MyHealthDetails.PutExtra ("MHBPStatus",myHealthStatusList[e]);
			StartActivity (MyHealthDetails);
			Activity.OverridePendingTransition (0, 0);
		}

	}
}

