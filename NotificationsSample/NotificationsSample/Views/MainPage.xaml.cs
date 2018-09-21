using System;
using Xamarin.Forms;

namespace NotificationsSample.Views
{
	public partial class MainPage : ContentPage
	{
	    private string Id = "test-xamarin";
		public MainPage()
		{
			InitializeComponent();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        var url = $"https://barisceviz.com/{Id.ToString()}";

	        var entry = new AppLinkEntry
	        {
	            Title = "Test Xamarin",
	            Description = "Deep linking test",
	            AppLinkUri = new Uri(url, UriKind.RelativeOrAbsolute),
	            IsLinkActive = true,
	        };

	        Application.Current.AppLinks.RegisterLink(entry);

        }
    }
}
