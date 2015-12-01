
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Widget;
using Android.Util;
using Android.Views;
using System.Threading;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using System;
using System.Threading.Tasks;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{
	[Activity (Label = "MyVote")]			
	public class MyVote_MainActivityPO : Android.Support.V7.App.AppCompatActivity
	{
		private MyVoteMAPOAdapter mVoteAdapter;

		private RecyclerView mRecyclerView;
		private MyVote_VerifyVoteButton myVoteVerify;
		public View imageHeader { get; set;}

		ProgressDialog progressDialog;
		private static MyVote_Data myvote_Data;
		private static int vote_value;

		int page = 1;
		bool isRefeshing=false;
		private List<dummyData> mVoteData;


		LinearLayout llMyPosterErrorLayout;
		TextView tvMyPosterErrorLayout;

		private int lastPage;
		private int totalItem;
		protected  override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MyVote_Main);

			progressDialog = ProgressDialog.Show (this, "Sila Tunggu", "Sedang Memuatkan...");

			//initiliaze jsonvalue
//			MyVote_Data myVoteData = new MyVote_Data();

			mRecyclerView = FindViewById <RecyclerView> (Resource.Id.recyclerView);
			var toolbar = FindViewById <Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			var mLayoutManager = new LinearLayoutManager (this);

			mRecyclerView.SetLayoutManager (mLayoutManager);

			//error layout
			llMyPosterErrorLayout = (LinearLayout)FindViewById (Resource.Id.llMyPosterErrorLayout);
			tvMyPosterErrorLayout = (TextView)FindViewById (Resource.Id.tvMyPosterErrorLayout);

			setupMyVoteData (page);


			if (mRecyclerView != null ) {
				mRecyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (this);

				var onScrollListener = new MyVote.MyVoteMAPOAdapter.MyvoteRecyclerViewOnScrollListener (layoutManager);
				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					page++;
					lastPage=MyVote_Data.getLastPage ();
					if (page <= lastPage && isRefeshing == false) {
						ThreadPool.QueueUserWorkItem (o => {
							setupMyVoteData (page);
						});
					}
				};

				mRecyclerView.AddOnScrollListener (onScrollListener);
				mRecyclerView.SetLayoutManager (layoutManager);
			}
		}
			
		public void setupMyVoteData(int page){

			if (this != null) {
					if (page == 1) {

						ThreadPool.QueueUserWorkItem ( o =>{
							mVoteData=MyVote_Data.GetVoteData(page);
							
							int totalItem=MyVote_Data.getTotalItem();

							if(mVoteData.Count != 0){
								mVoteAdapter = new MyVoteMAPOAdapter (this, mVoteData, totalItem);
								RunOnUiThread (() => mRecyclerView.SetAdapter (mVoteAdapter));

							}
							else{
								this.RunOnUiThread (() => {
									llMyPosterErrorLayout.Visibility = ViewStates.Visible;
								});
							}
							RunOnUiThread (() =>progressDialog.Dismiss ());

						});
					} else {

						ThreadPool.QueueUserWorkItem ( o =>{
							mVoteData.AddRange(MyVote_Data.GetVoteData(page));

							Console.WriteLine ("sizeeeeeeeeee{0}", mVoteData.Count);
							RunOnUiThread (() => mVoteAdapter.NotifyDataSetChanged ());

						});
					}
			}

		}

		public override void OnBackPressed ()
		{
			int count = FragmentManager.BackStackEntryCount;

			if (count == 0)
				base.OnBackPressed ();
			else
				FragmentManager.PopBackStack ();
		}


	}
}

