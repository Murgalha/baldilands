using System;

namespace Baldilands;

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
			Console.WriteLine("What item do you want to equip? (Type ENTER with empty name to return)");
			foreach (var Item in H.Bag.Inventory) {
				Console.WriteLine("> {0} ({1})", Item.Name.Capitalize(), Item.Type.Capitalize());
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
				Console.WriteLine("{0} equipped\n", It.Name.Capitalize());
			}
		}
	}

	private static void Unequip(Hero H) {
		string Part;
		bool IsPart = false;

		while(true) {
			IsPart = false;
			Console.WriteLine("What part do you want to unequip? (Type ENTER on empty part to return)");
			Console.WriteLine("> Head ({0})", H.Equip.Head != null ? H.Equip.Head.Name.Capitalize() : "Empty");
			Console.WriteLine("> Torso ({0})", H.Equip.Torso != null ? H.Equip.Torso.Name.Capitalize() : "Empty");
			Console.WriteLine("> Hand ({0})", H.Equip.Hand != null ? H.Equip.Hand.Name.Capitalize() : "Empty");
			Console.WriteLine("> Leg ({0})", H.Equip.Leg != null ? H.Equip.Leg.Name.Capitalize() : "Empty");
			Console.WriteLine("> Weapon ({0})", H.Weapon != null ? H.Weapon.Name.Capitalize() : "Empty");

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
						Console.WriteLine("{0} unequipped\n", Part.Capitalize());
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
				Console.WriteLine("> {0} ({1})", It.Name.Capitalize(), It.Type.Capitalize());
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
				Console.WriteLine("{0} dropped\n", Item.Name.Capitalize());
			}
		}
	}

	private static string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("equip"))
			return "equip";
		else if(Raw.Equals("2") || Raw.Equals("unequip"))
			return "unequip";
		else if(Raw.Equals("3") || Raw.Equals("drop"))
			return "drop";
		else if(Raw.Equals("4") || Raw.Equals("return"))
			return "return";
		return "";
	}

	public static void Manage(Hero H) {
		Console.Clear();
		string Input;

		while(true) {
			CharacterSheet.Show(H);
			Console.WriteLine("\nWhat do you want to do with your items?");
			Console.WriteLine("1. Equip");
			Console.WriteLine("2. Unequip");
			Console.WriteLine("3. Drop");
			Console.WriteLine("4. Return");

			Input = Console.ReadLine();
			Input = InventoryController.ParseCommand(Input);

			Console.Clear();
			if(Input.Equals("equip"))
				InventoryController.Equip(H);
			else if(Input.Equals("unequip"))
				InventoryController.Unequip(H);
			else if(Input.Equals("drop"))
				InventoryController.Drop(H);
			else if(Input.Equals("return"))
				return;
			else
				Console.WriteLine("Invalid command\n");
		}
	}
}
