using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleTypes
    {
        public enum eVehicleType
        {
            PetrolCar = 1,
            ElectricCar,
            PetrolBike,
            ElectricBike,
            Truck,
        }

        public static float DefineMaxTirePressureByType(eVehicleType i_VehicleType)
        {
            float maxTirePressure = 0;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricBike:
                    maxTirePressure = 30f;
                    break;
                case eVehicleType.ElectricCar:
                    maxTirePressure = 32f;
                    break;
                case eVehicleType.PetrolBike:
                    maxTirePressure = 30f;
                    break;
                case eVehicleType.PetrolCar:
                    maxTirePressure = 32f;
                    break;
                case eVehicleType.Truck:
                    maxTirePressure = 28f;
                    break;
            }

            return maxTirePressure;
        }

        public static int DefineTireAmountByType(eVehicleType i_VehicleType)
        {
            int tireAmount = 0;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricBike:
                    tireAmount = 2;
                    break;
                case eVehicleType.ElectricCar:
                    tireAmount = 4;
                    break;
                case eVehicleType.PetrolBike:
                    tireAmount = 2;
                    break;
                case eVehicleType.PetrolCar:
                    tireAmount = 4;
                    break;
                case eVehicleType.Truck:
                    tireAmount = 12;
                    break;
            }

            return tireAmount;
        }

        public static Vehicle CreateNewElectricBike(
                                string i_ModelName, 
                                string i_LicenseNumber, 
                                string[] i_ManufacturerNamesOfAllTires, 
                                float[] i_CurrentPressureOfAllTires, 
                                float i_RemainingBatteryTime, 
                                Bike.eLicense i_RequiredLicense, 
                                int i_EngineVolume)
        {
            Vehicle vehicle = new ElectricBike(
                                    i_ModelName, 
                                    i_LicenseNumber,
                                    i_ManufacturerNamesOfAllTires,
                                    i_CurrentPressureOfAllTires,
                                    i_RemainingBatteryTime,
                                    i_RequiredLicense,
                                    i_EngineVolume);              

            return vehicle;
        }

        public static Vehicle CreateNewElectricCar(
                                string i_ModelName,
                                string i_LicenseNumber,
                                string[] i_ManufacturerNamesOfAllTires,
                                float[] i_CurrentPressureOfAllTires,
                                float i_RemainingBatteryTime,
                                Car.eDoorCount i_DoorsAmount,
                                Car.eColor i_Color)
        {
            Vehicle vehicle = new ElectricCar(
                                    i_ModelName,
                                    i_LicenseNumber,
                                    i_ManufacturerNamesOfAllTires,
                                    i_CurrentPressureOfAllTires,
                                    i_RemainingBatteryTime,
                                    i_DoorsAmount,
                                    i_Color);

            return vehicle;
        }

        public static Vehicle CreateNewPetrolBike(
                                string i_ModelName,
                                string i_LicenseNumber,
                                string[] i_ManufacturerNamesOfAllTires,
                                float[] i_CurrentPressureOfAllTires,
                                float i_RemainingFuelAmount,
                                int i_EngineVolume,
                                Bike.eLicense i_LicenseTypeRequired)
        {
            Vehicle vehicle = new PetrolBike(
                                    i_ModelName,
                                    i_LicenseNumber,
                                    i_ManufacturerNamesOfAllTires,
                                    i_CurrentPressureOfAllTires,
                                    i_RemainingFuelAmount,
                                    i_EngineVolume,
                                    i_LicenseTypeRequired);
            
            return vehicle;
        }

        public static Vehicle CreateNewPetrolCar(
                                string i_ModelName,
                                string i_LicenseNumber,
                                string[] i_ManufacturerNamesOfAllTires,
                                float[] i_CurrentPressureOfAllTires,
                                float i_RemainingFuelAmount,
                                Car.eDoorCount i_DoorsAmount,
                                Car.eColor i_Color)
        {
            Vehicle vehicle = new PetrolCar(
                                    i_ModelName,
                                    i_LicenseNumber,
                                    i_ManufacturerNamesOfAllTires,
                                    i_CurrentPressureOfAllTires,
                                    i_RemainingFuelAmount,
                                    i_DoorsAmount,
                                    i_Color);

            return vehicle;
        }

        public static Vehicle CreateNewTruck(
                                string i_ModelName,
                                string i_LicenseNumber,
                                string[] i_ManufacturerNamesOfAllTires,
                                float[] i_CurrentPressureOfAllTires,
                                float i_RemainingFuelAmount,
                                bool i_IsCooled,
                                float i_TrunkSize)
        {            
            Vehicle vehicle = new Truck(
                                i_ModelName,
                                i_LicenseNumber,
                                i_ManufacturerNamesOfAllTires,
                                i_CurrentPressureOfAllTires,
                                i_RemainingFuelAmount,
                                i_IsCooled,
                                i_TrunkSize);

            return vehicle;                                
        }
    }
}
