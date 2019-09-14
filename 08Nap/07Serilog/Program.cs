using Serilog;
using System;
using System.Threading;

namespace _07Serilog
{
    class Program
    {
        static void Main(string[] args)
        {

            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                                                                .WriteTo.Console()
                                                                .WriteTo.File(".\\serilog.log")
                                                                .CreateLogger();

            try
            {
                LogTest();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "Program terminated unsuccessfully");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            
        }

        private static void LogTest()
        {
            var r = new Random();

            while (!Console.KeyAvailable)
            {
                var level = r.Next(100);

                if (level < 50)
                {
                    Log.Logger.Debug($"Debug: {level}");
                }

                if (level >= 50 && level < 70)
                {
                    Log.Logger.Information($"Information: {level}");
                }

                if (level >= 70 && level < 85)
                {
                    Log.Logger.Warning($"Warning: {level}");
                }
                if (level >= 85 && level < 95)
                {
                    Log.Logger.Error($"Error: {level}");
                }

                if (level >= 95)
                {
                    Log.Logger.Fatal($"Fatal: {level}");
                }
                Thread.Sleep(200);
            }
        }
    }
}
