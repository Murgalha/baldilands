namespace Baldilands;

public class Defense {

	private int _Def;
	private bool _Crit;

	public Defense(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			this._Crit = true;
			this._Def = d + (c.Armor*2) + c.Ability + c.AttackBuff + c.AttackDebuff;
		}
		else {
			this._Crit = false;
			this._Def = d + c.Armor + c.Ability + c.AttackBuff + c.AttackDebuff;
		}
	}

	public bool IsCritical() {
		return this._Crit;
	}

	public int Def {
		get {
			return this._Def;
		}
	}
}
