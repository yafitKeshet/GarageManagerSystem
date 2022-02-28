using System;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        public int EngineCapacity { get; set; }

        public eLicenseType LicenseType
        {
            get => m_LicenseType;
            set
            {
                if(!Enum.IsDefined(typeof(eLicenseType), value))
                {
                    throw new ArgumentException("invalid license type");
                }

                m_LicenseType = value;
            }
        }
        
    }
}
