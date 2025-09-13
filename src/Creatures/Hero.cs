using System;
using System.Linq;

namespace Baldilands;

public class Hero : ICreature {
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
    public string Name { get; }
    public string Race { get; }
    public Bag Bag { get; }
    public int Exp { get; set; }
    public int Level { get; set; }

    public Hero(int str, int ab, int res, int armr, int firepwr, string name, string race) {
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
        Name = name;
        Race = race;
        Bag = new Bag();
        Exp = 0;
        Level = 1;
    }

    public int TakeDamage(int dmg) {
        HP = Math.Max(HP - dmg, 0);
        return HP;
    }

    public Defense GetDefense() => new Defense(this);

    public MeleeAttack GetMeleeAttack() => new MeleeAttack(this);

    public RangedAttack GetRangedAttack() {
        var weapon = GetWeapon();
        if (weapon.HasValue && weapon.Value.Type.Equals("ranged"))
            return new RangedAttack(this);
        else
            return RangedAttack.Empty;
    }

    public Item? GetWeapon() { return Equip.Weapon; }

    public void ReceiveReward(Reward R) {
        if (!R.Item.HasValue)
            Bag.Add(R.Item.Value);
        Bag.Gold += R.Gold;
        Exp += R.Exp;
    }

    public void PickItem(Item it) { Bag.Add(it); }

    public void DropItem(Item it) { Bag.Remove(it); }

    public void EquipFromBag(string name) {
        Item New = Bag.Items.FirstOrDefault(x => x.Name.Equals(name));
        string Type = (New.Type.Equals("melee") || New.Type.Equals("ranged") ? "weapon" : New.Type);
        Item? Old = Equip.Remove(Type);
        Bag.Remove(New);
        Equip.Equip(New);
        if (Old != null)
            Bag.Add(Old.Value);
    }

    public void RemoveEquip(string part) {
        Item? it = Equip.Remove(part);
        if (it is not null)
            Bag.Add(it.Value);
    }

    public void Rest() {
        HP = (Resistance < 1 ? 1 : Resistance * 5);
        MP = (Resistance < 1 ? 1 : Resistance * 5);
    }

    public void LevelUp(string c) {
        if (c.Equals("strength"))
            Strength++;
        else if (c.Equals("ability"))
            Ability++;
        else if (c.Equals("resistance"))
            Resistance++;
        else if (c.Equals("armor"))
            Armor++;
        else if (c.Equals("Firepower"))
            Firepower++;
        else
            return;
        Level++;
        Exp -= 10;
    }

    public int Gold {
        get { return Bag.Gold; }
        set { Bag.Gold = value; }
    }
}
