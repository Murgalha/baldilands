using System.Collections.Generic;

public class Bag {
	public readonly List<Item> Inventory;
	public int Size => Inventory.Count;
	public int Gold { get; set; }

	public Bag() {
		Inventory = new List<Item>();
		Gold = Dice.Roll(6)*100;
	}

	public void Add(Item? it) {
		if(it == null)
			return;
		Inventory.Add(it);
	}

	public void Remove(Item? it) {
		if(it == null)
			return;
		Inventory.Remove(it);
	}
}
