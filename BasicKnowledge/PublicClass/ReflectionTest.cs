using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClass
{
    public class ReflectionTest
    {
        #region 构造函数
        private ReflectionTest()
        {
            Console.WriteLine("私有构造函数");
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine("字符串构造函数");
        }

        public ReflectionTest(int i)
        {
            Console.WriteLine("整型构造函数");
        }

        public ReflectionTest(int i, string name) {
            Console.WriteLine("多参数构造函数");
        }

        #endregion

        #region 方法


        /// <summary>
        /// 无参方法
        /// </summary>
        public void Show1()
        {
            Console.WriteLine("这里是{0}的Show1", this.GetType());
        }
        /// <summary>
        /// 有参数方法
        /// </summary>
        /// <param name="id"></param>
        public void Show2(int id)
        {

            Console.WriteLine("这里是{0}的Show2", this.GetType());
        }
        /// <summary>
        /// 重载方法之一
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Show3(int id, string name)
        {
            Console.WriteLine("这里是{0}的Show3", this.GetType());
        }
        /// <summary>
        /// 重载方法之二
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void Show3(string name, int id)
        {
            Console.WriteLine("这里是{0}的Show3_2", this.GetType());
        }
        /// <summary>
        /// 重载方法之三
        /// </summary>
        /// <param name="id"></param>
        public void Show3(int id)
        {

            Console.WriteLine("这里是{0}的Show3_3", this.GetType());
        }
        /// <summary>
        /// 重载方法之四
        /// </summary>
        /// <param name="name"></param>
        public void Show3(string name)
        {

            Console.WriteLine("这里是{0}的Show3_4", this.GetType());
        }
        /// <summary>
        /// 重载方法之五
        /// </summary>
        public void Show3()
        {

            Console.WriteLine("这里是{0}的Show3_1", this.GetType());
        }
        /// <summary>
        /// 私有方法
        /// </summary>
        /// <param name="name"></param>
        private void Show4(string name)
        {
            Console.WriteLine("这里是{0}的Show4", this.GetType());
        }
        /// <summary>
        /// 静态方法
        /// </summary>
        /// <param name="name"></param>
        public static void Show5(string name)
        {
            Console.WriteLine("这里是{0}的Show5", typeof(ReflectionTest));
        }
        #endregion
    }
}
