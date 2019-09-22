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
            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 25%");
            Data = 25;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 50%");
            Data = 50;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 75%");
            Data = 75;

            Thread.Sleep(1000);
            Console.WriteLine("LongRunningProcess: 100%");
            Data = 100;


        }


        private int data;
        public int Data
        {
            get { return data; }
            set
            {
                if (data == value) //ha nem változott ne értesítsünk
                {
                    return;
                }
                data = value;
                SendMessage();
            }
        }

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