﻿using System;

namespace _01IEnumerableT
{
    class Program
    {
        static void Main(string[] args)
        {
            var adat = new Adat(szam: 1, szoveg: "Marhahús");

            var adatok = new BejarhatoAdatok<Adat>(); //két fontos szerepet visel: adat csomagokat tarttalmaz és bejárhatóvá teszi őket


            adatok.Add(adat);
            adatok.Add(new Adat(szam: 2, szoveg: "Só"));
            adatok.Add(new Adat(szam: 3, szoveg: "Burgonya"));  
            adatok.Add(new Adat(szam: 4, szoveg: "Pirospaprika"));

            foreach (var item in adatok)
            {
                adatok.Remove(item);
                Console.WriteLine($"Adat szám: {item.Szam}, szöveg: {item.Szoveg}");
            }


            Console.ReadLine();
        }
    }
}
