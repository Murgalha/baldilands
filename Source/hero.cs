public class Hero : Creature {

	protected string _Name;
	protected Equipment _Equip;

	public Hero(int str, int ab, int res, int armr, int firepwr, string name)
	: base(str, ab, res, armr, firepwr) {
		this._Name = name;
		this._Equip = new Equipment();
	}

	public void Equip(Item it) {
		this._Equip.Equip(it);
		this._AttackBuff = this._Equip.AttackBuff;
		this._DefenseBuff = this._Equip.DefenseBuff;
	}

	public int Gold {
		get {
			return this._Equip.Gold;
		}
	}
}
