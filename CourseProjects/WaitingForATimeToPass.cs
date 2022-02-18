using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjects
{
    internal class WaitingForATimeToPass
    {
        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() => 
            {
                Console.WriteLine("You have 5 secondes to disarm the bomb by poressing any key");
                bool canceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(canceled ? "Bomb disarmed" : "BOOM!!!!");
            }, token);
            t.Start();

            Thread.SpinWait(10000);
            SpinWait.SpinUntil(() => false);
            Console.WriteLine("Are you still here?");

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program is done, press any key");
            Console.ReadKey();
        }
    }
}
