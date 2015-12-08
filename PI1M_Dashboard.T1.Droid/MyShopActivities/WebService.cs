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

		public class Product_Datum
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

		public class Root_product
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<Product_Datum> data { get; set; }
		}
			
		//local product need token
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

		//new product
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

		//top review product
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

		//search product
		public static string getSearchResult(string keyword, int page)
		{

			string requestStr = string.Format ("http://myshop.pi1m.my/api/product/search/{0}?page={1}",keyword,page);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestStr);
			Console.WriteLine ("[WebServices] searchws string: {0}",requestStr);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{
				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();
						Console.WriteLine ("[WebServices] Response Init: "+Json_Value1);

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
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
			public string url_photo_original { get; set; }
			public string url_photo_thumb_dashboard { get; set; }
			public string url_photo_large { get; set; }
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

