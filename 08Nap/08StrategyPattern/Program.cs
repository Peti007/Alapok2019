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


            //páros számok szorzata
            sum = store.ProductOfEven();
            Console.WriteLine($"Párosok szorzata: {sum}");

            
            var storeWStrategy = new DataStoreWithStrategy(data: new int[] { 1, 3, 4, 5, 7, 8, 10, 15, 30 });
           IStrategy strategy = new SumOfOddStrategy();
            storeWStrategy.SetStrategy(strategy);

            sum = storeWStrategy.Process();

            Console.WriteLine($"Páratlanok összege: {sum}");

            strategy = new ProductOfEventStrategy();

            storeWStrategy.SetStrategy(strategy);
            sum = storeWStrategy.Process();
            Console.WriteLine($"Párosok szorzata: {sum}");


            Console.ReadLine();
        }
    }
}
