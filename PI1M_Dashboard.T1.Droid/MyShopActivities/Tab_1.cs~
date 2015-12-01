
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
using Square.Picasso;
using Macaw.UIComponents;
using Android.Graphics;
using drawer_navigation;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyShop_Tab_1 : Android.Support.V4.App.Fragment
	{
		//MySkool_ListDataHolder listData;
		MyShop_ListDataHolderList listData;
		MyShop_RecyclerViewAdapter recyclerAdapter;
		RecyclerView recyclerView;
		RecyclerView.LayoutManager mLayoutManager;

		ImageView imageView1;

		LinearLayout llMSkT1ErrorStatus;
		TextView tvMSkT1ErrorStatus;

		List<MyShop_ListData> mySkoolListData = new List<MyShop_ListData>();
		List<string> mySkoolTitleList = new List<string> ();
		List<string> mySkoolContentList = new List<string> ();

		ProgressDialog progressDialog;

		MultiImageView imageView;
//		System.Timers.Timer _timer;

		LinearLayout llMST1PopularProd;
		LinearLayout ll_localProdAll;
		LinearLayout llMST1HiCommentProd;

		Button btn_seemore_popularprod;
		Button btn_seemore_newprod;
		Button btn_seemore_localprod;
		Button btn_seemore_reviewprod;

		public static string token_dashboard="";
		public override View OnCreateView(LayoutInflater inflater ,ViewGroup container ,Bundle savedInstanceState) 
		{
			//assign token 
			var tokenData = Activity.Intent.GetStringExtra ("Token");
			Console.Error.WriteLine ("token"+tokenData);
			token_dashboard = tokenData;

			View v = inflater.Inflate(Resource.Layout.ProdukMain ,container ,false);
			//TextView tvText = v.FindViewById<TextView> (Resource.Id.textView);
//			recyclerView = v.FindViewById <RecyclerView> (Resource.Id.recyclerView);
			btn_seemore_popularprod = v.FindViewById <Button> (Resource.Id.btn_seemore_popularprod);
			btn_seemore_newprod = v.FindViewById <Button> (Resource.Id.btn_seemore_newprod);
			btn_seemore_localprod = v.FindViewById <Button> (Resource.Id.btn_seemore_localprod);
			btn_seemore_reviewprod = v.FindViewById <Button> (Resource.Id.btn_seemore_reviewprod);

			progressDialog = ProgressDialog.Show (Activity, "Sila Tunggu", "Sedang Memuatkan...");

			llMST1PopularProd = v.FindViewById <LinearLayout> (Resource.Id.llMST1PopularProd);
			ll_localProdAll = v.FindViewById <LinearLayout> (Resource.Id.ll_localProdAll);
			llMST1HiCommentProd = v.FindViewById <LinearLayout> (Resource.Id.llMST1HiCommentProd);

			//llMSkT1ErrorStatus = (LinearLayout)v.FindViewById (Resource.Id.llMSPT1ErrorStatus);
			//tvMSkT1ErrorStatus = (TextView)v.FindViewById (Resource.Id.tvMSPT1ErrorStatus);
		
			//see more popular
			btn_seemore_popularprod.Click += delegate {
				var intent = new Intent (Application.Context, typeof(Product_Listing));
				intent.PutExtra ("tab", 1);
				StartActivity (intent);
			};

			//see more latest
			btn_seemore_newprod.Click += delegate {
				var intent = new Intent (Application.Context, typeof(Product_Listing));
				intent.PutExtra ("tab", 0);
				StartActivity (intent);
			};

			//see more local
			btn_seemore_localprod.Click += delegate {
				var intent = new Intent (Application.Context, typeof(Product_Listing));
				intent.PutExtra ("tab", 2);
				StartActivity (intent);
			};

			//see more review
			btn_seemore_reviewprod.Click += delegate {
				var intent = new Intent (Application.Context, typeof(Product_Listing));
				intent.PutExtra ("tab", 3);
				StartActivity (intent);
			};

			return v;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			ThreadPool.QueueUserWorkItem (o => { PopularProdSetup(); });
			ThreadPool.QueueUserWorkItem (o => { LatestProdSetup(); });

//			ThreadPool.QueueUserWorkItem (o => { LocalProdSetup(); });
			ThreadPool.QueueUserWorkItem (o => { HighestCommentProdSetup(); });
		}
			

		private void setupImage(ImageView image, string url){

			Picasso.With (Application.Context)
				.Load (url)
				.Placeholder (Resource.Drawable.placeholder_poster)
//				.Transform (new CropSquareTransformation())
				.Into(image);
		}


		private void PopularProdSetup()
		{
			List<string> popularProdPrice = new List<string> ();
			List<string> popularProdName = new List<string> ();
			List<string> popularProdImage = new List<string> ();
			List<int> popularProdID = new List<int> ();

			TextView tvMST1PPTile1ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile1ProdPrice);
			TextView tvMST1PPTile1ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile1ProdName);
			ImageView ivMST1PPTile1ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1PPTile1ProdPic);
			TextView tvMST1PPTile2ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile2ProdPrice);
			TextView tvMST1PPTile2ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile2ProdName);
			ImageView ivMST1PPTile2ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1PPTile2ProdPic);
			TextView tvMST1PPTile3ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile3ProdPrice);
			TextView tvMST1PPTile3ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile3ProdName);
			ImageView ivMST1PPTile3ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1PPTile3ProdPic);
			TextView tvMST1PPTile4ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile4ProdPrice);
			TextView tvMST1PPTile4ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PPTile4ProdName);
			ImageView ivMST1PPTile4ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1PPTile4ProdPic);

			RelativeLayout rl_ProdukPopular1 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukPopular1);
			RelativeLayout rl_ProdukPopular2 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukPopular2);
			RelativeLayout rl_ProdukPopular3 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukPopular3);
			RelativeLayout rl_ProdukPopular4 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukPopular4);

			string myShopRawData = getMyShopFeedJSONData();
			var myShopJSONed = JsonConvert.DeserializeObject<WebServices.MyShopFJDRObj> (myShopRawData);

			//popular box 1
			rl_ProdukPopular1.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", popularProdID[0]);
				StartActivity (intent);
			};

			//popular box 2
			rl_ProdukPopular2.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", popularProdID[1]);
				StartActivity (intent);
			};

			//popular box 2
			rl_ProdukPopular3.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", popularProdID[2]);
				StartActivity (intent);
			};


			//popular box 2
			rl_ProdukPopular4.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", popularProdID[3]);
				StartActivity (intent);
			};

			Activity.RunOnUiThread (() => {
				//llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
				//recyclerView.Visibility = ViewStates.Visible;
			});

			foreach (var msjsoned in myShopJSONed.PopularProducts) {

				popularProdPrice.Add(msjsoned.price);
				popularProdName.Add(msjsoned.title);
				popularProdImage.Add(msjsoned.url_photo_thumb);
				popularProdID.Add(Int32.Parse (msjsoned.id));

			}

			Activity.RunOnUiThread (() => {
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


		private void LatestProdSetup()
		{
			List<string> latestProdPrice = new List<string> ();
			List<string> latestProdName = new List<string> ();
			List<string> latestProdImage = new List<string> ();
			List<int> latestProdID = new List<int> ();

			TextView tvMST1LPTile1ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile1ProdPrice);
			TextView tvMST1LPTile1ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile1ProdName);
			ImageView ivMST1LPTile1ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1LPTile1ProdPic);
			TextView tvMST1LPTile2ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile2ProdPrice);
			TextView tvMST1LPTile2ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile2ProdName);
			ImageView ivMST1LPTile2ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1LPTile2ProdPic);
			TextView tvMST1LPTile3ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile3ProdPrice);
			TextView tvMST1LPTile3ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile3ProdName);
			ImageView ivMST1LPTile3ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1LPTile3ProdPic);
			TextView tvMST1LPTile4ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile4ProdPrice);
			TextView tvMST1LPTile4ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1LPTile4ProdName);
			ImageView ivMST1LPTile4ProdPic = (ImageView)Activity.FindViewById (Resource.Id.ivMST1LPTile4ProdPic);

			RelativeLayout rl_ProdukPopular1 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukTerbaru1);
			RelativeLayout rl_ProdukPopular2 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukTerbaru2);
			RelativeLayout rl_ProdukPopular3 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukTerbaru3);
			RelativeLayout rl_ProdukPopular4 = (RelativeLayout)Activity.FindViewById (Resource.Id.rl_ProdukTerbaru4);

			string myShopRawData = getMyShopFeedJSONData();
			var myShopJSONed = JsonConvert.DeserializeObject<WebServices.MyShopFJDRObj> (myShopRawData);

			//popular box 1
			rl_ProdukPopular1.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", latestProdID[0]);
				StartActivity (intent);
			};

			//popular box 2
			rl_ProdukPopular2.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", latestProdID[1]);
				StartActivity (intent);
			};

			//popular box 2
			rl_ProdukPopular3.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", latestProdID[2]);
				StartActivity (intent);
			};


			//popular box 2
			rl_ProdukPopular4.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", latestProdID[3]);
				StartActivity (intent);
			};

			Activity.RunOnUiThread (() => {
				//llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
				//recyclerView.Visibility = ViewStates.Visible;
			});

			foreach (var msjsoned in myShopJSONed.LatestProducts) {

				latestProdPrice.Add(msjsoned.price);
				latestProdName.Add(msjsoned.title);
				latestProdImage.Add(msjsoned.url_photo_thumb);
				latestProdID.Add(Int32.Parse (msjsoned.id));

			}

			Activity.RunOnUiThread (() => {
				tvMST1LPTile1ProdPrice.Text = "RM "+latestProdPrice [0];
				tvMST1LPTile1ProdName.Text = latestProdName [0];
				setupImage(ivMST1LPTile1ProdPic, latestProdImage[0]);

				tvMST1LPTile2ProdPrice.Text = "RM "+latestProdPrice [1];
				tvMST1LPTile2ProdName.Text = latestProdName [1];
				setupImage(ivMST1LPTile2ProdPic, latestProdImage[1]);

				tvMST1LPTile3ProdPrice.Text = "RM "+latestProdPrice [2];
				tvMST1LPTile3ProdName.Text = latestProdName [2];
				setupImage(ivMST1LPTile3ProdPic, latestProdImage[2]);

				tvMST1LPTile4ProdPrice.Text = "RM "+latestProdPrice [3];
				tvMST1LPTile4ProdName.Text = latestProdName [3];
				setupImage(ivMST1LPTile4ProdPic, latestProdImage[3]);
			});


		}



		private void LocalProdSetup()
		{
			List<MyShop_WebService.Localprod_Datum> prodList = new List<MyShop_WebService.Localprod_Datum>();


			TextView tvMST1PSTile1ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile1ProdPrice);
			TextView tvMST1PSTile1ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile1ProdName);
			ImageView ivLocalProd1 = (ImageView)Activity.FindViewById (Resource.Id.ivLocalProd1);

			TextView tvMST1PSTile2ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile2ProdPrice);
			TextView tvMST1PSTile2ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile2ProdName);
			ImageView ivLocalProd2 = (ImageView)Activity.FindViewById (Resource.Id.ivLocalProd2);

			TextView tvMST1PSTile3ProdPrice = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile3ProdPrice);
			TextView tvMST1PSTile3ProdName = (TextView)Activity.FindViewById (Resource.Id.tvMST1PSTile3ProdName);
			ImageView ivLocalProd3 = (ImageView)Activity.FindViewById (Resource.Id.ivLocalProd3);

			LinearLayout ll_localProd1 = (LinearLayout)Activity.FindViewById (Resource.Id.ll_localProd1);
			LinearLayout ll_localProd2 = (LinearLayout)Activity.FindViewById (Resource.Id.ll_localProd2);
			LinearLayout ll_localProd3 = (LinearLayout)Activity.FindViewById (Resource.Id.ll_localProd3);
			LinearLayout ll_localProdNoData = (LinearLayout)Activity.FindViewById (Resource.Id.ll_localProdNoData);
			LinearLayout ll_localProdAll1  = (LinearLayout)Activity.FindViewById (Resource.Id.ll_localProdAll1);
