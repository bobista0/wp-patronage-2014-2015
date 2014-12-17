using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
	public class Place : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private string _name;
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (value != this._name)
				{
					this._name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		private string _address;
		public string Address
		{
			get
			{
				return this._address;
			}
			set
			{
				if (value != this._address)
				{
					this._address = value;
					NotifyPropertyChanged("Address");
				}
			}
		}

		private double _latitude;
		public double Latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if (value != this._latitude)
				{
					this._latitude = value;
					NotifyPropertyChanged("Latitude");
				}
			}
		}

		private double _longitude;
		public double Longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				if (value != this._longitude)
				{
					this._longitude = value;
					NotifyPropertyChanged("Longitude");
				}
			}
		}

		private bool _hasWifi;
		public bool HasWifi
		{
			get
			{
				return this._hasWifi;
			}
			set
			{
				if (value != this._hasWifi)
				{
					this._hasWifi = value;
					NotifyPropertyChanged("HasWifi");
				}
			}
		}

		public override string ToString()
		{
			return String.Format("{0}, {1}", Name, Address);
		}
	}
}
