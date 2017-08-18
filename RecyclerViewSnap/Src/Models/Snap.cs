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
    public class Snap
    {
        public int mGravity { get; set; }
        public string mText { get; set; }
        public List<App> mApps { get; set; }

        public Snap(int mGravity, string mText, List<App> mApps)
        {
            this.mGravity = mGravity;
            this.mText = mText;
            this.mApps = mApps;
        }
    }
}