
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
	public class MyHealth_HeaderInfo
	{
		public string Name { get; set;}
		public List<MyHealth_DetailInfo> detailList { get; set; }

	}
}

