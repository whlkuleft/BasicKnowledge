using System;
using System.Collections.Generic;
using System.Text;
using 特性.TestAttribute;

namespace 特性
{
    public class LLTEST
    {
        [LL(2,3)]
        public string Name { get; set; }
    }
}
