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
            var shapes = new IShape[]
            {
                new Square(5),
                new Circle(5),
                new Rectangle(5, 6)
            };

            var area = new AreaCalculator(shapes);
            var areaOutpu = new AreaCalculatorOutput(area);

            Console.WriteLine(areaOutpu.ShowHtml());
            Console.WriteLine(areaOutpu.ShowJson());
            Console.WriteLine(areaOutpu.ShowXml());
            
            Console.ReadKey();
        }
    }


    //public class AreaCalculator
    //{
    //    private readonly IShape[] shapes;

    //    public AreaCalculator(IShape[] shapes)
    //    {
    //        this.shapes = shapes;
    //    }

    //    public float Sum()
    //    {
    //        return shapes.Sum(s => s.GetArea());
    //    }

    //    public string Show()
    //    {
    //        return string.Format("<div>{0}</div>", Sum());
    //    }
    //}

    public class AreaCalculator
    {
        private readonly IShape[] shapes;

        public AreaCalculator(IShape[] shapes)
        {
            this.shapes = shapes;
        }

        public float Sum()
        {
            return shapes.Sum(s => s.GetArea());
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


    public interface IShape
    {
        float GetArea();
    }

    public class Square : IShape
    {
        private readonly float length;

        public Square(float length)
        {
            this.length = length;
        }

        public float GetArea()
        {
            return length*length;
        }
    }

    public class Circle : IShape
    {
        private readonly float radious;

        public Circle(float radious)
        {
            this.radious = radious;
        }

        public float GetArea()
        {
            return (float)(radious*radious*Math.PI);
        }
    }

    public class Rectangle : IShape
    {
        private readonly float height;
        private readonly float width;

        public Rectangle(float height, float width)
        {
            this.height = height;
            this.width = width;
        }

        public float GetArea()
        {
            return width * height;
        }
    }
}
