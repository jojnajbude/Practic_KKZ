using System;

namespace prac6_console
{
    internal class Program
    {
        class Harvesting
        {
            protected int _area;
            protected int _per_hectar;

            public int Area { get => _area; set => _area = value; }
            public int Per_Hectar { get => _per_hectar; set => _per_hectar = value; }

            public Harvesting()
            {
                _area = 0;
                _per_hectar = 0;
            }
            public Harvesting(int area)
            {
                _area = area;
            }

            public virtual int Total_Harvest()
            {
                return _area * _per_hectar; 
            }

            public override string ToString()
            {
                return String.Format("Area: {0}\n Cost per hectar: {1}\n Total harvest cost: {2}", _area ,_per_hectar, Total_Harvest());
            }
        }

        class Farm : Harvesting
        {
            public Farm(int area) : base(area)
                {
                _per_hectar = 120;
                }
            public override int Total_Harvest()
            {
                int tax = 30;
                return _area * (_per_hectar - tax) ; 
            }
        }

        class Homesteads : Harvesting
        {
            public Homesteads(int area) : base(area)
            {
                _per_hectar = 100;
            }

            public override int Total_Harvest()
            {
                int tax = 22; 
                int expenses = _area / 20; 

                return (_area * (_per_hectar - tax)) - expenses;
            }
        }


        static void Main(string[] args)
        {
            Farm f = new Farm(500);
            Homesteads h = new Homesteads(1200);
            Console.WriteLine(f);
            Console.WriteLine(h);
            
        }
    }
}
