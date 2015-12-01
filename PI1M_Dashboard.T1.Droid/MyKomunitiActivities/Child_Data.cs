
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
	public class MyKomuniti_Child_Data
	{
		public string mDetail { get; set;}
		public string mTitle { get; set;}
		public string mDate { get; set;}
		public string mMonth { get; set;}
		public string mDay { get; set; }
		public string mMonthShort { get; set; }

		public MyKomuniti_Child_Data(string month, string monthShort, string title, string detail, string day, string date)
		{
			mMonth = month;
			mMonthShort = monthShort;
			mTitle = title;
			mDetail = detail;
			mDay = day;
			mDate = date;
		}

		public static List<MyKomuniti_Child_Data> childData()
		{
			var newChildData = new List<MyKomuniti_Child_Data> ();
			newChildData.Add (new MyKomuniti_Child_Data("Januari", "Jan", "Cuti Tahun Baru", "Semua Negeri kecuali Johor, Kedah, Kelantan, Perlis dan Terengganu", "1", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Januari", "Jan", "Maulidur Rasul", "Semua Negeri", "3", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Januari", "Jan", "Hari Keputeraan YDB N.Sembilan", "Negeri Sembilan sahaja.", "14", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Januari", "Jan", "Hari Keputeraan Kedah", "Kedah sahaja.", "18", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Februari", "Feb", "Hari Wilayah Persekutuan", "Negeri-negeri Wilayah Persekutuan sahaja.", "1", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Februari", "Feb", "Thaipusam", "Kuala Lumpur, Putrajaya, Johor, Negeri Sembilan, Perak, Pulau Pinang & Selangor sahaja.", "3", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Februari", "Feb", "Tahun Baru Cina", "Semua Negeri", "19", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Februari", "Feb", "Tahun Baru Cina", "Semua Negeri", "20", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mac", "Mac", "Ulang Tahun Pertabalan Sultan Terengganu", "Terengganu sahaja.", "4", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("April", "Apr", "Good Friday", "Sabah dan Sarawak sahaja.", "3", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("April", "Apr", "Hari Melaka Bandaraya Bersejarah", "Melaka sahaja.", "15", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("April", "Apr", "Hari Keputeraan Sultan Terengganu", "Terengganu sahaja.", "26", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Pekerja", "Semua Negeri", "1", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Wesak", "Semua Negeri", "3", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Hol", "Pahang sahaja", "7", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Israk Mikraj", "Kedah, Negeri Sembilan dan Perlis sahaja", "16", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Keputeraan Perlis", "Perlis sahaja", "17", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Kaamatan", "Sabah dan Labuan sahaja", "30", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Mei", "May", "Hari Kaamatan", "Sabah dan Labuan sahaja", "31", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Jun", "Jun", "Hari Gawai", "Sarawak sahaja", "1", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Jun", "Jun", "Hari Gawai", "Sarawak sahaja", "2", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Jun", "Jun", "Hari Keputeraan YDP Agong", "Semua Negeri", "6", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Jun", "Jun", "Awal Ramadhan", "Johor, Kedah dan Melaka sahaja", "18", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Julai", "Jul", "Nuzul Al-Quran", "Kelantan, Pahang, Perak, Perlis, Pulau Pinang, Selangor, Terengganu dan Wilayah Persekutuan sahaja", "4", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Julai", "Jul", "Hari Georgetown Kota Bersejarah Dunia", "Pulau Pinang sahaja", "7", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Julai", "Jul", "Hari Raya Aidil Fitri", "Semua Negeri", "17", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Julai", "Jul", "Hari Raya Aidil Fitri", "Semua Negeri", "18", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Julai", "Jul", "Hari Raya Aidil Fitri", "Semua Negeri", "18", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Ogos", "Aug", "Hari Kebangsaan", "Semua Negeri", "31", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("September", "Sep", "Ulang Tahun Kelahiran Gabenor Sarawak", "Sarawak sahaja", "12", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("September", "Sep", "Hari Raya Aidil Adha", "Semua Negeri", "24", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("September", "Sep", "Hari Raya Aidil Adha", "Kedah, Kelantan, Perlis dan Terengganu sahaja", "25", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Oktober", "Oct", "Ulang Tahun Kelahiran Gabenor Sabah", "Sabah sahaja", "3", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Oktober", "Oct", "Ulang Tahun Kelahiran Gabenor Melaka", "Melaka sahaja", "9", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Oktober", "Oct", "Awal Muharram (Maal Hijrah)", "Semua Negeri", "14", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Oktober", "Oct", "Hari Keputeraan Sultan Pahang", "Pahang sahaja", "24", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Deepavali", "Semua Negeri kecuali Sarawak", "10", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Keputeraan Sultan Kelantan", "Kelantan sahaja", "11", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Keputeraan Sultan Kelantan", "Kelantan sahaja", "12", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Hol Sultan Johor", "Johor sahaja", "18", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Keputeraan Sultan Johor", "Johor sahaja", "22", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("November", "Nov", "Hari Keputeraan Sultan Perak", "Perak sahaja", "27", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Disember", "Dec", "Hari Keputeraan Sultan Selangor", "Selangor sahaja", "11", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Disember", "Dec", "Maulidur Rasul", "Semua Negeri", "24", "2015"));
			newChildData.Add (new MyKomuniti_Child_Data("Disember", "Dec", "Hari Natal", "Semua Negeri", "25", "2015"));

			return newChildData;
		}
			
	}
}

