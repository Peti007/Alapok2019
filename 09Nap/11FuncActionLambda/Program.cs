using System;

namespace _11FuncActionLambda
{
    class Program
    {
        delegate int SquaringDef(int x);

        static void Main(string[] args)
        {
            SquaringDef squaringProcesslist = SqueringFunc;

            Console.WriteLine($"2 a négyzeten: {squaringProcesslist(2)}");


            squaringProcesslist = x => x * x;

            squaringProcesslist = (x) => { return x * x; };

            squaringProcesslist = (x) =>
            {
                Console.WriteLine($"négyzetre emelek, paraméter: {x}");
                return x * x;
            };
            Console.WriteLine($"2 a négyzeten: {squaringProcesslist(2)}");

            //Action és Func

            //az Action és a Func előredefiniált delegate
            //az Action<> egy void típusú delegate-et definiál
            //a paraméterek felsorolására van csak szükség
            //Action<T1,T2,..,TN> egyenértékű
            //delegate void XXX(T1 t1, T2 t2,....TN tn)




            Action<int, int> multiplicationProcessList = (a, b) => Console.WriteLine($"A szorzás eredménye:{a * b}");

            multiplicationProcessList(2, 5);

            //A Func egy nem void-dal visszatérő delegate definiciót jelent
            Func<int, int, int> multiplicationProcessListFunc = (a, b) => a * b;

            Console.WriteLine($"A szorzás eredménye:{multiplicationProcessListFunc(3,9)}");



            Console.ReadLine();
        }

        

        private static int SqueringFunc(int x)
        {
            return x * x;
        }
    }
}
