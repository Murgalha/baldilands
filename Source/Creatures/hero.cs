public class Hero : Creature {

	protected string _Name;
	protected Equipment _Equip;
	protected Bag _Bag;

	public Hero(int str, int ab, int res, int armr, int firepwr, string name)
	: base(str, ab, res, armr, firepwr) {
		this._Name = name;
		this._Equip = new Equipment();
		this._Bag = new Bag();
	}

	public int Gold {
		get {
			return this._Equip.Gold;
		}
	}

	public Item Weapon {
		get {
			return this._Equip.Weapon;
		}
		set {
			this._Equip.Equip(value);
			this._AttackBuff = this._Equip.AttackBuff;
		}
	}

	public string Name {
		get {
			return this._Name;
		}
	}
}
