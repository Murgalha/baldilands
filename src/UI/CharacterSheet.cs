using System;

namespace Baldilands;

public static class CharacterSheet {

	public static void Show(Hero H) {

		Console.WriteLine("Name: {0}\tRace: {1}", H.Name, H.Race.Capitalize());
		Console.WriteLine("HP: {0}\t\tMP: {1}", H.HP, H.MP);

		Console.WriteLine("\nStrength: {0}\tFirepower: {1}", H.Strength, H.Firepower);
		Console.WriteLine("Resistance: {0}\tArmor: {1}", H.Resistance, H.Armor);
		Console.WriteLine("Ability: {0}", H.Ability);

		Console.WriteLine("\nEXP: {0}", H.Exp);
		Console.WriteLine("Level: {0}", H.Level);
		Console.WriteLine("Gold: {0}", H.Gold);
		Console.WriteLine("Items:");
		foreach(var item in H.Bag.Inventory)
			Console.WriteLine("> {0}", item.Name.Capitalize());

		Console.WriteLine("\nEquipment:");
		Console.WriteLine("> Weapon: {0}", (H.Equip.Weapon != null ? H.Equip.Weapon.Name.Capitalize() : ""));
		Console.WriteLine("> Head: {0}", (H.Equip.Head != null ? H.Equip.Head.Name.Capitalize() : ""));
		Console.WriteLine("> Torso: {0}", (H.Equip.Torso != null ? H.Equip.Torso.Name.Capitalize() : ""));
		Console.WriteLine("> Hand: {0}", (H.Equip.Hand != null ? H.Equip.Hand.Name.Capitalize() : ""));
		Console.WriteLine("> Leg: {0}", (H.Equip.Leg != null ? H.Equip.Leg.Name.Capitalize() : ""));
	}
}
