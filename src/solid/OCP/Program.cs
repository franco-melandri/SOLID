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
            Console.WriteLine(area.Sum());

            Console.ReadKey();
        }
    }

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

    public interface IShape
    {
        float GetArea();
    }

    public class Square : IShape
    {
        protected readonly float length;

        public Square(float length)
        {
            this.length = length;
        }

        public float GetArea()
        {
            return length * length;
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
