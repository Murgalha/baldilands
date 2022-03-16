public class MeleeAttack {
	public readonly int Dmg;
	public readonly bool IsCritical;

	public static MeleeAttack Empty => new MeleeAttack(0, false);

	private MeleeAttack(int damage, bool isCritical) {
		Dmg = damage;
		IsCritical = isCritical;
	}

	public MeleeAttack(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			IsCritical = true;
			Dmg = d + (c.Strength*2) + c.Ability + c.AttackBuff - c.AttackDebuff;
		}
		else {
			IsCritical = false;
			Dmg = d + c.Strength + c.Ability + c.AttackBuff - c.AttackDebuff;
		}

		if(c.Equip.Weapon == null)
			Dmg /= 2;
	}
}
