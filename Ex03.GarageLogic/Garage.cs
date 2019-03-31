using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<Vehicle, Owner> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<Vehicle, Owner>();
        }

        public void AddVehicleAndOwnerToGarage(Vehicle i_Vehicle, Owner i_Owner)
        {
            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Key.LicensePlateNumber == i_Vehicle.LicensePlateNumber)
                {
                    vehicle.Key.RepairState = Vehicle.eRepairState.InRepair;
                    throw new ArgumentException(string.Format("Vehicle with this License Plate exists in the Garage, RepairState changed to 'In Repair'"));
                }                
            }

            m_VehiclesInGarage.Add(i_Vehicle, i_Owner);
        }

        public StringBuilder AllLicenseNumbersWithStateOf(Vehicle.eRepairState repairState)
        {
            StringBuilder licensePlates = new StringBuilder();

            foreach (KeyValuePair<Vehicle, Owner> vehice in m_VehiclesInGarage)
            {
                if (vehice.Key.RepairState == repairState)
                {
                    licensePlates.AppendLine(vehice.Key.LicensePlateNumber);
                }
            }

            return licensePlates;
        }

        public void AddFuelToVehicle(string i_PlateNumber, float i_FuelAmount, FuelVehicle.eFuelType i_FuelType)
        {
            FuelVehicle fuelVehicle = null;

            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Key.LicensePlateNumber == i_PlateNumber)
                {
                    fuelVehicle = vehicle.Key as FuelVehicle;

                    if (fuelVehicle == null)
                    {
                        throw new ArgumentException("This vehicle does not match this type of operation");
                    }
                    else
                    {
                        fuelVehicle.AddFuel(i_FuelAmount, i_FuelType);
                        break;
                    }
                }
            }

            if (fuelVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle with this license plates does not exists in the Garage"));
            }
        }

        public void ChargeElectricVehicle(string i_PlateNumber, float i_AdditionalTime)
        {
            ElectricVehicle electricVehicle = null;

            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Key.LicensePlateNumber == i_PlateNumber)
                {
                    electricVehicle = vehicle.Key as ElectricVehicle;

                    if (electricVehicle == null)
                    {
                        throw new ArgumentException(string.Format("This vehicle does not match this type of operation"));
                    }
                    else
                    {
                        electricVehicle.ChargeBattery(i_AdditionalTime);
                        break;
                    }
                }
            }

            if (electricVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle with this license plates does not exists in the Garage"));
            }
        }

        public void AddAirPressureToMax(string i_PlateNumber)
        {
            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Key.LicensePlateNumber == i_PlateNumber)
                {
                    vehicle.Key.AddPressureTillMaxToAllTires();
                    return;
                }
            }

            throw new ArgumentException(string.Format("Vehicle with this license plates does not exists in the Garage"));
        }

        public void ChangeRepairState(string i_LicensePlate, Vehicle.eRepairState i_NewRepairState)
        {
            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (i_LicensePlate == vehicle.Key.LicensePlateNumber)
                {
                    vehicle.Key.RepairState = i_NewRepairState;
                    return;
                }
            }

            throw new ArgumentException(string.Format("Vehicle with this license plates does not exists in the Garage"));
        }

        public StringBuilder AllInfoOfParticularVehicle(string i_PlateNumber)
        {
            StringBuilder outputInfo = new StringBuilder();

            foreach (KeyValuePair<Vehicle, Owner> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Key.LicensePlateNumber == i_PlateNumber)
                {
                    outputInfo.AppendLine(vehicle.Value.ToString());                // add the Owner info
                    outputInfo.AppendLine(vehicle.Key.ShowInfo());       // add the Vehicle info
                }
            }

            return outputInfo;
        }
    }
}
