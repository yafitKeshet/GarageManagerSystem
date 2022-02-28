using System;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected int m_NumOfDoors;
        private const int k_MinNumOfDoors=2;
        private const int k_MaxNumOfDoors=5;
        protected eCarColor m_CarColor;

        public eCarColor Color
        {
            get => m_CarColor;
            set
            {
                if(!Enum.IsDefined(typeof(eCarColor), value))
                {
                    throw new ArgumentException("invalid car color");
                }

                m_CarColor = value;
            }
        }

        public int NumOfDoors
        {
            get => m_NumOfDoors;
            set
            {
                if(value < k_MinNumOfDoors || value > k_MaxNumOfDoors)
                {
                    throw new ValueOutOfRangeException(value, k_MinNumOfDoors, k_MaxNumOfDoors);
                }
                m_NumOfDoors = value;
            }
        }

    }
}
