using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        //public void Message(IMessage data)
        //{
        //    Console.WriteLine($"UserInterface: {data.Data}");
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