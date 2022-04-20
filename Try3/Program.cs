using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Try3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            
            XmlConfigurator.Configure();

            var rc = HostFactory.Run(x =>
            {
                x.Service<TimerService>(s =>
                {
                    s.ConstructUsing(name => new TimerService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.UseLog4Net();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Timer Service");
                x.SetServiceName("TimerService");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
