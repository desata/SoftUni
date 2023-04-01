namespace SoftJail.Utils
{
    public class ValidationConstants
    {
        //Prisoner
        public const int PrisonerFullNameLengthMin = 3;
        public const int PrisonerFullNameLengthMax = 20;

        //TODO:
        //public const int PrisonerNickname = REGEX;

        public const int PrisonerAgeMin = 18;
        public const int PrisonerAgeMax = 65;

        public const int PrisonerBailMin  = 0;



        //Officer
        public const int OfficerFullNameLengthMin = 3;
        public const int OfficerFullNameLengthMax = 30;
        public const int OfficerSalaryMin = 0;

        //Cell
        public const int CellNumberMin = 1;
        public const int CellNumberMax = 1000;

        //Mail
        //TODO:
        //Address Regex

        //Departament
        public const int DepartamentNameLengthMin = 3;
        public const int DepartamentNameLengthMax = 25;


    }
}
