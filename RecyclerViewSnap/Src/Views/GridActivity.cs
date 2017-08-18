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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using RecyclerViewSnap.Src.Models;
using Com.Github.Rubensousa.Gravitysnaphelper;

namespace RecyclerViewSnap.Src.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class GridActivity : AppCompatActivity
    {
        private RecyclerView mRecyclerView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_grid);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            Adapters.Adapter adapter = new Adapters.Adapter(false, false, GetApps());

            mRecyclerView.SetLayoutManager(new GridLayoutManager(this, 2));
            mRecyclerView.HasFixedSize = (true);
            mRecyclerView.SetAdapter(adapter);
            new GravitySnapHelper((int)GravityFlags.Top).AttachToRecyclerView(mRecyclerView);
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