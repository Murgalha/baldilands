using System;
using System.Linq;
using System.Collections.Generic;

public static class InputParser {
	private const bool IgnoreCase = true;

	public static Action Parse(string input, IReadOnlyDictionary<int, Tuple<string, Action>> menuOptions, Action errorAction) {
		if(int.TryParse(input, out var optionNumber)) {
			if(!menuOptions.TryGetValue(optionNumber, out var dictTuple)) {
				return errorAction;
			}
			return dictTuple.Item2;
		}

		var lowerInput = input.ToLower();
		var tuple = menuOptions.Values.ToArray().FirstOrDefault(x => lowerInput.Equals(x.Item1.ToLower()));

		return tuple?.Item2 ?? errorAction;
	}
}
