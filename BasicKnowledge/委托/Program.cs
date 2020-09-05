using System;

namespace 委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                Test test = new Test(new MyTest().TestXY);
                test.Invoke("1", 2);
                //等同
                Test test1 = new MyTest().TestXY;
                test1.Invoke("1", 2);
                //等同
                test1("1", 2);
            }
            {
                MyTest test = new MyTest();
                test.AAA(test.TestXY);

            }

            {
                People people = new People();
                people.SayHiPerfect("wangnima", () => { Console.WriteLine("good morning"); });
                //等同
                Action action = people.SayHiE;
                people.SayHiPerfect("wangnima", action);
                //等同
                people.SayHiPerfect("wangnima", people.SayHiE);
            }
            Console.ReadLine();
        }

    }


    //定义委托，可以在类外面，也可以在类里面
    public delegate void Test(string x,int y);

    public class MyTest
    {
        public void TestXY(string x, int y) { 
        }
        public void AAA(Action<string,int> action) {
            string x = "1";
            int y = 0;
            action.Invoke(x, y);
        }

        public void BBB(Action action)
        {
            action.Invoke();
        }
    }

    public class People {
        //加参数判断---执行分支逻辑
        //好处：公共逻辑方便
        //坏处：任意分支变化，经常改动代码
        public void SayHiSwitch(string name,PeopleType peopleType) {
            switch (peopleType)
            {
                case PeopleType.E:
                    Console.WriteLine(name+"good morning");
                    break;
                case PeopleType.C:
                    Console.WriteLine(name+"早上好");
                    break;
                default:
                    break;
            }
        }
        //加方法满足不同的场景
        //好处：逻辑分离
        //坏处：增加公共逻辑麻烦，有很多重复代码
        public void SayHiE(string name) {
            Console.WriteLine(name+"good morning");
        }
        public void SayHiE()
        {
            Console.WriteLine("good morning");
        }
        public void SayHiC(string name) {
            Console.WriteLine(name+"早上好");
        }
        //既公共逻辑方便，又逻辑分离
        //逻辑解耦，代码重用
        public void SayHiPerfect(string name,Action action) {
            Console.WriteLine(name);
            action.Invoke();
        }

        public void TC(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public enum PeopleType { 
        E,C
    }
}
