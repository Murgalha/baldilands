using System;

public static class StringExtensions {
	/// <summary>
	/// Returns given string with first char on upper case
	/// </summary>
	public static string Capitalize(this string str) {
		return (Char.ToUpper(str[0]) + str.Substring(1));
	}
}
