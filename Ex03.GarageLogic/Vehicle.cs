using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eRepairState
        {
            InRepair,
            Done,
            Paid
        }

        private class Tire
        {
            private readonly string m_ManufacturerName;
            private readonly float m_MaxPressure;
            private float m_CurrentPressure;

            public Tire(string i_ManufacturerName, float i_MaxPressure, float i_CurrentPressure)
            {
                m_ManufacturerName = i_ManufacturerName;
                m_MaxPressure = i_MaxPressure;

                if (i_CurrentPressure > m_MaxPressure || i_CurrentPressure < 0)
                {
                    throw new ValueOutOfRangeException(m_MaxPressure, 0, "Tire Pressure");
                }
                else
                {
                    m_CurrentPressure = i_CurrentPressure;
                }
            }

            public void AddAirPressureToTire(float i_AdditionalPressure)
            {
                m_CurrentPressure = m_MaxPressure;
            }

            public string ManufacturerName
            {
                get { return m_ManufacturerName; }
            }

            public float CurrentPressure
            {
                get { return m_CurrentPressure; }
            }
        }
        
        public const int k_BikeTireAmount = 2;
        public const int k_CarTireAmount = 4;
        public const int k_TruckTireAmount = 12;
        private readonly string r_VehicleModelName;
        private readonly string r_LicensePlateNumber;
        private float r_EnergyRemainder;
        private readonly List<Tire> r_Tires;
        private eRepairState m_RepairState;

        public Vehicle(
                string i_VehicleModelName, 
                string i_LicensePlateNumber, 
                float i_EnergyRemainder,
                VehicleTypes.eVehicleType i_VehicleType,
                string[] i_ManufacturerNamesOfAllTires,
                float[] i_CurrentPressureOfAllTires)
        {
            r_VehicleModelName = i_VehicleModelName;
            r_LicensePlateNumber = i_LicensePlateNumber;
            r_EnergyRemainder = i_EnergyRemainder;            
            m_RepairState = eRepairState.InRepair;

            int tireAmount = VehicleTypes.DefineTireAmountByType(i_VehicleType);
            float maxTirePressure = VehicleTypes.DefineMaxTirePressureByType(i_VehicleType);

            r_Tires = new List<Tire>(tireAmount);

            for (int i = 0; i < tireAmount; i++)
            {
                r_Tires.Add(new Tire(i_ManufacturerNamesOfAllTires[i], maxTirePressure, i_CurrentPressureOfAllTires[i]));
            }                   
        }

        protected float EnergyRemainder
        {
            set { r_EnergyRemainder = value; }
        }

        public string LicensePlateNumber
        {
            get { return r_LicensePlateNumber; }
        }

        public eRepairState RepairState
        {
            get { return m_RepairState; }
            set { m_RepairState = value; }
        }

        public void AddPressureTillMaxToAllTires()
        {
            foreach (Tire tire in r_Tires)
            {
                tire.AddAirPressureToTire(0);
            }
        }

        public abstract string ShowInfo();               // abstract (pure virtual) method for future implementation in derived classes (Tracktor)

        public override string ToString()
        {
            int counter = 0;
            StringBuilder output = new StringBuilder();
            string info = string.Format(
@"model name: {0}
license plate: {1}
energy remainder: {2}%
current state in garage: {3}",
r_VehicleModelName, 
r_LicensePlateNumber, 
r_EnergyRemainder * 100, 
m_RepairState);

            output.AppendLine(info);

            foreach (Tire tire in r_Tires)
            {
                counter++;
                info = string.Format("tire {0}: manufacturer: {1}, pressure: {2}", counter, tire.ManufacturerName, tire.CurrentPressure);
                output.AppendLine(info);
            }

            return output.ToString();
        }
    }
}
