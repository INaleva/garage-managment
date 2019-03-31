using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        public enum eLicense
        {
            A,
            A1,
            B1,
            B2
        }

        private readonly eLicense m_RequiredLicense;
        private readonly int m_EngineVolume;
        
        public Bike(eLicense i_RequiredLicense, int i_EngineVolume)
        {
            m_RequiredLicense = i_RequiredLicense;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicense RequiredLicense
        {
            get { return m_RequiredLicense; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public override string ToString()
        {
            string output = string.Format(
@"Required License: {0}
Engine Volume: {1}", 
RequiredLicense, 
EngineVolume);
            
            return output;
        }
    }
}
