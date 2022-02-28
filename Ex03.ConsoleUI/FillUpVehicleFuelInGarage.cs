using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class FillUpVehicleFuelInGarage
    {
        public static void FillUpFuel(Garage i_Garage)
        {
            const string k_GetLicensePlateMsg = "Please enter the vehicle's license plate";
            const string k_GetFuelMsg = "How much would you like to";
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    Input.GetStringInput(out string licensePlate, k_GetLicensePlateMsg);
                    Vehicle vehicle = i_Garage.GetVehicle(licensePlate);
                    var property = vehicle.GetType().GetProperty("FuelType");

                    if (property != null)
                    {
                        fuelUpGasolineVehicle(k_GetFuelMsg, vehicle);
                    }
                    else
                    {
                        chargeAnElectricVehicle(k_GetFuelMsg, vehicle);
                    }

                    Output.PrintAndWait("Vehicle refueled");
                    isInputValid = true;
                }
                catch (Exception e)
                {
                    Output.PrintMsg(e.Message);
                }
            }
        }

        private static void chargeAnElectricVehicle(string i_GetFuelMsg, Vehicle i_Vehicle)
        {
            string rechargeMsg =
                $@"Your current battery percentage:{i_Vehicle.EnergyStatus}% 
your Max battery level: {i_Vehicle.MaxEnergy}Hours
{i_GetFuelMsg} charge (in minutes)?";

            Input.GetFloatInput(out float amount, rechargeMsg);
            amount /= 60;

            i_Vehicle.FuelUp(0, amount);
        }

        private static void fuelUpGasolineVehicle(string i_GetFuelMsg, Vehicle i_Vehicle)
        {
            string refuelMsg =
                $@"Your current fuel percentage:{i_Vehicle.EnergyStatus}%
your Max fuel level: {i_Vehicle.MaxEnergy}L
{i_GetFuelMsg} to refuel (in Liters)?";

            Input.GetFuelType(out eFuelType type);
            Input.GetFloatInput(out float amount, refuelMsg);

            i_Vehicle.FuelUp(type, amount);
        }

    }
}
