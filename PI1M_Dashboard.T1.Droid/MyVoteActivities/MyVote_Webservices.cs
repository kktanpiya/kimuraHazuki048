
using System;
using System.Text;

using System.Net;
using System.IO;
using Android.Util;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{			
	public static class MyVote_Webservices
	{
		const string url = "http://dashboard.pi1m.my";

		public static string GetLikeStatus(string posterID)
		{
			const string like_string = "http://dashboard.pi1m.my/api/myposter/like-poster";
			//get token from constant class
			string token = Const.tokenData;
			string siteid = Const.siteID;
			Console.WriteLine ("LIKEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE:{0}",posterID);

			return webServicesProcess (posterID, like_string, token, siteid);

		}

		public static string GetUnlikeStatus(string posterID)
		{
			const string unlike_string = "http://dashboard.pi1m.my/api/myposter/unlike-poster";
			//get token from constant class
			string token = Const.tokenData;
			string siteid = Const.siteID;
			Console.WriteLine ("TAKKKKKKKKKKKKKKKKKKKKKKKKKLIKEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE:{0}",posterID);

			return webServicesProcess (posterID, unlike_string, token, siteid);
		}

		public static string GetCheckLikeStatus(string posterID)
		{
			const string check_like_string = "http://dashboard.pi1m.my/api/myposter/check-user-like-poster";
			//get token from constant class
			string token = Const.tokenData;
			string siteid = Const.siteID;

			return webServicesProcess (posterID, check_like_string, token, siteid);
		}

		public static string webServicesProcess(string posterID, string url, string token, string siteid)
		{
			byte[] data = new ASCIIEncoding ().GetBytes(String.Format(""));
			string urlLikeString = String.Format("{0}?token={1}&siteid={2}&posterid={3}", url, token, siteid, posterID);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create (urlLikeString);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string JsonValue = "";

			try{

				using(var response = httpWebRequest.GetResponse()){

					using (var reader = new StreamReader (response.GetResponseStream())){
						Log.Debug("Response", response.ToString());
						JsonValue = reader.ReadToEnd();
					}
				}
			}
			catch(Exception e){

				Log.Debug ("Webservices", "Error like value passing.."+ e);
			}

			return JsonValue;
		}


		public static string GetJsonStringValue(int page)
		{
			string url =String.Format("http://dashboard.pi1m.my/api/myposter/poster?token={0}&siteid={1}&page={2}",Const.tokenData,Const.siteID,page);
			//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(url));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value = "";

			try
			{
				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value = reader.ReadToEnd ();
					}
				}
			}
			catch(System.Exception e) {

				Log.Debug ("[WebServices] Response Init",e.ToString());
			}

			return Json_Value;
		}
	}
}

