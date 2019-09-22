using System;
using System.Collections.Generic;
using System.Threading;

namespace _01ObserverPattern
{
    public class LongRunningProcess :IMessage
    {
        private readonly List<INotifiable> observers = new List<INotifiable>();





        //public LongRunningProcess(params IMessage[] observers)
        //{
        //    this.observers = observers ?? throw new ArgumentNullException(nameof(observers));
        //}

        public void Start()
        {
            Console.WriteLine("LongRunningProcess: 0%");
            Data = 0;
            SendMessage();

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            Data = 25;
            SendMessage();
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            Data = 50;
            SendMessage();
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            Data = 75;
            SendMessage();
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            Data = 100;
            Text = "Végeztem";
            SendMessage();
        }

        public int Data { get; set; }


        public string Text { get; set; }

        public void Subscribe(INotifiable observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(INotifiable observer)
        {
            observers.Remove(observer);
        }

        private  void SendMessage()
        {
            foreach (var observer in observers)
            {
                observer.Message(this);
            }
        }
    }
}