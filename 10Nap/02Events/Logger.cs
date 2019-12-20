using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        //public void Message(IMessage data)
        //{
        //    Console.WriteLine($"Logger: {data.Data}");
        //}
        //internal void Message(object sender, string e)
        //{
        //   //részletes adatoknál kell a típuskonverzió
        //   var data = (LongRunningProcess)sender;

        //    //ha csak a kiemelt adatokra van szükség
        //    Console.WriteLine($"Logger: {data.Data}");
        //}
        public void Message(object sender, EventDto e)
        {
             //részletes adatoknál kell a típuskonverzió
            var data = (LongRunningProcess)sender;

            //ha csak a kiemelt adatokra van szükség
            Console.WriteLine($"Logger: {e.Data}");
        }
    }
}