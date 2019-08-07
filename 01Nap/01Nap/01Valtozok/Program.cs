using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Valtozok
{
    class Program
    {
        static void Main(string[] args)
        {
            var ertekTipus = new ErtekTipus();
            ertekTipus.szam = 10;
            Console.WriteLine($"ertekTipus:{ertekTipus.szam}");
            Console.ReadKey();
        }
    }
}
