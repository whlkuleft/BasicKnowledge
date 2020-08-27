using System;
using System.Collections.Generic;
using System.Text;
using 特性.AttributeExtend;

namespace 特性
{
    
    public class Test
    {
        [Length(2,4)]
        public string Name { get; set; }
    }
}
