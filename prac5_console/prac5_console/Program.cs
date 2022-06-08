using System;

namespace prac5_console
{
    interface IPrint
    {
        public void Print();
    }

    abstract class GeometricShape
    {
        public abstract float GetArea();
    }

    class Rectangle: GeometricShape, IPrint
    {
        private float _sideA, _sideB;

        public float SideA { get { return _sideA; } set { _sideA = value; } }
        public float SideB { get { return _sideB; } set { _sideB = value; } }

        public override float GetArea()
        {
            return _sideA * _sideB;  
        }

        public override string ToString()
        {
            return $"Side A: {_sideA}\nSide B: {_sideB}\nArea: {GetArea()}";
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public Rectangle(float sideA, float sideB)
        {
            _sideA = sideA;
            _sideB = sideB;
        }
    }

    class Square: Rectangle
    {
        public override string ToString()
        {
            return $"Side: {SideA}\nArea: {GetArea()}";
        }

        public Square(float sideA) : base(sideA, sideA)
        {

        }
    }

    class Circle: GeometricShape, IPrint
    {
        float _radius;
        
        public float Radius { get { return _radius; } set { _radius = value; } }

        public override float GetArea()
        {
            return (float)Math.PI * _radius * _radius;
        }

        public override string ToString()
        {
            return $"Radius: {Radius}\nArea: {GetArea()}";
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public Circle(float radius)
        {
            _radius = radius;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle= new Circle(4.6f);
            circle.Print();
            Console.WriteLine();
            
            Rectangle rectangle = new Rectangle(4, 5);
            rectangle.Print();
            Console.WriteLine();
            
            Square square = new Square(8);
            square.Print();
        }
    }
}
