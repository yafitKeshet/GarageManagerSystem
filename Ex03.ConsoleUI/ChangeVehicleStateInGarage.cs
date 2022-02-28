using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class ChangeVehicleStateInGarage
    {
        internal static void ChangeVehicleStatus(Garage i_Garage)
        {
            const string k_GetLicensePlateMsg = "Please enter the vehicle's license plate";

            try
            {
                Input.GetStringInput(out string licensePlate, k_GetLicensePlateMsg);

                if (!i_Garage.DoesCarExist(licensePlate))
                {
                    throw new ArgumentException("This license plate is not in our system.");
                }
                else
                {
                    Input.GetVehicleStatusOption(out eVehicleStatus status);
                    i_Garage.ChangeVehicleStatus(licensePlate, status);
                }

                Output.PrintAndWait("Vehicle status changed");
            }
            catch (Exception e)
            {
                Output.PrintAndWait(e.Message);
            }
        }

    }
}
