using MilitaryElite.Implementations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                string soldierKind = input[0];
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];

                if (soldierKind == "Private")
                {
                    decimal salary = decimal.Parse(input[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id, @private);
                }
                else if (soldierKind == "LeutenantGeneral")
                {
                    decimal salary = decimal.Parse(input[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        int privateId = int.Parse(input[i]);
                        IPrivate @private = soldiers[privateId] as IPrivate;

                        lieutenantGeneral.Privates.Add(@private);
                    }
                    soldiers.Add(id, lieutenantGeneral);

                }
                else if (soldierKind == "Engeneer")
                {
                    decimal salary = decimal.Parse(input[4]);
                    //проверка corp
                    string corpAsString = input[5];

                    bool isValidEnum = Enum.TryParse<Corps>(corpAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }

                    IEngeneer engeneer = new Engeneer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string partName = input[i];
                        int hours = int.Parse(input[i + 1]);

                        IRepair repair = new Repair(partName, hours);

                        engeneer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engeneer);

                }
                else if (soldierKind == "Commando")
                {
                    decimal salary = decimal.Parse(input[4]);
                    //проверка corp
                    string corpAsString = input[5];

                    bool isValidEnum = Enum.TryParse<Corps>(corpAsString, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    //проверка missionState
                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string codeName = input[i];
                        string stateAsString = input[i + 1];

                        bool isValidStatusEnum = Enum.TryParse<Status>(stateAsString, out Status status);

                        if (!isValidStatusEnum)
                        {
                            continue;
                        }
                            IMission mission = new Mission(codeName, status);

                            commando.Missions.Add(mission);
                        
                    }
                    soldiers.Add(id, commando);
                }
                else
                {
                    string codeNumber = input[4];
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine().Split();
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
