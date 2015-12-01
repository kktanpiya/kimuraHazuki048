
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

namespace MyVote
{
	[Activity (Label = "SquareImageView")]			
	public class SquareImageView : ImageView
	{
		public SquareImageView (Context context) : base(context)
		{
			
		}

		public SquareImageView (Context context,  IAttributeSet attrs) : base (context, attrs)
		{

		}

		public SquareImageView (Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
		{

		}

		protected virtual void OnDraw (Canvas canvas) 
		{
			base.OnDraw (canvas);
		}

		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure (widthMeasureSpec, heightMeasureSpec);
			//create a square view
			SetMeasuredDimension (MeasuredWidth, MeasuredWidth);
		}
	}
}

