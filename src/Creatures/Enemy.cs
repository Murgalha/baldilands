using System;

namespace Baldilands;

public class Enemy : ICreature
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
    public string Species { get; }

    public Enemy(int str, int ab, int res, int armr, int firepwr, string spec)
    {
        Strength = str;
        Ability = ab;
        Resistance = res;
        Armor = armr;
        Firepower = firepwr;
        HP = (Resistance < 1 ? 1 : Resistance * 5);
        MP = (Resistance < 1 ? 1 : Resistance * 5);
        DefenseBuff = 0;
        DefenseDebuff = 0;
        AttackBuff = 0;
        AttackDebuff = 0;
        Equip = new Equipment();
        Species = spec;
    }

    public int TakeDamage(int dmg)
    {
        HP = Math.Max(HP - dmg, 0);
        return HP;
    }

    public Defense GetDefense() => new Defense(this);

    public MeleeAttack GetMeleeAttack() => new MeleeAttack(this);

    public RangedAttack GetRangedAttack()
    {
        var weapon = GetWeapon();
        if (weapon.HasValue && weapon.Value.Type.Equals("ranged"))
            return new RangedAttack(this);
        else
            return RangedAttack.Empty;
    }

    public Item? GetWeapon()
    {
        return Equip.Weapon;
    }
}
