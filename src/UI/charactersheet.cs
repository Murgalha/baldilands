using System;

namespace Baldilands;

public static class CharacterSheet {

	public static void Show(Hero H) {

		Console.WriteLine("Name: {0}\tRace: {1}", H.Name, StringModify.FirstToUpper(H.Race));
		Console.WriteLine("HP: {0}\t\tMP: {1}", H.HP, H.MP);

		Console.WriteLine("\nStrength: {0}\tFirepower: {1}", H.Strength, H.Firepower);
		Console.WriteLine("Resistance: {0}\tArmor: {1}", H.Resistance, H.Armor);
		Console.WriteLine("Ability: {0}", H.Ability);

		Console.WriteLine("\nEXP: {0}", H.Exp);
		Console.WriteLine("Level: {0}", H.Level);
		Console.WriteLine("Gold: {0}", H.Gold);
		Console.WriteLine("Items:");
		foreach(var item in H.Bag.Inventory)
			Console.WriteLine("> {0}", StringModify.FirstToUpper(item.Name));

		Console.WriteLine("\nEquipment:");
		Console.WriteLine("> Weapon: {0}", (H.Equip.Weapon != null ? StringModify.FirstToUpper(H.Equip.Weapon.Name) : ""));
		Console.WriteLine("> Head: {0}", (H.Equip.Head != null ? StringModify.FirstToUpper(H.Equip.Head.Name) : ""));
		Console.WriteLine("> Torso: {0}", (H.Equip.Torso != null ? StringModify.FirstToUpper(H.Equip.Torso.Name) : ""));
		Console.WriteLine("> Hand: {0}", (H.Equip.Hand != null ? StringModify.FirstToUpper(H.Equip.Hand.Name) : ""));
		Console.WriteLine("> Leg: {0}", (H.Equip.Leg != null ? StringModify.FirstToUpper(H.Equip.Leg.Name) : ""));
	}
}
