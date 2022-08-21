public class Hero : Creature {

	public readonly string Name;
	public readonly string Race;
	public Bag Bag { get; private set; }
	public int Exp { get; set; }
	public int Level { get; set; }

	public Hero(int str, int ab, int res, int armr, int firepwr, string name, string race)
		: base(str, ab, res, armr, firepwr) {
		Name = name;
		Race = race;
		Bag = new Bag();
		Exp = 0;
		Level = 1;
	}

	public static Hero Empty => new Hero(0, 0, 0, 0, 0, string.Empty, string.Empty);

	public void ReceiveReward(Reward R) {
		Bag.Add(R.Item);
		Bag.Gold += R.Gold;
		Exp += R.Exp;
	}

	public void PickItem(Item it) {
		Bag.Add(it);
	}

	public void DropItem(Item it) {
		Bag.Remove(it);
	}

	public void EquipFromBag(string name) {
		Item New = Bag.Inventory.Find(x => x.Name.Equals(name)) ?? Item.Empty;
		Item Old;
		string Type = (New.Type.Equals("melee") || New.Type.Equals("ranged") ? "weapon" : New.Type);
		Old = Equip.Remove(Type) ?? Item.Empty;
		Bag.Remove(New);
		Equip.Equip(New);
		if(Old != null)
			Bag.Add(Old);
	}

	public void RemoveEquip(string part) {
		Item? it = Equip.Remove(part);
		Bag.Add(it);
	}

	public void Rest() {
		HP = _GetMaxHpOrMp();
		MP = _GetMaxHpOrMp();
	}

	public void LevelUp(string c) {
		if(c.Equals("strength"))
			Strength++;
		else if(c.Equals("ability"))
			Ability++;
		else if(c.Equals("resistance"))
			Resistance++;
		else if(c.Equals("armor"))
			Armor++;
		else if(c.Equals("Firepower"))
			Firepower++;
		else
			return;
		Level++;
		Exp -= 10;
	}

	public int Gold {
		get {
			return Bag.Gold;
		}
		set {
			Bag.Gold = value;
		}
	}
}
