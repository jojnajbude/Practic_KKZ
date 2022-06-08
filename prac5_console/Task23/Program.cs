using System;

namespace Task23
{
    class Picture
    {
        Triangle[] triangles;
        int _arraySize;
        int _index = 0;
        public void Add(Triangle triangle)
        {
            try
            {
                triangles[_index] = triangle;
                _index++;
            }
            catch (Exception)
            {
                Console.WriteLine("You have reach the maximum number of elements");
            }
        }
        public Picture(int arraySize)
        {
            _arraySize = arraySize;
            triangles = new Triangle[_arraySize];
        }

        public void PrintArray()
        {
            foreach (var item in triangles)
            {
                Console.WriteLine(item);
            }
        }
    }

    abstract class Triangle
    {
        private string _name;
        public float _firstSide;
        public float _secondSide;
        public float _angle;

        public string Name { get => _name; protected set => _name = value; }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"This is: {Name}\nIts first side: {_firstSide}\nIts second side: {_secondSide}\nIts angle: {_angle}\nIts area: {GetArea()}\nIts peremiter: {GetPerimeter()}\n";
        }

        public Triangle(float firstSide, float secondSide, float angle)
        {
            _firstSide = firstSide;
            _secondSide = secondSide;
            _angle = angle;
        }
    }

    class EqTriangle: Triangle
    {
        public override double GetArea()
        {
            return (Math.Sqrt(3)/4)*Math.Pow(_firstSide, 2);
        }

        public override double GetPerimeter()
        {
            return _firstSide*3;
        }

        public override string ToString()
        {
            return $"This is: {Name}\nIts side: {_firstSide}\nIts angle: {_angle}\nIts area: {GetArea()}\nIts peremiter: {GetPerimeter()}\n";
        }

        public EqTriangle(float firstSide): base(firstSide,firstSide,60)
        {
            Name = "EqTriangle";
        }
    }

    class IsTriangle: Triangle
    {
        public override double GetArea()
        {
            double height = Math.Sin((_angle * Math.PI) / 180)*_firstSide;
            return 0.5*height*_secondSide;
        }

        public override double GetPerimeter()
        {
            return _firstSide * 2 + _secondSide;
        }

        public IsTriangle(float firstSide, float secondSide, float angle) : base(firstSide, secondSide, angle)
        {
            Name = "IsTriangle";
        }
    }

    class RectTriangle: Triangle
    {
        public override double GetArea()
        {
            return 0.5 * _secondSide * _firstSide;
        }

        public override double GetPerimeter()
        {
            double g = Math.Sqrt(Math.Pow(_firstSide, 2) + Math.Pow(_secondSide, 2));
            return _firstSide + _secondSide + g;
        }

        public RectTriangle(float firstSide, float secondSide) : base(firstSide, secondSide, 90)
        {
            Name = "RectTriangle";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Picture picture = new Picture(3);

            picture.Add(new RectTriangle(5,9));
            picture.Add(new IsTriangle(6f, 8f,35));
            picture.Add(new EqTriangle(9f));

            picture.PrintArray();
        }
    }
}
