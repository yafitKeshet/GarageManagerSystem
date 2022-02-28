using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected float m_EnergyStatus;

        public abstract string Model { get; set; }
        public abstract string LicensePlate { get; set; }
        public abstract List<Wheel> Wheels { get; }
        public abstract float MaxEnergy { get; }

        public float EnergyStatus
        {
            get => m_EnergyStatus;
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ValueOutOfRangeException(value, 0, 100);
                }

                m_EnergyStatus = value;
            }
        }

        public virtual void FuelUp(eFuelType i_Type, float i_Amount)
        {
            float percentageToFill = (i_Amount * 100) / MaxEnergy;
            float remaining = MaxEnergy - ((EnergyStatus / 100) * MaxEnergy);
            float newEnergyStatus = EnergyStatus + percentageToFill;

            if (newEnergyStatus > 100 || i_Amount < 0)
            {
                throw new ValueOutOfRangeException(i_Amount, 0, remaining);
            }

            EnergyStatus = newEnergyStatus;
        }

        public void FillUpWheels()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.FillUp();
            }
        }

        public void SetWheelsAirPressure(float i_NewAirPressure)
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.CurrentPressure = i_NewAirPressure;
            }
        }

        public void SetWheelsMaker(string i_Maker)
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.Maker = i_Maker;
            }
        }

    }
}
