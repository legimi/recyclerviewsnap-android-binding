﻿using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using RecyclerViewSnap.Src.Models;

namespace RecyclerViewSnap.Src.Adapters
{
    class Adapter : RecyclerView.Adapter
    {
        private List<App> mApps;
        private bool mHorizontal;
        private bool mPager;

        public Adapter(bool horizontal, bool pager, List<App> apps)
        {
            mHorizontal = horizontal;
            mApps = apps;
            mPager = pager;
        }
        public override int ItemCount
        {
            get { return mApps.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            App app = mApps[position];
            ((AdapterViewHolder)holder).imageView.SetImageResource(app.mDrawable);
            ((AdapterViewHolder)holder).nameTextView.Text = (app.mName);
            ((AdapterViewHolder)holder).ratingTextView.Text = (app.mRating + "");
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (mPager)
            {
                return new AdapterViewHolder(LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.adapter_pager, parent, false));
            }
            else
            {
                return mHorizontal ? new AdapterViewHolder(LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.adapter, parent, false)) :
                        new AdapterViewHolder(LayoutInflater.From(parent.Context)
                                .Inflate(Resource.Layout.adapter_vertical, parent, false));
            }
        }
        public override int GetItemViewType(int position)
        {
            return base.GetItemViewType(position);
        }

        public class AdapterViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
        {
            public ImageView imageView;
            public TextView nameTextView;
            public TextView ratingTextView;
            public AdapterViewHolder(View itemView) : base(itemView)
            {
                itemView.SetOnClickListener(this);
                imageView = itemView.FindViewById<ImageView>(Resource.Id.imageView);
                nameTextView = itemView.FindViewById<TextView>(Resource.Id.nameTextView);
                ratingTextView = itemView.FindViewById<TextView>(Resource.Id.ratingTextView);
            }

            public void OnClick(View v)
            {
            }
        }
    }
}