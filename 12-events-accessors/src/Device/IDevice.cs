namespace ThermostatApp
{
	public interface IDevice
	{
		double WarningTemperature { get; }
		double EmergencyTemperature { get; }
		void HandleEmergency();
		void RunDevice();
	}
}