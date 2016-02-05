using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    // The publisher: the class that other classes
    // will observe. This class publishes one delegate:
    // SecondChangeHandler.
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        // the delegate the subscribers must implement
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);

        // an instance of the delegate
        public SecondChangeHandler SecondChanged;

        // set the clock running it will raise an event for each new second
        public void Run()
        {
            for (;;)
            {
                // sleep 100 milliseconds
                Thread.Sleep(100);
                // get the current time
                System.DateTime dt = System.DateTime.Now;
                // if the second has changed notify the subscribers
                if (dt.Second != second)
                {
                    // create the TimeInfoEventArgs object to pass to the subscriber
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                    // if anyone has subscribed, notify them
                    if (SecondChanged != null)
                    {
                        SecondChanged(this, timeInformation);
                    }
                }

                // update the state
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }
}
