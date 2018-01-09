using System.Collections.Generic;

public class Bag {
	
	private List<Item> _Inventory;
	private int _ItemsNumber;
	private int _Gold;

	public Bag() {
		this._Inventory = new List<Item>();
		this._ItemsNumber = 0;
		this._Gold = Dice.Roll(6)*100;
	}

	public void Add(Item it) {
		if(it == null)
			return;
		this._Inventory.Add(it);
		this._ItemsNumber++;
	}

	public List<Item> Inventory {
		get {
			return this._Inventory;
		}
	}

	public int ItemsNumber {
		get {
			return this._ItemsNumber;
		}
	}

	public int Gold {
		get {
			return this._Gold;
		}
		set {
			this._Gold += value;
		}
	}
}