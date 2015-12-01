
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
using System.Threading.Tasks;

namespace MyVote
{	
	//test class only. ignore this.
	public class MyVote_VerifyVoteButton
	{
		private static MyVote_Data myvote_Data;
		private static int vote_value;

		public MyVote_VerifyVoteButton () {}

		public static async Task<List<int>> VerifyVoteButton(string tokenData)
		{

			myvote_Data = new MyVote_Data ();
			var vote_status = new List<int> ();

			foreach(var temp_data in MyVote_Data.GetVoteData(1))
			{

				var vote_status_value = await Task.Factory.StartNew(() => MyVote_Webservices.GetCheckLikeStatus(temp_data.imageId));

				if(vote_status_value == "true")
				{

					vote_value = 1;
				}
				else if(vote_status_value == "false")
				{
					vote_value = 0;
				}

				vote_status.Add (vote_value);
			}

			return vote_status;
		}
	}
}

