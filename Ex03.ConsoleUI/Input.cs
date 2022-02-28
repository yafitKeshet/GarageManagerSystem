using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    internal static class Input
    {
        private const string k_DefaultMsg = "Please enter an input";
        private const string k_InvalidInputMsg = "Input is invalid, please try again";

        internal static void GetIntInput(out int o_Input, string i_Msg = k_DefaultMsg)
        {
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                Output.PrintMsg(i_Msg);
                string inputString = Console.ReadLine();
                isInputValid = int.TryParse(inputString, out o_Input);

                if(!isInputValid)
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetFloatInput(out float o_Input, string i_Msg = k_DefaultMsg)
        {
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                Output.PrintMsg(i_Msg);
                string inputString = Console.ReadLine();
                isInputValid = float.TryParse(inputString, out o_Input);

                if(!isInputValid)
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetStringInput(out string o_Input, string i_Msg)
        {
            Output.PrintMsg(i_Msg);
            o_Input = Console.ReadLine();
        }

        internal static void GetBoolInput(out bool o_Input, string i_Msg, string i_AnswerForTrue, string i_AnswerForFalse)
        {
            o_Input = false;
            string inputMsg = $"{i_Msg}{Environment.NewLine}Enter {i_AnswerForTrue} or {i_AnswerForFalse}";
            bool isInputValid = false;

            while(!isInputValid)
            {
                Output.PrintMsg(inputMsg);
                string inputString = Console.ReadLine();

                if(inputString == i_AnswerForTrue)
                {
                    o_Input = true;
                    isInputValid = true;
                }
                else if(inputString == i_AnswerForFalse)
                {
                    o_Input = false;
                    isInputValid = true;
                }

                if(!isInputValid)
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetNumOfDoors(out int o_Input)
        {
            o_Input = 0;
            const string k_GetNumOfDoorsMessage = "Please enter the amount of doors in your car:";
            const int k_MaxAmountOfDoors = 5;
            const int k_MinAmountOfDoors = 2;
            string invalidNumOfDoorsMsg = $"Amount of doors must be between {k_MinAmountOfDoors} and {k_MaxAmountOfDoors}";
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out o_Input, k_GetNumOfDoorsMessage);
                isInputValid = (o_Input >= k_MinAmountOfDoors && o_Input <= k_MaxAmountOfDoors);

                if(!isInputValid)
                {
                    Output.PrintMsg(invalidNumOfDoorsMsg);
                }

            }
        }

        internal static void GetCarColor(out eCarColor o_Input)
        {
            string getColorMsg = $@"Please enter the color of your car:
{EnumHelper.GetCarColorsOptions()}";
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out int choice, getColorMsg);

                isInputValid = Enum.IsDefined(typeof(eCarColor), choice);

                if (isInputValid)
                {
                    o_Input = (eCarColor) choice;

                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }

            }
        }

        internal static void GetLicenseType(out eLicenseType o_Input)
        {
            o_Input = 0;
            bool isInputValid = false;
            string getLicenseTypeMsg = $@"Please enter your license Type:
{EnumHelper.GetLicenseTypesOptions()}";

            while(!isInputValid)
            {
                GetIntInput(out int choice, getLicenseTypeMsg);

                isInputValid = Enum.IsDefined(typeof(eLicenseType), choice);

                if(isInputValid)
                {
                    o_Input = (eLicenseType)choice;
                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetVehicleType(out eVehicleType o_Input)
        {
            string getVehicleTypeMsg = $@"Please enter the type of your vehicle:
{EnumHelper.GetVehicleTypesOptions()}";
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out int choice, getVehicleTypeMsg);

                isInputValid = Enum.IsDefined(typeof(eVehicleType), choice);

                if(isInputValid)
                {
                    o_Input = (eVehicleType)choice;
                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetDisplayOption(out eDisplayVehicle o_Input)
        {
            string getDisplayMsg = $@"Please choose display option for license plates:
{EnumHelper.GetLicensePlateDisplayFilters()}";
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out int choice, getDisplayMsg);

                isInputValid = Enum.IsDefined(typeof(eDisplayVehicle), choice);

                if(isInputValid)
                {
                    o_Input = (eDisplayVehicle)choice;
                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }
        
        internal static void GetVehicleStatusOption(out eVehicleStatus o_Input)
        {
            string getDisplayMsg = $@"Please choose new vehicle status:
{EnumHelper.GetVehicleStatusOptions()}";
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out int choice, getDisplayMsg);

                isInputValid = Enum.IsDefined(typeof(eVehicleStatus), choice);

                if(isInputValid)
                {
                    o_Input = (eVehicleStatus)choice;
                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }

        internal static void GetFuelType(out eFuelType o_Input)
        {
            string getVehicleTypeMsg = $@"Please choose type of fuel:
{EnumHelper.GetFuelTypesOptions()}";
            o_Input = 0;
            bool isInputValid = false;

            while(!isInputValid)
            {
                GetIntInput(out int choice, getVehicleTypeMsg);

                isInputValid = Enum.IsDefined(typeof(eFuelType), choice);

                if(isInputValid)
                {
                    o_Input = (eFuelType)choice;

                }
                else
                {
                    Output.PrintMsg(k_InvalidInputMsg);
                }
            }
        }
    }
}
