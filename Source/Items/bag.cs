using System.Collections.Generic;

public class Bag {
	
	private List<Item> _Inventory;
	private int _ItemsNumber;

	public Bag() {
		this._Inventory = new List<Item>();
		this._ItemsNumber = 0;
	}

	public void Add(Item it) {
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
}