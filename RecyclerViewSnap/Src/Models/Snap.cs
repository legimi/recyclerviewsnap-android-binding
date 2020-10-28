using System.Collections.Generic;

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