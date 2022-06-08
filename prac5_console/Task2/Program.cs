using System;

namespace Task21
{
    enum Shapes
    {
        Square, 
        Circle,
        Triangle
    }

    class Picture
    {
        Shape[] shapes;
        int _arraySize;

        public Picture(int arraySize)
        {
            _arraySize = arraySize;
        }
    }

    abstract class Shape
    {
        public abstract string Figure{get; set;}
            
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
