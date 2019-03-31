using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class PetrolCar : FuelVehicle
    {
        private const float k_MaxFuelTankCapacity = 45f;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const VehicleTypes.eVehicleType k_VehicleType = VehicleTypes.eVehicleType.PetrolCar;

        private Car m_PetrolCar;

        public PetrolCar(
                string i_ModelName, 
                string i_LicenseNumber,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                float i_RemainingFuelAmount,
                Car.eDoorCount i_DoorsAmount,
                Car.eColor i_Color) : base(
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
            m_PetrolCar = new Car(i_DoorsAmount, i_Color);
        }

        public override string ShowInfo()
        {
            string output = string.Format(ToString() + m_PetrolCar.ToString());
            
            return output;
        }
    }
}
