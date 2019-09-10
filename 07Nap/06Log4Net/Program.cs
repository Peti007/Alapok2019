using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();

            while (!Console.KeyAvailable)
            {
                var level = r.Next(100);

                if (level<50)
                {

                }

                if (level>=50 && level<70)
                {

                }

                if (level>=70 && level<85)
                {

                }
                if (level>=85 && level<95)
                {

                }

                if (level>=95)
                {

                }
                Thread.Sleep(200);
            }
        }
    }
}
