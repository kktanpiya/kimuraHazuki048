﻿using System;
using Android.Util;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Content;
using Square.Picasso;
using Java.Lang;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PI1M_Dashboard.T1.Droid
{
	public class Product_RecyclerViewAdapter : RecyclerView.Adapter
	{
		TypedValue typedValue = new TypedValue();
		int background;
		Activity parent;

		int totalItem;
		private List<MyShop_WebService.Product_Datum> prodList;

		public Product_RecyclerViewAdapter (Activity context, List<MyShop_WebService.Product_Datum> prodList,int totalItem)
		{
			parent = context;
			context.Theme.ResolveAttribute (Resource.Attribute.selectableItemBackground,typedValue, true);
			background = typedValue.ResourceId;
			this.totalItem = totalItem;
			this.prodList = prodList;
		}

		public class Product_ViewHolder : RecyclerView.ViewHolder
		{
			public string BoundString{ get; set;}
			public View View { get; set;}
			public ImageView ImageView { get; set;}
			public TextView txtPrice { get; set;}
			public TextView txtProdName { get; set;}
			public TextView txtProdDate { get; set;}

			public Product_ViewHolder (View view) : base (view)
			{
				View =  view;
				ImageView = view.FindViewById<ImageView>(Resource.Id.prodImage);
				txtPrice = view.FindViewById<TextView>(Resource.Id.txtPrice);
				txtProdName = view.FindViewById<TextView>(Resource.Id.txtProdName);
				txtProdDate = view.FindViewById<TextView>(Resource.Id.txtProdDate);
			}
		}

		public class ProgressViewHolder : RecyclerView.ViewHolder
		{
			public ProgressBar progressBar { get; private set; }

			public ProgressViewHolder (View itemView) : base (itemView)
			{
				progressBar = itemView.FindViewById <ProgressBar> (Resource.Id.progress_bar);
			}
		}

		protected class VIEW_TYPES 
		{
			public static  int NORMAL = 0;
			public static  int FOOTER = 1;
			public static  int ENDOFLIST = 2;
		}

		public override int GetItemViewType (int position)
		{
			int type=-1;

			if (position < prodList.Count - 1) {
				type = 0;
			} else if (totalItem == prodList.Count) {
				type = 2;

			} else if (position == prodList.Count - 1) {
				type = 1;
			}
			return type;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			RecyclerView.ViewHolder vh;
			if (viewType == VIEW_TYPES.NORMAL || viewType == VIEW_TYPES.ENDOFLIST) {
				var view = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyShop_listall_item, parent, false);
				view.SetBackgroundResource (background);
				return new Product_ViewHolder (view);
			}
			else {
				View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyShop_btmProgressbar, parent, false);
				vh = new ProgressViewHolder (itemView);

				return vh;
			}
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			if (holder.GetType () == typeof(Product_ViewHolder)) {

				DateTime dt = Convert.ToDateTime (prodList [position].created_at);
				string ProdDate = dt.ToString ("MMM dd, yyyy");

				var h = holder as Product_ViewHolder;
				h.txtPrice.Text = prodList [position].price;
				h.txtProdName.Text = prodList [position].title;
				h.txtProdDate.Text = ProdDate;
				h.View.SetTag (Resource.Id.recyclerView, Int32.Parse (prodList [position].id));
				h.View.Click += Product_Click;

				PicassoSetImage (prodList [position].url_photo_thumb, h.ImageView, h);
			}
		}

		public override void OnViewRecycled (Java.Lang.Object holder)
		{
			if (holder.GetType () == typeof(Product_ViewHolder)) {

				var h = holder as Product_ViewHolder;

				//untuk clear balik += time mula2 declare
				h.View.Click -= Product_Click;

				Log.Debug ("Recycled Debug", "OnViewRecycled entered...");
				base.OnViewRecycled (holder);
			}
		}

		public override int ItemCount
		{
			get { return prodList.Count; }
		}


		public void Product_Click (object sender, EventArgs e)
		{
			int product_id = (int) (((View) sender).GetTag(Resource.Id.recyclerView));
			var intent = new Intent (parent, typeof(Product_Details));
			intent.PutExtra("product_id", product_id);
			parent.StartActivity (intent);

		}

		public void PicassoSetImage(string url, ImageView poster, RecyclerView.ViewHolder holder)
		{
			//Picasso handling image from api url
			Picasso.With (parent)
				.Load (url)
				.Into(poster);
		}


		public class  ViewOnScrollListener : RecyclerView.OnScrollListener
		{
			public delegate void LoadMoreEventHandler(object sender, EventArgs e);
			public event LoadMoreEventHandler LoadMoreEvent;

			private LinearLayoutManager LayoutManager;

			public ViewOnScrollListener (LinearLayoutManager layoutManager)
			{
				LayoutManager = layoutManager;
			}

			public override void OnScrolled (RecyclerView recyclerView, int dx, int dy)
			{
				base.OnScrolled (recyclerView, dx, dy);

				var visibleItemCount = recyclerView.ChildCount;

				var totalItemCount = recyclerView.GetAdapter().ItemCount;
				var lastVisibleItem = ((LinearLayoutManager)recyclerView.GetLayoutManager()).FindLastCompletelyVisibleItemPosition();

				if ((lastVisibleItem+1) == totalItemCount) {
					LoadMoreEvent (this, null);
				}
			}
		}
	}
}

