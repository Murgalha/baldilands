using System;

public static class CharacterSheet {

	private static string FirstToUpper(string str) {
		return (Char.ToUpper(str[0]) + str.Substring(1));
	}

	public static void Show(Hero H) {

		Console.WriteLine("\nName: " + H.Name + "\tRace: " + H.Race);
		Console.WriteLine("HP: " + H.HP + "\t\tMP: " + H.MP);

		Console.WriteLine("\nStrength: " + H.Strength + "\tFirepower: "+ H.Firepower);
		Console.WriteLine("Resistance: " + H.Resistance+ "\tArmor: "+ H.Armor);
		Console.WriteLine("Ability: " + H.Ability);
		
		Console.WriteLine("\nEXP: " + H.Exp);
		Console.WriteLine("Gold: " + H.Gold);
		Console.WriteLine("Items:");
		foreach(var item in H.Bag.Inventory)
			Console.WriteLine("> " + FirstToUpper(item.Name));

		Console.WriteLine("\nEquipment:");
		Console.WriteLine("> Weapon: " + (H.Equip.Weapon != null ? FirstToUpper(H.Equip.Weapon.Name) : ""));
		Console.WriteLine("> Head: " + (H.Equip.Head != null ? FirstToUpper(H.Equip.Head.Name) : ""));
		Console.WriteLine("> Torso: " + (H.Equip.Torso != null ? FirstToUpper(H.Equip.Torso.Name) : ""));
		Console.WriteLine("> Hand: " + (H.Equip.Hand != null ? FirstToUpper(H.Equip.Hand.Name) : ""));
		Console.WriteLine("> Leg: " + (H.Equip.Leg != null ? FirstToUpper(H.Equip.Leg.Name) : ""));
	} 
}