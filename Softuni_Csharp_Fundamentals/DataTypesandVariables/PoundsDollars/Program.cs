﻿using System;

    internal class Program
    {
        static void Main(string[] args)
        {

        double num = double.Parse(Console.ReadLine());
        decimal result = (decimal)(num * 1.31);
        Console.WriteLine($"{result:f3}");




    }
}