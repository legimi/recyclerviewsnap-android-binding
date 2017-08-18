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

namespace RecyclerViewSnap.Src.Models
{
    public class App
    {
        public int mDrawable { get; set; }
        public string mName { get; set; }
        public float mRating { get; set; }
        public App(string mName, int mDrawable, float mRating)
        {
            this.mDrawable = mDrawable;
            this.mName = mName;
            this.mRating = mRating;
        }
    }
}