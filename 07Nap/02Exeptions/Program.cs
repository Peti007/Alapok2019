using System;

namespace _02Exeptions
{
    class Program
    {

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine($"---FirstChanceException---");
            Console.WriteLine(e.Exception.ToString());
            Console.WriteLine($"---FirstChanceException---");
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"---UnhandledException---");
            Console.WriteLine(((Exception)e.ExceptionObject).ToString());
            Console.WriteLine($"---UnhandledException---");
        }

        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                Console.WriteLine("Main try indul");
                FoProgram();
                Console.WriteLine("Main try végez");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Main catch indul");
                Console.WriteLine($"Main: {ex.ToString()}");
                throw;
                Console.WriteLine("Main catch végez");
            }
            finally
            {
                Console.WriteLine("Main finally indul");
                Console.WriteLine("Main finally végez");
            }
            Console.ReadLine();
        }

       

        private static void FoProgram()
        {
           
            try
            {
                Console.WriteLine("FoProgram try indul");
                Alprogram();
                Console.WriteLine("FoProgram try végez");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FoProgram catch indul");
                Console.WriteLine($"FoProgram: {ex.ToString()}");
                throw;
                Console.WriteLine("FoProgram catch végez");
            }
            finally
            {
                Console.WriteLine("FoProgram finally indul");
                Console.WriteLine("FoProgram finally végez");
            }
        }

        private static void Alprogram()
        {
            try
            {
                Console.WriteLine("Alprogram try indul");
                throw new ConfuseCurrencyException("Euró utalást kellene végezni, de a megadott számla HUF!");
                Console.WriteLine("Alprogram try végez");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Alprogram catch indul");
                Console.WriteLine($"Alprogram: {ex.ToString()}");
                throw;
                Console.WriteLine("Alprogram catch végez");
            }
            finally
            {
                Console.WriteLine("Alprogram finally indul");
                Console.WriteLine("Alprogram finally végez");
            }
        }
    }
}
