using System.Collections.Generic;

public class Bag {
	
	private List<Item> _Inventory;
	private int _Size;
	private int _Gold;

	public Bag() {
		this._Inventory = new List<Item>();
		this._Size = 0;
		this._Gold = Dice.Roll(6)*100;
	}

	public void Add(Item it) {
		if(it == null)
			return;
		this._Inventory.Add(it);
		this._Size++;
	}

	public void Remove(Item it) {
		if(it == null)
			return;
		this._Inventory.Remove(it);
		this._Size--;
	}

	public List<Item> Inventory {
		get {
			return this._Inventory;
		}
	}

	public int Size {
		get {
			return this._Size;
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