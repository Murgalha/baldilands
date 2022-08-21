using System;

public static class StringModify {
	/* returns given string with first char on upper case */
	public static string FirstToUpper(string? str) {
		if(str == null)
			return string.Empty;
		return (Char.ToUpper(str[0]) + str.Substring(1));
	}
}
