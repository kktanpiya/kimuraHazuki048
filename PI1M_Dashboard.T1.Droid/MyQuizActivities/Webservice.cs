using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace MyQuiz
{
	public class Webservice
	{
		public Webservice ()
		{
		}

		// begin: validate event code
		public static string ws_validateEventCode(string eventCode, string imei, string user_id)
		{
			Console.WriteLine ("ws_validateEventCode");

			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("event_code={0}&imei={1}&user_id={2}",eventCode,imei,user_id));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://dashboard.pi1m.my/api/mylucky/validate-user");
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


		public class quizs
		{
			public string question { set; get;}
			public int answer { set; get;}

		}

		public class validateEventCode
		{
			public bool permission { get; set;}
			public int success { get; set;}
			public string message { get; set;}
			public int event_id { get; set;}
			public List<quizs> quizs { get; set; }
		}
		// end: validate event code

		// begin: validate submit quiz
		public static string ws_submitQuiz(int event_id, string user_id, string imei)
		{
			Console.WriteLine ("submitQuiz: event_id={0}, user_id={1}, imei={2}", event_id, user_id, imei);
			byte[]  data = new ASCIIEncoding().GetBytes(string.Format("event_id={0}&user_id={1}&imei_no={2}", event_id, user_id, imei));
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://dashboard.pi1m.my/api/mylucky/quiz-complete");
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

		public class submitQuiz
		{
			public int success { get; set;}
			public string message { get; set;}
			public int luckyNo { get; set;}
		}
		//end submit quiz


		// begin: validate event open
		public static string ws_validateEventOpen()
		{
			Console.WriteLine ("ws_validateEventOpen");

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://dashboard.pi1m.my/api/mylucky/validate-event");
			httpWebRequest.Method = "POST";
			httpWebRequest.Timeout = 30000;
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";

			string Json_Value1 = "";

			try
			{
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

		public class validateEventOpen
		{
			public string status { get; set;}
			public bool permission { get; set;}

		}
		// end: validate event open

	}
}

