using System.Text;

namespace LetterCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string value = "last_interest_pmt_amt";
            foreach (char c in value)
            {
                Console.WriteLine((int)c);
            }
        }
    }
}