using System;

public class Market {

	private Hero H;

	public Market(Hero h) {
		this.H = h;
	}

	private Item Find(Hero H, string Name) {
		foreach(var It in H.Bag.Inventory) {
			if(It.Name.Equals(Name)) {
				return It;
			}
		}
		return null;
	}

	public void Sell() {
		string Name;

		while(true) {
			Console.WriteLine("Which item do you want to sell? (Type ENTER on empty item to return)");
			foreach(var It in this.H.Bag.Inventory) {
				Console.WriteLine("> {0} ({1}) - Selling price: {2}", StringModify.FirstToUpper(It.Name), StringModify.FirstToUpper(It.Type), It.Value/2);
			}

			Name = Console.ReadLine();
			Name = Name.ToLower();
			if(Name.Equals("")) {
				Console.Clear();
				return;
			}
			Item Item = this.Find(this.H, Name);
			Console.Clear();
			if(Item == null) {
				Console.WriteLine("Item not found\n");
			}
			else {
				H.DropItem(Item);
				H.Gold += (Item.Value/2);
				Console.WriteLine("{0} sold\n", StringModify.FirstToUpper(Item.Name));
			}		
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
		
		Console.Clear();
		while(true) {
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Buy");
			Console.WriteLine("2. Sell");
			Console.WriteLine("3. Return");

			Input = Console.ReadLine();
			Input = ParseCommand(Input);
			
			Console.Clear();
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
				Console.WriteLine("Invalid command\n");
			}
		}

	}
}