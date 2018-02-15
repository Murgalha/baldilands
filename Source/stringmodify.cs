using System;

public static class StringModify {

	public static string FirstToUpper(string str) {
		if(str == null)
			return null;
		return (Char.ToUpper(str[0]) + str.Substring(1));
	}
}