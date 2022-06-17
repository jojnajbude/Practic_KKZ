using System;

namespace prac1_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction10 = new Fraction(5.1568);
            Console.WriteLine(fraction10 + "\n");

            Fraction fraction1 = new Fraction(25, 50);
            Fraction fraction2 = new Fraction(44, 89);
            Console.WriteLine(fraction1 + fraction2 + "\n");

            Fraction fraction3 = new Fraction(25, 50);
            Fraction fraction4 = new Fraction(44, 89);
            Console.WriteLine(fraction3 - fraction4 + "\n");

            Complex complex1 = new Complex(25, 50);
            Complex complex2 = new Complex(44, 89);
            Console.WriteLine(complex1 + complex2 + "\n");

            Complex complex3 = new Complex(2, 8);
            Complex complex4 = new Complex(4, 16);
            Console.WriteLine(complex3 / complex4 + "\n");

            Date date1 = new Date(25, 11, 2003);
            Date date2 = new Date(12, 12, 2005);
            Console.WriteLine(date1 > date2);
            Console.WriteLine("\n");

            Date date3 = new Date(25, 11, 2003);
            int days = 346;
            Console.WriteLine(date3 + days + "\n");

            Time time1 = new Time(16, 52, 16);
            int minutes = 47;
            Console.WriteLine(time1 + minutes + "\n");

            Time time2 = new Time(16, 52, 16);
            Time time3 = new Time(78, 121, 17);
            Console.WriteLine(time3 - time2 + "\n");
        }
    }
}