//			TextView tv_localTiadaData = (TextView)Activity.FindViewById (Resource.Id.tv_localTiadaData);


			try{
				var jsonString = MyShop_WebService.GetJsonLocalProduct (MyShop_Tab_1.token_dashboard,1);
				var ProdData = JsonConvert.DeserializeObject<MyShop_WebService.Root_Localprod> (jsonString);
			
				foreach (var tempData in ProdData.data) {
					prodList.Add (new MyShop_WebService.Localprod_Datum () {
						id = tempData.id,
						title = tempData.title,
						price = "RM "+tempData.price,
						created_at = tempData.created_at,
						url_photo_large = tempData.url_photo_large,
					});
				}


				ll_localProd1.Click += (object sender, EventArgs e) => {
					int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
					var intent = new Intent (Application.Context, typeof(Product_Details));
					intent.PutExtra("product_id", Int32.Parse (prodList[0].id));
					StartActivity (intent);
				};

				ll_localProd2.Click += (object sender, EventArgs e) => {
					int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
					var intent = new Intent (Application.Context, typeof(Product_Details));
					intent.PutExtra("product_id", Int32.Parse (prodList[1].id));
					StartActivity (intent);
				};

				ll_localProd3.Click += (object sender, EventArgs e) => {
					int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
					var intent = new Intent (Application.Context, typeof(Product_Details));
					intent.PutExtra("product_id", Int32.Parse (prodList[2].id));
					StartActivity (intent);
				};

				Activity.RunOnUiThread (() => {

					if(prodList.Count >= 3)
					{
						tvMST1PSTile1ProdPrice.Text = prodList[0].price;
						tvMST1PSTile1ProdName.Text = prodList[0].title;
						setupImage(ivLocalProd1, prodList[0].url_photo_large);

						tvMST1PSTile2ProdPrice.Text = prodList[1].price;
						tvMST1PSTile2ProdName.Text = prodList[1].title;
						setupImage(ivLocalProd2, prodList[1].url_photo_large);

						tvMST1PSTile3ProdPrice.Text = prodList[2].price;
						tvMST1PSTile3ProdName.Text = prodList[2].title;
						setupImage(ivLocalProd3, prodList[2].url_photo_large);

					}
					else if(prodList.Count == 2)
					{
						tvMST1PSTile1ProdPrice.Text = prodList[0].price;
						tvMST1PSTile1ProdName.Text = prodList[0].title;
						setupImage(ivLocalProd1, prodList[0].url_photo_large);

						tvMST1PSTile2ProdPrice.Text = prodList[1].price;
						tvMST1PSTile2ProdName.Text = prodList[1].title;
						setupImage(ivLocalProd2, prodList[1].url_photo_large);

						Activity.RunOnUiThread (() => {
							ll_localProd3.Visibility = ViewStates.Gone;
						});
					}
					else if(prodList.Count == 1)
					{
						tvMST1PSTile1ProdPrice.Text = prodList[0].price;
						tvMST1PSTile1ProdName.Text = prodList[0].title;
						setupImage(ivLocalProd1, prodList[0].url_photo_large);

						Activity.RunOnUiThread (() => {
							ll_localProd2.Visibility = ViewStates.Gone;
							ll_localProd3.Visibility = ViewStates.Gone;
						});
					}

				});
			}
			catch(Exception ex){
				Activity.RunOnUiThread (() => {
					ll_localProd1.Visibility = ViewStates.Gone;
					ll_localProd2.Visibility = ViewStates.Gone;
					ll_localProd3.Visibility = ViewStates.Gone;
					ll_localProdNoData.Visibility = ViewStates.Visible;
				});
			}

		}

		private void HighestCommentProdSetup()
		{
			List<string> highCommentProdImage = new List<string> ();
			List<int> highCommentProdID = new List<int> ();
			List<string> highCommentTitle = new List<string> ();
			List<string> highCommentPrice = new List<string> ();

			ImageView iv_prodHighComment1 = (ImageView)Activity.FindViewById (Resource.Id.iv_prodHighComment1);
			ImageView iv_prodHighComment2 = (ImageView)Activity.FindViewById (Resource.Id.iv_prodHighComment2);
			ImageView iv_prodHighComment3 = (ImageView)Activity.FindViewById (Resource.Id.iv_prodHighComment3);
			TextView tv_prodCommentPrice1 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentPrice1);
			TextView tv_prodCommentPrice2 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentPrice2);
			TextView tv_prodCommentPrice3 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentPrice3);
			TextView tv_prodCommentTitle1 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentTitle1);
			TextView tv_prodCommentTitle2 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentTitle2);
			TextView tv_prodCommentTitle3 = (TextView)Activity.FindViewById (Resource.Id.tv_prodCommentTitle3);


			string myShopRawData = getMyShopFeedJSONData();
			var myShopJSONed = JsonConvert.DeserializeObject<WebServices.MyShopFJDRObj> (myShopRawData);

			Activity.RunOnUiThread (() => {
				//llMSkT1ErrorStatus.Visibility = ViewStates.Gone;
				//recyclerView.Visibility = ViewStates.Visible;
			});

			foreach (var msjsoned in myShopJSONed.ReviewProducts) {
				highCommentProdImage.Add(msjsoned.url_photo_large);
				highCommentProdID.Add(Int32.Parse (msjsoned.id));
				highCommentTitle.Add(msjsoned.title);
				highCommentPrice.Add(msjsoned.price);
			}

			iv_prodHighComment1.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", highCommentProdID[0]);
				StartActivity (intent);
			};

			iv_prodHighComment2.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", highCommentProdID[1]);
				StartActivity (intent);
			};

			iv_prodHighComment3.Click += (object sender, EventArgs e) => {
				int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
				var intent = new Intent (Application.Context, typeof(Product_Details));
				intent.PutExtra("product_id", highCommentProdID[2]);
				StartActivity (intent);
			};

			Activity.RunOnUiThread (() => {

				tv_prodCommentPrice1.Text = "RM "+highCommentPrice[0];
				tv_prodCommentPrice2.Text = "RM "+highCommentPrice[1];
				tv_prodCommentPrice3.Text = "RM "+highCommentPrice[2];
				tv_prodCommentTitle1.Text = highCommentTitle[0];
				tv_prodCommentTitle2.Text = highCommentTitle[1];
				tv_prodCommentTitle3.Text = highCommentTitle[2];

				setupImage(iv_prodHighComment1, highCommentProdImage[0]);
				setupImage(iv_prodHighComment2, highCommentProdImage[1]);
				setupImage(iv_prodHighComment3, highCommentProdImage[2]);
		
			});
			Activity.RunOnUiThread (() => { progressDialog.Hide();});

		}

		private void Test()
		{
			//Console.WriteLine ("Checking weight: {0}", llMST1PopularProd.WeightSum);
			//ll_localProdAll;
			//llMST1HiCommentProd;
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

		public void exitHandler(object sender, EventArgs e)
		{
			Activity.Finish ();
		}

		public string getMyShopFeedJSONData()
		{
			WebServices wbs = new WebServices ();
			return wbs.getMyShopFeed ();
		}

	}

	public class MyShop_ListDataHolderList
	{

		private readonly List<MyShop_ListData> mListData = new List<MyShop_ListData>();

		public MyShop_ListDataHolderList(List<MyShop_ListData> listData)
		{
			mListData = listData;
		}

		public int DataNum
		{
			get { 
				
				return mListData.Count; 
			
			}
		}

		public MyShop_ListData this [int i]
		{
			get { return mListData[i];}
		}
			
	}
}

