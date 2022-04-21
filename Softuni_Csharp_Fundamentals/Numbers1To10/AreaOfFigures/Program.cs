using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((side * side), 3));
            }
            else if (figure == "rectangle")
            {
                double sidea = double.Parse(Console.ReadLine());
                double sideb = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((sidea * sideb), 3));
            }
            else if (figure == "circle")
            { 
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((radius*radius * Math.PI), 3));

            }
            else if (figure == "triangle")
            {
                double sidea = double.Parse(Console.ReadLine());
                double sideb = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round((sidea * sideb)/2, 3));
            }
        }
    }
}


/*
Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и пресмята лицето й. 
Фигурите са четири вида: квадрат (square), правоъгълник (rectangle), кръг (circle) и триъгълник (triangle). 
На първия ред на входа се чете вида на фигурата (square, rectangle, circle или triangle).
•	Ако фигурата е квадрат, на следващия ред се чете едно число - дължина на страната му.
•	Ако фигурата е правоъгълник, на следващите два реда четат две числа - дължините на страните му.
•	Ако фигурата е кръг, на следващия ред чете едно число - радиусът на кръга.
•	Ако фигурата е триъгълник, на следващите два реда четат две числа - дължината на страната му и дължината на височината към нея.
Резултатът да се закръгли до 3 цифри след десетичната точка. 

 */