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
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using PI1M_Dashboard.T1.Droid;
using Newtonsoft.Json;
using Square.Picasso;

namespace myShop
{
	[Activity (Label = "MyshopMain",MainLauncher = true)]			
	public class MyShopMain : AppCompatActivity
	{
		public const string EXTRA_NAME = "BabyMetal_Death";
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.ProdukMain);
			var BabyMetalDeath = Intent.GetStringExtra (EXTRA_NAME);
			var toolbar = FindViewById<V7Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

//			var collapsingToolbar = FindViewById<CollapsingToolbarLayout> (Resource.Id.collapsing_toolbar);
//			collapsingToolbar.SetTitle (BabyMetalDeath);
//			loadBackdrop ();

			PopularProdSetup ();
		}
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) 
			{
			case Android.Resource.Id.Home:
				Finish ();
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}
//		void loadBackdrop()
//		{
//			var imageView = FindViewById<ImageView> (Resource.Id.backdrop);
//			var random = Pictures.GetRandomBackground ();
//			imageView.SetImageResource (random);
//		}
//		public override bool OnCreateOptionsMenu (IMenu menu)
//		{
//			MenuInflater.Inflate (Resource.Menu.sample_actions, menu);
//			return true;
//		}

		private void setupImage(ImageView image, string url){

			Picasso.With (MyVote.Const.context)
				.Load (url)
				.Placeholder (Resource.Drawable.placeholder_poster)
				.Into(image);
		}

		private void PopularProdSetup()
		{
			List<string> popularProdPrice = new List<string> ();
			List<string> popularProdName = new List<string> ();
			List<string> popularProdImage = new List<string> ();
			List<int> popularProdID = new List<int> ();

			TextView tvMST1PPTile1ProdPrice = (TextView)FindViewById (Resource.Id.tvMST1PPTile1ProdPrice);
			TextView tvMST1PPTile1ProdName = (TextView)FindViewById (Resource.Id.tvMST1PPTile1ProdName);
			ImageView ivMST1PPTile1ProdPic = (ImageView)FindViewById (Resource.Id.ivMST1PPTile1ProdPic);
			TextView tvMST1PPTile2ProdPrice = (TextView)FindViewById (Resource.Id.tvMST1PPTile2ProdPrice);
			TextView tvMST1PPTile2ProdName = (TextView)FindViewById (Resource.Id.tvMST1PPTile2ProdName);
			ImageView ivMST1PPTile2ProdPic = (ImageView)FindViewById (Resource.Id.ivMST1PPTile2ProdPic);
			TextView tvMST1PPTile3ProdPrice = (TextView)FindViewById (Resource.Id.tvMST1PPTile3ProdPrice);
			TextView tvMST1PPTile3ProdName = (TextView)FindViewById (Resource.Id.tvMST1PPTile3ProdName);
			ImageView ivMST1PPTile3ProdPic = (ImageView)FindViewById (Resource.Id.ivMST1PPTile3ProdPic);
			TextView tvMST1PPTile4ProdPrice = (TextView)FindViewById (Resource.Id.tvMST1PPTile4ProdPrice);
			TextView tvMST1PPTile4ProdName = (TextView)FindViewById (Resource.Id.tvMST1PPTile4ProdName);
			ImageView ivMST1PPTile4ProdPic = (ImageView)FindViewById (Resource.Id.ivMST1PPTile4ProdPic);

//			LinearLayout ll_boxPopular1 = (LinearLayout)FindViewById (Resource.Id.ll_boxPopular1);
//			LinearLayout ll_boxPopular2 = (LinearLayout)FindViewById (Resource.Id.ll_boxPopular2);
//			LinearLayout ll_boxPopular3 = (LinearLayout)FindViewById (Resource.Id.ll_boxPopular3);
//			LinearLayout ll_boxPopular4 = (LinearLayout)FindViewById (Resource.Id.ll_boxPopular4);

			string myShopRawData = getMyShopFeedJSONData();
			var myShopJSONed = JsonConvert.DeserializeObject<WebServices.MyShopFJDRObj> (myShopRawData);

//			//popular box 1
//			ll_boxPopular1.Click += (object sender, EventArgs e) => {
//				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
//				var intent = new Intent (Application.Context, typeof(Product_Details));
//				intent.PutExtra("product_id", popularProdID[0]);
//				StartActivity (intent);
//			};
//
//			//popular box 2
//			ll_boxPopular2.Click += (object sender, EventArgs e) => {
//				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
//				var intent = new Intent (Application.Context, typeof(Product_Details));
//				intent.PutExtra("product_id", popularProdID[1]);
//				StartActivity (intent);
//			};
//
//			//popular box 2
//			ll_boxPopular3.Click += (object sender, EventArgs e) => {
//				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
//				var intent = new Intent (Application.Context, typeof(Product_Details));
//				intent.PutExtra("product_id", popularProdID[2]);
//				StartActivity (intent);
//			};
//
//
//			//popular box 2
//			ll_boxPopular4.Click += (object sender, EventArgs e) => {
//				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
//				var intent = new Intent (Application.Context, typeof(Product_Details));
//				intent.PutExtra("product_id", popularProdID[3]);
//				StartActivity (intent);
//			};

			RunOnUiThread (() => {
				//llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
				//recyclerView.Visibility = ViewStates.Visible;
			});

			foreach (var msjsoned in myShopJSONed.PopularProducts) {

				popularProdPrice.Add(msjsoned.price);
				popularProdName.Add(msjsoned.title);
				popularProdImage.Add(msjsoned.url_photo_thumb);
				popularProdID.Add(Int32.Parse (msjsoned.id));

			}

			RunOnUiThread (() => {
				tvMST1PPTile1ProdPrice.Text = "RM "+popularProdPrice [0];
				tvMST1PPTile1ProdName.Text = popularProdName [0];
				setupImage(ivMST1PPTile1ProdPic, popularProdImage[0]);

				tvMST1PPTile2ProdPrice.Text = "RM "+popularProdPrice [1];
				tvMST1PPTile2ProdName.Text = popularProdName [1];
				setupImage(ivMST1PPTile2ProdPic, popularProdImage[1]);

				tvMST1PPTile3ProdPrice.Text = "RM "+popularProdPrice [2];
				tvMST1PPTile3ProdName.Text = popularProdName [2];
				setupImage(ivMST1PPTile3ProdPic, popularProdImage[2]);

				tvMST1PPTile4ProdPrice.Text = "RM "+popularProdPrice [3];
				tvMST1PPTile4ProdName.Text = popularProdName [3];
				setupImage(ivMST1PPTile4ProdPic, popularProdImage[3]);
			});
		}

		public string getMyShopFeedJSONData()
		{
			WebServices wbs = new WebServices ();
			return wbs.getMyShopFeed ();
		}
	}
}

