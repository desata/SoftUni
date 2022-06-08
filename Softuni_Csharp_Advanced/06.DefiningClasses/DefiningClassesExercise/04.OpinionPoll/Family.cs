using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {

        //The class should have a list of people,
        //method for adding members - void AddMember(Person member),
        //method returning the oldest family member – Person GetOldestMember().

        //полета
        private List<Person> familyMembers;

        //конструктори
        public Family()
        {
            familyMembers = new List<Person>();
        }

        //методи
        
        public void AddMember(Person member)
        { 
        this.familyMembers.Add(member);
        }
        public Person GetOldestMember()
        {

            Person person = this.familyMembers
                  .OrderByDescending(p => p.Age)
                  .FirstOrDefault();
            return person;

        }
    }
}
