using System;
using System.Collections.Generic;
using System.Text;

namespace 特性.AttributeExtend
{
    public abstract class AbstractValidateAttribute:Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
