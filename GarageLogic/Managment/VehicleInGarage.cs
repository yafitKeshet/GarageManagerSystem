using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public OwnerInformation OwnerInfo { get; set; }
        public Vehicle Vehicle { get; set; }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.Append(OwnerInfo.ToString());
            information.Append(Vehicle.ToString());

            return information.ToString();
        }

    }
}
