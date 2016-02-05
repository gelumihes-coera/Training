using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Tester
    {
        public void Run()
        {
            // create a new clock
            Clock theClock = new Clock();

            // create the display and tell it to subscribe to the clock just created
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);

            // create a Log object and tell it to subscribe to the clock
            LogCurrentTime lct = new LogCurrentTime();
            lct.Subscribe(theClock);

            // Get the clock started
            theClock.Run();
        }
    }
}
