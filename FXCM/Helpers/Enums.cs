using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCM.Helpers
{
    public static class EnumHelper<T>
    {
        public static string GetEnumDescription(string value)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

            if (name == null)
                return string.Empty;

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute.ElementAt(0)).Description : name;
        }

        public static T GetDescriptionEnum(string value)
        {
            Type type = typeof(T);
            var names = Enum.GetNames(type);

            foreach (string name in names)
            {
                var field = type.GetField(name);
                var attributes = ((DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).ElementAt(0)).Description;
                if (attributes == value)
                    return (T)field.GetValue(value);
            }
            return default;
        }

        public static T ConvertToEnum(object value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }
    }

    public enum Connection
    {
        [Description("Demo")]
        Demo,
        [Description("Real")]
        Real
    }
}
