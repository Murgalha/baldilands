public static class YesNoInput {

	/* parse input given needed on a 'yes/no' question */
	public static string Parse(string Raw) {
		/* passing string to lower case */
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("yes"))
			return "yes";
		else if(Raw.Equals("2") || Raw.Equals("no"))
			return "no";
		else
			return "";
	}
}
