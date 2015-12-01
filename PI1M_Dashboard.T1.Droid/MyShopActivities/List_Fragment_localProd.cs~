using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Newtonsoft.Json;
using drawer_navigation;
using Square.Picasso;
using System.Threading;
using System.Threading.Tasks;
using PI1M_Dashboard.T1.Droid;

namespace drawer_navigation
{
	public class List_Fragment_localProd : Android.Support.V4.App.Fragment
	{
		Activity context;
		private RecyclerView mRecyclerView;
		RecyclerView.LayoutManager mLayoutManager;
		private LocalProd_RecyclerViewAdapter recyclerAdapter;

		private static List<MyShop_WebService.Localprod_Datum> prodList = new List<MyShop_WebService.Localprod_Datum>();

		int currentPage;
		int lastPage;
		static int  totalItem;

		LinearLayout llMyShopErrorLayout;
		public List_Fragment_localProd (Activity Context)
		{
			this.context = Context;
		}

		ProgressBar progressBar;
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			if (mRecyclerView != null) {
				mRecyclerView.HasFixedSize = true;

				var layoutManager = new LinearLayoutManager (context);

				var onScrollListener = new LocalProd_RecyclerViewAdapter.ViewOnScrollListener (layoutManager);
				onScrollListener.LoadMoreEvent += (object sender, EventArgs e) => {
					currentPage++;
					if (currentPage <= lastPage ) {
						ThreadPool.QueueUserWorkItem (o => { setupData (currentPage); });
					}
				};
				mRecyclerView.AddOnScrollListener (onScrollListener);
				mRecyclerView.SetLayoutManager (layoutManager);
			}

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v;
			//set currentpage to 1
			currentPage = 1;
			ThreadPool.QueueUserWorkItem (o => { setupData (currentPage); });

			v = inflater.Inflate(Resource.Layout.MyShop_listall_fragment_list ,container ,false);
			mRecyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);
			progressBar = v.FindViewById <ProgressBar> (Resource.Id.pbHeaderProgress);
			llMyShopErrorLayout = (LinearLayout)v.FindViewById (Resource.Id.llMyShopErrorLayout);

