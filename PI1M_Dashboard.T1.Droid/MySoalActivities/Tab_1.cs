
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
using com.refractored.fab;
using Newtonsoft.Json;
using Android.Text;
using System.Threading;
using Android.Support.V4.Widget;
using System.ComponentModel;

namespace PI1M_Dashboard.T1.Droid
{
	public class MySoal_Tab_1 : Android.Support.V4.App.Fragment 
	{
		MySoal_PetiMasuk_ListDataHolderList listData;
		MySoal_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		LinearLayout llMST1ErrorLayout;
		TextView tvMST1ErrorStatus;

		List<MySoal_PetiMasuk_ListData> mySoalListData = new List<MySoal_PetiMasuk_ListData>();
		List<string> mySoalTitleList = new List<string> ();
		List<string> mySoalContentList = new List<string> ();

		ProgressDialog progressDialog;
		SwipeRefreshLayout mSlideRefreshLayout;

		View footerViewUL;

		string tokenWBS = "";
		int page = 1;
		int lastPage;
		public static bool isRefreshing = false;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			View v = inflater.Inflate(Resource.Layout.MySoal_tab_1 ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);

			llMST1ErrorLayout = (LinearLayout)v.FindViewById (Resource.Id.llMST1ErrorLayout);
			tvMST1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMST1ErrorStatus);

			footerViewUL = ((LayoutInflater)Activity.GetSystemService (Context.LayoutInflaterService)).Inflate (Resource.Layout.MySoal_ReadMoreLayout, null, false);

