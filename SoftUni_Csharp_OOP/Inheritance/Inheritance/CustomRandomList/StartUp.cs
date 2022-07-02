using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("Pesho");
            randomList.Add("Pesho1");
            randomList.Add("Pesho2");
            randomList.Add("Pesho3");
            randomList.Add("Pesho4");

            randomList.RandomString();
        }
    }
}
