
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
using Android.Support.V7.Widget;
using Android.Graphics;

namespace PI1M_Dashboard.T1.Droid
{
	public class MyShop_MyLinearLayoutManager : LinearLayoutManager {


		public MyShop_MyLinearLayoutManager(Context context) : base (context)
		{
			
		}
		public MyShop_MyLinearLayoutManager(Context context, int orientation, bool reverseLayout) : base(context, orientation, reverseLayout)
		{
			
		}

		private int[] mMeasuredDimension = new int[2];


		public override void OnMeasure(RecyclerView.Recycler recycler, RecyclerView.State state, int widthSpec, int heightSpec) 
		{
			var widthMode = Android.Views.View.MeasureSpec.GetMode (widthSpec);
			var heightMode = Android.Views.View.MeasureSpec.GetMode (heightSpec);
			int widthSize = View.MeasureSpec.GetSize(widthSpec);
			int heightSize = View.MeasureSpec.GetSize(heightSpec);
			int width = 0;
			int height = 0;

			for (int i = 0; i < ItemCount; i++) {
				measureScrapChild(recycler, i,
					View.MeasureSpec.MakeMeasureSpec(i, MeasureSpecMode.Unspecified),
					View.MeasureSpec.MakeMeasureSpec(heightSize, heightMode),
					mMeasuredDimension);

				if (Orientation == Horizontal) {
					width = width + mMeasuredDimension[0];
					if (i == 0) {
						height = mMeasuredDimension[1];
					}
				} else {
					height = height + mMeasuredDimension[1];
					if (i == 0) {
						width = mMeasuredDimension[0];
					}
				}
			}

			switch (widthMode) {

			case MeasureSpecMode.Exactly:
				width = widthSize;
				break;
			case MeasureSpecMode.AtMost:
				break;
			case MeasureSpecMode.Unspecified:
				break;
			default:
				break;
			}

			switch (heightMode) {
			case MeasureSpecMode.Exactly:
				height = heightSize;
				break;
			case MeasureSpecMode.AtMost:
				break;
			case MeasureSpecMode.Unspecified:
				break;
			default:
					break;
			}

			SetMeasuredDimension(width, height);
		}
			
		/*private void measureScrapChild(RecyclerView.Recycler recycler, int position, int widthSpec,
			int heightSpec, int[] measuredDimension)
		{
			
			View view = recycler.GetViewForPosition(position);
			recycler.BindViewToPosition(view, position);

			if (view != null)
			{
				view.Measure(widthSpec, heightSpec);
				//MeasureChildWithMargins(view, widthSpec, heightSpec);
				measuredDimension[0] = view.MeasuredWidth;
				measuredDimension[1] = view.MeasuredHeight;
				recycler.RecycleView(view);
			}
		}*/
		private void measureScrapChild(RecyclerView.Recycler recycler, int position, int widthSpec,
			int heightSpec, int[] measuredDimension) {

			View view = recycler.GetViewForPosition(position);
			recycler.BindViewToPosition(view, position);

			base.MeasureChildWithMargins (view, 0,0);

			if (view != null) {

				RecyclerView.LayoutParams p = view.LayoutParameters.JavaCast<RecyclerView.LayoutParams>();
				int childWidthSpec = ViewGroup.GetChildMeasureSpec (widthSpec,
					                     PaddingLeft + PaddingRight, p.Width);
				int childHeightSpec = ViewGroup.GetChildMeasureSpec (heightSpec,
					                      PaddingTop + PaddingBottom, p.Height);
				view.Measure (childWidthSpec, childHeightSpec);
				measuredDimension [0] = view.MeasuredWidth + p.LeftMargin + p.RightMargin;
				measuredDimension [1] = view.MeasuredHeight + p.BottomMargin + p.TopMargin;
				recycler.RecycleView (view);
			}
		}
	}
}

