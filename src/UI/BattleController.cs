using System;

public class BattleController {
	private Hero H;
	private Enemy E;
	private BattleManager BM;

	public BattleController(Hero h, Enemy e) {
		H = h;
		E = e;
		BM = new BattleManager((Creature)H, (Creature)E);
	}

	private void PrintBattleLog() {
		int i = 1, k = 0;
		string[] split = BM.CombatLog.Split('\n');
		foreach(var substring in split) {
			if(!string.IsNullOrEmpty(substring)) {
				if(k%2 == 0) {
					Console.WriteLine("\nTurn " + i + ":");
					i++;
				}
				Console.WriteLine("> " + substring);
				k++;
			}
		}
	}

	private string ParseCommand(string? Raw) {
		string Input = string.Empty;
		Raw = Raw?.ToLower() ?? string.Empty;

		if(Raw.Equals("1") || Raw.Equals("attack"))
			Input = "attack";
		else if(Raw.Equals("2") || Raw.Equals("ranged attack"))
			Input = "ranged attack";
		else if(Raw.Equals("3") || Raw.Equals("dodge"))
			Input = "dodge";
		else if(Raw.Equals("4") || Raw.Equals("run"))
			Input = "run";
		return Input;
	}

	private string ParseLogInput(string? Raw) {
		Raw = Raw?.ToLower() ?? string.Empty;

		if(Raw.Equals("1") || Raw.Equals("yes") || Raw.Equals("y"))
			return "yes";
		else if(Raw.Equals("2") || Raw.Equals("no") || Raw.Equals("n"))
			return "no";
		else
			return "";
	}

	private void PrintStats() {
		string str = "\n" + "You\t\t" + E.Species + "\n";
		str += "HP: " + H.HP + "\t\tHP: " + E.HP + "\n";
		str += "MP: " + H.MP + "\n";
		/* Enemy MP using skill */

		Console.WriteLine(str);
	}

	private bool IsVowel(char c) {
		return ("aeiouAEIOU".IndexOf(c) >= 0);
	}

	public void Battle() {
		string? Input = null;
		Reward Rwrd;

		Console.Clear();
		Console.WriteLine("You are now battling a{0} {1}", (IsVowel(E.Species[0]) ? "n" : ""), E.Species);
		while(!BM.HasEnded()) {
			Input = null;
			while(Input == null) {
				PrintStats();
				Console.WriteLine("Choose Your Command:");
				Console.WriteLine("1. Attack");
				Console.WriteLine("2. Ranged Attack");
				Console.WriteLine("3. Dodge");
				Console.WriteLine("4. Run");

				Input = Console.ReadLine();
				Input = ParseCommand(Input);
				Console.Clear();
				if(Input == null)
					Console.WriteLine("Invalid command");
			}
			BM.SetTurn(Input, "attack");
			BM.Turn();
			Console.Write(BM.TurnLog);

			if(BM.HasEnded())
				break;
		}

		if(H.HP == 0) {
			int Lost = BM.LostExp();
			Console.WriteLine("You lost the battle, but you managed to escape the enemy");
			Console.WriteLine("You lost {0} experience point{1}", Lost,
							  (Lost > 1 ? "s" : ""));
			H.Exp = Math.Max(H.Exp-Lost, 0);
			H.Damage = -1;
		}

		else if (E.HP == 0) {
			Rwrd = BM.GetReward();
			Console.WriteLine("You have slain the enemy! You won " + Rwrd.Exp + " experience point" + (Rwrd.Exp > 1 ? "s" : "") + " and " + Rwrd.Gold + " gold coin" + (Rwrd.Gold > 1 ? "s" : ""));
			if(Rwrd.Item != null)
				Console.WriteLine("You got " + Rwrd.Item.Name);
			H.ReceiveReward(Rwrd);
		}

		Input = null;
		while(true) {
			Console.WriteLine("\nDo you want to see the full battle log?");
			Console.WriteLine("1. Yes");
			Console.WriteLine("2. No");

			Input = Console.ReadLine();
			Input = ParseLogInput(Input);

			if(Input.Equals("yes")) {
				Console.Clear();
				PrintBattleLog();
				Console.Write("\nType ENTER to return...");
				Console.ReadLine();
				return;
			}

			else if(Input.Equals("no"))
				return;
			else if(Input.Equals("")) {
				Console.Clear();
				Console.WriteLine("Invalid answer\n");
			}
		}

	}

}
