using System;

namespace _01ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //két alkalmazás modul, ami igényt tart az információra
            //naplózás
            var log = new Logger();
            //felhasználói felület
            var ui = new UserInterface();

            //hosszantartó folyamat
            var process = new LongRunningProcess();

            process.DataChanged += log.Message;
            process.DataChanged += ui.Message;

            //process.ObserverCallList = null;

           // process.ObserverCallList(new LongRunningProcess());

           process.Start();

            process.DataChanged -= log.Message;
            process.DataChanged -= ui.Message;

            Console.WriteLine("A folyamat lefutott!");
            Console.ReadLine();
        }
    }
}
