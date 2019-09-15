using System;

namespace _09Delagate
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeWDelegate = new DataStoreWDelegate(data: new int[] { 1, 3, 4, 5, 7, 8, 10, 15, 30 });

            var sum = storeWDelegate.Process(SumOfOdd);
            Console.WriteLine($"Páratlanok összege: {sum}");


            sum = storeWDelegate.Process2(SumOfOdd);
            Console.WriteLine($"Páratlanok összege: {sum}");

            sum = storeWDelegate.Process3(data => 
            {
                var s = 0;
                foreach (var d in data)
                {
                    if (d % 2 == 1)
                    {
                        s += d;
                    }
                }
                return s;
            });

            Console.WriteLine($"Páratlanok összege: {sum}");


            Console.ReadLine();
        }

        private static int SumOfOdd(int[] data)
        {
            var sum = 0;
            foreach (var d in data)
            {
                if (d % 2 == 1)
                {
                    sum += d;
                }
            }
            return sum;
        }
    }
}
