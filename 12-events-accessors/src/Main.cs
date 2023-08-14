namespace ThermostatApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var device = new Device();

			device.RunDevice();
		}
	}

	public class TemperatureEventArgs : EventArgs
	{
		public float Temperature { get; set; }
		public DateTime CurrentDateTime { get; set; }
	}
}
