
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

namespace PI1M_Dashboard.T1.Droid
{			
	public class MySoal_Child_Data
	{
		public string mDetail { get; set;}
		public string mDate { get; set;}
		public string mMonth { get; set;}

		public MySoal_Child_Data(string month, string detail, string date)
		{
			mMonth = month;
			mDetail = detail;
			mDate = date;
		}

		public static List<MySoal_Child_Data> childData()
		{
			var newChildData = new List<MySoal_Child_Data> ();
			newChildData.Add (new MySoal_Child_Data("January", "Cuti Tahun Baru", "2015"));
			newChildData.Add (new MySoal_Child_Data("January", "Maulidur Rasul", "2015"));
			newChildData.Add (new MySoal_Child_Data("January", "Hari Keputeraan YDB N.Sembilan", "2015"));
			newChildData.Add (new MySoal_Child_Data("January", "Hari Keputeraan Kedah", "2015"));
			newChildData.Add (new MySoal_Child_Data("February", "Hari Wilayah Persekutuan", "2015"));
			newChildData.Add (new MySoal_Child_Data("February", "Thaipusam", "2015"));
			newChildData.Add (new MySoal_Child_Data("February", "Tahun Baru Cina", "2015"));
			newChildData.Add (new MySoal_Child_Data("Mac", "Ulang Tahun Pertabalan Sultan Terengganu", "2015"));
			newChildData.Add (new MySoal_Child_Data("April", "Good Friday", "2015"));
			newChildData.Add (new MySoal_Child_Data("April", "Hari Melaka Bandaraya Bersejarah", "2015"));
			newChildData.Add (new MySoal_Child_Data("April", "Hari Keputeraan Sultan Terengganu", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Hari Pekerja", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Hari Wesak", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Hari Hol", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Israk Mikraj", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Hari Keputeraan Perlis", "2015"));
			newChildData.Add (new MySoal_Child_Data("May", "Hari Kaamatan", "2015"));
			newChildData.Add (new MySoal_Child_Data("June", "Hari Gawai", "2015"));
			newChildData.Add (new MySoal_Child_Data("June", "Hari Keputeraan YDP Agong", "2015"));
			newChildData.Add (new MySoal_Child_Data("June", "Awal Ramadhan", "2015"));


			return newChildData;
		}
			
	}
}

