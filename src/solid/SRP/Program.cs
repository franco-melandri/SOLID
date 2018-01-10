using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new Shape[]
            {
                new Square(5),
                new Circle(5)
            };

            var area = new AreaCalculator(shapes);
            //Console.WriteLine(area.Show());

            var areaOutpu = new AreaCalculatorOutput(area);

            Console.WriteLine(areaOutpu.ShowHtml());
            Console.WriteLine(areaOutpu.ShowJson());
            Console.WriteLine(areaOutpu.ShowXml());


            Console.ReadKey();
        }
    }


    public class AreaCalculator
    {
        private readonly Shape[] shapes;
        public AreaCalculator(Shape[] shapes)
        {
            this.shapes = shapes;
        }
        public float Sum()
        {
            float sum = 0;
            foreach (var s in shapes)
            {
                var square = s as Square;
                if (square != null)
                {
                    sum += square.GetLenght() * square.GetLenght();
                }

                var circle = s as Circle;
                if (circle != null)
                {
                    sum += (float)(circle.GetRadious() * circle.GetRadious() * Math.PI);
                }
            }
            return sum;
        }

        //public string Show()
        //{
        //    return string.Format("<div>{0}</div>", Sum());
        //}
    }

    public class Shape
    {
    }

    public class Square : Shape
    {
        private readonly float length;

        public Square(float length)
        {
            this.length = length;
        }

        public float GetLenght()
        {
            return length;
        }
    }

    public class Circle : Shape
    {
        private readonly float radious;

        public Circle(float radious)
        {
            this.radious = radious;
        }

        public float GetRadious()
        {
            return radious;
        }
    }

    public class AreaCalculatorOutput
    {
        private readonly AreaCalculator areaCalculator;

        public AreaCalculatorOutput(AreaCalculator areaCalculator)
        {
            this.areaCalculator = areaCalculator;
        }

        public string ShowHtml()
        {
            return string.Format("<div>{0}</div>", areaCalculator.Sum());
        }
        public string ShowJson()
        {
            return string.Format("{1}\"Area\":{0}{2}", areaCalculator.Sum(), "{", "}");
        }

        public string ShowXml()
        {
            return string.Format("<xml><area>{0}</area></xml>", areaCalculator.Sum());
        }
    }
}
