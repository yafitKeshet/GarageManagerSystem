using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const int k_AmountOfWheels = 2;
        private const float k_WheelMaxAirPressure = 30;
        private const float k_MaxEnergy = 2.3f;

        public override string Model { get; set; }
        public override string LicensePlate { get; set; }
        public override List<Wheel> Wheels { get; } = Wheel.CreateListOfWheels(k_AmountOfWheels, k_WheelMaxAirPressure);
        public override float MaxEnergy { get => k_MaxEnergy; }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.Append($@"Vehicle Type: Electric Motorcycle
License Plate: {LicensePlate}, Model: {Model}, License Type: {LicenseType},
Remaining Battery: {EnergyStatus} hours
Wheels:
Maker: {Wheels[0].Maker}, Amount: {Wheels.Count}, Air pressure: {Wheels[0].CurrentPressure}");

            return information.ToString();
        }

    }
}
