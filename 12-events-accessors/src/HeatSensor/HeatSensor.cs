using System.ComponentModel;
namespace ThermostatApp
{
	class HeatSensor : IHeatSensor
	{
		float _warningLevel;
		float _emergencyLevel;

		bool _hasReachedWarningTemperature = false;
		bool _hasReachedEmergencyTemperature = false;

		protected EventHandlerList _listEventDelegates = new EventHandlerList();

		static readonly object _temparatureReachesWarningLevel = new object();
		static readonly object _temparatureReachesEmergencyLevel = new object();
		static readonly object _temparatureReachesBelowWarningLevel = new object();

		private float[] _temperature_data;

		protected virtual void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
		{
			((EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temparatureReachesWarningLevel])?.Invoke(this, e);
		}

		protected virtual void OnTemperatureReachesEmergencyLevel(TemperatureEventArgs e)
		{
			((EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temparatureReachesEmergencyLevel])?.Invoke(this, e);
		}

		protected virtual void OnTemperatureReachesBelowWarningLevel(TemperatureEventArgs e)
		{
			((EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temparatureReachesBelowWarningLevel])?.Invoke(this, e);
		}

		private void MonitorTemperature()
		{
			if (_temperature_data == null)
			{
				return;
			}
			foreach (float temp in _temperature_data)
			{
				Console.ResetColor();
				Console.WriteLine($"DateTime : {DateTime.Now} - Temperature : {temp}\n");

				if (temp >= _emergencyLevel)
				{
					TemperatureEventArgs e = new TemperatureEventArgs { Temperature = temp, CurrentDateTime = DateTime.Now };
					_hasReachedEmergencyTemperature = true;
					OnTemperatureReachesEmergencyLevel(e);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Device is shutting down due to emergency temperature\n");
					Console.ResetColor();
					break;
				}
				else if (temp >= _warningLevel)
				{
					TemperatureEventArgs e = new TemperatureEventArgs { Temperature = temp, CurrentDateTime = DateTime.Now };
					_hasReachedWarningTemperature = true;
					OnTemperatureReachesWarningLevel(e);
				}
				else if (temp < _warningLevel && _hasReachedWarningTemperature)
				{
					_hasReachedWarningTemperature = false;
					_hasReachedEmergencyTemperature = false;
					TemperatureEventArgs e = new TemperatureEventArgs { Temperature = temp, CurrentDateTime = DateTime.Now };
					OnTemperatureReachesBelowWarningLevel(e);
				}
				else if (temp < _emergencyLevel && _hasReachedEmergencyTemperature)
				{
					_hasReachedEmergencyTemperature = false;
				}

				Thread.Sleep(1000);
			}
		}

		public HeatSensor(float warningLevel, float emergencyLevel, float[] temperature_data)
		{
			_warningLevel = warningLevel;
			_emergencyLevel = emergencyLevel;
			_temperature_data = temperature_data;
		}

		event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
		{
			add
			{
				_listEventDelegates.AddHandler(_temparatureReachesEmergencyLevel, value);
			}

			remove
			{
				_listEventDelegates.RemoveHandler(_temparatureReachesEmergencyLevel, value);
			}
		}

		event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
		{
			add
			{
				_listEventDelegates.AddHandler(_temparatureReachesWarningLevel, value);
			}

			remove
			{
				_listEventDelegates.RemoveHandler(_temparatureReachesWarningLevel, value);
			}
		}

		event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesBelowWarningLevelEventHandler
		{
			add
			{
				_listEventDelegates.AddHandler(_temparatureReachesBelowWarningLevel, value);
			}

			remove
			{
				_listEventDelegates.RemoveHandler(_temparatureReachesBelowWarningLevel, value);
			}
		}

		void IHeatSensor.RunHeatSensor()
		{
			Console.WriteLine("Running Heat Sensor");
			MonitorTemperature();
		}
	}
}
