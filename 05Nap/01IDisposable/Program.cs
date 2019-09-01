using System;

namespace _01IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            ////készítünk egy önmaga után rednet hagyó/ maga után takarító osztályt
            //var takarito = new ItselfCleaner();


            //try //megpróbálja a kódblokkot végrehajtani
            //{
            //    //elvégezzük a dolgunk
            //}

            //finally //miután az előzőek lefutottak, akár hiba van akár nem, ez a kódblokk mindenképpen lefut
            //{
            //    //az IDisposable felület dispose függvényét használjuk
            //    ((IDisposable)takarito).Dispose();
            //}


            //hogy ne kelljen mindig ezt a sok kódot leírni, ezért
            //ilyen 'syntactic sugar' használatával a fordító generálja nekünk ugyanezt
            using (var takarit = new ItselfCleaner())
            {//ebben a kódblokkban van a védendő használata (ez a try ág)


            }

        }
    }
}
