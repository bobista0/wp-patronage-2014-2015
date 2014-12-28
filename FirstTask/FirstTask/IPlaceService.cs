using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
	public interface IPlaceService
	{
		void AddPlace(Place place);
		List<Place> GetPlaces();
	}
}
