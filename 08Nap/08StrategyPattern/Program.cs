using System;

namespace _08StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new DataStore(data: new int[] {1,3,4,5,7,8,10,15,30 });

            var sum = store.SumOfOdd();


            Console.WriteLine($"Páratlanok összege: {sum}");



            sum = store.ProductOfEven();
            Console.WriteLine($"Párosok szorzata: {sum}");

            Console.ReadLine();
        }
    }
}
