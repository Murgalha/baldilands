public class Attack {
	
	private int _Dmg;
	private bool _Crit;

	public Attack(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			this._Crit = true;
			this._Dmg = d + (c.Strength*2) + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
		else {
			this._Crit = false;
			this._Dmg = d + c.Strength + c.Ability + c.AttackBuff - c.AttackDebuff;
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