namespace ThermostatApp
{
    class Program
    {
        static void Main(string[] args) { }
    }

    class HeatSensor : IHeatSensor
    {
        public event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
        public event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
        public event EventHandler<TemperatureEventArgs> TemperatureReachesBelowWarningLevelEventHandler;
    }

    interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureReachesBelowWarningLevelEventHandler;
    }

    public class TemperatureEventArgs : EventArgs
    {
        public float Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}
