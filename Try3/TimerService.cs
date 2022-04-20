using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Try3
{
    public class TimerService
    {    
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

        readonly Timer _timer;
        public TimerService()
            {
            //WriteMessage();
            _timer = new Timer(1000) { AutoReset = true };

            // _timer.Elapsed += (sender, eventArgs) => File.AppendAllLines(@"C:\temp\tryLog\timer.log", new string[] { string.Format("It is {0} and all is well", DateTime.Now) });
            _timer.Elapsed += TimerElapsed;

        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };

            //File.AppendAllLines(@"C:\temp\tryLog\timer.log", lines);
            //message = lines[0];
            log.Warn(lines);
        }


        //private void WriteMessage()
        //{
        //    log.Info("Merhaba Alim");
        //    log.Error("Hata yapıyoruz");
        //}



        public void Start() { _timer.Start(); }
            public void Stop() { _timer.Stop(); }
        }
    
}
