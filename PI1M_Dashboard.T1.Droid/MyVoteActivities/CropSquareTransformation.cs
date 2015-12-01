
using System;

using Square.Picasso;
using Android.Graphics;

namespace MyVote
{		
	public class CropSquareTransformation : Java.Lang.Object, ITransformation
	{
		public Bitmap Transform (Bitmap bitmap)
		{
			int size = Math.Min(bitmap.Width, bitmap.Height);
			int x = (bitmap.Width - size) / 2;
			int y = (bitmap.Height - size) / 2;
			Bitmap result = Bitmap.CreateBitmap(bitmap, x, y, size, size);
			if (result != bitmap) {
				bitmap.Recycle();
			}
			return result;
		}

		public string Key {
			
			get { return "square()"; } 

		}
	}
}

