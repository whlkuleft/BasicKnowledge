using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClass
{
    public class Chinese : People, ISports
    {
        public void Pingpang()
        {
            Console.WriteLine("中国人打乒乓");
        }
    }
}
