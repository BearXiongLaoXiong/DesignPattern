using System;
using System.Linq;
using System.Runtime.Serialization;

namespace DesignPattern
{
    public static class Common
    {
        public static string GetClassName(this Type type)
        => $"{type.Name}.{((DataContractAttribute)type.GetCustomAttributes(typeof(DataContractAttribute), false).FirstOrDefault())?.Name}";
    }
}
