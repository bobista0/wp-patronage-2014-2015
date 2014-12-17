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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace FirstTask
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AddPlacePage : Page, INotifyPropertyChanged
	{
		private Geolocator geo = null;
		//private double _currentLatitude;
		//private double _currentLongitude;
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private Place _place;
		public Place Place
		{
			get
			{
				return this._place;
			}
			set
			{
				if (value != this._place)
				{
					this._place = value;
					NotifyPropertyChanged("Place");
				}
			}
		}

		public AddPlacePage()
		{
			this.InitializeComponent();
			this.NavigationCacheMode = NavigationCacheMode.Required;
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

			this.DataContext = this;
			{
				Place = new Place()
				{
					Name = "Technopark",
					Address = "",
					//Latitude = 60d,
					//Longitude = -13.5d,
					Latitude = pos.Coordinate.Point.Position.Latitude,
					Longitude = pos.Coordinate.Point.Position.Longitude,
					HasWifi = false,
				};
			};
		}
	}
}
