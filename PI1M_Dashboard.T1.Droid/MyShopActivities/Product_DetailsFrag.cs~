
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
using System.ComponentModel;
using Macaw.UIComponents;
using Android.Webkit;
using drawer_navigation;
using Newtonsoft.Json;
using myShopDescription;
using Android.Graphics;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Product_DetailsFrag")]			
	public class Product_DetailsFrag : Fragment
	{
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

		public static Product_DetailsFrag newInstance(string stringUrl)
		{

			Product_DetailsFrag fImage = new Product_DetailsFrag ();

			Bundle args = new Bundle ();
			args.PutString ("stringUrl", stringUrl);
			fImage.Arguments = args;

			return fImage;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.MyShop_ProductDetails, container, false);

			//setup background worker for data loading
			worker = new BackgroundWorker ();
			worker.DoWork += worker_DoWork;
			worker.WorkerSupportsCancellation = true;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			worker.RunWorkerAsync ();

			progress = new ProgressDialog(Activity);
			progress.Indeterminate = true;
			progress.SetProgressStyle(ProgressDialogStyle.Spinner);
			progress.SetMessage("Memuatkan data..");
			progress.SetCancelable(false);
			progress.Show();


			productImage = view.FindViewById<MultiImageView>(Resource.Id.productImage);
			tv_price = view.FindViewById <TextView> (Resource.Id.tv_price);
			tv_prodTitle = view.FindViewById <TextView> (Resource.Id.tv_prodTitle);
			wv_prodDesc = view.FindViewById <WebView> (Resource.Id.wv_prodDesc);
			//			btn_addToCart = FindViewById <Button> (Resource.Id.btn_addToCart);
			btn_sellerInfo = view.FindViewById <Button> (Resource.Id.btn_sellerInfo);

//			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
//			SetSupportActionBar (toolbar);
//			SupportActionBar.SetDisplayHomeAsUpEnabled (true);


			//call addToCart method
			//			btn_addToCart.Click += (sender, e) => {
			//				addToCart();
			//			};

			btn_sellerInfo.Click += btnSellerInfo_click;

			return view;
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

//			Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction ();
//			DialogSellerInfo_fragment dialog = new DialogSellerInfo_fragment (prodDetails.seller.name, prodDetails.seller.phone, prodDetails.seller.email, prodDetails.seller.gst );
//			dialog.Show (transaction, "dialog fragment");
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


			int x = 0;
			productImage.ImagesLoaded += (sender, e) =>
			{   // Loads the first image in the list
				Activity.RunOnUiThread(productImage.LoadImage);

				//dismiss loading after image loaded
				if(x == (list.Count-1))
				{
					progress.Dismiss();
				}
				x++;
			};

		}

		private void setupData(){

			//set product price
			tv_price.Text = "RM "+prodDetails.price;

			//set product title
			tv_prodTitle.Text = prodDetails.title;

			//format html for proper view
			String prodDesc = "<html><body>"+prodDetails.description.Replace("\r\n", "<br/>")+"</body></html>";

			//set product details
			String ua = "Mozilla/5.0 (Linux; U;`\nAndroid 2.0; en-us; Droid Build/ESD20) AppleWebKit/530.17 (KHTML, like\nGecko) Version/4.0 Mobile Safari/530.17";
			wv_prodDesc.Settings.JavaScriptEnabled = true;
			wv_prodDesc.Settings.UserAgentString = (ua);
			wv_prodDesc.LoadDataWithBaseURL ("", 
				prodDesc, 
				"text/html", 
				"UTF-8", "");
		}

		private void addToCart()
		{
			Toast.MakeText (Activity, "Item telah ditambahkan ke dalam bakul", ToastLength.Short).Show();	
		}




	}
}

