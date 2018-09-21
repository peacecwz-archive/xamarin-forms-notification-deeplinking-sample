using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace NotificationsSample.Droid
{
    [Activity(Label = "NotificationsSample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { "android.intent.action.VIEW" },
        Categories = new[] {
            "android.intent.action.VIEW",
            "android.intent.category.DEFAULT",
            "android.intent.category.BROWSABLE"
        },
        DataScheme = "https",
        DataHost = "barisceviz.com",
        DataPathPrefix = "/")
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:827356065973:android:47cbd1277ade7f5f")
                .SetApiKey("AIzaSyDq4M-SHiuHmNrQQhUhy31oTRJzUpbsCd4")
                .SetGcmSenderId("827356065973")
                .Build();
            try
            {
                FirebaseApp.InitializeApp(this, options);
                AndroidAppLinks.Init(this);
            }
            catch
            {
                // ignored
            }

            LoadApplication(new App());
        }

    }
}

