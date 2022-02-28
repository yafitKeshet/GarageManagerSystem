using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class RegularCar : Car
    {
        private const int k_AmountOfWheels = 4;
        private const float k_WheelMaxAirPressure = 29;
        private const float k_MaxEnergy = 45;
        private const eFuelType k_FuelType = eFuelType.Octan95;

        public override string Model { get; set; }
        public override string LicensePlate { get; set; }
        public override List<Wheel> Wheels { get; } = Wheel.CreateListOfWheels(k_AmountOfWheels, k_WheelMaxAirPressure);
        public override float MaxEnergy { get => k_MaxEnergy; }
        public eFuelType FuelType { get => k_FuelType; }

        public override void FuelUp(eFuelType i_Type, float i_Amount)
        {
            if (i_Type != FuelType)
            {
                throw new ArgumentException("Fuel type does not match the vehicle's fuel type");
            }

            base.FuelUp(i_Type,i_Amount);
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.Append(
                $@"Vehicle Type: Regular Car
License Plate: {LicensePlate}, Model: {Model}, Color: {Color},
Fuel Percentage: {EnergyStatus}%, Fuel Type: {FuelType}, Amount of doors: {NumOfDoors}
Wheels:
Maker: {Wheels[0].Maker}, Amount: {Wheels.Count}, Air pressure: {Wheels[0].CurrentPressure}");

            return information.ToString();
        }

    }
}
