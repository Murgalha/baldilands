public abstract class Creature {

	protected int _Strength;
	protected int _Ability;
	protected int _Resistance;
	protected int _Armor;
	protected int _FirePower;
	protected int _HP;
	protected int _MP;
	protected int _AttackBuff;
	protected int _DefenseBuff;
	protected int _AttackDebuff;
	protected int _DefenseDebuff;

	public Creature(int str, int ab, int res, int armr, int firepwr) {
		this._Strength = str;
		this._Ability = ab;
		this._Resistance = res;
		this._Armor = armr;
		this._FirePower = firepwr;
		this._HP = this._Resistance*5;
		this._MP = this._Resistance*5;
		this._DefenseBuff = 0;
		this._DefenseDebuff = 0;
		this._AttackBuff = 0;
		this._AttackDebuff = 0;
	}

	public int Strength {
		get {
			return this._Strength;
		}
	}

	public int Ability {
		get {
			return this._Ability;
		}
	}
	public int Resistance {
		get {
			return this._Resistance;
		}
	}
	public int Armor {
		get {
			return this._Armor;
		}
	}
	public int FirePower {
		get {
			return this._FirePower;
		}
	}

		public int HP {
		get {
			return this._HP;
		}
	}

	public int MP {
		get {
			return this._MP;
		}
	}

	public int Damage {
		set {
			this._HP -= value;
			if(this._HP <= 0)
				this._HP = 0;
		}
	}

	public int AttackBuff {
		get {
			return this._AttackBuff;
		}
	}

	public int AttackDebuff {
		get {
			return this._AttackDebuff;
		}
	}

	public int DefenseBuff {
		get {
			return this._DefenseBuff;
		}
	}

		public int DefenseDebuff {
		get {
			return this._DefenseDebuff;
		}
	}

	public Attack Attack{
		get {
			Attack A = new Attack(this);
			return A;
		}
	}

	public Defense Defense {
		get {
			Defense D = new Defense(this);
			return D;
		}
	}
}
