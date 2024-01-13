namespace PrimeNumberCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                bool isPrime = true;

                if (i % 2 == 0)
                {
                    isPrime = false;
                    System.Console.WriteLine("No");
                }
                else
                {
                    System.Console.WriteLine("yes");
                }

                count++;
            }
        }
    }
}