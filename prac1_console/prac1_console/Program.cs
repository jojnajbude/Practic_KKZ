using System;

namespace prac1_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(3, 4);
            Fraction f3 = new Fraction(8, 19);
            Fraction f4 = new Fraction(3, 10);
            Fraction f5 = new Fraction(9, 22);
            Fraction[] fractions = { f1,f2,f3,f4,f5};

            for (int i = 0; i < fractions.Length; i++)
            {
                Console.WriteLine(fractions[i] + "\n");
            }

            Array.Sort(fractions);

            Console.WriteLine("Result");
            for (int i = 0; i < fractions.Length; i++)
            {
                Console.WriteLine(fractions[i]+"\n");
            }
        }
    }
}
