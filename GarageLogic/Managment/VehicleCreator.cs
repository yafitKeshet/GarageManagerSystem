namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;

            switch(i_VehicleType)
            {
                case eVehicleType.RegularCar:
                    vehicle = new RegularCar();
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicleType.RegularMotorcycle:
                    vehicle = new RegularMotorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.RegularTruck:
                    vehicle = new RegularTruck();
                    break;
            }

            return vehicle;
        }

    }
}
