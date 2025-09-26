namespace Baldilands;

public class RangedAttack
{
    public int Points { get; }
    public bool IsCritical { get; }

    public static RangedAttack Empty = new RangedAttack();

    private RangedAttack()
    {
        Points = 0;
        IsCritical = false;
    }

    public RangedAttack(ICreature c)
    {
        int d = Dice.Roll(6);

        Points = d + c.Ability + c.AttackBuff - c.AttackDebuff;
        if (d == 6)
        {
            IsCritical = true;
            Points += (c.Firepower * 2);
        }
        else
        {
            IsCritical = false;
            Points += c.Firepower;
        }
    }
}
