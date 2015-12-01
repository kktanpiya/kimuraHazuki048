
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

namespace signupTest
{
	[Activity (Label = "dialog_signup")]			
	public class dialog_signup : DialogFragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			base.OnCreateView (inflater, container, savedInstanceState);


			var view = inflater.Inflate (Resource.Layout.sign_up_layout, container, false);

			return view;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{

			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;

		}

	}


}

