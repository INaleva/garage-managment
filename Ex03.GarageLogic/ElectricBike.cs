using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBike : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 1.8f;

        private Bike m_ElectricBike;

        public ElectricBike(
                string i_ModelName,
                string i_LicenseNumber,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                float i_RemainingBatteryTime,
                Bike.eLicense i_RequiredLicense, 
                int i_EngineVolume) : base(
                                        i_ModelName, 
                                        i_LicenseNumber,
                                        i_RemainingBatteryTime / k_MaxBatteryTime,
                                        VehicleTypes.eVehicleType.ElectricBike,
                                        i_ManufacturerNamesOfAllTires,
                                        i_CurrentPressureOfAllTires,
                                        i_RemainingBatteryTime,
                                        k_MaxBatteryTime)
        {
            m_ElectricBike = new Bike(i_RequiredLicense, i_EngineVolume);
        }

        public override string ShowInfo()
        {
            string output = string.Format(ToString() + m_ElectricBike.ToString());

            return output;
        }
    }
}
