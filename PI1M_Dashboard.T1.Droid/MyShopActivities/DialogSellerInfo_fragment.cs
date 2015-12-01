using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PI1M_Dashboard.T1.Droid;


namespace myShopDescription
{
	public class DialogSellerInfo_fragment : DialogFragment
	{

		private TextView txtNama;
		private TextView txtNoTelefon;
		private TextView txtEmail;
		private TextView txtGST;
		private Button mbtnTutup;

		string name,phone,email,gstID;

		public  DialogSellerInfo_fragment(String name,String phone,String email,String gstID)
		{
			this.name = name;
			this.phone = phone;
			this.email = email;
			this.gstID = gstID;


		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.seller_info, container, false);

			txtNama = view.FindViewById<TextView> (Resource.Id.txtNama);
			txtNoTelefon = view.FindViewById<TextView> (Resource.Id.txtNoTelefon);
			txtEmail = view.FindViewById<TextView> (Resource.Id.txtEmail);
			txtGST= view.FindViewById<TextView> (Resource.Id.txtGST);
			mbtnTutup = view.FindViewById<Button> (Resource.Id.btnDialogTutup);

			mbtnTutup.Click += mbtnTutup_Click;

			return view;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{

			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;

			txtNama.Text = name;
			txtNoTelefon.Text = phone;
			txtEmail.Text = email;

			if(!object.Equals(gstID, "0"))
				txtGST.Text = gstID;
			else
				txtGST.Text = "Tiada GST ID";
		}

		void mbtnTutup_Click (object sender, EventArgs e)
		{
			this.Dismiss ();
		}

	}
}