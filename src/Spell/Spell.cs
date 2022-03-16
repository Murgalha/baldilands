using System;

public class Spell {
	public readonly int Damage;
	public readonly int Duration;
	public readonly string Description;
	public readonly string School;

	public Spell(int dmg, int dur, string desc, string schl) {
		Damage = dmg;
		Duration = dur;
		Description = desc;
		School = schl;
	}
}
