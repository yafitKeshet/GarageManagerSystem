using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private float m_CurrentPressure;
        public string Maker { get; set; }
        public float MaxPressure { get; }

        public float CurrentPressure
        {
            get => m_CurrentPressure;
            set
            {
                if (value < 0 || value > MaxPressure)
                {
                    throw new ValueOutOfRangeException(value, 0, MaxPressure);
                }

                m_CurrentPressure = value;
            }
        }

        public Wheel(float i_MaxPressure, float i_CurrentPressure)
        {
            MaxPressure = i_MaxPressure;
            CurrentPressure = i_CurrentPressure;
        }

        public Wheel(float i_MaxPressure)
        {
            MaxPressure = i_MaxPressure;
        }

        public static List<Wheel> CreateListOfWheels(int i_AmountOfWheels, float i_MaxPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for(int i = 0; i < i_AmountOfWheels; i++)
            {
                wheels.Add(new Wheel(i_MaxPressure));
            }

            return wheels;
        }

        public void FillUp()
        {
            CurrentPressure = MaxPressure;
        }

    }
}
