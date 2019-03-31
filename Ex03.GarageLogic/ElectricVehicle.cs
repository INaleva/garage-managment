using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private readonly float m_MaxBatteryTime;
        private float m_RemainingBatteryTime;

        public ElectricVehicle(
                    string i_ModelName,
                    string i_LicenseNumber,
                    float i_EnergyRemainder,
                    VehicleTypes.eVehicleType i_VehicleType,
                    string[] i_ManufacturerNamesOfAllTires,
                    float[] i_CurrentPressureOfAllTires,
                    float i_RemainingBatteryTime,
                    float i_MaxBatteryTime) : base(
                                                i_ModelName,
                                                i_LicenseNumber,
                                                i_EnergyRemainder,
                                                i_VehicleType,
                                                i_ManufacturerNamesOfAllTires,
                                                i_CurrentPressureOfAllTires)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;

            if (i_RemainingBatteryTime > m_MaxBatteryTime || i_RemainingBatteryTime < 0)
            {
                throw new ValueOutOfRangeException(m_MaxBatteryTime, 0, "Remaining Battery Time");
            }
            else
            {
                m_RemainingBatteryTime = i_RemainingBatteryTime;
            }
        }

        public void ChargeBattery(float i_AdditionalTime)
        {
            if (i_AdditionalTime > m_MaxBatteryTime - m_RemainingBatteryTime || i_AdditionalTime < 0)
            {
                throw new ValueOutOfRangeException(m_MaxBatteryTime - m_RemainingBatteryTime, 0, "Additional Battery Time");
            }
            else
            {
                m_RemainingBatteryTime += i_AdditionalTime;
                EnergyRemainder = m_RemainingBatteryTime / m_MaxBatteryTime;
            }
        }

        public override abstract string ShowInfo();      // abstract (pure virtual) method for future implementation in derived classes (electric Tracktor)

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string info = string.Format(base.ToString() + @"Remaining Battery Time: {0}", m_RemainingBatteryTime);

            output.AppendLine(info);

            return output.ToString();
        }
    }
}
