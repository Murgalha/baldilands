using System.Collections.Generic;

namespace Baldilands;

public static class Initializer {

	public static List<string> InitMonsters() {
		List<string> monsters = new List<string>(new string[]{"abomination", "amoeba", "ankheg", "apparition", "archon", "atrocious vulture", "badger", "banshee", "basilisk", "beholder", "carnivorous grass", "carrion worm", "cave worm", "centaur", "cyclope", "dark dragon", "earth elemental", "ent", "gargoyle","ghost", "giant bee", "giant centipede", "giant eagle", "giant grasshopper","giant scorpion", "giant spider", "goblin soldier", "gryph", "gryph bee", "harpy", "hydra", "infernal hound", "jelly cube","kobold guard", "kraken", "lich", "lion", "medusa", "mummy", "phoenix", "rattling sniffer", "skeleton", "slark", "smasher", "tarrasque", "tentacute", "tiger", "voracious beetle", "walking bush", "warhorse", "white bear", "wisp", "witch", "wolf", "wyvern"});
		return monsters;
	}

	public static List<string> InitItems() {
		List<string> items = new List<string>(new string[]{"bionicsledgehammer","blackbow", "chainmailcuirass", "chainmailgauntlets", "chainmailgreaves", "chainmailhelmet", "claymore", "club", "dwarvenwaraxe", "elvenbow", "elvencuirass", "elvengauntlets", "elvengreaves", "elvenhelmet", "furcuirass", "furgauntlets", "furgreaves", "furhelmet", "heavycrossbow", "ironbow", "ironcuirass", "irondagger", "irongauntlets", "irongreaves", "ironhelmet", "ironlongsword", "ironwaraxe", "leathercuirass", "leathergauntlets", "leathergreaves", "leatherhelmet", "longbow", "mithrilcuirass", "mithrilgauntlets", "mithrilgreaves", "mithrilhelmet", "orcishcuirass", "orcishgauntlets", "orcishgreaves", "orcishhelmet", "rustyirondagger", "shortbow", "silverlongsword", "steelbow", "steelcuirass", "steeldagger", "steelgauntlets", "steelgreaves", "steelhelmet", "steelmace", "steelwarhammer", "woodbow", "woodcuirass", "woodgauntlets", "woodgreaves", "woodhelmet", "woodsword",  "zweihander"});
		return items;
	}
}
