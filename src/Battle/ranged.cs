public class RangedAttack {
	public readonly int Dmg;
	public readonly bool IsCritical;

	public static RangedAttack Empty => new RangedAttack(0, false);

	private RangedAttack(int damage, bool isCritical) {
		Dmg = damage;
		IsCritical = isCritical;
	}

	public RangedAttack(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			IsCritical = true;
			Dmg = d + (c.Firepower*2) + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
		else {
			IsCritical = false;
			Dmg = d + c.Firepower + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
	}
}
