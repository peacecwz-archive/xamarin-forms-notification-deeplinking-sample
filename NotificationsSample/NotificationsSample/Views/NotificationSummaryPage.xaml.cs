using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotificationsSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationSummaryPage : ContentPage
	{
		public NotificationSummaryPage (string labelText)
		{
			InitializeComponent ();
		    lblText.Text = labelText;
		}
	}
}