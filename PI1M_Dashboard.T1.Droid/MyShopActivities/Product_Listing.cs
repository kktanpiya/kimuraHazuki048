using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Support.V4.View;
using System.Threading.Tasks;
using PI1M_Dashboard.T1.Droid;
using Android.Support.V7.Widget;

namespace drawer_navigation
{
	[Activity (Label = "")]																																
	public class Product_Listing : AppCompatActivity
	{        
		DrawerLayout drawerLayout;

		private  List<MyShop_WebService.Localprod_Datum> prodList = new List<MyShop_WebService.Localprod_Datum>();
		ProgressBar progressBar;
		private RecyclerView mRecyclerView;

		int currentPage;
		int lastPage;

		RecyclerView.LayoutManager mLayoutManager;
		public Product_RecyclerViewAdapter recyclerAdapter;

		LinearLayout llMyShopErrorLayout;

		protected override void OnCreate(Bundle savedInstanceState) 
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.MyShop_listall_fragment_list);

			CoordinatorLayout cl = FindViewById <CoordinatorLayout> (Resource.Id.main_content);

			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#9C27B0"));


			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowHomeEnabled (true);

			mRecyclerView = FindViewById <RecyclerView> (Resource.Id.recyclerView);
			progressBar = FindViewById <ProgressBar> (Resource.Id.pbHeaderProgress);
			llMyShopErrorLayout = (LinearLayout)FindViewById (Resource.Id.llMyShopErrorLayout);

			currentPage = 1; 

			string action_type = Intent.GetStringExtra ("action_type");

			ThreadPool.QueueUserWorkItem (o => { setupData(currentPage , action_type); });

			if (mRecyclerView != null) {
				mRecyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (this);

				var onScrollListener = new Product_RecyclerViewAdapter.ViewOnScrollListener (layoutManager);
				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					currentPage++;
					if (currentPage <= lastPage) {
						ThreadPool.QueueUserWorkItem (o => { setupData (currentPage , action_type); });
					}
				};
				mRecyclerView.AddOnScrollListener (onScrollListener);
				mRecyclerView.SetLayoutManager (layoutManager);
			}

			//			var fab = FindViewById<FloatingActionButton> (Resource.Id.fab);
			//			fab.Click += (sender, e) => {
			//					Snackbar.Make (fab, "Here's a snackbar!", Snackbar.LengthLong).SetAction ("Action",
			//						new ClickListener (v => {
			//							Console.WriteLine ("Action handler");
			//						})).Show ();
			//		
			//
			//			}; 
		}
			
		public override bool OnOptionsItemSelected (IMenuItem item) 
		{
//			switch (item.ItemId) {
//			case Android.Resource.Id.Home:
//				drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
//				return true;
//			}
//			return base.OnOptionsItemSelected (item);
			switch (item.ItemId) {

			case Android.Resource.Id.Home:
				this.Finish ();
				this.OverridePendingTransition (0, 0);
				return true;

			default:
				return base.OnOptionsItemSelected (item);

			}

		}

		private void setupData(int page, string action_type)
		{
			try{

				string jsonString = "";

				string searchTerm = Intent.GetStringExtra ("search_term");

				switch(action_type)
				{
					case "popular"    : jsonString = MyShop_WebService.GetJsonPopularProduct (page);
								  	  break;
					case "latest"	  : jsonString = MyShop_WebService.GetJsonLatestProduct (page);
									  break;
					case "review"     : jsonString = MyShop_WebService.GetJsonReviewProduct (page);
						              break ;
					case "search"     : jsonString = MyShop_WebService.getSearchResult (searchTerm, page);
									  break ;
//					case "local"    : jsonString = MyShop_WebService.GetJsonLocalProduct (MyShop_Tab_1.token_dashboard,page);
//										  break ;
				}

				var ProdData = JsonConvert.DeserializeObject<MyShop_WebService.Root_Localprod> (jsonString);
				lastPage = ProdData.last_page;
				var totalItem = ProdData.total;

				foreach (var tempData in ProdData.data) {
					prodList.Add (new MyShop_WebService.Localprod_Datum () {
						id = tempData.id,
						title = tempData.title,
						price = "RM "+tempData.price,
						created_at = tempData.created_at,
						url_photo_thumb = tempData.url_photo_thumb,
					});
				}


				this.RunOnUiThread (() => {
					if (currentPage == 1) {
						mLayoutManager = new LinearLayoutManager (this);
						mRecyclerView.SetLayoutManager (mLayoutManager);

						recyclerAdapter = new Product_RecyclerViewAdapter (this, prodList, totalItem);
						mRecyclerView.SetAdapter (recyclerAdapter);

						progressBar.Visibility = ViewStates.Gone;

					}
					else{
						recyclerAdapter.NotifyDataSetChanged ();

					}
				});
			}
			catch(Exception ex){
				this.RunOnUiThread (() => {
					llMyShopErrorLayout.Visibility = ViewStates.Visible;
					progressBar.Visibility = ViewStates.Gone;
				});
			}
		
		}
	}

	public class ClickListener : Java.Lang.Object, View.IOnClickListener
	{
		public ClickListener (Action<View> handler)
		{
			Handler = handler;
		}

		public Action<View> Handler { get; set; }

		public void OnClick (View v)
		{
			var h = Handler;
			if (h != null)
				h (v);
		}
	} 
}


