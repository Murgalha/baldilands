using System.IO;

public static class FileCreator {
	/* Create monsters' files */
	public static void CreateMonsters() {
		var dirInfo = new DirectoryInfo("GameData/Bestiary/");
		if(dirInfo.Exists) {
			return;
		}

		Bestiary.Make("Giant Bee", 1, 3, 0, 0, 0, false);
		Bestiary.Make("Abomination", 2, 3, 4, 1, 0, false);
		Bestiary.Make("Rattling Sniffer", 1, 1, 3, 1, 1, true);
		Bestiary.Make("Gryph Bee", 2, 2, 2, 3, 0, false);
		Bestiary.Make("Atrocious Vulture", 1, 2, 1, 0, 0, false);
		Bestiary.Make("Giant Eagle", 3, 3, 3, 3, 0, false);
		Bestiary.Make("Amoeba", 4, 1, 6, 1, 0, false);
		Bestiary.Make("Ankheg", 2, 1, 2, 2, 3, true);
		Bestiary.Make("Apparition", 3, 2, 2, 1, 0, false);
		Bestiary.Make("Giant Spider", 1, 3, 1, 0, 1, true);
		Bestiary.Make("Walking Bush", 4, 1, 2, 2, 0, false);
		Bestiary.Make("Archon", 0, 3, 1, 0, 5, true);
		Bestiary.Make("Banshee", 3, 4, 3, 4, 4, true);
		Bestiary.Make("Basilisk", 0, 3, 2, 1, 1, true);
		Bestiary.Make("Beholder", 3, 3, 5, 5, 6, true);
		Bestiary.Make("Voracious Beetle", 4, 1, 18, 2, 0, false);
		Bestiary.Make("Witch", 3, 0, 3, 3, 0, false);
		Bestiary.Make("War Horse", 2, 1, 2, 1, 0, false);
		Bestiary.Make("Infernal Hound", 2, 2, 2, 2, 4, true);
		Bestiary.Make("Centaur", 4, 3, 3, 1, 1, false);
		Bestiary.Make("Giant Centipede", 3, 3, 2, 1, 0, false);
		Bestiary.Make("Jelly Cube", 1, 0, 5, 0, 0, false);
		Bestiary.Make("Dark Dragon", 4, 4, 4, 5, 9, true);
		Bestiary.Make("Earth Elemental", 1, 4, 3, 1, 1, true);
		Bestiary.Make("Smasher", 3, 2, 3, 3, 0, false);
		Bestiary.Make("Skeleton", 1, 0, 0, 2, 0, false);
		Bestiary.Make("Ent", 7, 3, 12, 5, 0, false);
		Bestiary.Make("Giant Scorpion", 2, 2, 3, 2, 0, false);
		Bestiary.Make("Ghost", 1, 1, 2, 2, 4, true);
		Bestiary.Make("Phoenix", 5, 6, 7, 6, 8, true);
		Bestiary.Make("Wisp", 0, 4, 0, 0, 0, false);
		Bestiary.Make("Giant Grasshopper", 1, 3, 2, 1, 1, false);
		Bestiary.Make("Gargoyle", 3, 5, 4, 4, 0, false);
		Bestiary.Make("Cyclope", 20, 4, 9, 7, 18, false);
		Bestiary.Make("Goblin Soldier", 0, 1, 1, 0, 1, true);
		Bestiary.Make("Carnivorous Grass", 0, 1, 0, 0, 0, false);
		Bestiary.Make("Lion", 3, 3, 2, 0, 0, false);
		Bestiary.Make("Tiger", 2, 3, 2, 0, 0, false);
		Bestiary.Make("Gryph", 2, 7, 3, 1, 0, false);
		Bestiary.Make("Harpy", 2, 5, 3, 1, 3, true);
		Bestiary.Make("Hydra", 4, 3, 10, 4, 10, true);
		Bestiary.Make("Kobold Guard", 0, 1, 0, 1, 0, false);
		Bestiary.Make("Kraken", 7, 5, 10, 6, 0, false);
		Bestiary.Make("Lich", 3, 5, 5, 6, 5, true);
		Bestiary.Make("Wolf", 1, 2, 1, 0, 0, false);
		Bestiary.Make("Medusa", 1, 2, 3, 0, 6, false);
		Bestiary.Make("Mummy", 4, 1, 3, 4, 0, false);
		Bestiary.Make("Slark", 0, 0, 0, 0, 0, false);
		Bestiary.Make("Tarrasque", 8, 5, 8, 10, 0, false);
		Bestiary.Make("Badger", 2, 1, 2, 1, 0, false);
		Bestiary.Make("Tentacute", 0, 0, 0, 0, 0, true);
		Bestiary.Make("White Bear", 3, 2, 3, 1, 0, false);
		Bestiary.Make("Wyvern", 5, 5, 4, 4, 3, false);
		Bestiary.Make("Cave Worm", 10, 1, 30, 4, 0, false);
		Bestiary.Make("Carrion Worm", 1, 2, 2, 2, 0, false);
	}

