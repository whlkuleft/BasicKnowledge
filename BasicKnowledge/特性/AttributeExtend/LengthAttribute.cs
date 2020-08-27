using System;
using System.Collections.Generic;
using System.Text;

namespace 特性.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field,AllowMultiple =true)]
    public class LengthAttribute : AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;
        public LengthAttribute(long min, long max) {
            this._Min = min;
            this._Max = max;
        }
        public override bool Validate(object property)
        {
            return property != null && long.TryParse(property.ToString(), out long length) && length >= _Min && length <= _Max;            
        }
    }
}
