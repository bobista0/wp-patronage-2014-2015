using FirstTask.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.Service
{
	public interface IPlaceService
	{
		void AddPlace(Place place);
		List<Place> GetPlaces();
	}
}
