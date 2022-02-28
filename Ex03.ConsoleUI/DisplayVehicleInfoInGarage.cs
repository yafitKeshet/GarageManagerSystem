using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class DisplayVehicleInfoInGarage
    {
        internal static void DisplayVehicleInfo(Garage i_Garage)
        {
            try
            {
                const string k_GetLicensePlateMsg = "Please enter the vehicle's license plate";
                Input.GetStringInput(out string licensePlate, k_GetLicensePlateMsg);

                if (!i_Garage.DoesCarExist(licensePlate))
                {
                    throw new ArgumentException("This license plate is not in our system.");
                }
                else
                {
                    Output.PrintAndWait(i_Garage.GetVehicleInfo(licensePlate));
                }
            }
            catch (Exception e)
            {
                Output.PrintAndWait(e.Message);
            }
        }

    }
}
