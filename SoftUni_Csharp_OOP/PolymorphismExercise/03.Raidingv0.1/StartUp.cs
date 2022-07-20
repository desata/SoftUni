using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int totalHerosPower = 0;
            int n = int.Parse(Console.ReadLine());
            IHero hero = null;

            for (int i = 1; i <= n; i++)

            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                List<string> types = new List<string> { "Druid", "Paladin", "Rogue", "Warrior" };

                if (types.Contains(type))
                {
                    if (type == "Druid")
                    {
                        Druid druid = new Druid(name, type, 80);
                        hero = druid;
                    }
                    else if (type == "Paladin")
                    {
                        Paladin paladin = new Paladin(name, type, 100);
                        hero = paladin;

                    }
                    else if (type == "Rogue")
                    {
                        Rogue rogue = new Rogue(name, type, 80);
                        hero = rogue;
                    }
                    else if (type == "Warrior")
                    {
                        Warrior warrior = new Warrior(name, type, 100);
                        hero = warrior;
                    }
                                       
                    Console.WriteLine(hero.CastAbility());
                    totalHerosPower += hero.Power;
                }

                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;

                }
            }

            int bossPower = int.Parse(Console.ReadLine());


            if (bossPower - totalHerosPower > 0)
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
