using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleManager trmanager = new TriangleManager();
            //standart equivalent triagle
            trmanager["triangle"] = new Triangle(2, 2, 2);
            //user's triangle
            trmanager["My_triangle"] = new Triangle(5, 2, 4);
            //User clones selected triangle
            Triangle triangle = trmanager["My_triangle"].Clone() as Triangle;
            triangle.GetInfo();
        }
    }
    abstract class Figure
    {
        public abstract Figure Clone();
        public abstract void GetInfo();
    }

    class Triangle : Figure
    {
        int sideA;
        int sideB;
        int sideC;

        public Triangle(int a, int b, int c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }
        public override Figure Clone()
        {
            return new Triangle(this.sideA, this.sideB, this.sideC);
        }
        public override void GetInfo()
        {
            Console.WriteLine("Triangle with sides {0}, {1}, {2} cm", sideA, sideB, sideC);
        }
    }

    class TriangleManager
    {
        private Dictionary<string, Figure> _figure =
          new Dictionary<string, Figure>();

        // Indexer
        public Figure this[string key]
        {
            get { return _figure[key]; }
            set { _figure.Add(key, value); }
        }
    }

}
