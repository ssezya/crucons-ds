using System;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Utils.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
        }
    }
}
