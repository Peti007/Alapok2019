using System;

namespace _02SikidomokTerulete
{
    class Program
    {
        static void Main(string[] args)
        {
            var negyzet = new Square(side: 4);

            //ez helyett:
            //"A négyzet területe: " + square.Area().ToString()"
            Console.WriteLine($"négyzet területe:{negyzet.Area()}");

            var circle = new Circle(radius: 5);
            Console.WriteLine($"kör területe:{circle.Area()}");

            var triangle = new Triangle(trianglebase: 6, height: 4);
            Console.WriteLine($"háromszög területe:{triangle.Area()}");

            Console.ReadLine();
        }
    }
}
