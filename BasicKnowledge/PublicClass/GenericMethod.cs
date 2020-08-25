using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClass
{
    //普通类泛型方法
    public class GenericMethod
    {
        public void Show<T, W, X>(T t, W w, X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    //泛型类泛型方法
    public class GenericClass<T, W, X>
    {
        public void Show(T t, W w, X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    //泛型类 泛型方法包含泛型类参数T
    public class GenericDouble<T>
    {
        public void Show<W, X>(T t, W w, X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }
}
