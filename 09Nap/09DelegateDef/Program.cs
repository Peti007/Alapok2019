using System;

namespace _09DelegateDef
{
    class Program
    {
        delegate void DelegateDef(string msg);

        //azért static mert a Main-ből fogjuk hívni ami static, ennek nincs köze a delegate témakörhöz.
        static void Hi(string txt)
        {
            Console.WriteLine($"Szia, de jó, hogy jössz: {txt}");
        }

        static void By(string str)
        {
            Console.WriteLine($"Szia, kár, hogy már mész: {str}");
        }

        static void Main(string[] args)
        {
            DelegateDef a;
            DelegateDef b;
            DelegateDef c;
            DelegateDef d;

            // csinálok egy híváslistát, ami egy hivatkozást tartlamaz
            a = Hi;

            // csinálok egy másik híváslistát, ami egy hivatkozást tartlamaz
            b = By;

            //ezeket a híváslistákat össze tudom fűzni
            c = a + b;

            //ezeknek a híváslistáknak tudom venni a különbségét
            d = c - a;

            Console.WriteLine("meghívjuk az [a] listát");
            a("a");
            Console.WriteLine("meghívjuk az [b] listát");
            b("b");
            Console.WriteLine("meghívjuk az [c] listát");
            c("c");
            Console.WriteLine("meghívjuk az [d] listát");
            d("d");
            Console.ReadLine();
        }
    }
}
