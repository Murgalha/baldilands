using System;

public static class CharSheet {

	public static void Show(Hero H) {

		Console.WriteLine("\nName: " + H.Name + "\tRace: " + H.Race);
		Console.WriteLine("HP: " + H.HP + "\t\tMP: " + H.MP);

		Console.WriteLine("\nStrength: " + H.Strength + "\tFire Power: "+ H.FirePower);
		Console.WriteLine("Resistance: " + H.Resistance+ "\tArmor: "+ H.Armor);
		Console.WriteLine("Ability: " + H.Ability);
		
		Console.WriteLine("\nGold: " + H.Gold);
		Console.WriteLine("Items:");
		foreach(var item in H.Bag.Inventory)
			Console.WriteLine("> " + item.Name);

		Console.WriteLine("\nEquipment:");
		Console.WriteLine("> Weapon: " + (H.Equip.Weapon != null ? H.Equip.Weapon.Name : ""));
		Console.WriteLine("> Head: " + (H.Equip.Head != null ? H.Equip.Head.Name : ""));
		Console.WriteLine("> Torso: " + (H.Equip.Torso != null ? H.Equip.Torso.Name : ""));
		Console.WriteLine("> Hand: " + (H.Equip.Hand != null ? H.Equip.Hand.Name : ""));
		Console.WriteLine("> Leg: " + (H.Equip.Leg != null ? H.Equip.Leg.Name : ""));
	} 
}