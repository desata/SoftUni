using System;

namespace _02._09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabers = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());
            int freeBelt = students / 6;
            double addLightsabers = (lightsabers * Math.Ceiling(students*0.1));
            double equipment = (lightsabers+ robes+ belts);
            double totalMoney = (equipment * students)-(freeBelt*belts)+ addLightsabers;

            
            if (totalMoney <= amountMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalMoney - amountMoney:F2}lv more.");
            }
            
        }
    }
}
