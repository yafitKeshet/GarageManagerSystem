namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        public bool CarryingRefrigeratedContents { get; set; }
        public float MaxCarryCapacity { get; set; }
    }
}
