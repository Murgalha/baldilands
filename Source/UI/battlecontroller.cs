using System;
using System.Text.RegularExpressions;

public class BattleController {

	private Hero H;
	private Enemy E;

	public BattleController(Hero h, Enemy e) {
		this.H = h;
		this.E = e;
	}

	private string ParseInput(string Raw) {
		string Input = null;
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("attack"))
			Input = "attack";
		else if(Raw.Equals("2") || Raw.Equals("ranged attack"))
			Input = "ranged attack";
		else if(Raw.Equals("3") || Raw.Equals("run"))
			Input = "run";

		return Input;
	}

	private void PrintStats() {
		string str = this.H.Name + "\t\t" + this.E.Species + "\n";
		str += "HP: " + this.H.HP + "\t\tHP: " + this.E.HP + "\n";
		str += "MP: " + this.H.MP + "\n";
		/* Enemy MP using skill */

		Console.WriteLine(str);
	}

	public void StartBattle() {
		BattleManager BM = new BattleManager((Creature)H, (Creature)E);

		while(!BM.HasEnded()) {
			string Input = null;

			while(Input == null) {

				if(BM.CheckRun()) break;

				PrintStats();
				Console.WriteLine("Choose Your Command:");
				Console.WriteLine("1. Attack");
				Console.WriteLine("2. Ranged Attack");
				Console.WriteLine("3. Run");
				
				Input = Console.ReadLine();
				Input = ParseInput(Input);
			}
			if(BM.HasEnded()) break;
			BM.SetTurn(Input, "attack");
			BM.Turn();
			Console.WriteLine(BM.ShowTurnLog());
			if(BM.HasEnded())
				break;
			BM.Turn();
			Console.WriteLine(BM.ShowTurnLog());
		}

		if(this.H.HP == 0) {
			Console.WriteLine("You lost the battle, but you managed to escape the enemy.");
		}

		else if (this.E.HP == 0) {
			Console.WriteLine("You won! You have slain the enemy.");
		}
	}

}