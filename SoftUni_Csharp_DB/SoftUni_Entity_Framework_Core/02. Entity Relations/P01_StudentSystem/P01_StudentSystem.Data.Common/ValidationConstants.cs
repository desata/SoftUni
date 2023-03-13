using System;

namespace P01_StudentSystem.Data.Common
{
    public class ValidationConstants
    {
        //Student 
        public const int StudentNameMaxLength = 100;
        
        public const int StudentPhoneNumberMaxLength = 10;

        //Course
        public const int CourseNameMaxLength = 80;

        public const int CourseDescriptionMaxLength = 2048;

        //Resource
        public const int ResourceNameMaxLength = 50;

        public const int ResourceUrlMaxLength = 2048;
    }
}