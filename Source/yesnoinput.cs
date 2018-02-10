public static class YesNoInput {
	
	public static string Parse(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("yes"))
			return "yes";
		else if(Raw.Equals("2") || Raw.Equals("no"))
			return "no";
		else
			return "";
	}
}