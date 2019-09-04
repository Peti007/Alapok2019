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

            var shoppingList = new List<string> { "só", "bors", "cukor" };

            foreach (var item in shoppingList)
            {
                shoppingList.Remove(item);
            }
            //nekünk kell az implementációban azzal foglalkozni, ha az adatok megváltoznak!

            //ha változik a lista akkor dob egy kivételt
            //saját osztályunk gondoskodik arról, hogyha változik a belső állapot, akkor a futó bejárások ne fussanak hibás helyzetbe


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
