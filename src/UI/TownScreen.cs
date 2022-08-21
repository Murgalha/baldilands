using System;
using System.Collections.Generic;

public class TownScreen {
	private bool mShouldExit;
	private SaveManager mSaveManager;
	private Hero mHero;
	private ShopScreen mShopScreen;

	public TownScreen(SaveManager saveManager) {
		mSaveManager = saveManager;
		mShopScreen = new ShopScreen(mSaveManager.Hero);
		mShouldExit = false;
		mHero = mSaveManager.Hero;
	}

	public void Go() {
		mHero = mSaveManager.Hero;

		var menuDict = new Dictionary<int, Tuple<string, Action>> {
			[1] = Tuple.Create<string, Action>("Battle", _ExecuteBattle),
			[2] = Tuple.Create<string, Action>("Shop", _ExecuteShop),
			[3] = Tuple.Create<string, Action>("Manage inventory", _ExecuteInventory),
			[4] = Tuple.Create<string, Action>("Rest", _ExecuteRest),
			[5] = Tuple.Create<string, Action>("Save", _ExecuteSave),
			[6] = Tuple.Create<string, Action>("Exit", _ExecuteExit)
			};

		Console.Clear();
		while(!mShouldExit) {
			Console.WriteLine("Where do you want to go now?");
			foreach(var kvp in menuDict) {
				Console.WriteLine($"{kvp.Key}. {kvp.Value.Item1}");
			}

			string input = Console.ReadLine() ?? string.Empty;
			var menuAction = InputParser.Parse(input, menuDict, _ExecuteInvalid);
			menuAction();
		}
	}

	private void _ExecuteBattle() {
		Console.Clear();
		List<string> Monsters = Initializer.InitMonsters();
		while(true) {
			this.ShowMonsters(Monsters);

			string? Ans = Console.ReadLine();
			Ans = Ans?.ToLower() ?? string.Empty;
			int Index = new int();
			int Value = -1;
			bool Numeric = false;

			if(Ans.Equals("1") || Ans.Equals("random")) {
				int d = Dice.Roll(Monsters.Count)-1;
				string[] tokens = Monsters[d].Split(' ');
				string file = String.Join("", tokens);
				Enemy E = Bestiary.Load(file);
				BattleController BC = new BattleController(mHero, E);
				BC.Battle();
				Console.Clear();
				break;
			}
			else if(Ans.Equals(""))
				break;
			else {
				try {
					Value = Int32.Parse(Ans);
					Numeric = true;
				}
				catch(SystemException) {
					Console.Clear();
					Console.WriteLine("Invalid monster\n");
					Numeric = false;
				}
			}

			if(Numeric)
				if(Value >= 2 && Value <= Monsters.Count+1)
					Index = Value-2;
				else
					Index = Monsters.BinarySearch(Ans);
			else
				Index = Monsters.BinarySearch(Ans);

			if(Index < 0) {
				Console.Clear();
				Console.WriteLine("Invalid monster\n");
			}
			else {
				string[] tokens = Monsters[Index].Split(' ');
				string file = String.Join("", tokens);
				Enemy E = Bestiary.Load(file);
				BattleController BC = new BattleController(mHero, E);
				BC.Battle();
				Console.Clear();
				break;
			}
		}
	}

	private void ShowMonsters(List<string> Monsters) {
		Console.WriteLine("Which monster do you want to battle with? (Type ENTER on empty monster to return)\n");
		Console.WriteLine("1. Random\t\t21. Ghost\t\t41. Phoenix");
		for(int i = 2; i <= 16; i++) {
			Console.WriteLine("{0}. {3}\t{6}{1}. {4}\t{7}{2}. {5}", i, i+20, i+40, StringModify.FirstToUpper(Monsters[i-2]), StringModify.FirstToUpper(Monsters[i+18]), StringModify.FirstToUpper(Monsters[i+38]), Monsters[i-2].Length < 12 ? "\t" : "",
							  Monsters[i+18].Length < 12 ? "\t" : "");
		}
	}


	private void _ExecuteShop() {
		mShopScreen.Go();

	}

	private string ParseShop(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("gold shop") ||
		   Raw.Equals("gold"))
			return "gold";
		else if(Raw.Equals("2") || Raw.Equals("experience shop") ||
				Raw.Equals("experience") || Raw.Equals("exp"))
			return "exp";
		else if(Raw.Equals("3") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	private void _ExecuteInventory() {
		InventoryController.Manage(mHero);
	}

	private void _ExecuteRest() {
		mHero.Rest();
		Console.Clear();
		Console.WriteLine("You are fully replenished\n");
	}

	private void _ExecuteSave() {
		Console.Clear();
		if(mSaveManager.SaveGame(mHero, mSaveManager.CurrentSlot))
			Console.WriteLine("Game saved!\n");
		else
			Console.WriteLine("Error! Could not save game\n");
	}

	private void _ExecuteExit() {
		mShouldExit = true;
	}

	private void _ExecuteInvalid() {
		Console.Clear();
		Console.WriteLine("Invalid command\n");
	}

}
