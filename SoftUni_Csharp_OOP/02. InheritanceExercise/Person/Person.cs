using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {

        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int Age
        {
            //age cannot be less than zero
            get { return age; }
            set {
                if (value < 0)
                {
                    throw new Exception();
                }
                                
                age = value; 
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()

        {

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",

            this.Name,

            this.Age));

            return stringBuilder.ToString();

        }
    }
}
