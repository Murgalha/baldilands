namespace Baldilands;

public class FileCreator
{
    public static void EnsureMonsterFilesExist()
    {
        Enemy[] enemies =
        [
            new(1, 3, 0, 0, 0, "Giant Bee"),
            new(2, 3, 4, 1, 0, "Abomination"),
            new(1, 1, 3, 1, 1, "Rattling Sniffer"),
            new(2, 2, 2, 3, 0, "Gryph Bee"),
            new(1, 2, 1, 0, 0, "Atrocious Vulture"),
            new(3, 3, 3, 3, 0, "Giant Eagle"),
            new(4, 1, 6, 1, 0, "Amoeba"),
            new(2, 1, 2, 2, 3, "Ankheg"),
            new(3, 2, 2, 1, 0, "Apparition"),
            new(1, 3, 1, 0, 1, "Giant Spider"),
            new(4, 1, 2, 2, 0, "Walking Bush"),
            new(0, 3, 1, 0, 5, "Archon"),
            new(3, 4, 3, 4, 4, "Banshee"),
            new(0, 3, 2, 1, 1, "Basilisk"),
            new(3, 3, 5, 5, 6, "Beholder"),
            new(4, 1, 18, 2, 0, "Voracious Beetle"),
            new(3, 0, 3, 3, 0, "Witch"),
            new(2, 1, 2, 1, 0, "War Horse"),
            new(2, 2, 2, 2, 4, "Infernal Hound"),
            new(4, 3, 3, 1, 1, "Centaur"),
            new(3, 3, 2, 1, 0, "Giant Centipede"),
            new(1, 0, 5, 0, 0, "Jelly Cube"),
            new(4, 4, 4, 5, 9, "Dark Dragon"),
            new(1, 4, 3, 1, 1, "Earth Elemental"),
            new(3, 2, 3, 3, 0, "Smasher"),
            new(1, 0, 0, 2, 0, "Skeleton"),
            new(7, 3, 12, 5, 0, "Ent"),
            new(2, 2, 3, 2, 0, "Giant Scorpion"),
            new(1, 1, 2, 2, 4, "Ghost"),
            new(5, 6, 7, 6, 8, "Phoenix"),
            new(0, 4, 0, 0, 0, "Wisp"),
            new(1, 3, 2, 1, 1, "Giant Grasshopper"),
            new(3, 5, 4, 4, 0, "Gargoyle"),
            new(20, 4, 9, 7, 18, "Cyclope"),
            new(0, 1, 1, 0, 1, "Goblin Soldier"),
            new(0, 1, 0, 0, 0, "Carnivorous Grass"),
            new(3, 3, 2, 0, 0, "Lion"),
            new(2, 3, 2, 0, 0, "Tiger"),
            new(2, 7, 3, 1, 0, "Gryph"),
            new(2, 5, 3, 1, 3, "Harpy"),
            new(4, 3, 10, 4, 10, "Hydra"),
            new(0, 1, 0, 1, 0, "Kobold Guard"),
            new(7, 5, 10, 6, 0, "Kraken"),
            new(3, 5, 5, 6, 5, "Lich"),
            new(1, 2, 1, 0, 0, "Wolf"),
            new(1, 2, 3, 0, 6, "Medusa"),
            new(4, 1, 3, 4, 0, "Mummy"),
            new(0, 0, 0, 0, 0, "Slark"),
            new(8, 5, 8, 10, 0, "Tarrasque"),
            new(2, 1, 2, 1, 0, "Badger"),
            new(0, 0, 0, 0, 0, "Tentacute"),
            new(3, 2, 3, 1, 0, "White Bear"),
            new(5, 5, 4, 4, 3, "Wyvern"),
            new(10, 1, 30, 4, 0, "Cave Worm"),
            new(1, 2, 2, 2, 0, "Carrion Worm"),
        ];

        foreach (Enemy enemy in enemies)
        {
            Bestiary.CreateFile(enemy);
        }
    }

