namespace qmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = 7;
            b = a;
           c = b++;
            c = a >= 100 ? b : c / 10;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            a = (int)Math.Sqrt(b * b + c * c);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);


        }
    }
}