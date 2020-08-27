using System;
using System.Collections.Generic;
using System.Text;

namespace 特性.AttributeExtend
{
    public abstract class AbstractTagAttribute:Attribute
    {
        public abstract string GetTag(object ovalue);
    }
}
