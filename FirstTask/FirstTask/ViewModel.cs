using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FirstTask
{
	public class ViewModel : INotifyPropertyChanged
	{
		PlaceService PlaceService = new PlaceService();
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string info)
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
						var DataAddMessage = new MessageDialog("Success!\nNumber of objects: " + PlaceService.GetPlaces().Count().ToString());
						DataAddMessage.ShowAsync();
					});
				}

				//Place = new Place();
				return _addCommand;
			}
		}

		private RelayCommand _clearCommand;
		public RelayCommand ClearCommand
		{
			get
			{
				if(_clearCommand == null)
				{
					
					_clearCommand = new RelayCommand(() =>
					{

						var DataEraseMessage = new MessageDialog("Clear all?");
						DataEraseMessage.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
						DataEraseMessage.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)));
						DataEraseMessage.DefaultCommandIndex = 0;
						DataEraseMessage.CancelCommandIndex = 1;

						DataEraseMessage.ShowAsync();
					});
				}

				return _clearCommand;
			}
		}
		private void CommandInvokedHandler(IUICommand command)
		{
			if(command.Label == "Yes")
				EraseContent();
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
