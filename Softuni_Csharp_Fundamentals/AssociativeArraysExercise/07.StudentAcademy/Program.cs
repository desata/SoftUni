using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            

            for (int i = 1; i <= numberOfRows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());


                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double> { grade, 1 });
                }
                else
                {
                    students[name][0] += grade;
                    students[name][1] += 1;
                }
            }

            foreach (var item in students)
            {
                double totalGrade = item.Value[0] / item.Value[1];
                if (totalGrade < 4.5)
                {
                    students.Remove(item.Key);
                }
                else {
                    Console.WriteLine($"{item.Key} -> {(totalGrade):F2}");
                }
                
            }
        }
    }
}
