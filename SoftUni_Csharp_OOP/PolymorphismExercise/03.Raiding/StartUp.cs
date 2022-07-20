using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int heroesPower = 0;
            int totalHerosPower = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                List<string> types = new List<string> { "Druid", "Paladin", "Rogue", "Warrior"};


                if (types.Contains(type))  
                {
                    if (type == "Druid")
                    {
                        Druid druid = new Druid(name, type);
                        heroesPower = 80;
                        druid.CastAbility();
                    }
                    else if (type == "Paladin")
                    {
                        Paladin paladin = new Paladin(name, type);
                        heroesPower = 100;
                        paladin.CastAbility();
                    }
                    else if (type == "Rogue")
                    {
                        Rogue rogue = new Rogue(name, type);
                        heroesPower = 80;
                        rogue.CastAbility();
                    }
                    else
                    {
                        Warrior warrior = new Warrior(name, type);
                        heroesPower = 100;
                        warrior.CastAbility();
                    }
                    totalHerosPower += heroesPower;
                }
               
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;

                }
            }
            int bossPower = int.Parse(Console.ReadLine());

           
            if (bossPower > totalHerosPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
