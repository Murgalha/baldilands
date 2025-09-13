using System;

namespace Baldilands;

public static class StringExtensions {
    public static string Capitalize(this string str) {
        if (string.IsNullOrEmpty(str))
            return string.Empty;
        return (Char.ToUpper(str[0]) + str.Substring(1));
    }
}
