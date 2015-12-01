
using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Square.Picasso;
using PI1M_Dashboard.T1.Droid;

namespace MyVote
{
	[Activity (Label = "FullImageView")]			
	public class FullImageView : Fragment
	{
		private ImageView ivImage;
		private ProgressBar progressbar;
		public Activity context;

		public static FullImageView newInstance(string stringUrl)
		{

			FullImageView fImage = new FullImageView ();

			Bundle args = new Bundle ();
			args.PutString ("stringUrl", stringUrl);
			fImage.Arguments = args;

			return fImage;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.MyVote_FullImageView, container, false);

			ivImage = view.FindViewById<ImageView> (Resource.Id.ivFullView);
			progressbar = view.FindViewById <ProgressBar> (Resource.Id.PBLoadingFullPoster);

			return view;
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			var imageUrl = Arguments.GetString ("stringUrl");

			Picasso.With (context)
				.Load (imageUrl)
				.Placeholder (Resource.Drawable.placeholder_poster)
				.Into (ivImage, delegate {
					progressbar.Visibility = ViewStates.Invisible;
				}, null);
		}
	}
}

