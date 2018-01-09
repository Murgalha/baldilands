using System;

class main {
	
	static void Main() {
		Hero c = new Hero(5, 4, 3, 2, 1, "Murilo", "Human");
		Enemy e = new Enemy(1, 2, 3, 4, 5, "Bee");
		Item it = new Item("Long Sword", "weapon", 2);

		BattleController BC = new BattleController(c, e);

		c.PickItem(it);

		CharSheet.Show(c);

		BC.Battle();

		CharSheet.Show(c);
	}
}