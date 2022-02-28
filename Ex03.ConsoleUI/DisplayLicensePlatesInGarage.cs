using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class DisplayLicensePlatesInGarage
    {
        internal static void DisplayLicensePlates(Garage i_Garage)
        {
            try
            {
                Input.GetDisplayOption(out eDisplayVehicle filter);
                List<string> platesToDisplay = i_Garage.GetLicensePlates(filter);
                Output.DisplayLicensePlates(platesToDisplay);
            }
            catch (Exception e)
            {
                Output.PrintAndWait(e.Message);
            }

        }
    }
}