			mSlideRefreshLayout = v.FindViewById<SwipeRefreshLayout> (Resource.Id.swipelayout);
			mSlideRefreshLayout.SetColorScheme (Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark, Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
			mSlideRefreshLayout.Refresh += mSlideRefreshLayout_Refresh;

			if (recyclerView != null) {
				recyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (Activity);
				var onScrollListener = new MySoalRecyclerViewOnScrollListener (layoutManager);

				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					Console.Error.WriteLine ("isRefeshing" + isRefreshing);
					page++;
					if (page <= lastPage && isRefreshing == false) {
						Console.Error.WriteLine ("masuk");

						ThreadPool.QueueUserWorkItem (o => {
							InitialProgress (page);
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

			progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			ThreadPool.QueueUserWorkItem(o => InitialProgress (page));

			//Compose Message Button (Floating Button)
			/*
			var fab = Activity.FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.AttachToRecyclerView(recyclerView);
			//fab.SetBackgroundResource (Android.Resource.Drawable.);
			fab.Click += (sender, e) => {
				Intent composeMsgIntent = new Intent(Activity.ApplicationContext,typeof(ComposeMsg));
				composeMsgIntent.PutExtra("UserEmail",Activity.Intent.GetStringExtra("Email"));
				composeMsgIntent.PutExtra("MySoalToken",tokenWBS);
				composeMsgIntent.PutExtra("SiteCode", Activity.Intent.GetStringExtra ("SiteCode"));
				Activity.StartActivity(composeMsgIntent); 
			};
			*/

		}

		private void InitialProgress(int page)
		{

			try {

				string mySoalToken = setupMySoalData ();
				string mySoalRawData = getMySoalPetiMasukJSONData(mySoalToken.ToString(), page);
				WebServices.MySoalPetiMasukRObj mySoalJSONed = JsonConvert.DeserializeObject<WebServices.MySoalPetiMasukRObj> (mySoalRawData);

				int totalPage = 0;

				Console.WriteLine ("[MySoal - Peti Masuk] Raw Data MySoal: {0}",mySoalRawData);

				foreach (var mySoalPaging in mySoalJSONed.paging) {
					Console.WriteLine ("[MySoal - Peti Masuk] Paging: {0}",mySoalPaging.count);
					totalPage = mySoalPaging.count;
					lastPage = mySoalPaging.pageCount;
				}

				if (totalPage != 0) {

					if(isRefreshing==true){
						mySoalListData.Clear ();	
					}

					Activity.RunOnUiThread (() => {
						llMST1ErrorLayout.Visibility = ViewStates.Gone;
						recyclerView.Visibility = ViewStates.Visible;
					});
					/*
					mySoalListData.Add (new MySoal_PetiMasuk_ListData () { 
						mTitle = "Gangguan Bekalan Air", 
						mContent = "Sila sedia maklum bahawa kawasan Felda Mat Daling akan mengalami gangguan bekalan air."
					});

					mySoalListData.Add (new MySoal_PetiMasuk_ListData () { 
						mTitle = "Ancaman Binatang Buas", 
						mContent = "Pihak berkuasa sedang mencari kaedah untuk menyelesaikan masalah tersebut."
					});

					mySoalListData.Add (new MySoal_PetiMasuk_ListData () { 
						mTitle = "Kebakaran Hutan",
						mContent = "Laporan berkenaan kebakaran hutan telah diterima dan sedang disiasat."
					});
					*/

					int count = 0;
					string content = "";

					foreach (var jsonedMySoal in mySoalJSONed.mail) {

						//string contentParsed = jsonedMySoal.content.Replace("s/<(.*?)>//g","");
						//Console.WriteLine ("[Tab1] Parsed: {0}",contentParsed);

						try{

							count = Html.FromHtml (jsonedMySoal.content).ToString().Count(char.IsLetter);

							Console.WriteLine ("[Tab 1] Counted: {0}",count);

							if(count <= 100)
							{
								content = Html.FromHtml(jsonedMySoal.content).ToString();
							}
							else
							{
								content = Html.FromHtml(jsonedMySoal.content).ToString().Substring(0,100)+"...";
							}

							mySoalListData.Add (new MySoal_PetiMasuk_ListData () { 
								mTitle = jsonedMySoal.title, 
								mContent = content
							});

							mySoalTitleList.Add (jsonedMySoal.title);
							mySoalContentList.Add (jsonedMySoal.content);

						}catch(Exception e){

							Console.WriteLine ("[Tab1 MySoal] Error on adding data: {0}",e);

						}


					}
					/*
					Activity.RunOnUiThread (() => {

						listData = new MySoal_PetiMasuk_ListDataHolderList (mySoalListData);

						mLayoutManager = new LinearLayoutManager (Activity);
						recyclerView.SetLayoutManager (mLayoutManager);


						recyclerAdapter = new MySoal_RecyclerViewAdapter (Activity, listData);
						recyclerView.SetAdapter (recyclerAdapter);
						//recyclerView.AddView(footerViewUL);

						recyclerAdapter.ItemClick += ItemClicked;

						progressDialog.Hide();
					});
					*/
					if (Activity != null) {

						Activity.RunOnUiThread (() => {
							if (page == 1) {

								listData = new MySoal_PetiMasuk_ListDataHolderList (mySoalListData);

								mLayoutManager = new LinearLayoutManager (Activity);
								recyclerView.SetLayoutManager (mLayoutManager);

								recyclerAdapter = new MySoal_RecyclerViewAdapter (Activity, listData, totalPage);
								recyclerView.SetAdapter (recyclerAdapter);
								//recyclerView.AddView(footerViewUL);

								recyclerAdapter.ItemClick += ItemClicked;

								progressDialog.Hide ();

								//if is refresing only toast
								if (isRefreshing == true) { 
									Toast.MakeText (Activity, "Data terkini telah dimuatkan..", ToastLength.Short).Show ();
								}

							} else {
								recyclerAdapter.NotifyDataSetChanged ();
							}
						});
					}

				} else {

					Activity.RunOnUiThread (() => {
						llMST1ErrorLayout.Visibility = ViewStates.Visible;
						recyclerView.Visibility = ViewStates.Gone;
						tvMST1ErrorStatus.Text = "Tiada maklumat tersedia buat masa ini.";
						progressDialog.Hide();
					});
				}
			}
			catch(Exception e)
			{
				
				Console.WriteLine ("[Tab 1 MySoal] Error while retrieving Peti Masuk data: {0}",e);

				Activity.RunOnUiThread (() => {
					llMST1ErrorLayout.Visibility = ViewStates.Visible;
					recyclerView.Visibility = ViewStates.Gone;
					tvMST1ErrorStatus.Text = "Terdapat ralat pada akaun anda. Sila hubungi pihak PI1M untuk tindakan.";
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
			InitialProgress (page);

		}

		private void ItemClicked(object sender, int e)
		{
			//Toast.MakeText (Activity, "Position is "+e, ToastLength.Short).Show();
			Intent PetiMasukDetails = new Intent (Activity, typeof(PetiMasuk_Details));
			PetiMasukDetails.PutExtra ("PMDTitle", mySoalTitleList[e]);
			PetiMasukDetails.PutExtra ("PMDContent", mySoalContentList[e]);
			StartActivity (PetiMasukDetails);
			Activity.OverridePendingTransition (0, 0);
		}

		private string setupMySoalData(){

			WebServices wbs = new WebServices ();

			string tokenData = Activity.Intent.GetStringExtra ("Token");

			Console.WriteLine ("[MySoal - Peti Masuk] Token from Dashboard: {0}",tokenData);

			string tokenWBSRaw = wbs.setMySoalAuth(tokenData);

			tokenWBS = "";

			try {

				var tokenWBSjson = JsonConvert.DeserializeObject<WebServices.mySoalAuthToken> (tokenWBSRaw);

				tokenWBS = tokenWBSjson.token.ToString();

				Console.WriteLine ("[MySoal - Peti Masuk] Token Retrieved: {0}",tokenWBS);

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

		public string getMySoalPetiMasukJSONData(string token, int page)
		{
			WebServices wbs = new WebServices ();
			return wbs.getMySoalPetiMasuk (token, page);
		}

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}
			
	}

	public class MySoal_PetiMasuk_ListDataHolderList
	{

		private readonly List<MySoal_PetiMasuk_ListData> mListData = new List<MySoal_PetiMasuk_ListData>();

		public MySoal_PetiMasuk_ListDataHolderList(List<MySoal_PetiMasuk_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { 

				return mListData.Count; 

			}
		}

		public MySoal_PetiMasuk_ListData this [int i]
		{
			get { return mListData[i];}
		}

	}

	public class MySoal_PetiMasuk_ListDataHolder
	{
		MySoal_PetiMasuk_ListData[] listData = { 
			new MySoal_PetiMasuk_ListData { 
				mTitle = "Aduan Jalan Raya",
				mContent = "Kami menerima aduan daripada pihak anda dan akan diselesaikan dalam masa terdekat. Terima kasih."
			},
			new MySoal_PetiMasuk_ListData { 
				mTitle = "Permohonan Membaiki Jalan", 
				mContent = "Permohonan anda sedang diproses dan akan mengambil masa dua hingga tiga hari bekerja." 
			},
			new MySoal_PetiMasuk_ListData { 
				mTitle = "Gangguan Bekalan Air", 
				mContent = "Dimaklumkan bahawa gangguan bekalan air akan berlaku di beberapa tempat di kawasan anda." },
			new MySoal_PetiMasuk_ListData { 
				mTitle = "Penambahan Lampu-lampu Jalan", 
				mContent = "Kawasan anda akan mendapat penambahan beberapa lampu jalan demi keselamatan para penduduk." 
			},
		};

		private readonly MySoal_PetiMasuk_ListData[] mListData;

		public MySoal_PetiMasuk_ListDataHolder()
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { return mListData.Length; }
		}

		public MySoal_PetiMasuk_ListData this [int i]
		{
			get { return mListData[i];}
		}
	}
}

