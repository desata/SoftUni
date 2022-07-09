using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pets : IBirthable
    {
        public Pets(string name, string date)
        {
            Name = name;
            Date = date;
        }

        //Pet Sharo 13/11/2005

        public string Name { get; set; }
        public string Date { get; set; }

    }
}
