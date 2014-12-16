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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace FirstTask
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPlacePage : Page
    {
		Geolocator geo = null;

		private Place _place;
		public AddPlacePage()
        {

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
			this.DataContext = new
			{
				Place = new Place()
				{
					Name = "Technopark",
					Address = "",
					//Latitude = 60,
					//Longitude = -13.5,
					HasWifi = false,
				}
			};
        }
		public Place Place
		{
			get
			{
				return _place;
			}
			set
			{
				_place = value;
			}
		}

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
			if (geo == null)
				geo = new Geolocator();

			Geoposition pos = await geo.GetGeopositionAsync();

			LatitudeBox.Text = pos.Coordinate.Point.Position.Latitude.ToString();
			LongitudeBox.Text = pos.Coordinate.Point.Position.Longitude.ToString();
        }
    }
}
