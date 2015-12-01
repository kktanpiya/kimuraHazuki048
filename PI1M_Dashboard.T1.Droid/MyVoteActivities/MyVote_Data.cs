
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using Android.Util;
using System.Net.Http;
using System;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{
	public class MyVote_Data
	{
		private static int last_page;
		private static int total_item;
		public MyVote_Data ()
		{
		}

		public static List<dummyData> GetVoteData(int page)
		{

			var jsonString = MyVote_Webservices.GetJsonStringValue(page);
			Log.Debug ("jsonString", jsonString);
			var myVoteData = new List<dummyData> ();
			var data = JsonConvert.DeserializeObject <JsonObject> (jsonString);

			//get last_page and total item
			last_page = data.last_page;
			total_item = data.total;

			if (total_item != 0) {
				foreach (var tempData in data.data) {
					myVoteData.Add (new dummyData () {
						imageId = tempData.id,
						imageString = tempData.path,
						voteStat = tempData.vote,

					});
				}
			}

			return myVoteData;
		}

		public static int getLastPage(){
			return last_page;
		}

		public static int getTotalItem(){
			return total_item;

		}
	}
}

