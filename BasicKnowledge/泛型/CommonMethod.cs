using System;
using System.Collections.Generic;
using System.Text;

namespace 泛型
{
    public class CommonMethod
    {
        /// <summary>
        /// 传入INT
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={iParameter},type={iParameter.GetType().Name}");
        }
        /// <summary>
        /// 传入String
        /// </summary>
        /// <param name="strParameter"></param>
        public static void ShowString(string strParameter)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={strParameter},type={strParameter.GetType().Name}");
        }
        /// <summary>
        /// 传入DateTime
        /// </summary>
        /// <param name="dateParameter"></param>
        public static void ShowDateTime(DateTime dateParameter)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={dateParameter},type={dateParameter.GetType().Name}");
        }

        /// <summary>
        /// 传入Object
        /// </summary>
        /// <param name="objectParameter"></param>
        public static void ShowObject(Object objectParameter)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={objectParameter},type={objectParameter.GetType().Name}");
        }

        /// <summary>
        /// 传入t
        /// </summary>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={tParameter},type={tParameter.GetType().Name}");
        }

        #region 性能对比方法
        public static void ShowIntDoNothing(int iParameter)
        {
            //Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={iParameter},type={iParameter.GetType().Name}");
        }
        public static void ShowObjectDoNothing(Object oParameter)
        {
            //Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={iParameter},type={iParameter.GetType().Name}");
        }
        public static void ShowDoNothing<T>(T tParameter)
        {
            //Console.WriteLine($"this is {typeof(CommonMethod).Name},parameter={iParameter},type={iParameter.GetType().Name}");
        }
        #endregion
    }
}
