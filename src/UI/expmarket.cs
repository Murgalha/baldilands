using System;

public class ExpMarket {

	private Hero H;

	public ExpMarket(Hero H) {
		this.H = H;
	}

	private string ParseCharacteristic(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("strength"))
			return "strength";
		else if(Raw.Equals("2") || Raw.Equals("ability"))
			return "ability";
		else if(Raw.Equals("3") || Raw.Equals("resistance"))
			return "resistance";
		else if(Raw.Equals("4") || Raw.Equals("armor"))
			return "armor";
		else if(Raw.Equals("5") || Raw.Equals("firepower"))
			return "firepower";
		else if(Raw.Equals("6") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	private void BuyCharacteristics() {
		string Charac;

		Console.Clear();
		while(true) {
			Console.WriteLine("Each characteristic point costs 10 experience points");
			Console.WriteLine("Which characteristic do you want to buy?");
			Console.WriteLine("(Current Exp: {0})\n", this.H.Exp);
			Console.WriteLine("1. Strength");
			Console.WriteLine("2. Ability");
			Console.WriteLine("3. Resistance");
			Console.WriteLine("4. Armor");
			Console.WriteLine("5. Firepower");
			Console.WriteLine("6. Return");

			Charac = Console.ReadLine();
			Charac = this.ParseCharacteristic(Charac);

			if(Charac.Equals("return"))
				return;
			else if(Charac.Equals("")) {
				Console.Clear();
				Console.WriteLine("Invalid characteristic\n");
			}
			else {
				if(this.H.Exp < 10) {
					Console.Clear();
					Console.WriteLine("Not enough experience\n");
				}
				else
					this.H.LevelUp(Charac);
			}
		}
	}

	private string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("characteristics") ||
		   Raw.Equals("buy characteristics"))
			return "characteristics";
		else if(Raw.Equals("2") || Raw.Equals("exchange") ||
				Raw.Equals("exchange for gold"))
			return "exchange";
		else if(Raw.Equals("3") || Raw.Equals("spells") ||
				Raw.Equals("buy spells"))
			return "spells";
		else if(Raw.Equals("4") || Raw.Equals("return"))
			return "return";
		else if(Raw.Equals("buy"))
			return "buy";
		else
			return "";
	}

	private void ExchangeExp() {
		string Value;
		int V = new int();

		Console.Clear();
		while(true) {
			Console.WriteLine("Here you can trade 1 experience point for 100 gold coins");
			Console.WriteLine("How many experience points do you want to trade: (Type ENTER on empty number to return)");
			Console.WriteLine("(Current Exp: {0})", this.H.Exp);

			Value = Console.ReadLine();

			if(Value.Equals("")) {
				Console.Clear();
				return;
			}

			try {
				V = Int32.Parse(Value);
			}
			catch(FormatException) {
				Console.Clear();
				Console.WriteLine("Invalid number\n");
				continue;
			}

			if(V > 0 && V <= this.H.Exp) {
				this.H.Gold += V*100;
				this.H.Exp -= V;
				Console.Clear();
				Console.WriteLine("{0} gold acquired. {1} experience lost", V*100, V);
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid number\n");
			}
		}
	}

	public void Shop() {
		string Input;

		Console.Clear();
		while(true) {
			Console.WriteLine("What do you want to do with your experience points?");
			Console.WriteLine("1. Buy Characteristics");
			Console.WriteLine("2. Exchange for gold");
			Console.WriteLine("3. Buy Spells");
			Console.WriteLine("4. Return");

			Input = Console.ReadLine();
			Input = ParseCommand(Input);

			Console.Clear();
			if(Input.Equals("characteristics")) {
				this.BuyCharacteristics();
			}
			else if(Input.Equals("exchange")) {
				this.ExchangeExp();
			}
			else if(Input.Equals("spells")) {
				Console.WriteLine("Coming soon\n");
			}
			else if(Input.Equals("buy")) {
				Console.WriteLine("Yes, it is a shop\n");
			}
			else if(Input.Equals("return")) {
				Console.Clear();
				return;
			}
			else {
				Console.WriteLine("Invalid command\n");
			}
		}

	}
}
