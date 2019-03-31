using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const float k_MaxBatteryTime = 3.2f;
        private const VehicleTypes.eVehicleType k_VehicleType = VehicleTypes.eVehicleType.ElectricCar;

        private Car m_ElectricCar;
        
        public ElectricCar(
                string i_ModelName,
                string i_LicenseNumber,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                float i_RemainingBatteryTime,
                Car.eDoorCount i_DoorsAmount,
                Car.eColor i_Color) : base(
                                        i_ModelName,
                                        i_LicenseNumber,
                                        i_RemainingBatteryTime / k_MaxBatteryTime,
                                        k_VehicleType,
                                        i_ManufacturerNamesOfAllTires,
                                        i_CurrentPressureOfAllTires,
                                        i_RemainingBatteryTime,
                                        k_MaxBatteryTime)
        {
            m_ElectricCar = new Car(i_DoorsAmount, i_Color);
        }

        public override string ShowInfo()
        {
            string output = string.Format(ToString() + m_ElectricCar.ToString());

            return output;
        }
    }
}
