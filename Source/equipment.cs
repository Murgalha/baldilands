public class Equipment {

	private Item _Head;
	private Item _Torso;
	private Item _Leg;
	private Item _Hand;
	private Item _Weapon;
	private int _Gold;
	private int _AttackBuff;
	private int _DefenseBuff;

	public Equipment() {
		this._Gold = Dice.Roll(6)*100;
		this._AttackBuff = 0;
		this._DefenseBuff = 0;
		this._Head = null;
		this._Torso = null;
		this._Leg = null;
		this._Hand = null;
		this._Weapon = null;
	}

	public void Equip(Item it) {
		if(it == null) return;

		if(it.Type.Equals("head")) {
			if(this._Head != null)
				this._DefenseBuff -= this._Head.Buff;
			this._Head = it;
			this._DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("torso")) {
			if(this._Torso != null)
				this._DefenseBuff -= this._Torso.Buff;
			this._Torso = it;
			this._DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("leg")) {
			if(this._Leg != null)
				this._DefenseBuff -= this._Leg.Buff;
			this._Leg = it;
			this._DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("hand")) {
			if(this._Hand != null)
				this._DefenseBuff -= this._Hand.Buff;
			this._Hand = it;
			this._DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("weapon")) {
			if(this._Weapon != null)
				this._AttackBuff -= this._Weapon.Buff;
			this._Weapon = it;
			this._AttackBuff += it.Buff;
		}
	}

	public int Gold {
		get {
			return this._Gold;
		}
	}

	public int AttackBuff {
		get {
			return this._AttackBuff;
		}
	}

	public int DefenseBuff {
		get {
			return this._DefenseBuff;
		}
	}
}