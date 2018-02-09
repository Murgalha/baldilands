public class Hero : Creature {

	protected string _Name;
	protected string _Race;
	protected Bag _Bag;
	protected int _Exp;

	public Hero(int str, int ab, int res, int armr, int firepwr, string name, string race)
	: base(str, ab, res, armr, firepwr) {
		this._Name = name;
		this._Race = race;
		this._Bag = new Bag();
		this._Exp = 0;
	}

	public void ReceiveReward(Reward R) {
		this._Bag.Add(R.Item);
		this._Bag.Gold += R.Gold;
		this._Exp += R.Exp;
	}

	public void PickItem(Item it) {
		this._Bag.Add(it);	
	}

	public void DropItem(Item it) {
		this._Bag.Remove(it);
	}

	public void EquipFromBag(string name) {
		Item New = this._Bag.Inventory.Find(x => x.Name.Equals(name));
		Item Old;
		string Type = (New.Type.Equals("melee") || New.Type.Equals("ranged") ? "weapon" : New.Type);
		Old = this._Equip.Remove(Type);
		this._Bag.Remove(New);
		this._Equip.Equip(New);
		if(Old != null)
			this._Bag.Add(Old);
	}

	public void RemoveEquip(string part) {
		Item it = this._Equip.Remove(part);
		this._Bag.Add(it);
	}

	public string Name {
		get {
			return this._Name;
		}
	}

	public string Race {
		get {
			return this._Race;
		}
	}

	public int Gold {
		get {
			return this._Bag.Gold;
		}
		set {
			this._Bag.Gold = value;
		}
	}

	public Bag Bag {
		get {
			return this._Bag;
		}
	}

	public int Exp {
		get {
			return this._Exp;
		}
		set {
			this._Exp = value;
		}
	}
}
