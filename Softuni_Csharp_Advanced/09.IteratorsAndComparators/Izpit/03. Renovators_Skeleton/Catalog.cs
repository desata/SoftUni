using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        //ctor
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            List<Renovator> renovator = new List<Renovator>();
        }
        //prop
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }


        //methods
        public int Count => Renovators.Count;


        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrWhiteSpace(renovator.Name) || string.IsNullOrWhiteSpace(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if(NeededRenovators >= Renovators.Count )
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                Renovators.Add(renovator);
               return "Successfully added {renovator.Name} to the catalog.";
            }

        }
        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(r => r.Name == name))
            {
                Renovators.FirstOrDefault(r => r.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (Renovators.Exists(r => r.Type == type))
            {
                int count = Renovators.Count(r => r.Type == type);

                Renovators.RemoveAll(r => r.Type == type);
                return count;
            }
            else
            {
                return 0;
            }
        }

        public Renovator HireRenovator(string name)
        {

            if (Renovators.Exists(r => r.Name == name) && Renovators.Exists(r => r.Hired == false))
            { 
                return Renovators.FirstOrDefault(r => r.Hired == true);     
            }
            else {
                return null;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {

                List<Renovator> renovatorToBePaid = new List<Renovator>();
                foreach (var ren in Renovators)
                {
                    if (ren.Days >= days)
                    {
                        renovatorToBePaid.Append(ren);
                    }
                }
                return renovatorToBePaid;
            


        }

        public string Report()
        {

            Renovators = Renovators.Where(r => r.Hired == false).ToList();


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var fishes in Renovators)
            {
                sb.AppendLine(fishes.ToString().TrimEnd());
            }

            return sb.ToString();
        }    


    }
}
