//using System;

//namespace CourseProjects
//{
//    internal class IntreducingTasks
//    {
//        private static void Write(char c)
//        {
//            int i = 1000;
//            while (i-- > 0)
//            {
//                Console.Write(c);
//            }
//        }
//        private static void Write(object o)
//        {
//            int i = 1000;
//            while (i-- > 0)
//            {
//                Console.Write(o.ToString());
//            }
//        }

//        static void Main(string[] args)
//        {
//            //CreateAndStartASimpleTasks();
//            //TasksWithState();
//            TasksWithReturnValue();

//            Console.WriteLine("Main program done, press any key.");
//            Console.ReadKey();
//        }

//        private static void TasksWithReturnValue()
//        {
//            string text1 = "testing", text2 = "this";
//            var t1 = new Task<int>(TextLength, text1);
//            t1.Start();
//            var t2 = Task.Factory.StartNew(TextLength, text2);

//            Console.WriteLine(t1.Result);
//            Console.WriteLine(t2.Result);

//        }

//        private static int TextLength(object o)
//        {
//            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object '{o}'...");
//            return o.ToString().Length;
//        }

//        private static void TasksWithState()
//        {
//            Task t = new Task(Write, "foo");
//            t.Start();

//            Task.Factory.StartNew(Write, "bar");
       
//        }

//        private static void CreateAndStartASimpleTasks()
//        {
//            Task.Factory.StartNew(() => {
//                Write('-');
//            });

//            Task t = new Task(() => Write('?'));
//            t.Start();

//            Write('.');
//        }

        
//    }
//}
