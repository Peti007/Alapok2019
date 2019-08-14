using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SikidomokTerulete
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(side: 4);

            //ez helyett:
            //"A négyzet területe: " + square.Area().ToString()"
            Console.WriteLine($"négyzet területe:{square.Area()}");

            var circle = new Circle(radius: 5);
            Console.WriteLine($"kör területe:{circle.Area()}");

            var triangle = new Triangle(trianglebase: 6, height: 4);
            Console.WriteLine($"háromszög területe:{triangle.Area()}");

            var areasum = square.Area();

            areasum = areasum + circle.Area();

            areasum += triangle.Area();

            //profibb megoldás

            var planes = new List<IPlane>();
            planes.Add(square);
            planes.Add(circle);
            planes.Add(triangle);

            //var sum = 0;
            //foreach (var plane in planes)
            //{
            //    sum += plane.Area();
            //}


            var sum = planes.Sum(x => x.Area());
            Console.WriteLine($"területek összege:{areasum}");
            Console.WriteLine($"területek összege:{planes.Sum(x => x.Area())}");







            Console.ReadLine();
        }
    }
}
