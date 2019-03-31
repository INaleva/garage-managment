using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public enum eOptions
        {
            AddVehicle = 1,
            ShowAllVehiclesInGarage,
            ChangeVehicleStatus,
            AddAirToTires,
            AddMoreFuel,
            AddMoreElectricity,
            ShowAllInfoAboutVehicle,
            Exit
        }

        private readonly Garage r_Garage;

        private static float getFuelAmount()
        {
            string output;
            string stringInput;
            float fuelAmount;

            output = string.Format(@"How much fuel to add?");
            Console.WriteLine(output);
            stringInput = Console.ReadLine();

            if (!float.TryParse(stringInput, out fuelAmount))
            {
                throw new FormatException();
            }

            return fuelAmount;
        }

        private static string getOwnersName()
        {
            string ownerName;
            string output = string.Format("Enter Owner's Name:");

            Console.WriteLine(output);
            ownerName = Console.ReadLine();

            return ownerName;
        }

        private static string getOwnersPhone()
        {
            string ownerPhone;
            string output = string.Format("Enter Owner's Phone:");

            Console.WriteLine(output);
            ownerPhone = Console.ReadLine();

            return ownerPhone;
        }

        private static VehicleTypes.eVehicleType getVehicleType()
        {
            string vehicleInput;
            int vehicleType = 0;
            string output = string.Format(
@"Enter vehicle type:
1. Petrol Car.
2. Electric Car.
3. Petrol Bike.
4. Electric Bike.
5. Truck.");
            Console.WriteLine(output);
            vehicleInput = Console.ReadLine();
            try
            {
                while (!int.TryParse(vehicleInput, out vehicleType) || vehicleType < 1 || vehicleType > 5)
                {
                    output = string.Format("Error,try again.");
                    Console.WriteLine(output);
                    vehicleInput = Console.ReadLine();
                }

                return (VehicleTypes.eVehicleType)vehicleType;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        private static string getModelName()
        {
            string inputModel;
            string output = string.Format(
@"Enter model name:");
            Console.WriteLine(output);
            inputModel = Console.ReadLine();
            return inputModel;
        }

        private static string getLicensePlateNumber()
        {
            string plateNumber;
            string output = string.Format(@"Enter license plate number: (up to 8 digits)");

            Console.WriteLine(output);
            plateNumber = Console.ReadLine();

            while (plateNumber.Length > 8)
            {
                output = string.Format(@"License plate is too long, try again.");
                Console.WriteLine(output);
                plateNumber = Console.ReadLine();
            }

            return plateNumber;
        }

        private static float getBatteryTimeToAdd()
        {
            float additionalTime = 0;
            string output = string.Format(@"Enter Additional Battery time: ");

            Console.WriteLine(output);

            while (!float.TryParse(Console.ReadLine(), out additionalTime))
            {
                output = string.Format(@"Error, enter float number again: ");
                Console.WriteLine(output);
            }

            return additionalTime;
        }

        private static string[] getTireManufacturers(VehicleTypes.eVehicleType i_VehicleType)
        {
            int tiresAmount = VehicleTypes.DefineTireAmountByType(i_VehicleType);
            string[] manufacturers = new string[tiresAmount];
            string output = string.Format("Enter the Manufacturers of All {0} Tires: ", tiresAmount);

            Console.WriteLine(output);

            for (int i = 0; i < tiresAmount; i++)
            {
                manufacturers[i] = Console.ReadLine();
            }

            return manufacturers;
        }

        private static float[] getCurrentPressureOfAllTires(VehicleTypes.eVehicleType i_VehicleType)
        {
            int tiresAmount = VehicleTypes.DefineTireAmountByType(i_VehicleType);
            float[] allTiresPressure = new float[tiresAmount];
            string output = string.Format("Enter the Air Pressure of All {0} Tires: ", tiresAmount);

            Console.WriteLine(output);

            for (int i = 0; i < tiresAmount; i++)
            {
                while (!float.TryParse(Console.ReadLine(), out allTiresPressure[i]))
                {
                    output = string.Format("Error,try again: ");
                    Console.WriteLine(output);
                }
            }

            return allTiresPressure;
        }

        private static bool getCheckIfTrunkIsCooled()
        {
            bool isCooled = false;
            string output = null;
            string Input = null;

            output = string.Format(@"Enter 'true' if the Trunk is Cooled, if not 'false': ");
            Console.WriteLine(output);
            Input = Console.ReadLine();

            while (!bool.TryParse(Input, out isCooled))
            {
                output = string.Format("Error,try again: ");
                Console.WriteLine(output);
                Input = Console.ReadLine();
            }

            return isCooled;
        }

        private static float getTrunkSize()
        {
            float trunkSize = 0;
            string output = null;
            string Input = null;

            output = string.Format(@"Enter the Trunk Size: ");
            Console.WriteLine(output);
            Input = Console.ReadLine();

            while (!float.TryParse(Input, out trunkSize))
            {
                output = string.Format("Error,try again: ");
                Console.WriteLine(output);
                Input = Console.ReadLine();
            }

            return trunkSize;
        }

        private static float getRemainingBatteryTime()
        {
            float remainingTime = 0;
            string output = null;
            string energyInput = null;

            output = string.Format(@"Enter the Remaining Battery Time: ");
            Console.WriteLine(output);
            energyInput = Console.ReadLine();

            while (!float.TryParse(energyInput, out remainingTime))
            {
                output = string.Format("Error,try again: ");
                Console.WriteLine(output);
                energyInput = Console.ReadLine();
            }

            return remainingTime;
        }

        private static int getBikeEngineVolume()
        {
            string volumeInput;
            int engineVolume;
            string output;
            output = string.Format("Enter the engine volume: ");
            Console.WriteLine(output);
            volumeInput = Console.ReadLine();
            try
            {
                while (!int.TryParse(volumeInput, out engineVolume))
                {
                    output = string.Format("Error,try again.");
                    Console.WriteLine(output);
                    volumeInput = Console.ReadLine();
                }

                return engineVolume;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        private static float getRemainingFuelAmount()
        {
            float remainingFuel = 0;
            string output = null;
            string Input = null;

            output = string.Format(@"Enter the Remaining Fuel Amount: ");
            Console.WriteLine(output);
            Input = Console.ReadLine();

            while (!float.TryParse(Input, out remainingFuel))
            {
                output = string.Format("Error,try again: ");
                Console.WriteLine(output);
                Input = Console.ReadLine();
            }

            return remainingFuel;
        }

        private static Vehicle.eRepairState getRepairState()
        {
            string output = string.Format(
@"Enter wanted repair state to display all vehicles.
0 for InRepair,
1 for Done,
2 for Paid");
            Console.WriteLine(output);

            int input = 0;

            int.TryParse(Console.ReadLine(), out input);
            Vehicle.eRepairState repairStateForFiltering = (Vehicle.eRepairState)input;

            return repairStateForFiltering;
        }

        private static Bike.eLicense getBikeLicenseType()
        {
            string licenseInput;
            int licenseType = 0;
            string output = string.Format(
@"Enter License type:
1. A
2. A1
3. B1
4. B2");
            Console.WriteLine(output);
            licenseInput = Console.ReadLine();
            try
            {
                while (!int.TryParse(licenseInput, out licenseType) || licenseType < 1 || licenseType > 4)
                {
                    output = string.Format("Error,try again.");
                    Console.WriteLine(output);
                    licenseInput = Console.ReadLine();
                }

                return (Bike.eLicense)licenseType - 1;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        private static Car.eColor getCarColor()
        {
            string colorInput;
            int colorType = 0;
            string output = string.Format(
@"Enter color type:
1.Grey,
2.Blue,
3.White,
4.Black");
            Console.WriteLine(output);
            colorInput = Console.ReadLine();
            try
            {
                while (!int.TryParse(colorInput, out colorType) || colorType < 1 || colorType > 4)
                {
                    output = string.Format("Error,try again.");
                    Console.WriteLine(output);
                    colorInput = Console.ReadLine();
                }

                return (Car.eColor)colorType - 1;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        private static Car.eDoorCount getCarDoorAmount()
        {
            string doorInput;
            int doorType = 0;
            string output = string.Format(
@"Enter door amount:
2,
3,
4,
5");
            Console.WriteLine(output);
            doorInput = Console.ReadLine();
            try
            {
                while (!int.TryParse(doorInput, out doorType) || doorType < 2 || doorType > 5)
                {
                    output = string.Format("Error,try again.");
                    Console.WriteLine(output);
                    doorInput = Console.ReadLine();
                }

                return (Car.eDoorCount)doorType;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        public static string getTireManfacturer()
        {
            string manufacturer = null;
            string output = string.Format("Enter the Tire Manufacturer Name: ");

            Console.WriteLine(output);
            manufacturer = Console.ReadLine();

            return manufacturer;
        }

        public static float getCurrentTirePressure()
        {
            float currentTirePressure = 0;
            string output = string.Format("Enter the current Tire Pressure: ");

            Console.WriteLine(output);

            while (!float.TryParse(Console.ReadLine(), out currentTirePressure))
            {
                output = string.Format("Wrong input, Enter againt: ");
                Console.WriteLine(output);
            }

            return currentTirePressure;
        }

        private static FuelVehicle.eFuelType getFuelType()
        {
            string stringInput;
            int fuelType;
            string output;
            output = string.Format(@"
Choose the fuel type to add.
1. Soler
2. Octan95
3. Octan96
4. Octan98");
            Console.WriteLine(output);
            stringInput = Console.ReadLine();
            if (!int.TryParse(stringInput, out fuelType))
            {
                throw new FormatException();
            }

            return (FuelVehicle.eFuelType)fuelType - 1;
        }

        public GarageUI()
        {
            r_Garage = new Garage();
        }
               
        public void GarageUIMainMenu()
        {         
            string output = string.Format(@"
Welcome to the garage.

1. Add Vehicle to the garage.
2. Show all the license plate of vehicles in the garage.
3. Change status of vehicle.
4. Fill air to maximum.
5. Add more fuel to a vehicle.
6. Charge an electric vehicle.
7. Show all information of a vehicle.
8. Exit");
            int option = 0;
            
            while ((eOptions)option != eOptions.Exit)
            {
                Console.WriteLine(output);
                int.TryParse(Console.ReadLine(), out option);

                switch ((eOptions)option)
                {
                    case eOptions.AddVehicle:
                        addVehicleToGarage();                  
                        break;
                    case eOptions.ShowAllVehiclesInGarage:
                        displayAllLicenseNumbers();
                        break;
                    case eOptions.ChangeVehicleStatus:
                        changeRepairState();
                        break;
                    case eOptions.AddAirToTires:
                        addAirToTires();
                        break;
                    case eOptions.AddMoreFuel:
                        addFuelToVehicle();
                        break;
                    case eOptions.AddMoreElectricity:
                        chargeElectricVehicle();
                        break;
                    case eOptions.ShowAllInfoAboutVehicle:
                        showAllInfoOfOneVehicle();
                        break;
                }
            }
        }

        private void addVehicleToGarage()
        {
            Vehicle vehicle = null;
            Owner owner = null;

            try
            {
                vehicle = chooseConstructorMethodByType();
                owner = new Owner(getOwnersName(), getOwnersPhone());                
                r_Garage.AddVehicleAndOwnerToGarage(vehicle, owner);                         
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Vehicle chooseConstructorMethodByType()
        {
            Vehicle vehicle = null;
            VehicleTypes.eVehicleType vehicleType = getVehicleType();

            switch (vehicleType)
            {
                case VehicleTypes.eVehicleType.ElectricBike:
                    vehicle = VehicleTypes.CreateNewElectricBike(
                                            getModelName(),
                                            getLicensePlateNumber(),
                                            getTireManufacturers(vehicleType),
                                            getCurrentPressureOfAllTires(vehicleType),
                                            getRemainingBatteryTime(),
                                            getBikeLicenseType(),
                                            getBikeEngineVolume());
                    break;
                case VehicleTypes.eVehicleType.ElectricCar:
                    vehicle = VehicleTypes.CreateNewElectricCar(
                                            getModelName(),
                                            getLicensePlateNumber(),
                                            getTireManufacturers(vehicleType),
                                            getCurrentPressureOfAllTires(vehicleType),
                                            getRemainingBatteryTime(),
                                            getCarDoorAmount(),
                                            getCarColor());
                    break;
                case VehicleTypes.eVehicleType.PetrolBike:
                    vehicle = VehicleTypes.CreateNewPetrolBike(
                                            getModelName(),
                                            getLicensePlateNumber(),
                                            getTireManufacturers(vehicleType),
                                            getCurrentPressureOfAllTires(vehicleType),
                                            getRemainingFuelAmount(),
                                            getBikeEngineVolume(),
                                            getBikeLicenseType());
                    break;
                case VehicleTypes.eVehicleType.PetrolCar:
                    vehicle = VehicleTypes.CreateNewPetrolCar(
                                            getModelName(),
                                            getLicensePlateNumber(),
                                            getTireManufacturers(vehicleType),
                                            getCurrentPressureOfAllTires(vehicleType),
                                            getRemainingFuelAmount(),
                                            getCarDoorAmount(),
                                            getCarColor());
                    break;
                case VehicleTypes.eVehicleType.Truck:
                    vehicle = VehicleTypes.CreateNewTruck(
                                            getModelName(),
                                            getLicensePlateNumber(),
                                            getTireManufacturers(vehicleType),
                                            getCurrentPressureOfAllTires(vehicleType),
                                            getRemainingFuelAmount(),
                                            getCheckIfTrunkIsCooled(),
                                            getTrunkSize());
                    break;
            }

            return vehicle;
        }

        private void displayAllLicenseNumbers()
        {
            Vehicle.eRepairState repairState = getRepairState();
            string output = string.Format(@"All License Plate Numbers With the State of {0}: ", repairState);                      

            Console.WriteLine(output);

            if (r_Garage.AllLicenseNumbersWithStateOf(repairState) != null)
            {
                output = r_Garage.AllLicenseNumbersWithStateOf(repairState).ToString();
                Console.WriteLine(output);
            }
            else
            {
                output = string.Format("None");
                Console.WriteLine(output);
            }
        }

        private void changeRepairState()
        {
            string licensePlates = getLicensePlateNumber();
            Vehicle.eRepairState newRepairState = getRepairState();
            try
            {
                r_Garage.ChangeRepairState(licensePlates, newRepairState);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }

        private void addAirToTires()
        {
            string licensePlates = getLicensePlateNumber();

            try
            {
                r_Garage.AddAirPressureToMax(licensePlates);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addFuelToVehicle()
        {            
            string plateNumber = getLicensePlateNumber();
            float fuelAmount = getFuelAmount();
            FuelVehicle.eFuelType typeOfFuel = getFuelType();

            try
            {
                r_Garage.AddFuelToVehicle(plateNumber, fuelAmount, typeOfFuel);
            }
            catch (ValueOutOfRangeException valueOutOfRange)
            {
                Console.WriteLine(valueOutOfRange.Message);
            }
            catch (ArgumentException logicError)
            {
                Console.WriteLine(logicError.Message);
            }
        }

        private void chargeElectricVehicle()
        {
            string plateNumber = getLicensePlateNumber();
            float timeToAdd = getBatteryTimeToAdd();

            try
            {
                r_Garage.ChargeElectricVehicle(plateNumber, timeToAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void showAllInfoOfOneVehicle()
        {
            string licensePlate = getLicensePlateNumber();
            string output = string.Format(
@"

Full Vehicle Information:
");
            Console.WriteLine(output);

            try
            {
                Console.WriteLine(r_Garage.AllInfoOfParticularVehicle(licensePlate).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }
}
