using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }
    
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

      //  public decimal Percentage { get; set; }


        public decimal IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
            return Salary;

        }


        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

    }
}
