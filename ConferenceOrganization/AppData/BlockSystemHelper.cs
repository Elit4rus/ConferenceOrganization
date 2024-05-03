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
        private static int incorrectInput = 0;
        public static DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 1)
        };
        public static int IncreaseIncorrectInput()
        {
            if (incorrectInput <= 3)
            {
                incorrectInput++;
            }
            else if (incorrectInput == 4)
            {
                incorrectInput = 0;
            }
            return incorrectInput;
        }
    }
}
