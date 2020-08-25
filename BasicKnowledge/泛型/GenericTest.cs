using PublicClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace 泛型
{
    public static class GenericTest
    {
        //基类约束
        public static void ShowPeople<T>(T t) where T:People{
            Console.WriteLine($"ID:{t.ID},Name:{t.Name}");
        }

        //接口约束
        public static void ShowSports<T>(T t) where T : ISports {
            t.Pingpang();
        }

        //引用类型约束
        public static T ShowObject<T>(T t) where T : class { return default(T); }

        //值类型约束
        public static T ShowStruct<T>(T t) where T : struct { return default(T); }

        //无参构造函数约束
        public static T ShowNew<T>(T t) where T : new() { return default(T); }

        //多组合约束
        public static void Show<T>(T t) where T : People, ISports, new() { }

        public class GenericMethod
        {
            public void Show<T, W, X>(T t, W w, X x)
            {
                Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
            }
        }

        public class GenericClass<T, W, X>
        {
            public void Show(T t, W w, X x)
            {
                Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
            }
        }


        public class GenericDouble<T>
        {
            public void Show<W, X>(T t, W w, X x)
            {
                Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
            }
        }

    }

    
}
