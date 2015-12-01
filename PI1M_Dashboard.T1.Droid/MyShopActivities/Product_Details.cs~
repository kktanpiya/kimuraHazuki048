using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Json;
using Square.Picasso;
using Android.Webkit;
using Android.Views;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Macaw.UIComponents;
using Android.Graphics;
using System.ComponentModel;
using Java.Interop;
using Android.Support.V4.View;
using Android.Support.V4.App;
using myShopDescription;
using drawer_navigation;


namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "", Icon = "@drawable/icon")]
	public class Product_Details : AppCompatActivity
	{
		RecyclerView.LayoutManager layoutManager;
		RecyclerView recyclerView;
		private MultiImageView productImage;
		private TextView tv_price;
		private TextView tv_prodTitle;
		private TextView tv_prodDetails;
		private WebView wv_prodDesc;
		private Button btn_addToCart;
		private Button btn_sellerInfo;

		String jsonProdDetail;
		MyShop_WebService.ProductDetails prodDetails;

		public static BackgroundWorker worker; 
		public static DoWorkEventArgs e;

		ProgressDialog progress;

		int product_id;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.MyShop_ProductDetails);

			product_id = Intent.GetIntExtra("product_id",0);
			//setup background worker for data loading
			worker = new BackgroundWorker ();
			worker.DoWork += worker_DoWork;
			worker.WorkerSupportsCancellation = true;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			worker.RunWorkerAsync ();

			progress = new ProgressDialog(this);
			progress.Indeterminate = true;
			progress.SetProgressStyle(ProgressDialogStyle.Spinner);
			progress.SetMessage("Memuatkan data..");
			progress.SetCancelable(false);
			progress.Show();


			productImage = FindViewById<MultiImageView>(Resource.Id.productImage);
			tv_price = FindViewById <TextView> (Resource.Id.tv_price);
			tv_prodTitle = FindViewById <TextView> (Resource.Id.tv_prodTitle);
			wv_prodDesc = FindViewById <WebView> (Resource.Id.wv_prodDesc);
//			btn_addToCart = FindViewById <Button> (Resource.Id.btn_addToCart);
			btn_sellerInfo = FindViewById <Button> (Resource.Id.btn_sellerInfo);

     		var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#9C27B0"));

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowHomeEnabled (true);


			//call addToCart method
//			btn_addToCart.Click += (sender, e) => {
//				addToCart();
//			};

			btn_sellerInfo.Click += btnSellerInfo_click;

		}	



		protected override void OnDestroy()
		{
			base.OnDestroy ();
			productImage.ClearImageCache ();
		}


//		public override bool OnCreateOptionsMenu (IMenu menu) 
//		{
//			MenuInflater.Inflate(Resource.Menu.product_detail, menu);
//			IMenuItem item = menu.FindItem (Resource.Id.menu_cart);
//			return true;
//		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {

			case Android.Resource.Id.Home:
				this.Finish ();
				this.OverridePendingTransition (0, 0);
				return true;

			default:
				return base.OnOptionsItemSelected (item);

			}
		}

		void worker_RunWorkerCompleted (object sender, EventArgs e)
		{
			//after completed task
			setupData();
			imageSlider ();
		}

		void worker_DoWork (object sender, DoWorkEventArgs ea)
		{

			if (worker.CancellationPending) { 
				Console.Error.WriteLine ("masukiniii");
				return;
			}
		
			jsonProdDetail = MyShop_WebService.GetJsonProductDetail (product_id);
			prodDetails = JsonConvert.DeserializeObject <MyShop_WebService.ProductDetails> (jsonProdDetail);
		}

		//popup seller details
		void btnSellerInfo_click(object sender, EventArgs e)
		{
			Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction ();
			DialogSellerInfo_fragment dialog = new DialogSellerInfo_fragment (prodDetails.sellerDetails.name,
				prodDetails.sellerDetails.phone, prodDetails.sellerDetails.email, prodDetails.sellerDetails.gst );
			dialog.Show (transaction, "dialog fragment");
		}

		private void imageSlider()
		{

			// Sets images for the slider icons and their size
			productImage.SliderSelectedIcon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.slider_blt_grn);
			productImage.SliderUnselectedIcon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.slider_blt_trans);
			productImage.SetSliderIconDimensions(20, 20);

			productImage.DownloadedImageSampleSize = 1;

			List<String> list = new List<string> ();

			foreach (var temp in prodDetails.photos) 
			{
				list.Add ("http://myshop.pi1m.my/productImage/thumbs_dashboard/"+temp.name);

			}

			productImage.LoadImageList(list.ToArray());


//			int x = 0;

			productImage.ImagesLoaded += (sender, e) =>
			{   
				// Loads the first image in the list
				RunOnUiThread(productImage.LoadImage);
				//dismiss loading after image loaded
//				Console.Error.WriteLine("x"+x);
//				if(x == (list.Count-1))
//				{
//				}
//				x++;
				progress.Dismiss();

			};
//			progress.Dismiss();


		}

		private void setupData(){

			//set product price
			tv_price.Text = "RM "+prodDetails.price;

			//set product title
			tv_prodTitle.Text = prodDetails.title;
			SupportActionBar.Title =  prodDetails.title;

			//format html for proper view
			string cssStyle="<style>img{display: inline;height: auto;max-width: 100%;}</style>";
			string prodDesc = cssStyle+"<html><body>"+prodDetails.description.Replace("\r\n", "<br/>")+"</body></html>";

			prodDesc = "<html><body>"+prodDesc.Replace("../../../", "http://myshop.pi1m.my/textImages")+"</body></html>";

			prodDesc = "<html><body>"+prodDesc.Replace("/textImages", "http://myshop.pi1m.my/textImages")+"</body></html>";
			wv_prodDesc.Settings.JavaScriptEnabled = true;
			wv_prodDesc.Settings.BuiltInZoomControls = true;
			wv_prodDesc.Settings.UseWideViewPort = false;	
//			wv_prodDesc.SetInitialScale (1);
//			wv_prodDesc.Settings.UserAgentString = (ua);
			Console.Error.WriteLine("test"+prodDesc);
			wv_prodDesc.LoadDataWithBaseURL ("", 
				prodDesc, 
				"text/html", 
				"UTF-8", "");
		}

		private void addToCart()
		{
			Toast.MakeText (this, "Item telah ditambahkan ke dalam bakul", ToastLength.Short).Show();	
		}
			
	
	}
}


