using System.Linq;

namespace Baldilands;

public static class DtoExtensions {
    public static HeroDto ToDto(this Hero hero) {
        return new HeroDto {
            DisplayName = $"{hero.Name}, the {hero.Race}",
            Strength = hero.Strength,
            Ability = hero.Ability,
            Resistance = hero.Resistance,
            Armor = hero.Armor,
            Firepower = hero.Firepower,
            HP = hero.HP,
            MP = hero.MP,
            AttackBuff = hero.AttackBuff,
            DefenseBuff = hero.DefenseBuff,
            AttackDebuff = hero.AttackDebuff,
            DefenseDebuff = hero.DefenseDebuff,
            Equipment = hero.Equip.ToDto(),
            Name = hero.Name,
            Race = hero.Race,
            Bag = hero.Bag.ToDto(),
            Exp = hero.Exp,
            Level = hero.Level,
        };
    }

    public static Hero ToHero(this HeroDto dto) {
        Hero hero = new(dto.Strength, dto.Ability, dto.Resistance, dto.Armor, dto.Firepower,
                        dto.Name, dto.Race);

        Bag bag = dto.Bag.ToBag();
        hero.Gold = bag.Gold;
        foreach (Item item in bag.Items) {
            hero.PickItem(item);
        }

        if (dto.Equipment.Head is not null)
            hero.Equip.Equip(dto.Equipment.Head.ToItem());
        if (dto.Equipment.Torso is not null)
            hero.Equip.Equip(dto.Equipment.Torso.ToItem());
        if (dto.Equipment.Leg is not null)
            hero.Equip.Equip(dto.Equipment.Leg.ToItem());
        if (dto.Equipment.Hand is not null)
            hero.Equip.Equip(dto.Equipment.Hand.ToItem());
        if (dto.Equipment.Weapon is not null)
            hero.Equip.Equip(dto.Equipment.Weapon.ToItem());

        return hero;
    }

    public static EnemyDto ToDto(this Enemy enemy) {
        return new EnemyDto {
            Strength = enemy.Strength,
            Ability = enemy.Ability,
            Resistance = enemy.Resistance,
            Armor = enemy.Armor,
            Firepower = enemy.Firepower,
            HP = enemy.HP,
            MP = enemy.MP,
            AttackBuff = enemy.AttackBuff,
            DefenseBuff = enemy.DefenseBuff,
            AttackDebuff = enemy.AttackDebuff,
            DefenseDebuff = enemy.DefenseDebuff,
            Equipment = enemy.Equip.ToDto(),
            Species = enemy.Species,
        };
    }

    public static Enemy ToEnemy(this EnemyDto dto) {
        Enemy enemy =
            new(dto.Strength, dto.Ability, dto.Resistance, dto.Armor, dto.Firepower, dto.Species);

        if (dto.Equipment.Head is not null)
            enemy.Equip.Equip(dto.Equipment.Head.ToItem());
        if (dto.Equipment.Torso is not null)
            enemy.Equip.Equip(dto.Equipment.Torso.ToItem());
        if (dto.Equipment.Leg is not null)
            enemy.Equip.Equip(dto.Equipment.Leg.ToItem());
        if (dto.Equipment.Hand is not null)
            enemy.Equip.Equip(dto.Equipment.Hand.ToItem());
        if (dto.Equipment.Weapon is not null)
            enemy.Equip.Equip(dto.Equipment.Weapon.ToItem());

        return enemy;
    }

    public static EquipmentDto ToDto(this Equipment equipment) {
        return new EquipmentDto {
            Head = equipment.Head?.ToDto() ?? null,     Torso = equipment.Torso?.ToDto() ?? null,
            Leg = equipment.Leg?.ToDto() ?? null,       Hand = equipment.Hand?.ToDto() ?? null,
            Weapon = equipment.Weapon?.ToDto() ?? null,
        };
    }

    public static Equipment ToEquipment(this EquipmentDto dto) {
        var equipment = new Equipment();

        if (dto.Head is not null) {
            equipment.Equip(dto.Head.ToItem());
        }
        if (dto.Torso is not null) {
            equipment.Equip(dto.Torso.ToItem());
        }
        if (dto.Leg is not null) {
            equipment.Equip(dto.Leg.ToItem());
        }
        if (dto.Hand is not null) {
            equipment.Equip(dto.Hand.ToItem());
        }
        if (dto.Weapon is not null) {
            equipment.Equip(dto.Weapon.ToItem());
        }

        return equipment;
    }

    public static BagDto ToDto(this Bag bag) {
        return new BagDto {
            Gold = bag.Gold,
            Items = bag.Items.Select(x => x.ToDto()).ToArray(),
        };
    }

    public static Bag ToBag(this BagDto dto) {
        var bag = new Bag();

        bag.Gold = dto.Gold;
        foreach (ItemDto itemDto in dto.Items) {
            bag.Add(itemDto.ToItem());
        }

        return bag;
    }

    public static ItemDto ToDto(this Item item) {
        return new ItemDto {
            Name = item.Name, Type = item.Type,   Category = item.Category,
            Buff = item.Buff, Value = item.Value,
        };
    }

    public static Item ToItem(this ItemDto dto) {
        return new Item(dto.Name, dto.Type, dto.Category, dto.Buff, dto.Value);
    }
}
