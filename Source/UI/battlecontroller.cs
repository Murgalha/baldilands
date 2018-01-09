using System;
using System.Text.RegularExpressions;

public class BattleController {

	private Hero H;
	private Enemy E;
	private BattleManager BM;

	public BattleController(Hero h, Enemy e) {
		this.H = h;
		this.E = e;
		this.BM = new BattleManager((Creature)this.H, (Creature)this.E);
	}

	private void PrintBattleLog() {
		string[] split = BM.ShowFullLog().Split('\n');
		Console.WriteLine();
		foreach(var substring in split)
			if(!string.IsNullOrEmpty(substring))
				Console.WriteLine("> " + substring);
	}

	private string ParseCommand(string Raw) {
		string Input = null;
		Raw = Raw.ToLower();

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

	private string ParseLogInput(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("yes") || Raw.Equals("y"))
			return "yes";
		else if(Raw.Equals("2") || Raw.Equals("no") || Raw.Equals("n"))
			return "no";
		else
			return null;
	}

	private void PrintStats() {
		string str = "\n" + this.H.Name + "\t\t" + this.E.Species + "\n";
		str += "HP: " + this.H.HP + "\t\tHP: " + this.E.HP + "\n";
		str += "MP: " + this.H.MP + "\n";
		/* Enemy MP using skill */

		Console.WriteLine(str);
	}

	public void Battle() {
		bool RunSuccess = false;
		string Input = null;
		Reward Rwrd;
		
		while(!BM.HasEnded()) {
			RunSuccess = BM.CheckRun();
			if(RunSuccess) {
				BM.SaveRunLog(RunSuccess);
				break;
			}
			else if(BM.TriedRun()) {
				BM.SaveRunLog(RunSuccess);
				Console.Write(BM.ShowTurnLog());
			}
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
			if(BM.HasEnded()) break;
			BM.SetTurn(Input, "attack");
			BM.Turn();
			Console.Write(BM.ShowTurnLog());
			if(BM.HasEnded())
				break;
			BM.Turn();
			Console.Write(BM.ShowTurnLog());
		}

		if(this.H.HP == 0) {
			Console.WriteLine("You lost the battle, but you managed to escape the enemy");
		}

		else if (this.E.HP == 0) {
			Rwrd = BM.GetReward();
			Console.WriteLine("You have slain the enemy! You won " + Rwrd.Exp + " experience points and " + Rwrd.Gold + " gold coins");
			if(Rwrd.Item != null)
				Console.WriteLine("You got " + Rwrd.Item.Name);
			this.H.ReceiveReward(Rwrd);
		}

		else if(RunSuccess) {
			Console.WriteLine("You ran away!");
		}

		Input = null;
		while(Input == null) {
			Console.WriteLine("\nDo you want to see the full battle log?");
			Console.WriteLine("1. Yes");
			Console.WriteLine("2. No");

			Input = Console.ReadLine();
			Input = ParseLogInput(Input);
		}

		if(Input.Equals("yes"))
			PrintBattleLog();
	
	}

}