using FirstTask.Body;
using FirstTask.Service;
using FirstTask.SharedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;

namespace FirstTask.ViewModel
{
	public class PlacesViewModel : ObservedObjectEssential
	{
		private NavigationService NavigationService = new NavigationService();
		private PlaceService PlaceService = new PlaceService();

		public PlacesViewModel()
		{
			LoadData();
		}

		private async void LoadData()
		{
			Places = await PlaceService.GetLocations();
		}

		private List<Place> _places = new List<Place>();
		public List<Place> Places
		{
			get
			{
				return this._places;
			}
			set
			{
				if (value != this._places)
				{
					this._places = value;
					NotifyPropertyChanged("Places");
				}
			}
		}

		private RelayCommand _addCommand;
		public RelayCommand AddCommand
		{
			get
			{
				if (_addCommand == null)
				{
					_addCommand = new RelayCommand(() => Add());
				}

				return _addCommand;
			}
		}

		private void Add()
		{
			NavigationService.Navigate(typeof(AddPlacePage));
		}
	}
}
