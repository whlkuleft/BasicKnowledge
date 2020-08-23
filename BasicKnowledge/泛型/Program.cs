using System;
using System.Diagnostics;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a = 1;
            string str = "2";
            Object o = 3;
            DateTime date = DateTime.Now;
            {
                Console.WriteLine("明确类型：");
                CommonMethod.ShowInt(a);
                CommonMethod.ShowString(str);
                CommonMethod.ShowDateTime(date);
            }
            {
                Console.WriteLine("Object继承类型：");
                CommonMethod.ShowObject(a);
                CommonMethod.ShowObject(str);
                CommonMethod.ShowObject(date);
            }
            {
                Console.WriteLine("泛型：");
                CommonMethod.Show<int>(a);
                CommonMethod.Show(a);//省略int,语法糖自我推断
                CommonMethod.Show(str);
                CommonMethod.Show<DateTime>(date);
            }
            {
                Console.WriteLine("效率对比");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    CommonMethod.ShowIntDoNothing(a);
                }
                stopwatch.Stop();
                long sw1 = stopwatch.ElapsedMilliseconds;
                stopwatch.Restart();
                for (int i = 0; i < 100000000; i++)
                {
                    CommonMethod.ShowObjectDoNothing(a);
                }
                stopwatch.Stop();
                long sw2 = stopwatch.ElapsedMilliseconds;
                stopwatch.Restart();
                for (int i = 0; i < 100000000; i++)
                {
                    CommonMethod.ShowDoNothing<int>(a);
                }
                stopwatch.Stop();
                long sw3 = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"明确类型耗时:{sw1},装箱类型耗时:{sw2},泛型耗时:{sw3}");
            }
        }
    }
}
