namespace Trucks.Utilities
{
    public class ValidationConstants
    {
        //Client
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMaxLength = 40;


        //Despatcher
        public const int DespatcherNameMaxLength = 40;
        public const int DespatcherNameMinLength = 2;


        //Truck        
        public const int TruckRegistrationNumberLength = 8;
        public const string TruckPlateRegex = @"([A-Z]{2})(\d{4})([A-Z]{2})";

        public const int TruckVinNumberLength = 17;

        public const int TruckTankCapacityMin = 950;
        public const int TruckTankCapacityMax = 1420;

        public const int TruckCargoCapacityMin = 5000;
        public const int TruckCargoCapacityMax = 29000;


        public const int TruckCategoryTypeMin = 0;
        public const int TruckCategoryTypeMax = 3;
        
        public const int TruckMakeTypeMin = 0;
        public const int TruckMakeTypeMax = 4;

    }
}
