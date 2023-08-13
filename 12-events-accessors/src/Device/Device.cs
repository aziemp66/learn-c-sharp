namespace ThermostatApp
{
	public class Device : IDevice
	{
		const float WARNING_TEMPERATURE = 27;
		const float EMERGENCY_TEMPERATURE = 75;

		double IDevice.WarningTemperature => WARNING_TEMPERATURE;

		double IDevice.EmergencyTemperature => EMERGENCY_TEMPERATURE;
		void IDevice.HandleEmergency()
		{
			Console.WriteLine();
			ShutDownDevice();
			Console.WriteLine();
		}

		public void RunDevice()
		{
			Console.WriteLine("Device is running");

			ICoolingMechanism coolingMechanism = new CoolingMechanism();
			var heatSensor = new HeatSensor(WARNING_TEMPERATURE, EMERGENCY_TEMPERATURE, new float[] { 16, 17, 16.5f, 18, 19, 22, 24, 26.75f, 28.7f, 27.6f, 16, 18, 20, 45, 68, 86.45f, 80.2f });
			var thermostat = new Thermostat(coolingMechanism, heatSensor, this);

			thermostat.RunThermostat();
		}

		public void ShutDownDevice()
		{
			Console.WriteLine("Shutting down device");
		}
	}
}