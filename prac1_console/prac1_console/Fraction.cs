using System;

namespace prac1_console
{
    public class Fraction : IComparable
    {
        private int _sign;
        private int _intPart;
        private int _numerator;
        private int _denominator;

        public int Numerator { set { _numerator = value; } get { return _numerator; } }
        public int Denominator { set { _denominator = value; } get { return _denominator; } }
        public int IntPart { set { _intPart = value; } get => GetIntPart(); }
        public int Sign { set { _sign = value; } get { return _sign; } }

        public Fraction()
        {

        }

        public Fraction(int numerator, int denominator, int sign = 1, int intPart = 0)
        {
            _sign = sign;
            _intPart = intPart;
            _numerator = numerator;
            _denominator = denominator;
        }

        public Fraction(double number)
        {
            if (number >= 0)
            {
                _sign = 1;
            }
            else _sign = -1;
            string str = number.ToString();
            string[] str_array = str.Split(",");


            _intPart = Math.Abs(Convert.ToInt32(str_array[0]));
            _numerator = Convert.ToInt32(str_array[1]);
            string zeros = "";
            for (int i = 0; i < (str_array[1].Length); i++)
            {
                zeros += "0";
            }
            _denominator = Convert.ToInt32("1" + zeros);

        }

        public void GetImproperView()
        {
            _numerator += _intPart * _denominator;
            _intPart = 0;
        }

        public void GetMixedView()
        {
            Cancellation();
            if (_numerator > _denominator)
            {
                _intPart = _numerator / _denominator;
                _numerator = _numerator - (_denominator * _intPart);
            }
        }

        public void Cancellation()
        {
            bool access = false;

            while (!access)
            {
                if (_numerator % 2 == 0 && _denominator % 2 == 0)
                {
                    _numerator = _numerator / 2;
                    _denominator = _denominator / 2;
                }
                else if (_numerator % 3 == 0 && _denominator % 3 == 0)
                {
                    _numerator = _numerator / 3;
                    _denominator = _denominator / 3;
                }
                else if (_numerator % 5 == 0 && _denominator % 5 == 0)
                {
                    _numerator = _numerator / 5;
                    _denominator = _denominator / 5;
                }
                else access = true;
            }
        }

        private int GetIntPart()
        {
            GetMixedView();
            return _intPart;
        }

        public static Fraction Parse(string str)
        {
            int intPart, numerator, denominator, sign;
            string[] strs = str.Split(' ');
            string[] strs1;
            Fraction res;
            if (strs.Length == 1)
            {
                strs1 = strs[0].Split('/');
                numerator = int.Parse(strs1[0]);
                denominator = int.Parse(strs1[1]);
                res = new Fraction(numerator, denominator);
                res.GetMixedView();
                return res;
            }
            sign = int.Parse(strs[0]);
            intPart = int.Parse(strs[1]);
            numerator = int.Parse(strs[2]);
            denominator = int.Parse(strs[3]);
            res = new Fraction(numerator, denominator, intPart, sign);
            res.GetMixedView();
            return res;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.IntPart = fraction1.Sign * fraction1.IntPart + fraction2.Sign * fraction2.IntPart;

            result.Numerator = fraction1.Sign * (fraction1.Numerator * fraction2.Denominator)
                + fraction2.Sign * (fraction2.Numerator * fraction1.Denominator);

            result.Denominator = fraction1.Denominator * fraction2.Denominator;

            result.Cancellation();

            return result;
        }

        public static Fraction operator +(Fraction fraction, int number)
        {
            fraction.IntPart += number;
            return fraction;
        }

        public static float operator +(float number, Fraction fraction)
        {
            number += fraction.IntPart;
            number += ((float)fraction.Numerator / (float)fraction.Denominator);
            return number;
        }

        public static Fraction operator -(Fraction fraction)
        {
            fraction.Sign *= -1;
            return fraction;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.IntPart = fraction1.Sign * fraction1.IntPart - fraction2.Sign * fraction2.IntPart;

            result.Numerator = fraction1.Sign * (fraction1.Numerator * fraction2.Denominator)
                - fraction2.Sign * (fraction2.Numerator * fraction1.Denominator);

            result.Denominator = fraction1.Denominator * fraction2.Denominator;

            result.Cancellation();

            return result;
        }

        public static Fraction operator -(Fraction fraction, int number)
        {
            fraction.IntPart -= number;
            return fraction;
        }

        public static float operator -(float number, Fraction fraction)
        {
            number -= fraction.IntPart;
            number -= ((float)fraction.Numerator / (float)fraction.Denominator);
            return number;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            fraction1.GetImproperView();
            fraction2.GetImproperView();
            result.Numerator = fraction1.Numerator * fraction2.Numerator;
            result.Denominator = fraction1.Denominator * fraction2.Denominator;
            result.GetMixedView();
            return result;
        }

        public static Fraction operator *(Fraction fraction, int number)
        {
            fraction.GetImproperView();
            fraction.Numerator *= number;
            fraction.GetMixedView();
            return fraction;
        }

        public static float operator *(float number, Fraction fraction)
        {
            fraction.GetImproperView();
            number = (number * fraction.Numerator) / (float)fraction.Denominator;
            return number;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            fraction1.GetImproperView();
            fraction2.GetImproperView();
            result.Numerator = fraction1.Numerator * fraction2.Denominator;
            result.Denominator = fraction1.Denominator * fraction2.Numerator;
            result.GetMixedView();
            return result;
        }

        public static Fraction operator /(Fraction fraction, int number)
        {
            fraction.Denominator *= number;
            fraction.GetMixedView();
            return fraction;
        }

        public static float operator /(float number, Fraction fraction)
        {
            fraction.GetImproperView();
            number = (number * fraction.Denominator) / (float)fraction.Numerator;
            return number;
        }
        public static bool operator >(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator > (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public static bool operator <(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator < (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public static bool operator >=(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator >= (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public static bool operator <=(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator <= (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public static bool operator !=(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator != (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public static bool operator ==(Fraction ob1, Fraction ob2)
        {
            bool result;
            ob1.GetImproperView();
            ob2.GetImproperView();
            result = (float)ob1.Numerator / (float)ob1.Denominator == (float)ob2.Numerator / (float)ob2.Denominator;
            ob1.GetMixedView();
            ob2.GetMixedView();
            return result;
        }

        public int CompareTo(object obj)
        {
            if (this < (obj as Fraction)) return -1;
            if (this > (obj as Fraction)) return 1;
            return 0;
        }

        public override string ToString()
        {
            string sgn = "";
            if (_sign == -1) sgn = "-";
            return "Integer part: "+ sgn + IntPart + " Fraction: " + Numerator + "/" + Denominator;
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   _sign == fraction._sign &&
                   _intPart == fraction._intPart &&
                   _numerator == fraction._numerator &&
                   _denominator == fraction._denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_sign, _intPart, _numerator, _denominator);
        }

        ~Fraction()
        {
            Console.WriteLine("Object has destroyed");
        }
    }
}