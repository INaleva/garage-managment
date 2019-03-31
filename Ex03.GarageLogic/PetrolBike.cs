using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class PetrolBike : FuelVehicle
    {
        private const float k_MaxFuelTankCapacity = 6f;
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const VehicleTypes.eVehicleType k_VehicleType = VehicleTypes.eVehicleType.PetrolBike;

        private Bike m_PetrolBike;
        
        public PetrolBike(
                string i_ModelName,
                string i_LicenseNumber,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                float i_RemainingFuelAmount,
                int i_EngineVolume, 
                Bike.eLicense i_LicenseTypeRequired) : base(
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
            m_PetrolBike = new Bike(i_LicenseTypeRequired, i_EngineVolume);             
        }

        public override string ShowInfo()
        {
            string info = string.Format(ToString() + m_PetrolBike.ToString());

            return info;
        }
    }
}
