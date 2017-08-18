using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using System;
using Android.Support.V7.Widget;
using RecyclerViewSnap.Src.Models;
using System.Collections.Generic;
using RecyclerViewSnap.Src.Adapters;
using Android.Content;
using RecyclerViewSnap.Src.Views;

namespace RecyclerViewSnap
{
    [Activity(Label = "RecyclerViewSnap", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, Android.Support.V7.Widget.Toolbar.IOnMenuItemClickListener
    {
        public string ORIENTATION = "orientation";

        private RecyclerView mRecyclerView;
        private bool mHorizontal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.main);
            toolbar.SetOnMenuItemClickListener(this);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            mRecyclerView.HasFixedSize = (true);

            if (savedInstanceState == null)
            {
                mHorizontal = true;
            }
            else
            {
                mHorizontal = savedInstanceState.GetBoolean(ORIENTATION);
            }

            SetupAdapter();
        }

        private void SetupAdapter()
        {
            List<App> apps = GetApps();

            SnapAdapter snapAdapter = new SnapAdapter();
            if (mHorizontal)
            {
                snapAdapter.AddSnap(new Snap((int)GravityFlags.CenterHorizontal, "Snap center", GetApps()));
                snapAdapter.AddSnap(new Snap((int)GravityFlags.Start, "Snap start", GetApps()));
                snapAdapter.AddSnap(new Snap((int)GravityFlags.End, "Snap end", GetApps()));
                snapAdapter.AddSnap(new Snap((int)GravityFlags.Center, "GravityPager snap", GetApps()));
                mRecyclerView.SetAdapter(snapAdapter);
            }
            else
            {
                RecyclerViewSnap.Src.Adapters.Adapter adapter = new RecyclerViewSnap.Src.Adapters.Adapter(false, false, GetApps());
                mRecyclerView.SetAdapter(adapter);
            }
        }
        public bool OnMenuItemClick(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.layoutType)
            {
                mHorizontal = !mHorizontal;
                SetupAdapter();
                item.SetTitle(mHorizontal ? "Vertical" : "Horizontal");
            }
            else if (item.ItemId == Resource.Id.grid)
            {
                StartActivity(new Intent(this, typeof(GridActivity)));
            }
            return false;
        }
        private List<App> GetApps()
        {
            List<App> apps = new List<App>();
            apps.Add(new App("Google+", Resource.Drawable.ic_google_48dp, 4.6f));
            apps.Add(new App("Gmail", Resource.Drawable.ic_gmail_48dp, 4.8f));
            apps.Add(new App("Inbox", Resource.Drawable.ic_inbox_48dp, 4.5f));
            apps.Add(new App("Google Keep", Resource.Drawable.ic_keep_48dp, 4.2f));
            apps.Add(new App("Google Drive", Resource.Drawable.ic_drive_48dp, 4.6f));
            apps.Add(new App("Hangouts", Resource.Drawable.ic_hangouts_48dp, 3.9f));
            apps.Add(new App("Google Photos", Resource.Drawable.ic_photos_48dp, 4.6f));
            apps.Add(new App("Messenger", Resource.Drawable.ic_messenger_48dp, 4.2f));
            apps.Add(new App("Sheets", Resource.Drawable.ic_sheets_48dp, 4.2f));
            apps.Add(new App("Slides", Resource.Drawable.ic_slides_48dp, 4.2f));
            apps.Add(new App("Docs", Resource.Drawable.ic_docs_48dp, 4.2f));
            apps.Add(new App("Google+", Resource.Drawable.ic_google_48dp, 4.6f));
            apps.Add(new App("Gmail", Resource.Drawable.ic_gmail_48dp, 4.8f));
            apps.Add(new App("Inbox", Resource.Drawable.ic_inbox_48dp, 4.5f));
            apps.Add(new App("Google Keep", Resource.Drawable.ic_keep_48dp, 4.2f));
            apps.Add(new App("Google Drive", Resource.Drawable.ic_drive_48dp, 4.6f));
            apps.Add(new App("Hangouts", Resource.Drawable.ic_hangouts_48dp, 3.9f));
            apps.Add(new App("Google Photos", Resource.Drawable.ic_photos_48dp, 4.6f));
            apps.Add(new App("Messenger", Resource.Drawable.ic_messenger_48dp, 4.2f));
            apps.Add(new App("Sheets", Resource.Drawable.ic_sheets_48dp, 4.2f));
            apps.Add(new App("Slides", Resource.Drawable.ic_slides_48dp, 4.2f));
            apps.Add(new App("Docs", Resource.Drawable.ic_docs_48dp, 4.2f));
            return apps;
        }
    }


}

