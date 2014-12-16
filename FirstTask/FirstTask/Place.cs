using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
	public class Place : INotifyPropertyChanged
	{
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		private string _address;
		public string Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
			}
		}

		

		private double _latitude;
		public double Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				_latitude = value;
			}
		}

		private double _longitude;
		public double Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				_longitude = value;
			}
		}

		private bool _hasWifi;
		public bool HasWifi
		{
			get
			{
				return _hasWifi;
			}
			set
			{
				_hasWifi = value;
			}
		}

		public override string ToString()
		{
			string format = "{" + Name + "}, " + "{" + Address + "}";

			return format;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
