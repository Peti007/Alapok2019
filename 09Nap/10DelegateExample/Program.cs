using System;
using System.Collections.Generic;

namespace _10DelegateExample
{
    class Program
    {

       static string CharToRemove = "m";

        static void Main(string[] args)
        {
            var lines = new List<string>();
            lines.Add("Első elem");
            lines.Add("Második elem");
            lines.Add("Harmadik elem");
            lines.Add("Negyedik elem");
            lines.Add("Ötödik elem");
            lines.Add("Hatodik elem");


            var store = new DataStore(lines);


            //store.ProcessData(RemoveA);
            //store.ProcessData(RemoveE);
            //store.ProcessData(RemoveChar);

            DataStore.FuncDef processList;

            //processList = RemoveA;
            //processList = processList + RemoveE + RemoveChar;


            processList = delegate { }; //üres híváslist definiálása, típus nélkül

            processList += RemoveA;
            processList += RemoveE;
            processList += RemoveChar;

            CharToRemove = "l";

            //hogy ha lokális változót szeretnénk beküldeni a függvénybe, 
            //akkor remekül használható a külön függvénydefinicó helyett, az anonymus delegate használata:

            processList += delegate (ref string toModify)
            {
                var toReplace = "d";
                toModify = toModify.Replace(toReplace, "");
            };

            var toReplaceVar = "k";
            processList += delegate (ref string toModify)
            {
                
                toModify = toModify.Replace(toReplaceVar, "");
            };


            store.ProcessData(processList);


       


            store.Print();


            Console.ReadLine();
        }

        private static void RemoveA(ref string text)
        {
            //a Replace függvény nem módosítja a text értékét, hanem egy új szövegpéldányt hoz létre
            //így azeredményt visszaírjuk a text változóba
            text = text.Replace("a","");
        }

        private static void RemoveE(ref string text)
        {
            text = text.Replace("e", "");
        }


        private static void RemoveChar(ref string text)
        {
            //kívülről jövő paramétert is használhatok a delegate-nél: amit a definicó lát, az "megy a híváslistával"
            text = text.Replace(CharToRemove, "");
        }


    }
}
