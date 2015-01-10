using FirstTask.Body;
using FirstTask.Service;
using FirstTask.SharedItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FirstTask.ViewModel
{
	public class AddPlaceViewModel : ObservedObjectEssential
	{
		public AddPlaceViewModel()
		{
			HardwareButtons.BackPressed += HardwareButtons_BackPressed;
		}

		private NavigationService NavigationService = new NavigationService();
		PlaceService PlaceService = new PlaceService();

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
					this._place.GetCurrentLocation();
					NotifyPropertyChanged("Place");
				}
			}
		}

		private RelayCommand _addCommand;
		public RelayCommand AddCommand
		{
			get
			{
				if(_addCommand == null)
				{
					_addCommand = new RelayCommand(() =>
					{
						PlaceService.AddPlace(Place);
						Place = new Place();
						NavigateBack();
					});
				}

				return _addCommand;
			}
		}

		private void NavigateBack()
		{
			NavigationService.Navigate(typeof(PlacesListPage));
		}

		private RelayCommand _clearCommand;
		public RelayCommand ClearCommand
		{
			get
			{
				if(_clearCommand == null)
				{
					_clearCommand = new RelayCommand(() => Cancel());
				}

				return _clearCommand;
			}
		}

		private void Cancel()
		{
			var DataEraseMessage = new MessageDialog("Seriously?");
			DataEraseMessage.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.ClearTextBoxInvokedHandler)));
			DataEraseMessage.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.ClearTextBoxInvokedHandler)));
			DataEraseMessage.DefaultCommandIndex = 0;
			DataEraseMessage.CancelCommandIndex = 1;

			DataEraseMessage.ShowAsync();
		}

		private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
		{
			Frame frame = Window.Current.Content as Frame;
			if (frame == null)
			{
				return;
			}

			if (frame.CanGoBack)
			{
				Cancel();
				e.Handled = true;
			}
		}

		private void ClearTextBoxInvokedHandler(IUICommand command)
		{
			if(command.Label == "Yes")
			{
				NavigateBack();
				EraseContent();
				Place.GetCurrentLocation();
				HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
			}
			else
				return;
		}

		private void EraseContent()
		{
			Place.Name = "";
			Place.Address = "";
			Place.Latitude = 0.00d;
			Place.Longitude = 0.00d;
			Place.HasWifi = false;
		}
	}
}
