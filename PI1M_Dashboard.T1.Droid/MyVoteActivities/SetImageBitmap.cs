
using System;
using Android.Graphics;
using System.Net;
using System.Threading.Tasks;
using Android.Util;

namespace MyVote
{			
	public static class SetImageBitmap
	{
		static readonly Task<bool> falseTask = Task.FromResult(false);

		public async static Task<Bitmap> GetImageBitmapFromUrl(string url)
		{
			BitmapFactory.Options opts = new BitmapFactory.Options ();
			Bitmap imageBitmap = null;

			opts.InSampleSize = 1;

			using (var webClient = new WebClient ()) {

				var imageBytes = await webClient.DownloadDataTaskAsync (url);
				if (imageBytes != null && imageBytes.Length > 0) {

					imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length, opts);
					opts.InBitmap = imageBitmap;

					Log.Debug ("bitmapID", imageBitmap.ToString());
				}
			}

			return imageBitmap;
		}

	}
}

