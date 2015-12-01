
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
using Android.Support.V4.App;

namespace PI1M_Dashboard.T1.Droid
{		
	public class MyKomuniti_ViewPagerAdapter : FragmentPagerAdapter
	{
		public List<string> mTitles = new List<string>();
		Android.Support.V4.App.Fragment fragment;

		public MyKomuniti_ViewPagerAdapter (Android.Support.V4.App.FragmentManager fm) : base (fm)
		{
			mTitles.Add ("Awam");
			mTitles.Add ("Pentadbir");
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			switch (position) {

			case 0:
				fragment = new MyKomuniti_Tab_1();
				break;
			case 1:
				fragment = new MyKomuniti_Tab_2();
				break;
			}

			return fragment;
		}
			
		public string GetHeaderTitle(int position)
		{
			return mTitles[position];
		}

		public override int Count
		{
			get { return mTitles.Count; }
		}
	}
}

