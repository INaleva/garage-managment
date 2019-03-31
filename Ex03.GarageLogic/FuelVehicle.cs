using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private readonly eFuelType m_FuelType;        
        private readonly float m_MaxFuelCapacity;
        private float m_RemainingFuelAmount;

        public FuelVehicle(
                string i_ModelName,
                string i_LicenseNumber,
                float i_EnergyRemainder,
                VehicleTypes.eVehicleType i_VehicleType,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires,
                eFuelType i_FuelType,
                float i_MaxFuelCapacity,
                float i_RemainingFuelAmount) : base(
                                                i_ModelName, 
                                                i_LicenseNumber, 
                                                i_EnergyRemainder,
                                                i_VehicleType,
                                                i_ManufacturerNamesOfAllTires,
                                                i_CurrentPressureOfAllTires)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelCapacity = i_MaxFuelCapacity;

            if (i_RemainingFuelAmount > m_MaxFuelCapacity || i_RemainingFuelAmount < 0)
            {
                throw new ValueOutOfRangeException(m_MaxFuelCapacity, 0, "Fuel Amount");
            }
            else
            {
                m_RemainingFuelAmount = i_RemainingFuelAmount;
            }
        }

        public void AddFuel(float i_AdditionalAmount, eFuelType i_FuelType)
        {
            if (i_FuelType == m_FuelType)
            {
                if (i_AdditionalAmount <= m_MaxFuelCapacity - m_RemainingFuelAmount || i_AdditionalAmount < 0)
                {
                    m_RemainingFuelAmount += i_AdditionalAmount;
                    EnergyRemainder = m_RemainingFuelAmount / m_MaxFuelCapacity; 
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaxFuelCapacity - m_RemainingFuelAmount, 0, "Additional Fuel Amount");
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Fuel type does not match"));
            }          
        }

        public override abstract string ShowInfo();      // abstract (pure virtual) method for future implementation in derived classes (Tracktor)

        public override string ToString()
        {            
            string output = string.Format(
base.ToString() +
@"Fuel Type: {0}
Remaining Fuel Amount: {1}
", 
m_FuelType, 
m_RemainingFuelAmount);
            
            return output;
        }
    }
}
