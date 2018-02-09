using System;

public static class StringModify {

	public static string FirstToUpper(string str) {
		return (Char.ToUpper(str[0]) + str.Substring(1));
	}
}