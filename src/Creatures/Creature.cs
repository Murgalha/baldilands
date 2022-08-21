public abstract class Creature {
	public int Strength { get; protected set; }
	public int Ability { get; protected set; }
	public int Resistance { get; protected set; }
	public int Armor { get; protected set; }
	public int Firepower { get; protected set; }
	public int HP { get; protected set; }
	public int MP { get; protected set; }
	public int AttackBuff { get; protected set; }
	public int DefenseBuff { get; protected set; }
	public int AttackDebuff { get; protected set; }
	public int DefenseDebuff { get; protected set; }
	public Equipment Equip { get; protected set; }

	public Creature(int str, int ab, int res, int armr, int firepwr) {
		Strength = str;
		Ability = ab;
		Resistance = res;
		Armor = armr;
		Firepower = firepwr;
		HP = _GetMaxHpOrMp();
		MP = _GetMaxHpOrMp();
		DefenseBuff = 0;
		DefenseDebuff = 0;
		AttackBuff = 0;
		AttackDebuff = 0;
		Equip = new Equipment();
	}

	public int Damage {
		set {
			HP = (HP-value <= 0 ? 0 : HP-value);
		}
	}

	public RangedAttack Ranged {
		get {
			RangedAttack RA;
			if(Weapon != null && Weapon.Type.Equals("ranged"))
				RA = new RangedAttack(this);
			else
				RA = RangedAttack.Empty;
			return RA;
		}
	}

	public MeleeAttack Melee {
		get {
			MeleeAttack MA = new MeleeAttack(this);
			return MA;
		}
	}

	public Defense Defense {
		get {
			Defense D = new Defense(this);
			return D;
		}
	}

	public Item? Weapon {
		get {
			return Equip.Weapon;
		}
	}

	protected int _GetMaxHpOrMp() {
		return (Resistance < 1 ? 1 : Resistance*5);
	}
}
