using System;
using System.ComponentModel;
using System.Linq;

namespace Contract.Domain
{
    public static class Helper
    {
        public static string GetEnumerationDescription(Enum value)
        {
            var fi = value
                .GetType()
                .GetField(value.ToString());

            if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
                return attributes.First().Description;
            

            return value.ToString();
        }
    }
}
