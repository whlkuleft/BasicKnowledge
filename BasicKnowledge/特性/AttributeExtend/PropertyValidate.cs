using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace 特性.AttributeExtend
{
    public static class PropertyValidate
    {
        public static bool Validate<T>( this T model) {
            Type type = model.GetType();
            //遍历获取所有属性
            foreach (PropertyInfo property in type.GetProperties())
            {
                //属性是否被定义特性
                if (property.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    //获取属性的值
                    var value = property.GetValue(model);
                    //遍历获取该属性上的所有特性
                    foreach (AbstractValidateAttribute attribute in property.GetCustomAttributes(typeof(AbstractValidateAttribute), true))
                    {
                        //当有一个特性不满足要求时就返回false，全部满足才返回true
                        if (!attribute.Validate(value))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
