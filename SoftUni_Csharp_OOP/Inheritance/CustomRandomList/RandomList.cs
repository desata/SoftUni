using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rand = new Random();

       

        public string RandomString()
        { 
            int index = rand.Next(0, this.Count);
            string strings = this[index];
            this.RemoveAt(index);

            return strings;

        }


    }
}
