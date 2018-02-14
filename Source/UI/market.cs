using System;

public class Market {

	private Hero H;

	public Market(Hero h) {
		this.H = h;
	}

	public void Sell() {
		string Input;

		while(true) {
			Console.WriteLine("Which item do you want to sell?");
			foreach(var It in this.H.Bag.Inventory) {
				Console.WriteLine("> {0} ({1}) - Selling price: {2}", StringModify.FirstToUpper(It.Name), StringModify.FirstToUpper(It.Type), It.Value/2);
			}
			Console.ReadLine();
			return;
		}
	}

	private string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("buy"))
			return "buy";
		else if(Raw.Equals("2") || Raw.Equals("sell"))
			return "sell";
		else if(Raw.Equals("3") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	public void Shop() {
		string Input;
		
		while(true) {
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Buy");
			Console.WriteLine("2. Sell");
			Console.WriteLine("3. Return");

			Input = Console.ReadLine();
			Input = ParseCommand(Input);

			if(Input.Equals("buy")) {
				// this.Buy();
			}
			else if(Input.Equals("sell")) {
				this.Sell();
			}
			else if(Input.Equals("return")) {
				return;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid command\n");
			}
		}

	}
}