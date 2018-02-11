using System;

public static class CharacterCreator {

	private class Race {
		public int StrengthBonus;
		public int FirepowerBonus;
		public int ResistanceBonus;
		public int ArmorBonus;
		public int AbilityBonus;
		public string race;
	
		public Race(string race) {
			this.StrengthBonus = 0;
			this.FirepowerBonus = 0;
			this.ResistanceBonus = 0;
			this.ArmorBonus = 0;
			this.AbilityBonus = 0;
			this.race = race;

			if(race.Equals("dark elf"))
				this.AbilityBonus = 1;
			else if(race.Equals("dwarf"))
				this.ResistanceBonus = 1;
			else if(race.Equals("elf"))
				this.FirepowerBonus = 1;
			else if(race.Equals("orc"))
				this.StrengthBonus = 1;
			else if(race.Equals("undead"))
				this.ResistanceBonus = -1;
		}
	}

	public class Stats {
		public int Strength;
		public int Firepower;
		public int Resistance;
		public int Armor;
		public int Ability;

		public Stats(int s, int f, int r, int a, int ab) {
			this.Strength = s;
			this.Firepower = f;
			this.Resistance = r;
			this.Armor = a;
			this.Ability = ab;
		}
	}

	private static string ParseRace(string Raw) {
		string Input;

		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("dark elf"))
			Input = "dark elf";
		else if(Raw.Equals("2") || Raw.Equals("dwarf"))
			Input = "dwarf";
		else if(Raw.Equals("3") || Raw.Equals("elf"))
			Input = "elf";
		else if(Raw.Equals("4") || Raw.Equals("human"))
			Input = "human";
		else if(Raw.Equals("5") || Raw.Equals("orc"))
			Input = "orc";
		else if(Raw.Equals("6") || Raw.Equals("undead"))
			Input = "undead";
		else
			Input = "";
		return Input;
	}

	private static string ChooseName() {
		string Name;

		while(true) {
			Console.WriteLine("What is your name? (Maximum of 32 letters)");
			Name = Console.ReadLine();

			if(!Name.Equals("")) {
				if(Name.Length > 32)
					return Name.Substring(0, 32);
				else
					return Name;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid name. Do not leave name empty\n");
			}
		}
	}

	private static Race ChooseRace() {
		string Race;

		while(true) {
			Console.WriteLine("What is your race?");
			Console.WriteLine("1. Dark Elf");
			Console.WriteLine("2. Dwarf");
			Console.WriteLine("3. Elf");
			Console.WriteLine("4. Human");
			Console.WriteLine("5. Orc");
			Console.WriteLine("6. Undead");

			Race = Console.ReadLine();
			Race = ParseRace(Race);

			if(Race.Equals("")) {
				Console.Clear();
				Console.WriteLine("Invalid race\n");
			}
			else {
				Race R = new Race(Race);
				return R;
			}
		}
	}

	private static bool IsNum(string Num) {
		for(int i = 0; i < Num.Length; i++) {
			if(Num[i] == '0' || Num[i] == '1' || Num[i] == '2' || Num[i] == '3' || Num[i] == '4' || Num[i] == '5' || Num[i] == '6' || Num[i] == '7' || Num[i] == '8' || Num[i] == '9')
				continue;
			else
				return false;
		}
		return true;
	}

	private static void PrintState(string State, string Top, int Points) {
		Console.WriteLine("{0}\n(Remaining Points: {1})\n", Top, Points);
		Console.Write("{0}\n", State);
	}

	public static Stats ChooseStats() {
		int MaxPoints = 7;
		int RemainingPoints = MaxPoints;
		int Step = 0;
		string State = "", CurTop;
		string Num, Ans;
		int Strength = 0, Ability = 0, Resistance = 0, Armor = 0, Firepower = 0;

		Console.Clear();

		CurTop = "It is now time for you to determine the numbers of your characteristics.\nYou have a total of 7 points to spend on 5 different characteristics.\n\n";
		CurTop += Descriptor.Strength;

		while(true) {
			Console.Clear();
			CharacterCreator.PrintState(State, CurTop, RemainingPoints);
			if(Step == 0) {
				Console.Write("Strength: ");
				Num = Console.ReadLine();
				if(Num.Equals("") || !CharacterCreator.IsNum(Num) || Int32.Parse(Num) > RemainingPoints) {
					Console.Clear();
					CurTop = "Invalid value";
				}
				else {
					int Value = Int32.Parse(Num);
					Step++;
					State += "Strength: " + Num + "\n";
					Strength = Value;
					RemainingPoints -= Value;
					CurTop = Descriptor.Ability;
				}
			}
			else if(Step == 1) {
				Console.Write("Ability: ");
				Num = Console.ReadLine();
				if(Num.Equals("") || !CharacterCreator.IsNum(Num) || Int32.Parse(Num) > RemainingPoints) {
					Console.Clear();
					CurTop = "Invalid value";
				}
				else {
					int Value = Int32.Parse(Num);
					Step++;
					State += "Ability: " + Num + "\n";
					Ability = Value;
					RemainingPoints -= Value;
					CurTop = Descriptor.Resistance;
				}
			}
			else if(Step == 2) {
				Console.Write("Resistance: ");
				Num = Console.ReadLine();
				if(Num.Equals("") || !CharacterCreator.IsNum(Num) || Int32.Parse(Num) > RemainingPoints) {
					Console.Clear();
					CurTop = "Invalid value";
				}
				else {
					int Value = Int32.Parse(Num);
					Step++;
					State += "Resistance: " + Num + "\n";
					Resistance = Value;
					RemainingPoints -= Value;
					CurTop = Descriptor.Armor;
				}
			}
			else if(Step == 3) {
				Console.Write("Armor: ");
				Num = Console.ReadLine();
				if(Num.Equals("") || !CharacterCreator.IsNum(Num) || Int32.Parse(Num) > RemainingPoints) {
					Console.Clear();
					CurTop = "Invalid value";
				}
				else {
					int Value = Int32.Parse(Num);
					Step++;
					State += "Armor: " + Num + "\n";
					Armor = Value;
					RemainingPoints -= Value;
					CurTop = Descriptor.Firepower;
				}
			}
			else if(Step == 4) {
				Console.Write("Firepower: ");
				Num = Console.ReadLine();
				if(Num.Equals("") || !CharacterCreator.IsNum(Num) || Int32.Parse(Num) > RemainingPoints) {
					Console.Clear();
					CurTop = "Invalid value";
				}
				else {
					int Value = Int32.Parse(Num);
					Step++;
					State += "Firepower: " + Num + "\n";
					Firepower = Value;
					RemainingPoints -= Value;
				}
			}
			else if(Step == 5) {
				if(RemainingPoints > 0) {
					Console.WriteLine("\nYou still have {0} unspent point{1}", RemainingPoints, (RemainingPoints > 1 ? "s" : ""));
					while(true) {
						Console.WriteLine("Do you wish to reset your points?");
						Console.WriteLine("1. Yes");
						Console.WriteLine("2. No");

						Ans = Console.ReadLine();
						Ans = YesNoInput.Parse(Ans);
						if(Ans.Equals("yes")) {
							RemainingPoints = MaxPoints;
							Step = 0;
							State = "";
							break;
						}
						else if(Ans.Equals("no"))
							return new Stats(Strength, Firepower, Resistance, Armor, Ability);
						else
							Console.WriteLine("Invalid command\n");
					}
				}
				else
					return new Stats(Strength, Firepower, Resistance, Armor, Ability);

			}
		}
	}

	private static bool ConfirmData(string Name, Race race, Stats stats) {
		string Ans;
		while(true) {
			Console.WriteLine("Name: {0}", Name);
			Console.WriteLine("Race: {0}",StringModify.FirstToUpper(race.race));
			Console.WriteLine("Strength: {0}", stats.Strength);
			Console.WriteLine("Ability: {0}", stats.Ability);
			Console.WriteLine("Resistance: {0}", stats.Resistance);
			Console.WriteLine("Armor: {0}", stats.Armor);
			Console.WriteLine("Firepower: {0}\n", stats.Firepower);
			Console.WriteLine("Done?");
			Console.WriteLine("1. Yes");
			Console.WriteLine("2. No");

			Ans = Console.ReadLine();
			Ans = YesNoInput.Parse(Ans);
			if(Ans.Equals("yes"))
				return true;
			else if(Ans.Equals("no"))
				return false;
			else {
				Console.Clear();
				Console.WriteLine("Invalid command\n");
			}
		}
	}

	private static string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("name"))
			return "name";
		else if(Raw.Equals("2") || Raw.Equals("race"))
			return "race";
		else if(Raw.Equals("3") || Raw.Equals("characteristics"))
			return "characteristics";
		else if(Raw.Equals("4") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	public static Hero Create() {
		Console.Clear();
		string Name = CharacterCreator.ChooseName();
		Console.Clear();
		Race Race = CharacterCreator.ChooseRace();
		Console.Clear();
		Stats Stats = ChooseStats();

		string Input;

		while(true) {
			Console.Clear();
			if(CharacterCreator.ConfirmData(Name, Race, Stats))
				break;
			else {
				Console.Clear();
				Console.WriteLine("What do you want to change?");
				Console.WriteLine("1. Name");
				Console.WriteLine("2. Race");
				Console.WriteLine("3. Characteristics");
				Console.WriteLine("4. Return");

				Input = Console.ReadLine();
				Input = CharacterCreator.ParseCommand(Input);
			
				if(Input.Equals("name"))
					Name = CharacterCreator.ChooseName();
				else if(Input.Equals("race"))
					Race = CharacterCreator.ChooseRace();
				else if(Input.Equals("characteristics"))
					Stats = CharacterCreator.ChooseStats();
				else if(Input.Equals("return"))
					continue;
				else {
					Console.Clear();
					Console.WriteLine("Invalid command\n");
				}
			}
		}
		int Strength = Stats.Strength + Race.StrengthBonus;
		int Ability = Stats.Ability + Race.AbilityBonus;
		int Resistance = Stats.Resistance + Race.ResistanceBonus;
		int Armor = Stats.Armor + Race.ArmorBonus;
		int Firepower = Stats.Firepower + Race.FirepowerBonus;
		return new Hero(Strength, Ability, Resistance, Armor, Firepower, Name, Race.race);
	}
}