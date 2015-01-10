using FirstTask.Body;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FirstTask.Service
{
	public class PlaceService : IPlaceService
	{
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://patronatwp-borysrybak.azure-mobile.net/",
			"WXMJvGxXbIZjGDKSlCVNComGPHhuRG70"
		);

		private static List<Place> _places = new List<Place>();
		public void AddPlace(Place place)
		{
			_places.Add(place);
			AddToAzure(place);
		}

		public List<Place> GetPlaces()
		{
			return _places;
		}

		private async void AddToAzure(Place place)
		{
			await MobileService.GetTable<Place>().InsertAsync(place);
		}

		public async Task<List<Place>> GetLocations()
		{
			return await MobileService.GetTable<Place>().ToCollectionAsync().ContinueWith(t => t.Result.ToList());
		}

	}
}
