namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Data;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        private static XmlHelper xmlHelper;

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {

            StringBuilder sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            ImportDespatchersDto[] despatcherDtos =
                xmlHelper.Deserialize<ImportDespatchersDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespachers = new HashSet<Despatcher>();

            foreach (ImportDespatchersDto despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();

                foreach (ImportTruckDto truckDto in despatcherDto.Trucks)
                {

                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType,
                    };

                    validTrucks.Add(truck);
                }

                Despatcher despatcher = new Despatcher()
                { 
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };

                validDespachers.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, validTrucks.Count));

            }

            context.Despatchers.AddRange(validDespachers);
            context.SaveChanges();

            

            return sb.ToString().TrimEnd();


        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}