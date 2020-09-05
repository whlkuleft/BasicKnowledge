using System;
using 设计模式.观察者模式;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 委托实现观察者模式
            {
                Action action = new Action(new Dog().Wang);
                action += new Baby().Cry;
                Cat cat = new Cat();
                cat.MiaoDelegate(action);
                //同上
                Cat catevent = new Cat();
                catevent.miaoAction += new Baby().Cry;
                catevent.miaoAction += new Dog().Wang;
                catevent.MiaoEvent();
            }
            //老方式实现：一组对象继承父类接口方法，猫方法调用时遍历对象执行接口方法
            #endregion
            Console.ReadLine();
        }
    }
}
