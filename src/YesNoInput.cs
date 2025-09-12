namespace Baldilands;

public static class YesNoInput {
	/// <summary>
	/// Parse input into "yes" or "no"
	/// </summary>
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
