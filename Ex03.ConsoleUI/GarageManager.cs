using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageManager
    {
        private static readonly Garage sr_Garage =  new Garage();

        private enum eMainMenu
        {
            AddVehicle = 1,
            DisplayLicensePlates,
            ChangeVehicleStatus,
            ChangeTirePressureToMax,
            FillUpFuel,
            DisplayVehicleInfo,
            Exit
        }

        internal void PlayGarage()
        {
            bool continueRunning;

            Output.PrintTitle();
            do
            {
                Output.PrintMainMenu();
                continueRunning = getCommand();
                Console.Clear();
            }
            while(continueRunning);

            Output.PrintAndWait("Press any key to exit");
        }

        private bool getCommand()
        {
            bool toContinue = true;
            bool isInputValid;

            do
            {
                Input.GetStringInput(out string input, "Please choose an option from the menu: ");
                isInputValid = eMainMenu.TryParse(input, out eMainMenu choice);

                switch (choice)
                {
                    case eMainMenu.AddVehicle:
                        AddVehicleToGarage.AddVehicle(sr_Garage);    
                        break;
                    case eMainMenu.DisplayLicensePlates:
                        DisplayLicensePlatesInGarage.DisplayLicensePlates(sr_Garage);
                        break;
                    case eMainMenu.ChangeVehicleStatus:
                        ChangeVehicleStateInGarage.ChangeVehicleStatus(sr_Garage);
                        break;
                    case eMainMenu.ChangeTirePressureToMax:
                        ChangeVehicleTirePressueInGarage.ChangeTirePressue(sr_Garage);
                        break;
                    case eMainMenu.FillUpFuel:
                        FillUpVehicleFuelInGarage.FillUpFuel(sr_Garage);
                        break;
                    case eMainMenu.DisplayVehicleInfo:
                        DisplayVehicleInfoInGarage.DisplayVehicleInfo(sr_Garage);
                        break;
                    case eMainMenu.Exit:
                        toContinue = false;
                        break;
                    default:
                        isInputValid = false;
                        break;
                }

            } while (!isInputValid);

            return toContinue;
        }

    }
}
