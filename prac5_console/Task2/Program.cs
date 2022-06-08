using System;

namespace Task21
{
    enum Shapes
    {
        Circle = 0,
        Triangle = 3,
        Square = 4
    }

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
            shapes = new Shape[arraySize];
        }

        public void PrintArray()
        {
            foreach (var item in shapes)
            {
                item.Print();
            }
        }
    }

    abstract class Shape
    {
        protected Shapes figure;

        protected int sideLength;

        public int SideLength { get { return sideLength; } }

        public int VertexAmount { get; protected set; }

        public abstract Shapes Figure { get; protected set; }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public void Print()
        {
            Console.WriteLine("This is: " + Figure + "\n" + ToString());
        }

        public override string ToString()
        {
            return  "Its side lenght: " + sideLength + "\nIts area: " + GetArea() + "\nIts perimeter: " + GetPerimeter() + "\n";
        }
    }

    class Square : Shape
    {
        public override Shapes Figure
        {
            get { return figure; }
            protected set { figure = value; }
        }

        public override double GetArea()
        {
            return sideLength*sideLength;
        }

        public override double GetPerimeter()
        {
            return sideLength*4;
        }

        public Square(int _sideLenth)
        {
            VertexAmount = 4;

            Figure = (Shapes)VertexAmount;

            sideLength = _sideLenth;
        }
    }

    class Circle : Shape
    {
        public override Shapes Figure
        {
            get { return figure; }
            protected set { figure = value; }
        }

        public override double GetArea()
        {
            return Math.PI*sideLength*sideLength;
        }

        public override double GetPerimeter()
        {
            return 2*Math.PI*sideLength;
        }

        public Circle(int _sideLenth)
        {
            VertexAmount = 0;

            Figure = (Shapes)VertexAmount;

            sideLength = _sideLenth;
        }

        public override string ToString()
        {
            return "Its radius: " + sideLength 
                + "\nIts area: " + String.Format("{0:0.00}", GetArea())
                + "\nIts perimeter: " + String.Format("{0:0.00}", GetPerimeter())
                + "\n";
        }
    }

    class Triangle : Shape
    {
        public override Shapes Figure
        {
            get { return figure; }
            protected set { figure = value; }
        }

        public override double GetArea()
        {
            return (sideLength*sideLength)/2;
        }

        public override double GetPerimeter()
        {
            return 3 * sideLength;
        }

        public Triangle(int _sideLenth)
        {
            VertexAmount = 3;

            Figure = (Shapes)VertexAmount;

            sideLength = _sideLenth;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Picture picture = new Picture(3);

            picture.Add(new Square(5));
            picture.Add(new Triangle(6));
            picture.Add(new Circle(7));

            picture.PrintArray();
        }
    }
}
