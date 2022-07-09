using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizens : IBirthable
    {
        public Citizens(string name, int age, string id, string date)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;
        }

        //Citizen Peter 22 9010101122 10/10/1990

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Date { get; set; }

    }
}
