using System;
using System.Collections.Generic;
using System.Threading;

namespace _01ObserverPattern
{
    public class LongRunningProcess
    {
        private readonly List<IMessage> observers = new List<IMessage>();





        //public LongRunningProcess(params IMessage[] observers)
        //{
        //    this.observers = observers ?? throw new ArgumentNullException(nameof(observers));
        //}

        public void Start()
        {
            Console.WriteLine("LongRunningProcess: 0%");
            SendMessage(0);

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            SendMessage(25);
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            SendMessage(50);
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            SendMessage(75);
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            SendMessage(100);
        }

        public void Subscribe(IMessage observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IMessage observer)
        {
            observers.Remove(observer);
        }

        private  void SendMessage(int data)
        {
            foreach (var observer in observers)
            {
                observer.Message(data);
            }
        }
    }
}