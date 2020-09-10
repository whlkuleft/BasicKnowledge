using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace 异步多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                Task task1 = new Task(() => { Console.WriteLine("task1"); });
                Console.WriteLine("启动1");
                task1.Start();
                //同上
                Task task2 = Task.Run(() => { Console.WriteLine("task2"); });
                Console.WriteLine("启动2");
                //同上
                Task task3 = Task.Factory.StartNew(() => { Console.WriteLine("task3"); });
                Console.WriteLine("启动3");
            }
            {
                Console.WriteLine("总共并发三件事");
                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = Task.Factory;
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第一件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第二件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第三件事"); }));
                Task.WaitAll(taskList.ToArray());
                Console.WriteLine("阻塞执行，全部完成");
            }
            {
                Console.WriteLine("总共并发三件事");
                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = Task.Factory;
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第一件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第二件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第三件事"); }));
                taskFactory.ContinueWhenAll(taskList.ToArray(), (o) =>
                {
                    foreach (var item in o)
                    {
                        Console.WriteLine(item.Status);
                    }
                    Console.WriteLine("非阻塞执行，全部完成");
                });
            }
            {
                Console.WriteLine("总共并发三件事");
                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = Task.Factory;
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第一件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(4000); Console.WriteLine("第二件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(6000); Console.WriteLine("第三件事"); }));
                Task.WaitAny(taskList.ToArray());
                Console.WriteLine("有一件完成");
            }
            {
                Console.WriteLine("总共并发三件事");
                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = Task.Factory;
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("第一件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(4000); Console.WriteLine("第二件事"); }));
                taskList.Add(taskFactory.StartNew(() => { Thread.Sleep(6000); Console.WriteLine("第三件事"); }));
                taskFactory.ContinueWhenAny(taskList.ToArray(), (o) =>
                {
                    Console.WriteLine(o.Status);
                    Console.WriteLine("非阻塞执行，有一件完成");
                });
            }
            Console.WriteLine("Hello End!");
            Console.ReadLine();
        }
    }
}
