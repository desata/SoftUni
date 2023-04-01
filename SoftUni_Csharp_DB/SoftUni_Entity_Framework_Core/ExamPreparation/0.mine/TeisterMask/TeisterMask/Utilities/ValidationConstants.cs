namespace Footballers.Utilities
{
    public class ValidationConstants
    {
        //Footballer
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;


        //Team
        public const int TeamNameMaxLength = 40;
        public const int TeamNameMinLength = 3;
        public const int NationalityNameMinLength = 2;
        public const int NationalityNameMaxLength = 40;

        //•	Name – text with length [3, 40]. Should contain letters (lower and upper case), digits, spaces, a dot sign ('.') 
        // public const string TruckPlateRegex = @"([A-Z]{2})(\d{4})([A-Z]{2})";

        //Coach        
        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;
    }
}
