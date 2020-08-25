using DBInterface;
using DBSQL;
using Microsoft.Extensions.Configuration;
using PublicClass;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Utility;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                IDBHelper iDBHelper = new SQLHelper();
                iDBHelper.Query();
            }
            {
                Assembly assembly = Assembly.Load("DBSQL");
                Type[] t = assembly.GetTypes();
                //遍历类型
                foreach (Type type in t)
                {
                    Console.WriteLine(type.FullName);
                    //遍历属性(带getset)
                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        Console.WriteLine(property.Name);
                    }
                    //遍历字段（不带getset）
                    foreach (FieldInfo field in type.GetFields())
                    {
                        Console.WriteLine(field.Name);
                    }
                    //遍历方法
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        Console.WriteLine(method.Name);
                        //遍历参数
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            Console.WriteLine(parameter.Name);
                        }
                    }
                }
                Object iDBHelper = assembly.CreateInstance("DBSQL.SQLHelper");
                IDBHelper DBHelper = iDBHelper as IDBHelper;
                DBHelper.Query();
            }
            {

                //工厂+配置文件+反射 实现热插拔
                IDBHelper dBHelper = DBHelperFactory.CreateInstance();
                dBHelper.Query();
            }
            {
                //反射创建对象
                Assembly assembly = Assembly.Load("PublicClass");
                Type type = assembly.GetType("PublicClass.ReflectionTest");
                Object reflectionTest = Activator.CreateInstance(type,true);//私有构造函数（可以破坏单例）
                Object reflectionTest2 = Activator.CreateInstance(type,new object[] { "test"});//字符串构造函数
                Object reflectionTest3 = Activator.CreateInstance(type, new object[] { 123});//整型构造函数
                Object reflectionTest4 = Activator.CreateInstance(type, new object[] { 123,"test" });//整型构造函数
                
                //反射调用普通方法
                object oTest = Activator.CreateInstance(type,true);

                MethodInfo show1 = type.GetMethod("Show1");
                show1.Invoke(oTest, new object[0]);// 反射调用方法 

                MethodInfo show2 = type.GetMethod("Show2");
                show2.Invoke(oTest, new object[] { 123 });// 反射调用方法 ,需要参数的时候，参数类型必须和方法参数类型保持一致

                // 重载方法:
                MethodInfo show3 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                show3.Invoke(oTest, new object[] { "Test", 134 });// 反射调用方法 

                // 反射调用私有方法
                MethodInfo show4 = type.GetMethod("Show4",BindingFlags.NonPublic | BindingFlags.Instance);
                show4.Invoke(oTest, new object[] { "Test" });

                // 反射调用静态方法
                MethodInfo show5 = type.GetMethod("Show5");
                show5.Invoke(oTest, new object[] { "Test" });//对象的实例  可以传入，也可以传入null
                show5.Invoke(null, new object[] { "Test" });  
            }
            {
                //反射调用泛型方法
                //泛型编译之后生成展位符  `1   `2    `3
                GenericMethod genericMethod = new GenericMethod();
                genericMethod.Show<int, string, DateTime>(1234, "", DateTime.Now);

                Assembly assembly = Assembly.Load("PublicClass");
                Type type = assembly.GetType("PublicClass.GenericMethod");
                object oTest = Activator.CreateInstance(type);
                MethodInfo genericMethod1 = type.GetMethod("Show");//指定方法名
                MethodInfo genericMethod2 = genericMethod1.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });// 指定泛型方法的  具体参数 
                genericMethod2.Invoke(oTest, new object[] { 123, "Test", DateTime.Now }); // 传入参数必须和声明的一样

                //在泛型类中 调用方法
                Type type1 = assembly.GetType("PublicClass.GenericClass`3"); //获取一个泛型类型 
                Type type2 = type1.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });//指定泛型类参数
                object oGenericTest = Activator.CreateInstance(type2);//创建泛型类
                MethodInfo genericMethod3 = type2.GetMethod("Show");//指定方法名
                genericMethod3.Invoke(oGenericTest, new object[] { 123, "Test", DateTime.Now });

                //在泛型类中 调用泛型方法 其中一个参数是泛型类参数类型
                Type type3 = assembly.GetType("PublicClass.GenericDouble`1"); //获取一个泛型类型 
                Type type4 = type3.MakeGenericType(new Type[] { typeof(int)});//指定泛型类参数
                object oGeneric = Activator.CreateInstance(type4);//创建泛型类
                MethodInfo genericMethod4 = type4.GetMethod("Show");//指定方法名
                MethodInfo genericMethod5 = genericMethod4.MakeGenericMethod(new Type[] {typeof(string), typeof(DateTime) });// 指定泛型方法的  具体参数 
                genericMethod5.Invoke(oGeneric, new object[] { 123, "Test", DateTime.Now });
            }


            Console.ReadLine();
        }

    }
}
