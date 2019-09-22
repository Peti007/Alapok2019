using System;

namespace _01ObserverPattern
{
    public class Logger
    {
        //public void Message(IMessage data)
        //{
        //    Console.WriteLine($"Logger: {data.Data}");
        //}
        internal void Message(object sender, string e)
        {
            var data = (LongRunningProcess)sender;

            Console.WriteLine($"Logger: {data.Data}");
        }
    }
}