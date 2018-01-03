using System;

class main {
	
	static void Main() {
		Hero c = new Hero(5, 4, 3, 2, 1, "Murilo");
		Enemy e = new Enemy(1, 2, 3, 4, 5, "Bee");

		BattleController BC = new BattleController(c, e);

		BC.StartBattle();

	}
}