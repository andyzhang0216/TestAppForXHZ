using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingSnow.Contract
{
    public static class ReflectionHelpers
    {
        public static string GetCustomEnumStringValue(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (EnumValueAttribute[])fi.GetCustomAttributes(typeof(EnumValueAttribute), false);
            return (attributes.Length > 0) ? attributes[0].EnumValue : objEnum.ToString();
        }

        public static string StringValue(this Enum value)
        {
            return GetCustomEnumStringValue(value);
        }
    }


    public class EnumValueAttribute : Attribute
    {
        public string EnumValue;
        public EnumValueAttribute(string enumValue)
        {
            this.EnumValue = enumValue;
        }
        public override string ToString()
        {
            return this.EnumValue;
        }
    }
}
