using System;
using System.Net.Http.Headers;
using System.Reflection;
using 特性.AttributeExtend;
using 特性.TestAttribute;

namespace 特性
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string x = "wanggg";
            long.TryParse(x, out long y);
            Console.WriteLine(y);
            {
                LLTEST test = new LLTEST();
                test.Name = "wangnima";
                Type type = test.GetType();
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.IsDefined(typeof(LLAttribute),true))
                    {
                        var value = property.GetValue(test);
                        LLAttribute att = property.GetCustomAttribute(typeof(LLAttribute), true) as LLAttribute;
                        string re = att.validate(value);
                        if (re!="")
                        {
                            Console.WriteLine(re);
                        }
                    }
                }
            }
            //{
            //    Test test = new Test();
            //    test.Name = "test";
            //    bool isflag = PropertyValidate.Validate(test);
            //    test.Validate();
            //}
            Console.ReadLine();
        }
 
    }
}
