using System;

namespace _02Ermehamisitas
{
    public class Coin
    {
        public Coin()
        {
            Console.WriteLine("Coin konstruktor");
        }

        Random random = new Random();



        public virtual int Collect()
        {
            Console.Write("Coin.Collect");
            return random.Next(0,2);
        }
    }
}