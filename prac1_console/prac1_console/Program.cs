using System;

namespace prac1_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fraction S = new Fraction(5.1568);

            //Console.WriteLine(S);
            //Time T = new Time();

            //Time T1 = Time.Parse("10 12 13");

            //Console.WriteLine(T1);
            //Complex complex = new Complex(2, 4);
            //Complex complex1 = new Complex(8, 6);

            //Console.WriteLine(complex/complex1);
            Date date1 = new Date(25, 11, 2003);
            Date date2 = new Date(31, 05, 2022);

            Console.WriteLine(date2 + date1);
        }
    }
}
