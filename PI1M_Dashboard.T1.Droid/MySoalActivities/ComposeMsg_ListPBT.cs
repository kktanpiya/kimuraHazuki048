
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
using Newtonsoft.Json;
using Android.Util;
using Android.Support.V7.App;
using Android.Graphics;
using Android.Content.PM;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Pilih Senarai PBT", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class ComposeMsg_ListPBT : ActionBarActivity
	{
		ListView listView;
		List<WebServices.MSPBTRootObject> listItems;
		SparseBooleanArray sparseArray;
		List<string> pbtListArray;
		List<string> pbtListIDArray;
		Button btnMSCMLPBTLSubmit;

		private Android.Support.V7.Widget.Toolbar toolbar;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.MySoal_ComposeMsgListPBTLayout);

			WebServices.MSPBTRootObject pbtList = GetPBTList ();

			pbtListArray = new List<string> ();
			pbtListIDArray = new List<string> ();

			foreach (var pbtListExtract in pbtList.pbt) {
				pbtListArray.Add (pbtListExtract.School.name);
				pbtListIDArray.Add (pbtListExtract.School.id);
			}

			listView = FindViewById<ListView>(Resource.Id.lvMSCMLPBTLpbt);
			listItems = new List<WebServices.MSPBTRootObject>();
			listView.Adapter = new ArrayAdapter(this, Resource.Layout.MySoal_SimpleListItemModified, pbtListArray);
			listView.ChoiceMode = ChoiceMode.Multiple;

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.app_bar);
			toolbar.SetBackgroundColor (Color.ParseColor ("#F44336"));
			SetSupportActionBar (toolbar);

			btnMSCMLPBTLSubmit = FindViewById<Button> (Resource.Id.btnMSCMLPBTLSubmit);

			btnMSCMLPBTLSubmit.Click += SetToAddress;

		}

		private WebServices.MSPBTRootObject GetPBTList()
		{
			WebServices wbs = new WebServices ();
			string mysoalPBTRaw = wbs.getMySoalPBT (Intent.GetStringExtra ("SiteCode"));
			WebServices.MSPBTRootObject pbtList = JsonConvert.DeserializeObject<WebServices.MSPBTRootObject> (mysoalPBTRaw);
			//Toast.MakeText (this, mysoalPBTRaw, ToastLength.Short).Show ();

			return pbtList;
		}

		private void SetToAddress(object sender, EventArgs e)
		{
			
			List<string> PBT_selected = new List<string>();
			List<string> ID_PBT_selected = new List<string>();
			sparseArray = FindViewById<ListView> (Resource.Id.lvMSCMLPBTLpbt).CheckedItemPositions;

			string Pbt_Name_selected;
			string Pbt_ID_selected;

			for (var i = 0; i < sparseArray.Size (); i++) {

				string selectedValue = string.Empty;
				string ID_selected = string.Empty;

				int position = sparseArray.KeyAt(i);

				if (sparseArray.ValueAt (i) == true) 
				{
					selectedValue = listView.GetItemAtPosition (position).ToString ();
					ID_selected = pbtListIDArray[position];
					//groups.Remove (groups [position]);
					//Android.Widget.Toast.MakeText(this,"Subscribed for "+selectedValue, Android.Widget.ToastLength.Short).Show();
					//searchGroupAdapter.NotifyDataSetChanged ();

					PBT_selected.Add(selectedValue);
					ID_PBT_selected.Add(ID_selected);
				}

			}

			Pbt_Name_selected = String.Join(" , ", PBT_selected);
			Pbt_ID_selected = String.Join(" , ", ID_PBT_selected);

			Intent intentToSend = new Intent();
			intentToSend.PutExtra("PBT_Name",Pbt_Name_selected.ToString());
			intentToSend.PutExtra("PBT_ID",Pbt_ID_selected.ToString());
			SetResult(Result.Ok,intentToSend);

			this.Finish ();
			this.OverridePendingTransition (0, 0);
		}

	}
}

