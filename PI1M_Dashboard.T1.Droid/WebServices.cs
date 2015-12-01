using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace PI1M_Dashboard.T1.Droid
{
	public class WebServices
	{
		//string mySkoolToken = "";

		public WebServices ()
		{
		}

		public string getLoginData(string email, string password, string regid, string imei, string os)
		{
			Console.WriteLine ("[WebServices] GetLoginData");

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("username={0}&password={1}&regid={2}&imei={3}&os={4}",email,password,regid,imei,os));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://dashboard.pi1m.my/mobile/session/login");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string Json_Value1 = "";

			try
			{
				
				Stream myStream = httpWebRequest.GetRequestStream();
				myStream.Write(data,0,data.Length);
				myStream.Close();


				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public string getLoginData2(string email, string password, string regid, string imei, string os)
		{
			Console.WriteLine ("GetLoginData");

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("username={0}&password={1}&regid={2}&imei={3}&os={4}",email,password,regid,imei,os));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://dashboard.pi1m.my/mobile/session/login");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string Json_Value1 = "";

			try
			{
				
				Stream myStream = httpWebRequest.GetRequestStream();
				myStream.Write(data,0,data.Length);
				myStream.Close();

				Console.WriteLine ("Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class LoginData_TableItems
		{
			public int success { get; set; }
			public string message { get; set; }
			public string user_id { get; set; }
			public string email { get; set; }
			public string full_name { get; set; }
			public string site_name { get; set; }
			public string sitecode { get; set; }
			public string site_id { get; set; }
			public string ic_no { get; set; }
			public string token { get; set; }
		}

		/****************************************************
		 
		 		MySkool with Authorization and JSON Data
		 
		 ****************************************************/


		public string setMySkoolAuth(string Token)
		{
			Console.WriteLine ("[WebServices] SetMySkoolAuth with token: {0}",Token);

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",Token));

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://myskool.pi1m.my/users/dashboardv2_login");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string Json_Value1 = "";

			try
			{

				Stream myStream = httpWebRequest.GetRequestStream();
				myStream.Write(data,0,data.Length);
				myStream.Close();

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class mySkoolAuthToken
		{
			public string token { get; set; }
		}

		public string getMySkoolPetiMasuk(string token, int page)
		{
			Console.WriteLine ("[WebServices] SetMySkoolPetiMasuk with token: {0}",token);

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			string requestStr = string.Format ("http://myskool.pi1m.my/walls/dashboardv2_json_wall/{0}/page:{1}", token, page);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestStr);
			Console.WriteLine ("[WebServices] SetMySkoolPetiMasuk string: {0}",requestStr);
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

		public class MSPMDDatum
		{
			public string id { get; set; }
			public string content { get; set; }
			public string text { get; set; }
			public bool readmore { get; set; }
			public string title { get; set; }
			public string created { get; set; }
			public string creator { get; set; }
		}

		public class MSPMDPaging
		{
			public int page { get; set; }
			public int current { get; set; }
			public int count { get; set; }
			public bool prevPage { get; set; }
			public bool nextPage { get; set; }
			public int pageCount { get; set; }
		}

		public class MySkoolPetiMasukData
		{
			public List<MSPMDDatum> data { get; set; }
			public List<MSPMDPaging> paging { get; set; }
		}


		/****************************************************
		 
		 		MySoal with Authorization and JSON Data
		 
		 ****************************************************/

		public string setMySoalAuth(string Token)
		{
			Console.WriteLine ("[WebServices] SetMySoalAuth with token: {0}",Token);

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",Token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://mysoal.pi1m.my/messages/login_dashboardv2");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string Json_Value1 = "";

			try
			{

				Stream myStream = httpWebRequest.GetRequestStream();
				myStream.Write(data,0,data.Length);
				myStream.Close();

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class mySoalAuthToken
		{
			public string token { get; set; }
		}
			
		public string getMySoalPetiMasuk(string mySoalToken, int page)
		{
			Console.WriteLine ("[WebServices] SetMySoalAuth with token: {0}",mySoalToken);

			//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://mysoal.pi1m.my/messages/dashboardv2_json_message/{0}/inbox/page:{1}",mySoalToken,page));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class MSPMROMail
		{
			public string id { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string created { get; set; }
			public string category { get; set; }
			public string folders { get; set; }
			public string ori_date { get; set; }
			public string ori_time { get; set; }
			public string time { get; set; }
			public string email { get; set; }
			public string summary { get; set; }
			public string sender { get; set; }
			public string date { get; set; }
			public int comment { get; set; }
			public object author { get; set; }
			/*
			public string id { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string created { get; set; }
			public string category { get; set; }
			public List<string> folders { get; set; }
			public string important { get; set; }
			public string ori_date { get; set; }
			public string date { get; set; }
			public string ori_time { get; set; }
			public string time { get; set; }
			public string sender { get; set; }
			public string email { get; set; }
			public string summary { get; set; }
			public int comment { get; set; }
			public object author { get; set; }
			public int dahread { get; set; }
			*/
		}

		public class MSPMROPaging
		{
			public int page { get; set; }
			public int current { get; set; }
			public int count { get; set; }
			public bool prevPage { get; set; }
			public bool nextPage { get; set; }
			public int pageCount { get; set; }
			public string order { get; set; }
			public int limit { get; set; }
			//public List<object> options { get; set; }
			public string paramType { get; set; }
		}

		public class MySoalPetiMasukRObj
		{
			public List<MSPMROMail> mail { get; set; }
			public List<MSPMROPaging> paging { get; set; }
			public int unread { get; set; }
		}
			
		public string setMySoalSentMessage(string mySoalToken, string sendto, string title, string content)
		{
			Console.WriteLine ("[WebServices] setMySoalSentMessage with token: {0}",mySoalToken);

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("token={0}&sendto={1}&title={2}&content={3}",mySoalToken,sendto,title,content));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://mysoal.pi1m.my/messages/dashboardv2_save_message/"));
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;

			string Json_Value1 = "";

			try
			{

				Stream myStream = httpWebRequest.GetRequestStream();
				myStream.Write(data,0,data.Length);
				myStream.Close();

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class MySoalSentMessageRootObj
		{
			public int status { get; set; }
		}

		public string getMySoalPBT(string UserSiteCode)
		{
			Console.WriteLine ("[WebServices] Sitecode: {0}",UserSiteCode);

			//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://mysoal.pi1m.my/messages/mobile_list_site/{0}",UserSiteCode));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class MSPBTSchool
		{
			public string id { get; set; }
			public string name { get; set; }
		}

		public class MSPBTPbt
		{
			public MSPBTSchool School { get; set; }
		}

		public class MSPBTRootObject
		{
			public List<MSPBTPbt> pbt { get; set; }
			public string message { get; set; }
			public int status { get; set; }
		}

		/****************************************************
		 
		 		MyHealth with JSON Data
		 
		 ****************************************************/

		public string getMyHealthBPRecords(string token, int page)
		{
			Console.WriteLine ("[WebServices] GetMyHealthBPRecords with token: {0}",token);

			//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://dashboard.pi1m.my/api/myhealth/bp-records/{0}?page={1}",token,page));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class MHBPDatum
		{
			public string id { get; set; }
			public string ihealth_id { get; set; }
			public string BPUnitText { get; set; }
			public string BPL { get; set; }
			public string DataID { get; set; }
			public string HP { get; set; }
			public string HR { get; set; }
			public string IsArr { get; set; }
			public string LP { get; set; }
			public string LastChangeTime { get; set; }
			public string Lat { get; set; }
			public string Lon { get; set; }
			public string MDate { get; set; }
			public string Note { get; set; }
			public string color { get; set; }
			public string Mdatef { get; set; }
			public string Mtimef { get; set; }
			public string MdateTime { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
		}

		public class MHBPData
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<MHBPDatum> data { get; set; }
		}

		public class MyHealthBloodPressureData
		{
			public string status { get; set; }
			public MHBPData BP_data { get; set; }
		}

		public string getMyHealthBWRecords(string token, int page)
		{
			Console.WriteLine ("[WebServices] GetMyHealthBWRecords with token: {0}",token);

			//byte[]  data = new ASCIIEncoding().GetBytes(string.Format("dash_token={0}",token));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://dashboard.pi1m.my/api/myhealth/weight-records/{0}?page={1}",token,page));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class MHBWDatum
		{
			public string id { get; set; }
			public string ihealth_id { get; set; }
			public string DataID { get; set; }
			public string BMI { get; set; }
			public string BoneValue { get; set; }
			public string DCI { get; set; }
			public string FatValue { get; set; }
			public string LastChangeTime { get; set; }
			public string MDate { get; set; }
			public string MuscaleValue { get; set; }
			public string Note { get; set; }
			public string WaterValue { get; set; }
			public string WeightValue { get; set; }
			public string Mdatef { get; set; }
			public string Mtimef { get; set; }
			public string MdateTime { get; set; }
			public string LeanWeight { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
		}

		public class MHBWData
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<MHBWDatum> data { get; set; }
		}

		public class MyHealthBodyWeightData
		{
			public string status { get; set; }
			public MHBWData W_data { get; set; }
		}


		/****************************************************
		 
		 		MyVote with JSON Data
		 
		 ****************************************************/

		public string getMySoalPosterList(string token, string siteid, string page)
		{
			Console.WriteLine ("[WebServices] GetMySoalPosterList with token: {0}",token);

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://dashboard.pi1m.my/api/myposter/poster?token={0}&siteid={1}&page={2}",token,siteid,page));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		//http://dashboard.pi1m.my/api/announcement/user-announcements/eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiIyNyJ9.PDlMmlRol4oyc3SkmXTZ6YfAnn1A5tI0Q--0tp-xLuo

		/****************************************************
		 
		 		MyKomuniti Feed JSON Data
		 
		 ****************************************************/

		public string GetMyKomunitiFeed(string dashtoken,int page)
		{
			Console.WriteLine ("[WebServices] GetMyKomunitiFeed send with page {0}",page);

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://dashboard.pi1m.my/api/announcement/user-announcements/{0}?page={1}",dashtoken,page.ToString()));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}


		public class MyKomunitiFSite
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

		public class MyKomunitiFUser
		{
			public string id { get; set; }
			public string ic_no { get; set; }
			public string dob { get; set; }
			public string gender_id { get; set; }
			public string occupation_id { get; set; }
			public string email { get; set; }
			public string full_name { get; set; }
			public string verified { get; set; }
			public string is_admin { get; set; }
			public string site_id { get; set; }
			public string poster_group_id { get; set; }
			public string poster_group_ownership { get; set; }
			public string remember_token { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
			public MyKomunitiFSite site { get; set; }
		}

		public class MyKomunitiFDatum
		{
			public string id { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string excerpt { get; set; }
			public string approval { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
			public MyKomunitiFUser user { get; set; }
		}

		public class MyKomunitiFRObj
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<MyKomunitiFDatum> data { get; set; }
		}

		/********************* BEGIN-MyKomuniti Admin Feed JSON DATA ***/

		public string GetMyKomunitiAdminFeed(string dashtoken,int page)
		{
			Console.WriteLine ("[WebServices] GetMyKomunitiFeed send with page {0}",page);

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://dashboard.pi1m.my/api/announcement/hq-announcements/10?page={0}",page.ToString()));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}


		public class MyKomunitiFAdminUser
		{
			public string id { get; set; }
			public string email { get; set; }
			public string permissions { get; set; }
			public string activated { get; set; }
			public object activation_code { get; set; }
			public string activated_at { get; set; }
			public string last_login { get; set; }
			public string persist_code { get; set; }
			public object reset_password_code { get; set; }
			public string first_name { get; set; }
			public string last_name { get; set; }
			public object site_id { get; set; }
			public object region_id { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
		}

		public class MyKomunitiFAdminDatum
		{
			public string id { get; set; }
			public string user_id { get; set; }
			public string is_site { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string created_at { get; set; }
			public string updated_at { get; set; }
			public MyKomunitiFAdminUser user { get; set; }
		}

		public class MyKomunitiFAdminRObj
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<MyKomunitiFAdminDatum> data { get; set; }
		}
		/********************* END-MyKomuniti Admin Feed JSON DATA ***/

		/****************************************************
		 
		 		MyShop Feed JSON Data
		 
		 ****************************************************/

		public string getMyShopFeed()
		{
			Console.WriteLine ("[WebServices] getMyShopFeed");

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://myshop.pi1m.my/api/product/mobile"));
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value1 = "";

			try
			{

				Console.WriteLine ("[WebServices] Response Init: "+httpWebRequest.GetResponse ());

				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}


		public class MSFJROLPPhoto
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class MSFJROLPUSite
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

		public class MSFJROLPUser
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
			public MSFJROLPUSite site { get; set; }
		}

		public class MyShopFJDRObjLatestProduct
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
			public object url_photo_thumb_dashboard { get; set; }
			public List<MSFJROLPPhoto> photos { get; set; }
			public MSFJROLPUser user { get; set; }
		}

		public class MSFJROPPPhoto2
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class MSFJROPPUser2
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

		public class MyShopFJDRObjPopularProduct
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
			public string url_photo_thumb_dashboard { get; set; }
			public object category { get; set; }
			public List<MSFJROPPPhoto2> photos { get; set; }
			public MSFJROPPUser2 user { get; set; }
		}

		public class MSFJRORPPhoto3
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
		}

		public class MSFJRORPUser3
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

		public class MyShopFJDRObjReviewProduct
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
			public string url_photo_thumb_dashboard { get; set; }

			public object category { get; set; }
			public List<MSFJRORPPhoto3> photos { get; set; }
			public MSFJRORPUser3 user { get; set; }
		}

		public class MyShopFJDRObj
		{
			public List<MyShopFJDRObjLatestProduct> LatestProducts { get; set; }
			public List<MyShopFJDRObjPopularProduct> PopularProducts { get; set; }
			public List<MyShopFJDRObjReviewProduct> ReviewProducts { get; set; }
		}
	}
}

