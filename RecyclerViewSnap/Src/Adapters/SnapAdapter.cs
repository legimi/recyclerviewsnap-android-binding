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
using Com.Github.Rubensousa.Gravitysnaphelper;
using RecyclerViewSnap.Src.Models;
using static Android.Support.V7.Widget.RecyclerView;

namespace RecyclerViewSnap.Src.Adapters
{
    public class SnapAdapter : RecyclerView.Adapter, GravitySnapHelper.ISnapListener
    {
        public int VERTICAL = 0;
        public int HORIZONTAL = 1;

        private List<Snap> mSnaps;

        public SnapAdapter()
        {
            mSnaps = new List<Snap>();
        }

        public void AddSnap(Snap snap)
        {
            mSnaps.Add(snap);
        }

        private OnTouchListener mTouchListener = new OnTouchListener()
        {
            OnTouchAction = (v, e) =>
            {
                v.Parent.RequestDisallowInterceptTouchEvent(true);
            }
        };
        public override int ItemCount
        {
            get { return mSnaps.Count; }
        }

        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            Snap snap = mSnaps[position];
            ((SnapAdapterViewHolder)holder).snapTextView.Text = (snap.mText);

            if (snap.mGravity == ((int)GravityFlags.Start) || snap.mGravity == ((int)GravityFlags.End))
            {
                ((SnapAdapterViewHolder)holder).recyclerView.SetLayoutManager(new LinearLayoutManager(((SnapAdapterViewHolder)holder)
                        .recyclerView.Context, LinearLayoutManager.Horizontal, false));
                new GravitySnapHelper(snap.mGravity, false, this).AttachToRecyclerView(((SnapAdapterViewHolder)holder).recyclerView);
            }
            else if (snap.mGravity == (int)GravityFlags.CenterHorizontal ||
                  snap.mGravity == (int)GravityFlags.CenterVertical)
            {
                ((SnapAdapterViewHolder)holder).recyclerView.SetLayoutManager(new LinearLayoutManager(((SnapAdapterViewHolder)holder)
                        .recyclerView.Context, snap.mGravity == (int)GravityFlags.CenterHorizontal ?
                        LinearLayoutManager.Horizontal : LinearLayoutManager.Vertical, false));
                new LinearSnapHelper().AttachToRecyclerView(((SnapAdapterViewHolder)holder).recyclerView);
            }
            else if (snap.mGravity == ((int)GravityFlags.Center))
            { // Pager snap
                ((SnapAdapterViewHolder)holder).recyclerView.SetLayoutManager(new LinearLayoutManager(((SnapAdapterViewHolder)holder)
                        .recyclerView.Context, LinearLayoutManager.Horizontal, false));
                new GravityPagerSnapHelper(((int)GravityFlags.Start)).AttachToRecyclerView(((SnapAdapterViewHolder)holder).recyclerView);
            }
            else
            { // Top / Bottom
                ((SnapAdapterViewHolder)holder).recyclerView.SetLayoutManager(new LinearLayoutManager(((SnapAdapterViewHolder)holder)
                        .recyclerView.Context));
                new GravitySnapHelper(snap.mGravity).AttachToRecyclerView(((SnapAdapterViewHolder)holder).recyclerView);
            }


            ((SnapAdapterViewHolder)holder).recyclerView.SetAdapter(new Adapter(snap.mGravity == ((int)GravityFlags.Start)
                    || snap.mGravity == ((int)GravityFlags.End)
                    || snap.mGravity == ((int)GravityFlags.CenterHorizontal),
                    snap.mGravity == ((int)GravityFlags.Center), snap.mApps));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = viewType == VERTICAL ? LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.adapter_snap_vertical, parent, false)
                : LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.adapter_snap, parent, false);

            if (viewType == VERTICAL)
            {
                view.FindViewById(Resource.Id.recyclerView).SetOnTouchListener(mTouchListener);
            }

            return new SnapAdapterViewHolder(view);
        }

        public override int GetItemViewType(int position)
        {
            Snap snap = mSnaps[position];
            switch (snap.mGravity)
            {
                case (int)GravityFlags.CenterVertical:
                    return VERTICAL;
                case (int)GravityFlags.CenterHorizontal:
                    return HORIZONTAL;
                case (int)GravityFlags.Start:
                    return HORIZONTAL;
                case (int)GravityFlags.Top:
                    return VERTICAL;
                case (int)GravityFlags.End:
                    return HORIZONTAL;
                case (int)GravityFlags.Bottom:
                    return VERTICAL;
            }
            return HORIZONTAL;
        }

        public void OnSnap(int p0)
        {
        }



        class OnTouchListener : Java.Lang.Object, View.IOnTouchListener
        {
            public Action<View, MotionEvent> OnTouchAction;
            public bool OnTouch(View v, MotionEvent e)
            {
                OnTouchAction?.Invoke(v, e);
                return false;
            }
        }
        class SnapAdapterViewHolder : RecyclerView.ViewHolder
        {
            public TextView snapTextView;
            public RecyclerView recyclerView;
            public SnapAdapterViewHolder(View itemView) : base(itemView)
            {
                snapTextView = itemView.FindViewById<TextView>(Resource.Id.snapTextView);
                recyclerView = itemView.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            }
        }
    }
}