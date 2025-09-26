namespace Baldilands;

public class Defense
{
    public int Points { get; }
    public bool IsCritical { get; }

    public Defense(ICreature c)
    {
        int d = Dice.Roll(6);

        Points = d + c.Ability + c.AttackBuff + c.AttackDebuff;
        if (d == 6)
        {
            IsCritical = true;
            Points += c.Armor * 2;
        }
        else
        {
            IsCritical = false;
            Points += c.Armor;
        }
    }
}
