using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.ComponentModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace FirstTask
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AddPlacePage : Page
	{
		public AddPlacePage()
		{
			this.InitializeComponent();
			this.NavigationCacheMode = NavigationCacheMode.Required;

			this.DataContext = new ViewModel()
			{
				Place = new Place()
				{
					Name = "Technopark",
					Address = "",
					Latitude = 0.00d,
					Longitude = 0.00d,
					HasWifi = false,
				}
			};

		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		private void IsNameFieldEmpty(object sender, TextChangedEventArgs e)
		{
			if (NameBox.Text.ToString() == String.Empty)
				AddButton.IsEnabled = false;
			else
				AddButton.IsEnabled = true;
		}

		//private async void IsNameFieldEmpty(FrameworkElement sender, DataContextChangedEventArgs args)
		//{
		//	if(NameBox.Text.ToString() == String.Empty)
		//		AddButton.IsEnabled = false;
		//	else
		//		AddButton.IsEnabled = true;
		//}
	}
}
