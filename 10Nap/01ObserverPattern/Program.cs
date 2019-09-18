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


            process.Subscribe(log);
            process.Subscribe(ui);

            process.Start();

            process.Unsubscribe(log);
            process.Unsubscribe(ui);

            Console.WriteLine("A folyamat lefutott!");
            Console.ReadLine();
        }
    }
}
