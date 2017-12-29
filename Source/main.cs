using System;

class main {
	
	static void Main() {
		Hero c = new Hero(10, 10, 3, 6, 3, "charlinho");
		Enemy e = new Enemy(1, 1, 100, 1, 1, "bee");
		BattleManager battle = new BattleManager(c, e);

		while(c.HP != 0 && e.HP != 0) {
			Console.WriteLine("Choose your command: ");
			string cmd = Console.ReadLine();
			Console.WriteLine("Your HP: " + c.HP + "\t" + "Enemy HP: " + e.HP);
			if(cmd.Equals("1")) {
				battle.SetTurn("attack", "attack");
			}
			battle.Turn();
			Console.WriteLine(battle.ShowTurnLog());
			if(c.HP == 0 || e.HP == 0) break;
			battle.Turn();
			Console.WriteLine(battle.ShowTurnLog());
		}

		if(c.HP == 0)
			Console.WriteLine("You are dead.\n");
		else
			Console.WriteLine("The enemy is dead.\n");

	}
}