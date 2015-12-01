using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Android.Util;
using Newtonsoft.Json;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyShop_WebService
	{
		public MyShop_WebService ()
		{
			
		}

		public static string GetJsonLatestProduct ()
		{
			string Json_Value = "";

				try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/mobile");
					//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
					httpWebRequest.Method = "GET";
					httpWebRequest.ContentType = "application/x-www-form-urlencoded";

					using (var response = httpWebRequest.GetResponse ()) {

						using (var reader = new StreamReader (response.GetResponseStream ())) {

							Json_Value = reader.ReadToEnd ();
						}
					}
				} catch (System.Exception e) {

					Log.Debug ("[WebServices] Response Init", e.ToString ());
				}
		
			return Json_Value;
		}

		public class Photo
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class Site
		{
			public string id { get; set; }
			public string code { get; set; }
			public string address { get; set; }
			public string region_id { get; set; }
			public string state { get; set; }
			public string email { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
		}

		public class User
		{
			public string id { get; set; }
			public string site_id { get; set; }
			public string name { get; set; }
			public string icNo { get; set; }
			public string address { get; set; }
			public string email { get; set; }
			public string phone { get; set; }
			public string gst { get; set; }
			public string type { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public Site site { get; set; }
		}

		public class LatestProductDatum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public object sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public object category { get; set; }
			public List<Photo> photos { get; set; }
			public User user { get; set; }
		}

		public class Photo2
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class User2
		{
			public string id { get; set; }
			public string site_id { get; set; }
			public string name { get; set; }
			public string icNo { get; set; }
			public string address { get; set; }
			public string email { get; set; }
			public string phone { get; set; }
			public string gst { get; set; }
			public string type { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public List<object> merchants { get; set; }
		}

		public class PopularProductDatum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public object category { get; set; }
			public List<Photo2> photos { get; set; }
			public User2 user { get; set; }
		}

		public class Photo3
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class User3
		{
			public string id { get; set; }
			public string site_id { get; set; }
			public string name { get; set; }
			public string icNo { get; set; }
			public string address { get; set; }
			public string email { get; set; }
			public string phone { get; set; }
			public string gst { get; set; }
			public string type { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public List<object> merchants { get; set; }
		}

		public class ReviewProductDatum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public object category { get; set; }
			public List<Photo3> photos { get; set; }
			public User3 user { get; set; }
		}

		public class RootObject
		{
			public List<LatestProductDatum> LatestProducts { get; set; }
			public List<PopularProductDatum> PopularProducts { get; set; }
			public List<ReviewProductDatum> ReviewProducts { get; set; }
		}

		//local product
		public class Localprod_Datum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
		}

		public class Root_Localprod
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<Localprod_Datum> data { get; set; }
		}

		public static string GetJsonLocalProduct (string token,int page)
		{
			string Json_Value = "";

			token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiIxMCIsInNpdGVfaWQiOiIxMDg2In0.KpcrERsAumEbPbBIYQ9cqrz2ZlGgQRsSKwk5-pqkyTc";
//			token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiI2Iiwic2l0ZV9pZCI6IjI3NiJ9.s-orQl_BYFUcVr20s0QuvcMLIJ\nT5e1vHvkXTihGfbQI";

			try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/product-by-site?&token={0}&page={1}",token,page);
				Console.Error.WriteLine("url"+url);
				//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			} catch (System.Exception e) {

				Log.Debug ("[WebServices] Response Init", e.ToString ());
			}

			return Json_Value;
		}

		//popular product
		public class PopularProd_Datum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
		}

		public class Root_PopularProd
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<PopularProd_Datum> data { get; set; }
		}

		public static string GetJsonPopularProduct (int page)
		{
			string Json_Value = "";

			try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/popular?page="+page);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			} catch (System.Exception e) {

				Log.Debug ("[WebServices] Response Init", e.ToString ());
			}

			return Json_Value;
		}


		//|latest product 
		public class LatestProd_Datum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public object sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
		}

		public class Root_LatestProd
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<LatestProd_Datum> data { get; set; }
		}

		public static string GetJsonLatestProduct (int page)
		{
			string Json_Value = "";

			try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/latest-product-myshop?page="+page);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			} catch (System.Exception e) {

				Log.Debug ("[WebServices] Response Init", e.ToString ());
			}

			return Json_Value;
		}


		//review product
		public class Category
		{
			public string id { get; set; }
			public string name { get; set; }
			public object updated_at { get; set; }
			public object created_at { get; set; }
		}

		public class SubCategory
		{
			public string id { get; set; }
			public string category_id { get; set; }
			public string name { get; set; }
			public object updated_at { get; set; }
			public object created_at { get; set; }
			public Category category { get; set; }
		}

		public class Photo_review
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
		}

		public class ReviewProd_Datum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
			public SubCategory sub_category { get; set; }
			public List<Photo> photos { get; set; }
			public List<object> reviews { get; set; }
		}

		public class Root_ReviewProd
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<ReviewProd_Datum> data { get; set; }
		}

		public static string GetJsonReviewProduct (int page)
		{
			string Json_Value = "";

			try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/all-product-review?page="+page);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			} catch (System.Exception e) {

				Log.Debug ("[WebServices] Response Init", e.ToString ());
			}

			return Json_Value;
		}

		//view product details
		public class Photo_seller
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
		}

		public class Seller
		{
			public string id { get; set; }
			public string site_id { get; set; }
			public string name { get; set; }
			public string icNo { get; set; }
			public string address { get; set; }
			public string email { get; set; }
			public string phone { get; set; }
			public string gst { get; set; }
			public string type { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class Review
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string user_id { get; set; }
			public string rating { get; set; }
			public string comment { get; set; }
			public string approved { get; set; }
			public string spam { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}
		public class ProductDetails
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public string sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
			public List<Photo_seller> photos { get; set; }
			[JsonProperty("user")]
			public Seller sellerDetails { get; set; }
			public List<Review> reviews { get; set; }

		}

		public static string GetJsonProductDetail(int prodID)
		{
			string Json_Value = "";

			try {
				string url = String.Format ("http://myshop.pi1m.my/api/product/find-product-detail/"+prodID);
				//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (string.Format (url));
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			} catch (System.Exception e) {

				Log.Debug ("[WebServices] Response Init", e.ToString ());
			}

			return Json_Value;
		}


	}
}

