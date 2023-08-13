namespace ThermostatApp
{
	public class CoolingMechanism : ICoolingMechanism
	{
		void ICoolingMechanism.Off()
		{
			Console.WriteLine("\nCooling Mechanism is Off\n");
		}

		void ICoolingMechanism.On()
		{
			Console.WriteLine("\nCooling Mechanism is On\n");
		}
	}
}
