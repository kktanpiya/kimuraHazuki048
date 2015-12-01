using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.Net;
using System.Net.Sockets;

namespace PI1M_Dashboard.T1.Droid
{
	public class Commonlib
	{
		public static string tokenData = "";
		public static string siteID = "";
		public static int errorInternet= 1;
		public static int errorServer= 0;
		public static int dontCloseActivity= 0;
		public static int closeActivity= 1;

		static int  timeout=11000;
		static string host1="208.67.222.222";
		static string host2="8.8.8.8";
		static string host3="8.8.4.4";
		static int port=53;


		public static bool IsOnline (Activity context,int close)
		{
			//for checking internet is on 
			ConnectivityManager connectivityManager = (ConnectivityManager)context.GetSystemService("connectivity");
			var activeConnection = connectivityManager.ActiveNetworkInfo;

			//internet is on
			if ((activeConnection != null) && activeConnection.IsConnected) {

				Console.Error.WriteLine ("1st level checking");
				var client1 = new TcpClient();
				try{
					if (!client1.ConnectAsync (host1, port).Wait (timeout)) {
						client1.Close ();
					} 
					return true;
				}
				catch {
					try{
						Console.Error.WriteLine ("2nd level checking");
						var client2 = new TcpClient();
						if (!client2.ConnectAsync (host2, port).Wait (timeout)) {
							client2.Close ();
						}
						return true;
					}
					catch {
						try{
							Console.Error.WriteLine ("3rd level checking");
							var client3 = new TcpClient();
							if (!client3.ConnectAsync (host3, port).Wait (timeout)) {
								dialogErrorInternet (context, errorInternet, close);
								client3.Close ();
								return false;
							}
							return true;
						}
						catch {
							Console.Error.WriteLine ("internet off");
							dialogErrorInternet (context, errorInternet, close);
							return false;
						}
					}
				}

			} else {
				Console.Error.WriteLine ("internet off");
				dialogErrorInternet (context, errorInternet, close);
				return false;

			}

		}

		//no dialog alert
		public static bool IsOnline (Activity context)
		{
			//for checking internet is on 
			ConnectivityManager connectivityManager = (ConnectivityManager)context.GetSystemService("connectivity");
			var activeConnection = connectivityManager.ActiveNetworkInfo;

			//internet is on
			if ((activeConnection != null) && activeConnection.IsConnected) {

				Console.Error.WriteLine ("1st level checking");
				var client1 = new TcpClient();
				try{
					if (!client1.ConnectAsync (host1, port).Wait (timeout)) {
						client1.Close ();
					} 

					return true;
				}
				catch {
					try{
						Console.Error.WriteLine ("2nd level checking");
						var client2 = new TcpClient();
						if (!client2.ConnectAsync (host2, port).Wait (timeout)) {
							client2.Close ();
						}
						return true;
					}
					catch {
						try{
							Console.Error.WriteLine ("3rd level checking");
							var client3 = new TcpClient();
							if (!client3.ConnectAsync (host3, port).Wait (timeout)) {
								client3.Close ();
								return false;
							}
							return true;
						}
						catch {
							Console.Error.WriteLine ("internet off");
							return false;
						}
					}
				}

			} else {
				Console.Error.WriteLine ("internet off");
				return false;
			}
		}

		//closeActivity is for finish() activity
		public static void dialogErrorInternet(Activity context,int errorType,int close){

			context.RunOnUiThread (() => {
				string errorMsg = "";
				if(errorType == errorInternet){
					errorMsg = "Ralat. Sila semak sambungan internet anda.";
				}else if(errorType == errorServer){
					errorMsg = "Ralat. Server Pi1M dalam proses penyelenggaraan .";
				}

				Android.App.AlertDialog alertDialog;
				Android.App.AlertDialog.Builder alertDialogBuilder = new Android.App.AlertDialog.Builder (context);

				alertDialogBuilder
					.SetTitle ("Masalah")
					.SetMessage (string.Format (errorMsg))
					.SetCancelable (false)
					.SetPositiveButton ("OK", delegate {
						if(close==closeActivity){
							context.Finish ();
						}
					});
				alertDialog = alertDialogBuilder.Create ();
				alertDialog.Show ();


			});
		}


	}
}

