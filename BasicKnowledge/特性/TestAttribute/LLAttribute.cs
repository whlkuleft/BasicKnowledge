using System;
using System.Collections.Generic;
using System.Text;
using 特性.AttributeExtend;

namespace 特性.TestAttribute
{
    public class LLAttribute:Attribute
    {
        public long min;
        public long max;
        public LLAttribute(long Min, long Max)
        {
            this.min = Min;
            this.max = Max;
        }
        public class AttReturn
        {
            public bool isOK { get; set; }
        }

        public string validate(object ovalue) {
            if (ovalue != null)
            {
                long l = ovalue.ToString().Length;
                string ret = "";
                if (l > max)
                {
                    ret = "字符串过长了";
                }
                else if (l < min)
                {
                    ret = "字符串过短了";

                }
                return ret;
            }
            else {
                return "数据不可为空";
            }
        }
    }
}
