using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get;  set; }
        public float MinValue { get;  set; }

        public ValueOutOfRangeException(float i_Value, float i_MinValue, float i_MaxValue) :  base($"The value : {i_Value} you entered is out of range ({i_MinValue} - {i_MaxValue})")
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

    }
}
