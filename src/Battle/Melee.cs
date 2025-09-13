namespace Baldilands;

public class MeleeAttack {
    public int Points { get; }
    public bool IsCritical { get; }

    public static MeleeAttack Empty = new MeleeAttack();

    public MeleeAttack(ICreature c) {
        int d = Dice.Roll(6);

        Points = d + c.Ability + c.AttackBuff - c.AttackDebuff;
        if (d == 6) {
            IsCritical = true;
            Points += (c.Strength * 2);
        } else {
            IsCritical = false;
            Points += c.Strength;
        }

        if (c.Equip.Weapon == null)
            Points /= 2;
    }

    private MeleeAttack() {
        Points = 0;
        IsCritical = false;
    }
}
