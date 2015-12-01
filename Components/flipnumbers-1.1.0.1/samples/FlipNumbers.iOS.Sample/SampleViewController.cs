using System;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

#else
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
#endif

using FlipNumbers;

namespace FlipNumbers.iOS.Sample
{
	public partial class SampleViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Random rnd = new Random ((int)DateTime.UtcNow.Ticks);

			// background
			using (var image = UIImage.FromBundle ("back.png")) { 
				UIImageView imageView = new UIImageView (image); 
				imageView.Frame = View.Frame; 
				imageView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions; 
				View.AddSubview (imageView); 
			} 

			// the flip numbers
			FlipNumbersView flipView = new FlipNumbersView (digitsCount: 4);
			// flipView.FlipDuration = 1.0;
			flipView.Value = rnd.Next (9999);
			View.AddSubview (flipView);
			flipView.Center = View.Center;

			// the button
			UIButton randomize = new UIButton (UIButtonType.RoundedRect); 
			randomize.Frame = new CGRect (12, View.Frame.Height - 12 - 50 - 12, View.Frame.Width - 12 - 12, 50);
			randomize.BackgroundColor = UIColor.DarkGray; 
			randomize.AutoresizingMask = UIViewAutoresizing.FlexibleMargins; 
			randomize.SetTitle ("Flip To New Number", UIControlState.Normal); 
			randomize.TouchUpInside += delegate { 
				flipView.SetValue (rnd.Next (9999), animated: true);
			}; 
			View.AddSubview (randomize); 
		}
	}
}
