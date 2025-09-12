namespace Baldilands;

public class MeleeAttack {

	private int _Dmg;
	private bool _Crit;

	public MeleeAttack() {
		this._Dmg = 0;
		this._Crit = false;
	}

	public MeleeAttack(ICreature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			this._Crit = true;
			this._Dmg = d + (c.Strength*2) + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
		else {
			this._Crit = false;
			this._Dmg = d + c.Strength + c.Ability + c.AttackBuff - c.AttackDebuff;
		}

		if(c.Equip.Weapon == null)
			this._Dmg /= 2;
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
