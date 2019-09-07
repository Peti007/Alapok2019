using System;

namespace _02Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Main try indul");

                var helyzet = Helyzetek.Nulla;

                switch (helyzet)
                {
                    case Helyzetek.Egy:
                        Console.WriteLine($"minden ok: {helyzet}");
                        break;
                    case Helyzetek.Ketto:
                        Console.WriteLine($"minden ok: {helyzet }");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Valami nem stimmel{helyzet}");
                        break;
                }




                Console.WriteLine("Main try befejeződik");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Main Argument catch indul");

                Console.WriteLine(ex.ToString());

                Console.WriteLine("Main Argument catch befejeződik");
            }

            catch (OutOfMemoryException) { } 

            catch (Exception ex)
            {
                Console.WriteLine("Main catch indul");
                Console.WriteLine(ex.ToString());


                Console.WriteLine("Main catch befejeződik");
                //throw;
            }
            finally
            {
                Console.WriteLine("Main finally indul");


                Console.WriteLine("Main finally befejeződik");
            }


            Console.ReadLine();
        }
    }
}
