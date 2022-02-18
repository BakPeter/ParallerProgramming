//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CourseProjects
//{
//    internal class CancellingTasks
//    {
//        public static void Main(string[] args)
//        {
//            //CancellableTasks();
//            //MonitoringCancelation();
//            CompositeCancelationToken();

//            Console.WriteLine("Main Program done, press any key.");
//            Console.ReadKey();
//        }

//        private static void CompositeCancelationToken()
//        {
//            var planned = new CancellationTokenSource();
//            var preventative = new CancellationTokenSource();
//            var emergency = new CancellationTokenSource();

//            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
//                planned.Token, preventative.Token, emergency.Token);

//            Task.Factory.StartNew(() =>
//            {
//                int i = 0;
//                while (true)
//                {
//                    paranoid.Token.ThrowIfCancellationRequested();
//                    Console.WriteLine($"{i++}\t");
//                    Thread.Sleep(100);
//                }
//            }, paranoid.Token);

//            paranoid.Token.Register(() => Console.WriteLine("Cancellation requested"));

//            Console.ReadKey();

//            //planned.Cancel();
//            //emergency.Cancel();
//            preventative.Cancel();
//            //paranoid.Cancel();
//        }

//private static void MonitoringCancelation()
//        {
//            var cts = new CancellationTokenSource();
//            var token = cts.Token;

//            token.Register(() =>
//            {
//                Console.WriteLine("Cancellation has been requested Register callback.");
//            });

//            Task t = new Task(() =>
//            {
//                int i = 0;
//                while (true)
//                {
//                    if (token.IsCancellationRequested)
//                    {
//                        Console.WriteLine("Cancellation has been executed.");
//                        break;
//                    }
//                    else
//                    {
//                        Console.WriteLine($"{i++}\t");
//                        Thread.Sleep(100);
//                    }
//                }
//            });
//            t.Start();

//            Task t2 = Task.Factory.StartNew(() => {
//                char c = 'a';
//                while(true)
//                {
//                    //token.ThrowIfCancellationRequested();

//                    if (token.IsCancellationRequested)
//                    {
//                        throw new OperationCanceledException();
//                    }
//                    else
//                    {
//                        Console.WriteLine($"{c++}\t");
//                        Thread.Sleep(200);
//                    }
//                }
//            }, token);

//            Task.Factory.StartNew(() =>
//            {
//                token.WaitHandle.WaitOne();
//                Console.WriteLine("Wait handle realeased, thus cancelation was requested");
//            });

//            Console.ReadKey();

//            cts.Cancel();
            
//            Thread.Sleep(1000);

//            Console.WriteLine($"Task has been canceled. The status of the canceled task 't' is {t.Status}.");
//            Console.WriteLine($"Task has been canceled. The status of the canceled task 't2' is {t2.Status}.");
//            Console.WriteLine($"t.IsCanceled = {t.IsCanceled}, t2.IsCanceled = {t2.IsCanceled}");
//        }

//        private static void CancellableTasks()
//        {
//            var cts = new CancellationTokenSource();
//            var token = cts.Token;
//            Task t = new Task(() =>
//            {
//                int i = 0;
//                while(true)
//                {
//                    if(token.IsCancellationRequested)
//                    {
//                        break;
//                    } else
//                    {
//                        Console.WriteLine($"{i++}\t");
//                    }
//                }
//            });
//            t.Start();

//            Console.ReadKey();
//            cts.Cancel();
//            Console.WriteLine("Task has been canceled.");
//        }
//    }
//}
