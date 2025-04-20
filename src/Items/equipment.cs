namespace Baldilands;

public class Equipment {

	private Item _Head;
	private Item _Torso;
	private Item _Leg;
	private Item _Hand;
	private Item _Weapon;
	private int _AttackBuff;
	private int _DefenseBuff;

	public Equipment() {
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

		else if(it.Type.Equals("melee") || it.Type.Equals("ranged")) {
			if(this._Weapon != null)
				this._AttackBuff -= this._Weapon.Buff;
			this._Weapon = it;
			this._AttackBuff += it.Buff;
		}
	}

	public Item Remove(string part) {
		Item aux = null;
		if(part.Equals("head") && this._Head != null) {
			aux = this._Head;
			this._DefenseBuff -= this._Head.Buff;
			this._Head = null;
		}

		else if(part.Equals("torso") && this._Torso != null) {
			aux = this._Torso;
			this._DefenseBuff -= this._Torso.Buff;
			this._Torso = null;
		}

		else if(part.Equals("leg") && this._Leg != null) {
			aux = this._Leg;
			this._DefenseBuff -= this._Leg.Buff;
			this._Leg = null;
		}

		else if(part.Equals("hand") && this._Hand != null) {
			aux = this._Hand;
			this._DefenseBuff -= this._Hand.Buff;
			this._Hand = null;
		}

		else if(part.Equals("weapon") && this._Weapon != null) {
			aux = this._Weapon;
			this._AttackBuff -= this._Weapon.Buff;
			this._Weapon = null;
		}
		return aux;
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

	public Item Weapon {
		get {
			return this._Weapon;
		}
	}

	public Item Head {
		get {
			return this._Head;
		}
	}

	public Item Torso {
		get {
			return this._Torso;
		}
	}

	public Item Hand {
		get {
			return this._Hand;
		}
	}

	public Item Leg {
		get {
			return this._Leg;
		}
	}
}
