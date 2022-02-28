using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class ChangeVehicleTirePressueInGarage
    {
        internal static void ChangeTirePressue(Garage i_Garage)
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
                    i_Garage.FillUpTires(licensePlate);
                }

                Output.PrintAndWait("Vehicle tires filled");
            }
            catch (Exception e)
            {
                Output.PrintAndWait(e.Message);
            }
        }

    }
}
