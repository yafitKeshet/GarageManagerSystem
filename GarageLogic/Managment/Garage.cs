using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> r_VehiclesInProccess;
        public Garage()
        {
            r_VehiclesInProccess = new Dictionary<string, VehicleInGarage>();
        }

        public bool DoesCarExist(string i_LicensePlate)
        {
            bool result = r_VehiclesInProccess.ContainsKey(i_LicensePlate);

            return result;
        }

        public void AddVehicle(string i_LicensePlate, VehicleInGarage i_VehicleInGarage)
        {
            if(DoesCarExist(i_LicensePlate))
            {
                throw new ArgumentException("Vehicle already in garage");
            }
            else
            {
                r_VehiclesInProccess.Add(i_LicensePlate, i_VehicleInGarage);
            }
        }

        public List<string> GetLicensePlates(eDisplayVehicle i_Filter)
        {
            List<string> licensePlates = new List<string>();

            foreach(var registry in r_VehiclesInProccess)
            {
                OwnerInformation info = registry.Value.OwnerInfo;
                eDisplayVehicle vehicleStatus = (eDisplayVehicle)info.VehicleStatus;

                if(i_Filter == eDisplayVehicle.Unfiltered || i_Filter == vehicleStatus)
                {
                    licensePlates.Add(info.LicensePlate);
                }
            }

            return licensePlates;
        }

        public void ChangeVehicleStatus(string i_LicensePlate ,eVehicleStatus i_Status)
        {
            GetOwnerInformation(i_LicensePlate).VehicleStatus = i_Status;
        }

        public void FillUpTires(string i_LicensePlate)
        {
            GetVehicle(i_LicensePlate).FillUpWheels();
        }

        public string GetVehicleInfo(string i_LicensePlate)
        {
            string information = string.Empty;

            foreach(KeyValuePair<string, VehicleInGarage> kvp in r_VehiclesInProccess)
            {
                if(kvp.Key == i_LicensePlate)
                {
                    information = kvp.Value.ToString();
                    break;
                }
            }

            return information;
        }

        public Vehicle GetVehicle(string i_LicensePlate)
        {
            bool registryExists = r_VehiclesInProccess.TryGetValue(i_LicensePlate, out VehicleInGarage registry);

            if(!registryExists)
            {
                throw new KeyNotFoundException($"A registry with the license plate: {i_LicensePlate} Does not exist");
            }

            return registry.Vehicle;
        }

        public OwnerInformation GetOwnerInformation(string i_LicensePlate)
        {
            bool registryExists = r_VehiclesInProccess.TryGetValue(i_LicensePlate, out VehicleInGarage registry);

            if(!registryExists)
            {
                throw new KeyNotFoundException($"A registry with the license plate: {i_LicensePlate} Does not exist");
            }

            return registry.OwnerInfo;
        }
        
    }
}
