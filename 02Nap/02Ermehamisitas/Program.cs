using System;

namespace _02Ermehamisitas
{
    class Program
    {
        static void Main(string[] args)
        {
            var coin = new FakeCoin();
            DoCollects(coin);
        }

        private static void DoCollects(Coin coin)
        {
            Console.WriteLine("Az érmefeldobások eredménye:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{coin.Collect()},");
            }
            Console.ReadLine();
        }
    }
}
