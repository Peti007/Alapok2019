using System;

namespace _01ObserverPattern
{
    public class UserInterface
    {
        //public void Message(IMessage data)
        //{
        //    Console.WriteLine($"UserInterface: {data.Data}");
        //}
        internal void Message(object sender, string e)
        {
            var data = (LongRunningProcess)sender;

            Console.WriteLine($"UserInterface: {data.Data}");
        }
    }
}