	/* Create items' files */
	public static void CreateItems() {
		var armorDirInfo = new DirectoryInfo("GameData/Inventory/Armor");
		var weaponDirInfo = new DirectoryInfo("GameData/Inventory/Weapon");
		if(armorDirInfo.Exists && weaponDirInfo.Exists) {
			return;
		}

		Inventory.Make("wood sword", "melee", "weapon", 0, 50);
		Inventory.Make("rusty iron dagger", "melee", "weapon", 1, 125);
		Inventory.Make("iron dagger", "melee", "weapon", 3, 210);
		Inventory.Make("steel dagger", "melee", "weapon", 4, 270);
		Inventory.Make("iron longsword", "melee", "weapon", 6, 300);
		Inventory.Make("silver longsword", "melee", "weapon", 7, 500);
		Inventory.Make("claymore", "melee", "weapon", 8, 750);
		Inventory.Make("zweihander", "melee", "weapon", 10, 1000);
		Inventory.Make("iron war axe", "melee", "weapon", 5, 450);
		Inventory.Make("dwarven war axe", "melee", "weapon", 8, 1250);
		Inventory.Make("club", "melee", "weapon", 3, 200);
		Inventory.Make("steel mace", "melee", "weapon", 7, 625);
		Inventory.Make("steel warhammer", "melee", "weapon", 8, 1300);
		Inventory.Make("bionic sledgehammer", "melee", "weapon", 15, 5000);
		Inventory.Make("wood bow", "ranged", "weapon", 0, 50);
		Inventory.Make("iron bow", "ranged", "weapon", 2, 150 );
		Inventory.Make("short bow", "ranged", "weapon", 1, 100);
		Inventory.Make("long bow", "ranged", "weapon", 3, 250);
		Inventory.Make("elven bow", "ranged", "weapon", 10, 2000);
		Inventory.Make("steel bow", "ranged", "weapon", 6, 650);
		Inventory.Make("black bow", "ranged", "weapon", 8, 975);
		Inventory.Make("heavy crossbow", "ranged", "weapon", 7, 700);
		Inventory.Make("wood helmet", "head", "armor", 0, 100);
		Inventory.Make("leather helmet", "head", "armor", 2, 150);
		Inventory.Make("fur helmet", "head", "armor", 4, 200);
		Inventory.Make("iron helmet", "head", "armor", 6, 275);
		Inventory.Make("steel helmet", "head", "armor", 7, 500);
		Inventory.Make("chainmail helmet", "head", "armor", 9, 575);
		Inventory.Make("elven helmet", "head", "armor", 10, 800);
		Inventory.Make("orcish helmet", "head", "armor", 11, 1000);
		Inventory.Make("mithril helmet", "head", "armor", 13, 1250);
		Inventory.Make("wood cuirass", "torso", "armor", 0, 150);
		Inventory.Make("leather cuirass", "torso", "armor", 3, 300);
		Inventory.Make("fur cuirass", "torso", "armor", 5, 500);
		Inventory.Make("iron cuirass", "torso", "armor", 6, 700);
		Inventory.Make("steel cuirass", "torso", "armor", 7, 725);
		Inventory.Make("chainmail cuirass", "torso", "armor", 11, 1350);
		Inventory.Make("elven cuirass", "torso", "armor", 12, 1500);
		Inventory.Make("orcish cuirass", "torso", "armor", 14, 1750);
		Inventory.Make("mithril cuirass", "torso", "armor", 15, 2500);
		Inventory.Make("wood greaves", "leg", "armor", 0, 50);
		Inventory.Make("leather greaves", "leg", "armor", 1, 125);
		Inventory.Make("fur greaves", "leg", "armor", 2, 190);
		Inventory.Make("iron greaves", "leg", "armor", 4, 225);
		Inventory.Make("steel greaves", "leg", "armor", 5, 350);
		Inventory.Make("orcish greaves", "leg", "armor", 6, 440);
		Inventory.Make("chainmail greaves", "leg", "armor", 8, 750);
		Inventory.Make("elven greaves", "leg", "armor", 7, 950);
		Inventory.Make("mithril greaves", "leg", "armor", 10, 1200);
		Inventory.Make("wood gauntlets", "hand", "armor", 0, 100);
		Inventory.Make("leather gauntlets", "hand", "armor", 1, 150);
		Inventory.Make("fur gauntlets", "hand", "armor", 1, 175);
		Inventory.Make("iron gauntlets", "hand", "armor", 2, 200);
		Inventory.Make("steel gauntlets", "hand", "armor", 3, 300);
		Inventory.Make("chainmail gauntlets", "hand", "armor", 5, 375);
		Inventory.Make("elven gauntlets", "hand", "armor", 7, 425);
		Inventory.Make("orcish gauntlets", "hand", "armor", 8, 450);
		Inventory.Make("mithril gauntlets", "hand", "armor", 10, 500);
	}
}
