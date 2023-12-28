using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Reflection;

namespace Sureze.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        try
        {
            return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .FirstOrDefault()?
                        .GetCustomAttribute<DisplayAttribute>()?
                        .GetName();
        }
        catch(Exception)
        {
            return "";
        }
    }
}