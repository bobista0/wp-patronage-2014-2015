using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FirstTask.Service
{
	public interface INavigationService
	{
		void RegisterRootFrame(Frame frame);
		void Navigate(Type type);
	}
}
