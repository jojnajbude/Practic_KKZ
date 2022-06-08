using System;

namespace Task22
{
    class Picture
    {
        Shape[] shapes;
        int _arraySize;
        int _index = 0;
        public void Add(Shape shape)
        {
            try
            {
                shapes[_index] = shape;
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
            shapes = new Shape[_arraySize];
        }

        public void PrintArray()
        {
            foreach (var item in shapes)
            {
                Console.WriteLine(item);
            }
        }
    }

    abstract class Shape
    {
        protected string figure;
        protected float _firstParam;
        protected float _secondParam;

        public string Figure
        {
            get { return figure; }
            protected set { figure = value; }
        }

        public abstract float FirstParam { get; set; }
        public abstract float SecondParam { get; set; }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public abstract void Print();

        public override string ToString()
        {
            return "This is: " + Figure;
        }

        public Shape(float firstParam, float secondParam)
        {
            _firstParam = firstParam;
            _secondParam = secondParam;
        }
    }

    class Pentagon: Shape
    {
        public override float FirstParam { get => _firstParam; set => _firstParam = value; }
        public override float SecondParam { get => _secondParam; set => _secondParam = value; }

        public override double GetArea()
        {
            double height = (FirstParam / 2) / Math.Tan((36 * Math.PI) / 180);
            return 0.25 * FirstParam * height;
        }

        public override double GetPerimeter()
        {
            return FirstParam * SecondParam;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return base.ToString() 
                + "\nIts side length: " + FirstParam
                + "\nIts area: " + String.Format("{0:0.00}", GetArea())
                + "\nIts perimeter: " + String.Format("{0:0.00}", GetPerimeter())
                + "\n";
        }

        public Pentagon(float firstParam): base(firstParam, 5) 
        {
            Figure = "Pentagon";
        }
    }

    class Ellipse: Shape
    {
        public override float FirstParam { get => _firstParam; set => _firstParam = value; }
        public override float SecondParam { get => _secondParam; set => _secondParam = value; }

        public override double GetArea()
        {
            return Math.PI * FirstParam * SecondParam;
        }

        public override double GetPerimeter()
        {
            return 4*((Math.PI*FirstParam*SecondParam+(FirstParam-SecondParam))/(FirstParam+SecondParam));
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return base.ToString() 
                + "\nIts long semiaxis: " + FirstParam
                + "\nIts short semiaxis: " + SecondParam
                + "\nIts area: " + String.Format("{0:0.00}", GetArea())
                + "\nIts perimeter: " + String.Format("{0:0.00}", GetPerimeter())
                + "\n";
        }

        public Ellipse(float firstParam, float secondParam) : base(firstParam, secondParam)
        {
            Figure = "Ellipse";
        }   
    }

    class Triangle: Shape
    {
        public override float FirstParam { get => _firstParam; set => _firstParam = value; }
        public override float SecondParam { get => _secondParam; set => _secondParam = value; }

        public override double GetArea()
        {
            return FirstParam * SecondParam;
        }

        public override double GetPerimeter()
        {
            double g = Math.Sqrt(Math.Pow(_firstParam,2)+Math.Pow(_secondParam,2));
            return FirstParam+SecondParam+g;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return base.ToString()
                + "\nIts first leg: " + FirstParam
                + "\nIts second leg: " + SecondParam
                + "\nIts area: " + String.Format("{0:0.00}", GetArea())
                + "\nIts perimeter: " + String.Format("{0:0.00}", GetPerimeter())
                + "\n";
        }

        public Triangle(float firstParam, float secondParam) : base(firstParam, secondParam)
        {
            Figure = "Right triangle";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Picture picture = new Picture(3);

            picture.Add(new Pentagon(5));
            picture.Add(new Triangle(6f,8f));
            picture.Add(new Ellipse(4f,9f));

            picture.PrintArray();
        }
    }
}