			return v;
		}

		private void setupData(int page)
		{
			try{
				
				var jsonString = MyShop_WebService.GetJsonLocalProduct (MyShop_Tab_1.token_dashboard,page);
				var ProdData = JsonConvert.DeserializeObject<MyShop_WebService.Root_Localprod> (jsonString);
				lastPage = ProdData.last_page;
				totalItem = ProdData.total;
				foreach (var tempData in ProdData.data) {
					prodList.Add (new MyShop_WebService.Localprod_Datum () {
						id = tempData.id,
						title = tempData.title,
						price = "RM "+tempData.price,
						created_at = tempData.created_at,
						url_photo_thumb = tempData.url_photo_thumb,
					});
				}


				context.RunOnUiThread (() => {
					if (currentPage == 1) {
						mLayoutManager = new LinearLayoutManager (Activity);
						mRecyclerView.SetLayoutManager (mLayoutManager);

						recyclerAdapter = new LocalProd_RecyclerViewAdapter (Activity);
						mRecyclerView.SetAdapter (recyclerAdapter);

						progressBar.Visibility = ViewStates.Gone;
					}
					else{
						recyclerAdapter.NotifyDataSetChanged ();
					}
				});
			}
			catch(Exception ex){
				Activity.RunOnUiThread (() => {
					llMyShopErrorLayout.Visibility = ViewStates.Visible;
					progressBar.Visibility = ViewStates.Gone;
				});
			}

		}

		public class LocalProd_RecyclerViewAdapter : RecyclerView.Adapter
		{
			TypedValue typedValue = new TypedValue();
			int background;
			Android.App.Activity parent;

			public class LocalProd_ViewHolder : RecyclerView.ViewHolder
			{
				public string BoundString{ get; set;}
				public View View { get; set;}
				public ImageView ImageView { get; set;}
				public TextView txtPrice { get; set;}
				public TextView txtProdName { get; set;}
				public TextView txtProdDate { get; set;}

				public LocalProd_ViewHolder (View view) : base (view)
				{
					View =  view;
					ImageView = view.FindViewById<ImageView>(Resource.Id.prodImage);
					txtPrice = view.FindViewById<TextView>(Resource.Id.txtPrice);
					txtProdName = view.FindViewById<TextView>(Resource.Id.txtProdName);
					txtProdDate = view.FindViewById<TextView>(Resource.Id.txtProdDate);

				}
			}

			public class ProgressViewHolder : RecyclerView.ViewHolder
			{
				public ProgressBar progressBar { get; private set; }

				public ProgressViewHolder (View itemView) : base (itemView)
				{
					progressBar = itemView.FindViewById <ProgressBar> (Resource.Id.progress_bar);

				}
			}
				
			public LocalProd_RecyclerViewAdapter (Android.App.Activity context)
			{
				parent = context;
				context.Theme.ResolveAttribute (Resource.Attribute.selectableItemBackground,typedValue, true);
				background = typedValue.ResourceId;
			}

			protected class VIEW_TYPES {
				public static  int NORMAL = 0;
				public static  int FOOTER = 1;
				public static  int ENDOFLIST = 2;

			}

			public override int GetItemViewType (int position)
			{
				int type=-1;

				if (position < prodList.Count - 1) {
					type = 0;
				} else if (totalItem == prodList.Count) {
					type = 2;

				} else if (position == prodList.Count - 1) {
					type = 1;
				}
				return type;
			}

			public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
			{
				RecyclerView.ViewHolder vh;
				if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				var view = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyShop_listall_item, parent, false);
					view.SetBackgroundResource (background);
					return new LocalProd_ViewHolder (view);
				}
				else {
					View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyShop_btmProgressbar, parent, false);
					vh = new ProgressViewHolder (itemView);

					return vh;
				}
			}

			public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
			{
				if (holder.GetType () == typeof(LocalProd_ViewHolder)) {

					DateTime dt = Convert.ToDateTime (prodList [position].created_at);
					string ProdDate = dt.ToString ("MMM dd, yyyy");

					var h = holder as LocalProd_ViewHolder;
					h.txtPrice.Text = prodList [position].price;
					h.txtProdName.Text = prodList [position].title;
					h.txtProdDate.Text = ProdDate;
					h.View.SetTag (Resource.Id.recyclerView, Int32.Parse (prodList [position].id));
					h.View.Click += Product_Click;

					PicassoSetImage (prodList [position].url_photo_thumb, h.ImageView, h);
				}
			}

			public override void OnViewRecycled (Java.Lang.Object holder)
			{
				if (holder.GetType () == typeof(LocalProd_ViewHolder)) {

					var h = holder as LocalProd_ViewHolder;

					//untuk clear balik += time mula2 declare
					h.View.Click -= Product_Click;

					Log.Debug ("Recycled Debug", "OnViewRecycled entered...");
					base.OnViewRecycled (holder);
				}
			}

			public override int ItemCount
			{
				get { return prodList.Count; }
			}


			public void Product_Click (object sender, EventArgs e)
			{
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (parent, typeof(Product_Details));
				intent.PutExtra("product_id", product_id);
				parent.StartActivity (intent);

			}

			public void PicassoSetImage(string url, ImageView poster, RecyclerView.ViewHolder holder)
			{
				//Picasso handling image from api url
				Picasso.With (parent)
					.Load (url)
					.Into(poster);
			}

			public class  ViewOnScrollListener : RecyclerView.OnScrollListener
			{
				public delegate void LoadMoreEventHandler(object sender, EventArgs e);
				public event LoadMoreEventHandler LoadMoreEvent;

				private LinearLayoutManager LayoutManager;

				public ViewOnScrollListener (LinearLayoutManager layoutManager)
				{
					LayoutManager = layoutManager;
				}

				public override void OnScrolled (RecyclerView recyclerView, int dx, int dy)
				{
					base.OnScrolled (recyclerView, dx, dy);

					var visibleItemCount = recyclerView.ChildCount;

					var totalItemCount = recyclerView.GetAdapter().ItemCount;
					var lastVisibleItem = ((LinearLayoutManager)recyclerView.GetLayoutManager()).FindLastCompletelyVisibleItemPosition();

					if ((lastVisibleItem+1) == totalItemCount) {
						LoadMoreEvent (this, null);
					}
				}
			}
		}
	}
}

