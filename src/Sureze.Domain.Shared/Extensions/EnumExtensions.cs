﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Reflection;

namespace Sureze.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()?
                        .GetCustomAttribute<DisplayAttribute>()?
                        .GetName();
    }
}