using System;
using System.Linq;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new IShape[]
            {
                new Square(5),
                new Circle(5)
            };

            var area = new AreaCalculator(shapes);
            var perimeter = new PerimeterCalculator(shapes);

            var outputArea = new GenericCalculatorOutput(area);
            var outputPerimeter = new GenericCalculatorOutput(perimeter);

            Console.WriteLine(outputArea.ShowHtml());
            Console.WriteLine(outputPerimeter.ShowHtml());

            Console.ReadKey();
        }
    }

    public class GenericCalculator
    {
        protected readonly IShape[] shapes;

        public GenericCalculator(IShape[] shapes)
        {
            this.shapes = shapes;
        }

        public virtual float Sum()
        {
            return 0;
        }
    }

    public class AreaCalculator : GenericCalculator
    {
        public AreaCalculator(IShape[] shapes)
            : base(shapes)
        {
        }

        public override float Sum()
        {
            return shapes.Sum(s => s.GetArea());
        }
    }

    public class PerimeterCalculator : GenericCalculator
    {
        public PerimeterCalculator(IShape[] shapes)
            : base(shapes)
        {
        }

        public override float Sum()
        {
            return shapes.Sum(s => s.GetPerimeter());
        }
    }

    public interface IShape
    {
        float GetArea();
        float GetPerimeter();
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
            return length * length;
        }

        public float GetPerimeter()
        {
            return length*4;
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
            return (float)(radious * radious * Math.PI);
        }

        public float GetPerimeter()
        {
            return (float) (2*Math.PI*radious);
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

        public float GetPerimeter()
        {
            return (width + height ) * 2;
        }
    }

    public class GenericCalculatorOutput
    {
        private readonly GenericCalculator areaCalculator;

        public GenericCalculatorOutput(GenericCalculator areaCalculator)
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


