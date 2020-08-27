using System;
using System.Collections.Generic;
using System.Text;

namespace 特性.AttributeExtend
{
    public class TagAttribute:AbstractTagAttribute
    {
        private string Tag = "";
        public TagAttribute(string tagName) {
            this.Tag = tagName;
        }

        public override string GetTag(object ovalue)
        {
            return ovalue.ToString();
        }
    }
}
