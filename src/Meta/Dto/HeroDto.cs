using System;

namespace Baldilands;

[Serializable]
public class HeroDto {
    public int Strength;
    public int Ability;
    public int Resistance;
    public int Armor;
    public int Firepower;
    public int HP;
    public int MP;
    public int AttackBuff;
    public int DefenseBuff;
    public int AttackDebuff;
    public int DefenseDebuff;
    public EquipmentDto Equipment;
    public string Name;
    public string Race;
    public BagDto Bag;
    public int Exp;
    public int Level;
}
