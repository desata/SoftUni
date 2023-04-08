namespace TeisterMask.Utilities
{
    public class ValidationConstants
    {
        //Employee
        public const int EmployeeUsernameMinLength = 3;
        public const int EmployeeUsernameMaxLength = 40;
        //Should contain only lower or upper case letters and/or digits
        public const string EmployeeUsernameRegex = @"^[A-Za-z0-9]{3, }$";
        //Consists only of three groups (separated by '-'), the first two consist of three digits and the last one – of 4 digits. (required)
        public const string EmployeePhoneRegex = @"^\d{3}\-\d{3}\-\d{4}$";


        //Project
        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 40;

        //Task
        public const int TaskNameMinLength = 2;
        public const int TaskNameMaxLength = 40;

    }
}
