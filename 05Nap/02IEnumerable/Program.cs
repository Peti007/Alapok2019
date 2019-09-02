using System;
using System.Collections.Generic;

namespace _02IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in ShoppingList())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> ShoppingList()
        {
            yield return "1 kg marhahús";
            yield return "só";
            yield return "1 kg burgonya";
            yield return "1 kg liszt";

            ShoppingList();
            Main(new string[] { });
        }
        public void InstanceFunction() {
            ShoppingList();
            Main(new string[] { });

        }
    }
}
