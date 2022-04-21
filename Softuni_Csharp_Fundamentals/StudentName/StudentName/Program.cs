using System;

namespace StudentName
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double studentGrade = double.Parse(Console.ReadLine());
            
            
            Console.Write($"Name: {studentName}");
            Console.Write($", Age: {studentAge}");
            Console.WriteLine($", Grade: {studentGrade:F2}");
        }
    }
}
/*
 1. Student Information
Create a program that receives 3 lines of input:
 student name
 age
 average grade.
Your task is to print all the info about the student in the following format: &quot;Name: {student name}, Age:
{student age}, Grade: {student grade}&.*/