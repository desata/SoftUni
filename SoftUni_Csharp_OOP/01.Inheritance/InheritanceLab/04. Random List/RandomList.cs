using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Random_List
{
    public class RandomList : List<string>
    {
        //Create a RandomList class that has all the functionality of List<string>.
        //Add an additional function that returns and removes a random element from the list.

        Random random = new Random();

        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }


            int index = random.Next(0, this.Count);

            string str = this[index];

            this.RemoveAt(index);

            return str;

           
        }
    }
}
