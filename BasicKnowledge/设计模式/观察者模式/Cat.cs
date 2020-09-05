using System;
using System.Collections.Generic;
using System.Text;

namespace 设计模式.观察者模式
{
    public class Cat
    {
        public void Miao() {
            Console.WriteLine("喵一下");
            new Dog().Wang();
            new Baby().Cry();
        }

        public void MiaoDelegate(Action action)
        {
            Console.WriteLine("喵一下");
            action.Invoke();
        }

        public event Action miaoAction;
        public void MiaoEvent()
        {
            Console.WriteLine("喵一下");
            miaoAction?.Invoke();
        }
    }
}
