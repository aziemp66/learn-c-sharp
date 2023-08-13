namespace ThermostatApp
{
	public class Thermostat
	{
		private ICoolingMechanism _coolingMechanism;
		private IHeatSensor _heatSensor;
		private IDevice _device;


		public Thermostat(ICoolingMechanism coolingMechanism, IHeatSensor heatSensor, IDevice device)
		{
			_coolingMechanism = coolingMechanism;
			_heatSensor = heatSensor;
			_device = device;
		}

		private void WireUpEventsToEvenHandlers()
		{
			_heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
			_heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
			_heatSensor.TemperatureReachesBelowWarningLevelEventHandler += HeatSensor_TemperatureReachesBelowWarningLevelEventHandler;
		}

		private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object? sender, TemperatureEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"\nEmergency Alert: Emergency Level is {_device.EmergencyTemperature} degrees Celsius and above");
			_device.HandleEmergency();
			Console.ResetColor();
		}

		private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"\nWarning Alert: Warning Level is between {_device.WarningTemperature} and {_device.EmergencyTemperature} degrees Celsius");
			_coolingMechanism.On();
			Console.ResetColor();
		}

		private void HeatSensor_TemperatureReachesBelowWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"\nInformation Alert: Temperature Falls Below {_device.WarningTemperature} degrees Celsius");
			_coolingMechanism.Off();
			Console.ResetColor();
		}

		public void RunThermostat()
		{
			Console.WriteLine("Running Thermostat");

			WireUpEventsToEvenHandlers();
			_heatSensor.RunHeatSensor();
		}
	}
}