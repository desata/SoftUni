using System;
using System.Collections.Generic;

namespace Riding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> heroes = new List<string> {"Druid", "Paladin", "Rogue", "Warrior" };
            int heroPower = 0;
            IHero hero = null;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroes.Contains(heroType))
                {
                    if (heroType == "Druid")
                    {
                        hero = new Druid(name, heroType);
                    }
                    else if (heroType == "Paladin")
                    {
                        hero = new Paladin(name, heroType);
                    }
                    else if (heroType == "Rogue")
                    {
                        hero = new Rogue(name, heroType);
                    }
                    else if (heroType == "Warrior")
                    {
                        hero = new Warrior(name, heroType);
                    }

                    heroPower += hero.Power;

                    Console.WriteLine(hero.CastAbility());
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i -= 1;
                }
            }


            long bossPower = int.Parse(Console.ReadLine());


            if (bossPower <= heroPower)
            {
                Console.WriteLine("Victory!");
                
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
