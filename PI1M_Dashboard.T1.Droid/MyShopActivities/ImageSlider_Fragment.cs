using Android.Support.V4.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Widget;
using System.Collections.Generic;
using Square.Picasso;
using System;
using Android.Content;
using Android.Views;

namespace PI1M_Dashboard.T1.Droid
{
	public class ImageSlider_Fragment : Fragment
	{
		private int position;
		private static List<string> listImageThumbsUrl = new List<string>();
		private static List<string> listImageOriUrl = new List<string>();

		public static ImageSlider_Fragment NewInstance(int position, List<string> listImageThumbsUrl, List<string> listImageOriUrl)
		{
			//assign urlimagelist to list
			ImageSlider_Fragment.listImageThumbsUrl = listImageThumbsUrl;
			ImageSlider_Fragment.listImageOriUrl = listImageOriUrl;

			var f = new ImageSlider_Fragment ();
			var b = new Bundle ();
			b.PutInt("position", position);
			f.Arguments = b;
			return f;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			position = Arguments.GetInt ("position");
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var root = inflater.Inflate(Resource.Layout.fragment_card, container, false);
			ImageView iv = root.FindViewById<ImageView> (Resource.Id.imageview);
		
			Picasso.With (Activity)
				.Load(listImageThumbsUrl[position])
				.Placeholder (Resource.Drawable.placeholder_poster)
				.Into(iv);

			iv.Click += (object sender, System.EventArgs e) => popup(listImageOriUrl[position]);

			ViewCompat.SetElevation(root, 50);
			return root;
		}

		private void popup(string url)
		{
			var activity2 = new Intent (Activity, typeof(ImageSlider_oriImage));
			activity2.PutExtra ("url", url);
			StartActivity (activity2);		
		}
	}
}

