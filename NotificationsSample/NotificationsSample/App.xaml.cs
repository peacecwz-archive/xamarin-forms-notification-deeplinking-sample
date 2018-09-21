using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using NotificationsSample.Views;
using Xamarin.Forms;

namespace NotificationsSample
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            OneSignal.Current.StartInit("a7784902-2abe-44c4-ba3a-26be8a68a4c6")
                .InFocusDisplaying(OSInFocusDisplayOption.None)
                .HandleNotificationReceived(OnNotificationRecevied)
                .HandleNotificationOpened(OnNotificationOpened)
                .EndInit();

            MainPage = new Views.MainPage();
        }

        private void OnNotificationOpened(OSNotificationOpenedResult result)
        {
            if (result.notification?.payload?.additionalData == null)
            {
                return;
            }

            if (result.notification.payload.additionalData.ContainsKey("labelText"))
            {
                var labelText = result.notification.payload.additionalData["labelText"];
                App.Current.MainPage = new NotificationSummaryPage(labelText.ToString());
            }

        }

        private void OnNotificationRecevied (OSNotification notification)
        {
            if (notification.payload?.additionalData == null)
            {
                return;
            }

            if (notification.payload.additionalData.ContainsKey("labelText"))
            {
                var labelText = notification.payload.additionalData["labelText"];
                App.Current.MainPage = new NotificationSummaryPage(labelText.ToString());
            }
        }

        protected override void OnAppLinkRequestReceived (Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            if (!uri.LocalPath.Contains("/text-xamarin"))
                return;

            string id = uri.Query.Replace("id?=", "");

            App.Current.MainPage = new DeepLinkingSummaryPage(id);
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
