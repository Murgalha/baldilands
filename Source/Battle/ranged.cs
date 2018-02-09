public class RangedAttack {
	
	private int _Dmg;
	private bool _Crit;

	public RangedAttack() {
		this._Dmg = 0;
		this._Crit = false;
	}

	public RangedAttack(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			this._Crit = true;
			this._Dmg = d + (c.Firepower*2) + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
		else {
			this._Crit = false;
			this._Dmg = d + c.Firepower + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
	}

	public bool IsCritical() {
		return this._Crit;
	}

	public int Dmg {
		get {
			return this._Dmg;
		}
	}
}