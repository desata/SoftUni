using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IHero> heroes = new List<IHero>();
            int heroesPower = 0;
            int totalHerosPower = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                // List<string> types = new List<string> { "Druid", "Paladin", "Rogue", "Warrior"};

                IHero currentHero = null;

                if (type == "Druid")
                {
                    currentHero = new Druid(name, type);
                    heroesPower = 80;
                    
                }
                else if (type == "Paladin")
                {
                    currentHero = new Paladin(name, type);
                    heroesPower = 100;

                }
                else if (type == "Rogue")
                {
                    currentHero = new Rogue(name, type);
                    heroesPower = 80;

                }
                else if (type == "Warrior")
                {
                    currentHero = new Warrior(name, type);
                    heroesPower = 100;

                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;

                }

                totalHerosPower += heroesPower;
                currentHero.CastAbility();
                heroes.Add(currentHero);
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
