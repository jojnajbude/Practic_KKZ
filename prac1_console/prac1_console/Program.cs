using System;

namespace prac1_console
{


   
    internal class Program
    {
        static void Main(string[] args)

        {
            //string s1 = "1 5 12 10";
            //string s2 = "123/10";


            //Fraction s = Fraction.Parse(s1);
            //Console.WriteLine(s.IntPart + "|" + s.Numerator + "/" + s.Denominator);
            ///*
            //Fraction f = new Fraction(38, 12);
            //f.GetMixedView();
            //Console.WriteLine(f.IntPart+"|"+f.Numerator+"/"+f.Denominator);*/


            Time t1 = new Time(156489);
            Time t2 = new Time(33, 15, 12);
            Time t3 = new Time(60,75,12);
            Time t4 = new Time();
            Console.WriteLine(t3);
            Console.WriteLine(t1);
            t3 = t3 - t1;
            Console.WriteLine(t3);
            Console.WriteLine(Time.Parse("15 62 13"));
            Console.WriteLine(Time.Parse("156489"));

        }
    }
}
