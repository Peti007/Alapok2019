using System;

namespace _01Objektumok
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane1 = new Plane();
            var plane2 = new Plane();

            if (plane1 == plane2)
            {
                Console.WriteLine("A két példány azonos");
            }
            else {
                Console.WriteLine("A két példány nem azonos");
            }

            plane1.NrOfEdge = 3;
            plane2.NrOfEdge = 5;

            
            plane1.Name = "PLANE1";

            Console.WriteLine(plane1.Name);

            plane1.Show(1, 3);

            
            var ertek = 2;
            var referencia = new ReferenciaTipus() { ertek = 3 };
            var ertek2 = 4;

            Console.WriteLine($"ertek: {ertek}, referencia: {referencia.ertek}, ertek2: {ertek2}");

            int ertek3;
            plane1.Show(ertek, referencia, ref ertek2, out ertek3);
            Console.WriteLine($"ertek: {ertek}, referencia: {referencia.ertek},ertek2: {ertek2}, ertek3: {ertek3}");

            plane1.Show(); // ez a paraméter nélküli fgv-t hívja
            plane1.Show(width: 9, name: "akármi"); //alapértelmezett értéke miatt a height paramétert nem kell megadni, a fordító megtalálja




            Console.ReadLine();
        }
    }
}
