using System;

namespace _02Ermehamisitas
{
    public class Coin
    {
        Random random = new Random();

        public int Collect()
        {
            return random.Next(0,2);
        }
    }
}