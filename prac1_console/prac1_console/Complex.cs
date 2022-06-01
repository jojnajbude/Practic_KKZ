using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac1_console
{
    internal class Complex
    {
        private int _a = 0;
        private int _b = 0;
        private int _i;

        public int Re { set => _a = value; get => _a; }
        public int Im { set => _b = value; get => _b; }

        public Complex()
        {

        }

        public Complex(int a, int b)
        {
            _a = a;
            _b = b;
        }

        ~Complex()
        {
            Console.WriteLine("Object has destroyed.");
        }

        
        public static Complex operator +(Complex u, Complex v)
        {
            u._a += v._a;
            u._b += v._b;
            return u;
        }

        public static Complex operator -(Complex u, Complex v)
        {
            u._a -= v._a;
            u._b -= v._b;
            return u;
        }

        public static Complex operator *(Complex u, Complex v)
        {
            u._a = (u._a * v._a) - (u._b * v._b);
            v._b = (u._b * v._a) + (u._a * v._b);
            return u;
        }

        public static Complex operator /(Complex u, Complex v)
        {
            u._a = ((u._a * v._a) + (u._b * v._b)) / (v._a^2 + v._b^2);
            v._b = ((u._b*v._a)-(u._a*v._b)) / (v._a ^ 2 + v._b ^ 2);
            return u;
        }

        public static Complex Parse(string str)
        {
            Complex res = new Complex();
            string[] str_array = str.Split(' ');
            res._a = Convert.ToInt32(str_array[0]);
            res._b = Convert.ToInt32(str_array[2].Trim('i'));
            return res;
        }
        
        

        public override string ToString()
        {
            if (_b > 0) return _a + "+" + _b + "i";
            else if (_b == 0) return Convert.ToString(_a);
            else if (_a == 0) return _b + "i";
            else if (_b < 0) return _a +""+ _b + "i";
            else return "Error";
        }

    }
}