    public static void EnsureItemFilesExist()
    {
        Item[] items =
        [
            new("wood sword", "melee", "weapon", 0, 50),
            new("rusty iron dagger", "melee", "weapon", 1, 125),
            new("iron dagger", "melee", "weapon", 3, 210),
            new("steel dagger", "melee", "weapon", 4, 270),
            new("iron longsword", "melee", "weapon", 6, 300),
            new("silver longsword", "melee", "weapon", 7, 500),
            new("claymore", "melee", "weapon", 8, 750),
            new("zweihander", "melee", "weapon", 10, 1000),
            new("iron war axe", "melee", "weapon", 5, 450),
            new("dwarven war axe", "melee", "weapon", 8, 1250),
            new("club", "melee", "weapon", 3, 200),
            new("steel mace", "melee", "weapon", 7, 625),
            new("steel warhammer", "melee", "weapon", 8, 1300),
            new("bionic sledgehammer", "melee", "weapon", 15, 5000),
            new("wood bow", "ranged", "weapon", 0, 50),
            new("iron bow", "ranged", "weapon", 2, 150),
            new("short bow", "ranged", "weapon", 1, 100),
            new("long bow", "ranged", "weapon", 3, 250),
            new("elven bow", "ranged", "weapon", 10, 2000),
            new("steel bow", "ranged", "weapon", 6, 650),
            new("black bow", "ranged", "weapon", 8, 975),
            new("heavy crossbow", "ranged", "weapon", 7, 700),
            new("wood helmet", "head", "armor", 0, 100),
            new("leather helmet", "head", "armor", 2, 150),
            new("fur helmet", "head", "armor", 4, 200),
            new("iron helmet", "head", "armor", 6, 275),
            new("steel helmet", "head", "armor", 7, 500),
            new("chainmail helmet", "head", "armor", 9, 575),
            new("elven helmet", "head", "armor", 10, 800),
            new("orcish helmet", "head", "armor", 11, 1000),
            new("mithril helmet", "head", "armor", 13, 1250),
            new("wood cuirass", "torso", "armor", 0, 150),
            new("leather cuirass", "torso", "armor", 3, 300),
            new("fur cuirass", "torso", "armor", 5, 500),
            new("iron cuirass", "torso", "armor", 6, 700),
            new("steel cuirass", "torso", "armor", 7, 725),
            new("chainmail cuirass", "torso", "armor", 11, 1350),
            new("elven cuirass", "torso", "armor", 12, 1500),
            new("orcish cuirass", "torso", "armor", 14, 1750),
            new("mithril cuirass", "torso", "armor", 15, 2500),
            new("wood greaves", "leg", "armor", 0, 50),
            new("leather greaves", "leg", "armor", 1, 125),
            new("fur greaves", "leg", "armor", 2, 190),
            new("iron greaves", "leg", "armor", 4, 225),
            new("steel greaves", "leg", "armor", 5, 350),
            new("orcish greaves", "leg", "armor", 6, 440),
            new("chainmail greaves", "leg", "armor", 8, 750),
            new("elven greaves", "leg", "armor", 7, 950),
            new("mithril greaves", "leg", "armor", 10, 1200),
            new("wood gauntlets", "hand", "armor", 0, 100),
            new("leather gauntlets", "hand", "armor", 1, 150),
            new("fur gauntlets", "hand", "armor", 1, 175),
            new("iron gauntlets", "hand", "armor", 2, 200),
            new("steel gauntlets", "hand", "armor", 3, 300),
            new("chainmail gauntlets", "hand", "armor", 5, 375),
            new("elven gauntlets", "hand", "armor", 7, 425),
            new("orcish gauntlets", "hand", "armor", 8, 450),
            new("mithril gauntlets", "hand", "armor", 10, 500),
        ];

        foreach (Item item in items)
        {
            Inventory.CreateFile(item);
        }
    }
}
