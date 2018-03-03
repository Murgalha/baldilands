using System;
using System.Collections.Generic;
using System.IO;

public class Market {

	private Hero H;

	public Market(Hero h) {
		this.H = h;
	}

	private Item Find(Hero H, string Name) {
		foreach(var It in H.Bag.Inventory) {
			if(It.Name.Equals(Name)) {
				return It;
			}
		}
		return null;
	}

	private string ParseMerchant(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("weapons merchant") ||
		Raw.Equals("weapons"))
			return "weapons";
		else if(Raw.Equals("2") || Raw.Equals("armors merchant") ||
		Raw.Equals("armors"))
			return "armors";
		else if(Raw.Equals("3") || Raw.Equals("armors merchant") ||
		Raw.Equals("consumables"))
			return "consumables";
		else if(Raw.Equals("4") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	private void LoadWeapons(out List<Item> Melee, out List<Item> Ranged) {
		string[] paths = Directory.GetFileSystemEntries("./Inventory/Weapon", "*.itm");
		Melee = new List<Item>();
		Ranged = new List<Item>();
		foreach(var filepath in paths) {
			string file = Path.GetFileNameWithoutExtension(filepath);
			Item It = Inventory.Load(file, "weapon");
			if(It.Type.Equals("melee"))
				Melee.Add(It);
			else
				Ranged.Add(It);
		}
		return;
	}

	private void LoadArmors(out List<Item> Armor) {
		string[] paths = Directory.GetFileSystemEntries("./Inventory/Armor", "*.itm");
		Armor = new List<Item>();
		foreach(var filepath in paths) {
			string file = Path.GetFileNameWithoutExtension(filepath);
			Item It = Inventory.Load(file, "armor");
			Armor.Add(It);
		}
		return;
	}

	private int Find(List<Item> items, string name) {
		for(int i = 0; i < items.Count; i++)
			if(items[i].Name.Equals(name))
				return i;
		return -1;
	}

private void BuyRanged(List<Item> Ranged) {
		string Weapon;
		int Index = new int();
		while(true) {
			Console.WriteLine("Which weapon do you want to buy? (Type ENTER on empty weapon to return)");
			Console.WriteLine("Current gold: {0}\n", this.H.Gold);
			foreach(var weapon in Ranged)
				Console.WriteLine("> {0} - Buying price: {2}", StringModify.FirstToUpper(weapon.Name), weapon.Type, weapon.Value);
			
			Weapon = Console.ReadLine();
			Weapon = Weapon.ToLower();

			if(Weapon.Equals("")) {
				Console.Clear();
				return;
			}

			Index = this.Find(Ranged, Weapon);

			Console.Clear();
			if(Index < 0) {
				Console.WriteLine("Weapon not found\n");
			}
			else {
				Item It = new Item(Ranged[Index]);
				if(this.H.Gold < It.Value) {
					Console.WriteLine("Not enough gold\n");
				}
				else {
					this.H.Gold -= It.Value;
					this.H.PickItem(It);
					Console.WriteLine("{0} bought\n", 
					StringModify.FirstToUpper(It.Name));
				}
			}
		}
	}

	private void BuyMelee(List<Item> Melee) {
		string Weapon;
		int Index = new int();
		while(true) {
			Console.WriteLine("Which weapon do you want to buy? (Type ENTER on empty weapon to return)");
			Console.WriteLine("Current gold: {0}\n", this.H.Gold);
			foreach(var weapon in Melee)
				Console.WriteLine("> {0} - Buying price: {2}", StringModify.FirstToUpper(weapon.Name), weapon.Type, weapon.Value);
			
			Weapon = Console.ReadLine();
			Weapon = Weapon.ToLower();

			if(Weapon.Equals("")) {
				Console.Clear();
				return;
			}

			Index = this.Find(Melee, Weapon);

			Console.Clear();
			if(Index < 0) {
				Console.WriteLine("Weapon not found\n");
			}
			else {
				Item It = new Item(Melee[Index]);
				if(this.H.Gold < It.Value) {
					Console.WriteLine("Not enough gold\n");
				}
				else {
					this.H.Gold -= It.Value;
					this.H.PickItem(It);
					Console.WriteLine("{0} bought\n", 
					StringModify.FirstToUpper(It.Name));
				}
			}
		}
	}

	private string ParseWeaponType(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("melee"))
			return "melee";
		else if(Raw.Equals("2") || Raw.Equals("ranged"))
			return "ranged";
		else if(Raw.Equals("3") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	private void BuyArmor(List<Item> Armor) {
		string ArmorName;
		int Index = new int();
		Console.Clear();
		while(true) {
			Console.WriteLine("Which armor do you want to buy? (Type ENTER on empty armor to return)");
			Console.WriteLine("Current gold: {0}\n", this.H.Gold);
			
			Console.Write("> {0} - Buying price: {1}\t", StringModify.FirstToUpper(Armor[0].Name), Armor[0].Type, 
			Armor[0].Value);
			Console.Write("> {0} - Buying price: {1}\n", StringModify.FirstToUpper(Armor[1].Name), 
			Armor[1].Value);
			for(int i = 2; i < Armor.Count; i+=2) {
				Console.Write("> {0} - Buying price: {1}\t\t", StringModify.FirstToUpper(Armor[i].Name), 
				Armor[i].Value);
				Console.Write("> {0} - Buying price: {1}\n", StringModify.FirstToUpper(Armor[i+1].Name), 
				Armor[i+1].Value);
			}
			
			ArmorName = Console.ReadLine();
			ArmorName = ArmorName.ToLower();

			if(ArmorName.Equals("")) {
				Console.Clear();
				return;
			}

			Index = this.Find(Armor, ArmorName);

			Console.Clear();
			if(Index < 0) {
				Console.WriteLine("Weapon not found\n");
			}
			else {
				Item It = new Item(Armor[Index]);
				if(this.H.Gold < It.Value) {
					Console.WriteLine("Not enough gold\n");
				}
				else {
					this.H.Gold -= It.Value;
					this.H.PickItem(It);
					Console.WriteLine("{0} bought\n", 
					StringModify.FirstToUpper(It.Name));
				}
			}
		}
	}

	private void Buy() {
		List<Item> Melee;
		List<Item> Ranged;
		List<Item> Armor;
		string Merchant;
		this.LoadWeapons(out Melee, out Ranged);
		this.LoadArmors(out Armor);

		while(true) {
			Console.WriteLine("Select the merchant you want to buy from");
			Console.WriteLine("1. Weapons Merchant");
			Console.WriteLine("2. Armors Merchant");
			Console.WriteLine("3. Consumables Merchant");
			Console.WriteLine("4. Return");
		
			Merchant = Console.ReadLine();
			Merchant = this.ParseMerchant(Merchant);

			if(Merchant.Equals("weapons")) {
				string WeaponType;

				Console.Clear();
				while(true) {
					Console.WriteLine("Which type of weapon do you want to buy?");
					Console.WriteLine("1. Melee");
					Console.WriteLine("2. Ranged");
					Console.WriteLine("3. Return");

					WeaponType = Console.ReadLine();
					WeaponType = this.ParseWeaponType(WeaponType);

					Console.Clear();
					if(WeaponType.Equals("melee")) {
						this.BuyMelee(Melee);
						break;
					}
					else if(WeaponType.Equals("ranged")) {
						this.BuyRanged(Ranged);
						break;
					}
					else if(WeaponType.Equals("return"))
						break;
					else
						Console.WriteLine("Invalid type of weapon\n");
				}
			}
			else if(Merchant.Equals("armors")) {
				this.BuyArmor(Armor);
			}
			else if(Merchant.Equals("consumables")) {
				Console.Clear();
				Console.WriteLine("Coming soon\n");
			}
			else if(Merchant.Equals("return")) {
				Console.Clear();
				return;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid merchant\n");
			}
		}
	}

	public void Sell() {
		string Name;

		while(true) {
			Console.WriteLine("Which item do you want to sell? (Type ENTER on empty item to return)");
			foreach(var It in this.H.Bag.Inventory) {
				Console.WriteLine("> {0} ({1}) - Selling price: {2}", StringModify.FirstToUpper(It.Name), StringModify.FirstToUpper(It.Type), It.Value/2);
			}

			Name = Console.ReadLine();
			Name = Name.ToLower();
			if(Name.Equals("")) {
				Console.Clear();
				return;
			}
			Item Item = this.Find(this.H, Name);
			Console.Clear();
			if(Item == null) {
				Console.WriteLine("Item not found\n");
			}
			else {
				H.DropItem(Item);
				H.Gold += (Item.Value/2);
				Console.WriteLine("{0} sold\n", StringModify.FirstToUpper(Item.Name));
			}		
		}
	}

	private string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("buy"))
			return "buy";
		else if(Raw.Equals("2") || Raw.Equals("sell"))
			return "sell";
		else if(Raw.Equals("3") || Raw.Equals("return"))
			return "return";
		else
			return "";
	}

	public void Shop() {
		string Input;
		
		Console.Clear();
		while(true) {
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Buy");
			Console.WriteLine("2. Sell");
			Console.WriteLine("3. Return");

			Input = Console.ReadLine();
			Input = ParseCommand(Input);
			
			Console.Clear();
			if(Input.Equals("buy")) {
				this.Buy();
			}
			else if(Input.Equals("sell")) {
				this.Sell();
			}
			else if(Input.Equals("return")) {
				return;
			}
			else {
				Console.WriteLine("Invalid command\n");
			}
		}

	}
}