using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class AddVehicleToGarage
    {
        internal static void AddVehicle(Garage i_Garage)
        {
            try
            {
                VehicleInGarage vehicleInGarage = createNewVehicleInGarage(i_Garage);
                i_Garage.AddVehicle(vehicleInGarage.OwnerInfo.LicensePlate, vehicleInGarage);
            }
            catch (Exception e)
            {
                Output.PrintAndWait(e.Message);
            }
        }

        private static VehicleInGarage createNewVehicleInGarage(Garage i_Garage)
        {
            VehicleInGarage vehicleInGarage = new VehicleInGarage();

            vehicleInGarage.OwnerInfo = createOwnerInformation(i_Garage);
            vehicleInGarage.Vehicle = createVehicle(vehicleInGarage.OwnerInfo);

            return vehicleInGarage;
        }

        private static OwnerInformation createOwnerInformation(Garage i_Garage)
        {
            const string k_GetNameMsg = "Please enter the vehicle owner's name";
            const string k_GetPhoneNumberMsg = "Please enter the vehicle owner's Phone Number";
            const string k_GetLicensePlateMsg = "Please enter the vehicle's license plate";

            Input.GetStringInput(out string name, k_GetNameMsg);
            Input.GetStringInput(out string number, k_GetPhoneNumberMsg);
            Input.GetStringInput(out string licensePlate, k_GetLicensePlateMsg);

            OwnerInformation information = new OwnerInformation(name, number, licensePlate, eVehicleStatus.InRepair);

            if (i_Garage.DoesCarExist(licensePlate))
            {
                throw new ArgumentException("This license plate is already linked with another vehicle");
            }

            return information;
        }

        private static Vehicle createVehicle(OwnerInformation i_OwnerInformation)
        {
            Vehicle vehicle = null;
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    Input.GetVehicleType(out eVehicleType vehicleType);
                    vehicle = VehicleCreator.CreateVehicle(vehicleType);
                    vehicle.LicensePlate = i_OwnerInformation.LicensePlate;
                    setDefaultVehicleFields(vehicle);
                    setVehicleTypeSpecificFields(vehicle);
                    Output.PrintAndWait("Vehicle inserted");
                    isInputValid = true;
                }
                catch (ArgumentException e)
                {
                    Output.PrintAndWait(e.Message);
                }
            }

            return vehicle;
        }

        private static void setDefaultVehicleFields(Vehicle i_Vehicle)
        {
            setVehicleModel(i_Vehicle);
            setVehicleEnergyStatus(i_Vehicle);
            setVehicleWheelsPressure(i_Vehicle);
            setVehicleWheelsMaker(i_Vehicle);
        }

        private static void setVehicleModel(Vehicle i_Vehicle)
        {
            const string k_GetModelMsg = "Please enter your vehicle model name:";

            Input.GetStringInput(out string model, k_GetModelMsg);
            i_Vehicle.Model = model;
        }

        private static void setVehicleEnergyStatus(Vehicle i_Vehicle)
        {
            const string k_GetEnergyStatus = "Please enter your fuel/battery level";
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    Input.GetFloatInput(out float energyStatus, k_GetEnergyStatus);
                    i_Vehicle.EnergyStatus = energyStatus;
                    isInputValid = true;
                }
                catch (Exception e)
                {
                    Output.PrintMsg(e.Message);
                }
            }
        }

        private static void setVehicleWheelsPressure(Vehicle i_Vehicle)
        {
            const string k_GetCurrentTirePressure = "Please enter your current tire pressure:";
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    Input.GetFloatInput(out float pressure, k_GetCurrentTirePressure);
                    i_Vehicle.SetWheelsAirPressure(pressure);
                    isInputValid = true;
                }
                catch (Exception e)
                {
                    Output.PrintMsg(e.Message);
                }
            }
        }

        private static void setVehicleWheelsMaker(Vehicle i_Vehicle)
        {
            const string k_GetWheelsMaker = "Please enter your wheels maker:";
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    Input.GetStringInput(out string maker, k_GetWheelsMaker);
                    i_Vehicle.SetWheelsMaker(maker);
                    isInputValid = true;
                }
                catch (Exception e)
                {
                    Output.PrintMsg(e.Message);
                }
            }
        }

        private static void setVehicleTypeSpecificFields(Vehicle i_Vehicle)
        {
            if (i_Vehicle is Car)
            {
                setCarColor(i_Vehicle);
                setNumOfDoors(i_Vehicle);
            }
            if (i_Vehicle is Motorcycle)
            {
                setLicenseType(i_Vehicle);
                setEngineCapacity(i_Vehicle);
            }
            if (i_Vehicle is Truck)
            {
                setCarryDangerousMaterial(i_Vehicle);
                setLoadCapacity(i_Vehicle);
            }
        }

        private static void setCarColor(Vehicle i_Vehicle)
        {
            Input.GetCarColor(out eCarColor color);
            (i_Vehicle as Car).Color = color;
        }

        private static void setNumOfDoors(Vehicle i_Vehicle)
        {
            Input.GetNumOfDoors(out int numOfDoors);
            (i_Vehicle as Car).NumOfDoors = numOfDoors;
        }

        private static void setLicenseType(Vehicle i_Vehicle)
        {
            Input.GetLicenseType(out eLicenseType licenseType);
            (i_Vehicle as Motorcycle).LicenseType = licenseType;
        }

        private static void setEngineCapacity(Vehicle i_Vehicle)
        {
            const string k_GetEngineCapacityMsg = "What is your engine's capacity? (in Cubic Centimeter)";

            Input.GetIntInput(out int engineCapacity, k_GetEngineCapacityMsg);
            (i_Vehicle as Motorcycle).EngineCapacity = engineCapacity;
        }

        private static void setCarryDangerousMaterial(Vehicle i_Vehicle)
        {
            const string k_GetCarryingDangerousMaterialMsg = "Does your truck carry refrigerated contents?";

            Input.GetBoolInput(out bool carryingRefrigeratedContents, k_GetCarryingDangerousMaterialMsg, "Y", "N");
            (i_Vehicle as Truck).CarryingRefrigeratedContents = carryingRefrigeratedContents;
        }

        private static void setLoadCapacity(Vehicle i_Vehicle)
        {
            const string k_GetMaxCarryMsg = "What is your truck's max carry capacity?";

            Input.GetFloatInput(out float loadCapacity, k_GetMaxCarryMsg);
            (i_Vehicle as Truck).MaxCarryCapacity = loadCapacity;
        }

    }
}
