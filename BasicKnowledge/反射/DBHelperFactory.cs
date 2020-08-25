using DBInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Utility;

namespace 反射
{
    public static class DBHelperFactory
    {
        static string DLLName = ConfigHelper.GetAppSettings("ReflectSection:ReflectDLL");
        static string TypeName = ConfigHelper.GetAppSettings("ReflectSection:ReflectType");
        public static IDBHelper CreateInstance() {
            Assembly assembly = Assembly.LoadFrom(DLLName);
            Type type = assembly.GetType(TypeName);
            object Object = Activator.CreateInstance(type);
            return Object as IDBHelper;
        }
    }
}
