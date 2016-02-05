using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // a second subscriber whose job is to write to a file
    public class LogCurrentTime
    {
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChanged +=
                  new Clock.SecondChangeHandler(WriteLogEntry);
        }

        // this method should write to a file
        // we write to the console to see the effect
        // this object keeps no state
        public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Logging to file: {0}:{1}:{2}",
               ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
    }
}
