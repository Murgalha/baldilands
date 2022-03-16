public class Defense {
	public int Def { get; }
	public bool IsCritical { get; }

	public Defense(Creature c) {
		int d = Dice.Roll(6);

		if(d == 6) {
			IsCritical = true;
			Def = d + (c.Armor*2) + c.Ability + c.AttackBuff + c.AttackDebuff;
		}
		else {
			IsCritical = false;
			Def = d + c.Armor + c.Ability + c.AttackBuff + c.AttackDebuff;
		}
	}
}
