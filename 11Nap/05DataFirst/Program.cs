using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05DataFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new CodeFirstDBEntities();

            Console.WriteLine($"Tanárok: {db.Teachers.Count()}, Tárgyak: {db.Subjects.Count()}");

            Console.ReadLine();
        }
    }
}
