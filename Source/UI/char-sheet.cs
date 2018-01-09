using System;

public static class CharSheet {

	public static void Show(Hero H) {

		Console.WriteLine("Name: " + H.Name + "\tRace: " + H.Race);
		Console.WriteLine("HP: " + H.HP + "\t\tMP: " + H.MP);

		Console.WriteLine("\nStrength: " + H.Strength + "\tFire Power: "+ H.FirePower);
		Console.WriteLine("Resistance: " + H.Resistance+ "\tArmor: "+ H.Armor);
		Console.WriteLine("Ability: " + H.Ability);
	
		Console.WriteLine("\nItems:");
		foreach(var item in H.Bag.Inventory)
			Console.WriteLine("> " + item.Name);
	} 
}