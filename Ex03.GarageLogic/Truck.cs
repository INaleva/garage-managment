using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        private const float k_MaxFuelTankCapacity = 115f;
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const VehicleTypes.eVehicleType k_VehicleType = VehicleTypes.eVehicleType.Truck;
        
        private bool m_IsCooled;
        private float m_TrunkSize;

        public Truck(
                string i_ModelName,
                string i_LicenseNumber,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                float i_RemainingFuelAmount,
                bool i_IsCooled,
                float i_TrunkSize) : base(
                                        i_ModelName,
                                        i_LicenseNumber,
                                        i_RemainingFuelAmount / k_MaxFuelTankCapacity,
                                        k_VehicleType,
                                        i_ManufacturerNamesOfAllTires,
                                        i_CurrentPressureOfAllTires,
                                        k_FuelType,
                                        k_MaxFuelTankCapacity,
                                        i_RemainingFuelAmount)
        {
            m_IsCooled = i_IsCooled;
            m_TrunkSize = i_TrunkSize;
        }

        public override string ShowInfo()
        {
            string output = string.Format(
ToString() + 
@"Trunk is cooled: {0}
Trunk size: {1}", 
m_IsCooled,
m_TrunkSize);

            return output;
        }
    }
}
