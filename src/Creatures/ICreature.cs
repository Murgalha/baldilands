namespace Baldilands;

public interface ICreature
{
    public int Strength { get; set; }
    public int Ability { get; set; }
    public int Resistance { get; set; }
    public int Armor { get; set; }
    public int Firepower { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int AttackBuff { get; set; }
    public int DefenseBuff { get; set; }
    public int AttackDebuff { get; set; }
    public int DefenseDebuff { get; set; }
    public Equipment Equip { get; set; }

    public int TakeDamage(int dmg);
    public MeleeAttack GetMeleeAttack();
    public RangedAttack GetRangedAttack();
    public Defense GetDefense();
    public Item? GetWeapon();
}
