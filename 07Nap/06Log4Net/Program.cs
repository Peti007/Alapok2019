using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06Log4Net
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        //ugyanaz
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger("_06Log4Net.Program");


        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var r = new Random();

            while (!Console.KeyAvailable)
            {
                var level = r.Next(100);

                if (level<50)
                {
                    log.Debug($"Debug üzenet: {level}");
                }

                if (level>=50 && level<70)
                {
                    log.Info($"Info üzenet: {level}");
                }

                if (level>=70 && level<85)
                {
                    log.Warn($"Warn üzenet: {level}");
                }
                if (level>=85 && level<95)
                {
                    log.Error($"Error üzenet: {level}");
                }

                if (level>=95)
                {
                    log.Fatal($"Fatal üzenet: {level}");
                }
                Thread.Sleep(200);
            }
        }
    }
}
