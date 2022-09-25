using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Animals
{
    public class Animal
    {
        private int age;
        private string gender;
        private string name;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }
                name = value;
            }            
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }

                age = value;
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }

                gender = value;
            }

        }


        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
