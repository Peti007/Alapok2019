﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace _01ObserverPattern
{
    public class LongRunningProcess 
    {


        ////Ilyen értesítést tudunk hívni, így ilyeneket engedünk a listára
        //public delegate void MessageDef(IMessage data);

        ////ez pedig a híváslistánk
        //public MessageDef ObserverCallList;


        //definiáljuk az eseményt
        //ami
        //1. delegate típusdefinició
        //2. delegate hiváslista változó definició
        //
        // ez egy különleges delegate-et definiál
        // a.) csak void típusú függvényt definiál
        // b.) ezt a híváslistát nem lehet az osztályon kívülről meghívni
        //c.) ezt a havíáslistát nem lehet osztályon kivűlről inicializálni (= művelet)
        public event EventHandler<string> DataChanged;
        //a függvénynek két paramétere van minden esetben:
        //obeject sender,
        //és
        //T e
        //az első kötelező, a másikat a generikus paraméter jelöli ki

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

        
        private  void SendMessage()
        {
            var callList = DataChanged;

            if (callList!=null)
            {
                callList(this, "ez itt egy esemény");
            }
            //gyorsabban ugyanez
            //ObserverCallList?.Invoke(this);
           
        }
    }
}