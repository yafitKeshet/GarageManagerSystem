using System.Text;

namespace Ex03.GarageLogic
{
    public class OwnerInformation
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public eVehicleStatus VehicleStatus { get; set; } = eVehicleStatus.InRepair;
        public string LicensePlate { get; set; }

        public OwnerInformation(string i_Name, string i_PhoneNumber, string i_LicensePlate, eVehicleStatus i_Status)
        {
            Name = i_Name;
            PhoneNumber = i_PhoneNumber;
            LicensePlate = i_LicensePlate;
            VehicleStatus = i_Status;
        }

        public override bool Equals(object i_ToCompare)
        {
            bool result = false;

            if(i_ToCompare != null)
            {
                result = (LicensePlate == ((OwnerInformation)i_ToCompare).LicensePlate);
            }

            return result;
        }

        public static bool operator ==(OwnerInformation i_ToCompare, OwnerInformation i_ToCompareTo)
        {
            bool result;

            if(i_ToCompare != null)
            {
                result = i_ToCompare.Equals(i_ToCompareTo);
            }
            else
            {
                result = i_ToCompareTo == null;
            }

            return result;
        }

        public static bool operator !=(OwnerInformation i_ToCompare, OwnerInformation i_ToCompareTo)
        {
            return !(i_ToCompare == i_ToCompareTo);
        }

        public override int GetHashCode()
        {
            return LicensePlate.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.Append($@"Owner Name: {Name} , Owner Phone-Number: {PhoneNumber}
Vehicle Status: {VehicleStatus} ,");

            return information.ToString();
        }

    }
}