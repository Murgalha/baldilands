using System;

public static class InventoryController {

	private static bool IsPart(string part) {
		if(part.Equals("head") || part.Equals("torso") || part.Equals("hand") || part.Equals("leg") || part.Equals("weapon"))
			return true;
		return false;
	}

	private static Item Find(Hero H, string Name) {
		foreach(var It in H.Bag.Inventory) {
			if(It.Name.Equals(Name)) {
				return It;
			}
		}
		return null;
	}

	private static bool PartIsNull(Hero H, string Part) {
	if(Part.Equals("head")) {
		if(H.Equip.Head == null)
		return true;
	}
	else if(Part.Equals("torso")) {
		if(H.Equip.Torso == null)
		return true;
	}
	else if(Part.Equals("hand")) {
		if(H.Equip.Hand == null)
		return true;
	}
	else if(Part.Equals("leg")) {
		if(H.Equip.Leg == null)
		return true;
	}
	else if(Part.Equals("weapon")) {
		if(H.Weapon == null)
		return true;
	}
	return false;
}

	private static void Equip(Hero H) {
		string Name;

		while(true) {
			Console.WriteLine("What item do you want to equip? Type ENTER with empty name to return)");
			foreach (var Item in H.Bag.Inventory) {
				Console.WriteLine("> {0} ({1})", StringModify.FirstToUpper(Item.Name), StringModify.FirstToUpper(Item.Type));
			}

			Name = Console.ReadLine();
			Name = Name.ToLower();
			if(Name.Equals("")) {
				Console.Clear();
				return;
			}
			Item It = InventoryController.Find(H, Name);
			Console.Clear();
			if(It == null) {
				Console.WriteLine("Item not found\n");
			}
			else {
				H.EquipFromBag(It.Name);
				Console.WriteLine("{0} equipped\n", StringModify.FirstToUpper(It.Name));
			}
		}
	}

	private static void Unequip(Hero H) {
		string Part;
		bool IsPart = false;

		while(true) {
			IsPart = false;
			Console.WriteLine("What part do you want to unequip? (Type ENTER on empty part to return)");
			Console.WriteLine("> Head ({0})", H.Equip.Head != null ? StringModify.FirstToUpper(H.Equip.Head.Name) : "Empty");
			Console.WriteLine("> Torso ({0})", H.Equip.Torso != null ? StringModify.FirstToUpper(H.Equip.Torso.Name) : "Empty");
			Console.WriteLine("> Hand ({0})", H.Equip.Hand != null ? StringModify.FirstToUpper(H.Equip.Hand.Name) : "Empty");
			Console.WriteLine("> Leg ({0})", H.Equip.Leg != null ? StringModify.FirstToUpper(H.Equip.Leg.Name) : "Empty");
			Console.WriteLine("> Weapon ({0})", H.Weapon != null ? StringModify.FirstToUpper(H.Weapon.Name) : "Empty");
		
			Part = Console.ReadLine();
			Part = Part.ToLower();
			if(Part.Equals("")) {
				Console.Clear();
				return;
			}
			IsPart = InventoryController.IsPart(Part);
			Console.Clear();
			if(!IsPart)
				Console.WriteLine("Unknown part\n");
			else {
				if(InventoryController.PartIsNull(H, Part))
					Console.WriteLine("You do not have any item equipped there\n");
				else {
					H.RemoveEquip(Part);
					if(InventoryController.PartIsNull(H, Part))
						Console.WriteLine("{0} unequipped\n", StringModify.FirstToUpper(Part));
					else
						Console.WriteLine("Error! Could not unequip {0}\n", Part);
				}
			}
		}
	}

	private static void Drop(Hero H) {
		string Name;

		while(true) {
			Console.WriteLine("What item do you want to drop? (Type ENTER with empty name to return)");
			foreach(var It in H.Bag.Inventory)
				Console.WriteLine("> {0} ({1})", StringModify.FirstToUpper(It.Name), StringModify.FirstToUpper(It.Type));
			Name = Console.ReadLine();
			Name = Name.ToLower();
			if(Name.Equals("")) {
				Console.Clear();
				return;
			}
			Item Item = InventoryController.Find(H, Name);
			Console.Clear();
			if(Item == null)
				Console.WriteLine("Item not found\n");
			else {
				H.DropItem(Item);
				Console.WriteLine("{0} dropped\n", StringModify.FirstToUpper(Item.Name));
			}
		}
	}

	private static string ParseCommand(string Raw) {
		string Input = "";
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("equip"))
			Input = "equip";
		else if(Raw.Equals("2") || Raw.Equals("unequip"))
			Input = "unequip";
		else if(Raw.Equals("3") || Raw.Equals("drop"))
			Input = "drop";
		return Input;
	}

	public static void Manage(Hero H) {
		Console.Clear();
		CharacterSheet.Show(H);
		Console.WriteLine();
		string Input;

		while(true) {
			Console.WriteLine("What do you want to do with your items? (Type empty command to return");
			Console.WriteLine("1. Equip");
			Console.WriteLine("2. Unequip");
			Console.WriteLine("3. Drop");
		
			Input = Console.ReadLine();
			Input = InventoryController.ParseCommand(Input);

			Console.Clear();
			if(Input.Equals("equip"))
				InventoryController.Equip(H);
			else if(Input.Equals("unequip"))
				InventoryController.Unequip(H);
			else if(Input.Equals("drop"))
				InventoryController.Drop(H);		
			else if(Input.Equals(""))
				return;
			else
				Console.WriteLine("Invalid command");
		}
	}
}