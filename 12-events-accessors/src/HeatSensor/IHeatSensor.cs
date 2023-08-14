namespace ThermostatApp
{
	public interface IHeatSensor
	{
		event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
		event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
		event EventHandler<TemperatureEventArgs> TemperatureReachesBelowWarningLevelEventHandler;

		void RunHeatSensor();
	}
}
