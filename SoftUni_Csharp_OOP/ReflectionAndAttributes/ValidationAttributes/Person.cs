using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [Required]
        public string FullName { get; set; }

        [MyRangeAttributes(12,99)]
        public int Age { get; set; }
    }
}
