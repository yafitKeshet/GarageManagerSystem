using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal static class Output
    {
        internal static void PrintMsg(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }

        internal static void PrintTitle()
        {
            const string k_Title = @"   ___                          __  __                             
  / __|__ _ _ _ __ _ __ _ ___  |  \/  |__ _ _ _  __ _ __ _ ___ _ _ 
 | (_ / _` | '_/ _` / _` / -_) | |\/| / _` | ' \/ _` / _` / -_) '_|
  \___\__,_|_| \__,_\__, \___| |_|  |_\__,_|_||_\__,_\__, \___|_|  
                    |___/                            |___/         ";

            PrintMsg(k_Title);
        }

        internal static void PrintMainMenu()
        {
           const string k_MainMenu =
@"GARAGE MANAGEMENT SYSTEM:
1. Insert a new vehicle to the garage
2. Show license plate numbers
3. Change vehicle Status
4. Fill tires air pressure
5. Fill up fuel
6. Show vehicle information
7. Exit program";

            PrintMsg(k_MainMenu);
        }

        internal static void DisplayLicensePlates(List<string> i_LicensePlates)
        {
            int i = 1;

            foreach (string plate in i_LicensePlates)
            {
                PrintMsg($"{i}. {plate}");
                i++;
            }

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }

        internal static void PrintAndWait(string i_Msg)
        {
            PrintMsg(i_Msg);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
    }
}
