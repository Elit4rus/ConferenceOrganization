using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ConferenceOrganization.AppData
{
    internal class BlockSystemHelper
    {
        public static int incorrectInput = 0;
        public static DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 1)
        };
        public static int IncreaseIncorrectInput() => ++incorrectInput;
    }
}
