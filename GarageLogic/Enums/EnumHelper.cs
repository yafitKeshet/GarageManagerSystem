namespace Ex03.GarageLogic
{
    public static class EnumHelper
    {
        public static string GetCarColorsOptions()
        {
            const string k_CarColorsOptions =
@"1. Red
2. White
3. Black
4. Blue";

            return k_CarColorsOptions;
        }

        public static string GetVehicleStatusOptions()
        {
            const string k_VehicleStatusOptions =
@"1. In repair
2. Repaired
3. Payed";

            return k_VehicleStatusOptions;
        }

        public static string GetLicensePlateDisplayFilters()
        {
            const string k_LicensePlateDisplayFilters =
             @"1. Vehicles - in repair
2. Vehicles - repaired
3. Vehicles - Payed
4. Vehicles - unfiltered";

            return k_LicensePlateDisplayFilters;
        }

        public static string GetLicenseTypesOptions()
        {
            const string k_LicenseTypesOptions =
@"1. A
2. A2
3. AA
4. B";

            return k_LicenseTypesOptions;
        }

        public static string GetVehicleTypesOptions()
        {
            const string k_VehicleTypesOptions = 
@"1. Regular Car
2. Electric Car
3. Regular Motorcycle
4. Electric Motorcycle
5. Regular Truck";

            return k_VehicleTypesOptions;
        }

        public static string GetFuelTypesOptions()
        {
            const string k_FuelTypesOptions =
@"1. Soler
2. Octan95
3. Octan96
4. Octan98";

            return k_FuelTypesOptions;
        }
    }
}