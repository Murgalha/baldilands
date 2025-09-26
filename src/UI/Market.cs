using System;
using System.Collections.Generic;
using System.Linq;

namespace Baldilands;

public class Market
{
    private Hero H;

    public Market(Hero h)
    {
        this.H = h;
    }

    private string ParseMerchant(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("weapons merchant") || Raw.Equals("weapons"))
            return "weapons";
        else if (Raw.Equals("2") || Raw.Equals("armors merchant") || Raw.Equals("armors"))
            return "armors";
        else if (Raw.Equals("3") || Raw.Equals("armors merchant") || Raw.Equals("consumables"))
            return "consumables";
        else if (Raw.Equals("4") || Raw.Equals("return"))
            return "return";
        else
            return "";
    }

    private void LoadWeapons(out List<Item> Melee, out List<Item> Ranged)
    {
        // TODO: I think we don't need to load all items here
        string[] itemNames = Initializer.Weapons();
        Melee = new List<Item>();
        Ranged = new List<Item>();
        foreach (var itemName in itemNames)
        {
            string file = Inventory.GetItemPath(itemName);
            Item? it = Inventory.Load(file);
            if (it is not null)
            {
                if (it.Value.Type.Equals("melee"))
                    Melee.Add(it.Value);
                else
                    Ranged.Add(it.Value);
            }
        }
        return;
    }

    private void LoadArmors(out List<Item> Armor)
    {
        // TODO: I think we don't need to load all items here
        string[] armorNames = Initializer.Armors();
        Armor = new List<Item>();
        foreach (var armorName in armorNames)
        {
            string file = Inventory.GetItemPath(armorName);
            Item? it = Inventory.Load(file);
            Armor.Add(it.Value);
        }
        return;
    }

    private void BuyRanged(List<Item> Ranged)
    {
        string Weapon;
        int Index = new int();
        while (true)
        {
            Console.WriteLine(
                "Which weapon do you want to buy? (Type ENTER on empty weapon to return)"
            );
            Console.WriteLine("Current gold: {0}\n", this.H.Gold);
            foreach (var weapon in Ranged)
                Console.WriteLine(
                    "> {0} - Buying price: {2}",
                    weapon.Name.Capitalize(),
                    weapon.Type,
                    weapon.Value
                );

            Weapon = Console.ReadLine();
            Weapon = Weapon.ToLower();

            if (Weapon.Equals(""))
            {
                Console.Clear();
                return;
            }

            Index = Ranged.FindIndex(x => x.Name.Equals(Weapon));

            Console.Clear();
            if (Index < 0)
            {
                Console.WriteLine("Weapon not found\n");
            }
            else
            {
                Item tmp = Ranged[Index];
                Item It = new Item(tmp.Name, tmp.Type, tmp.Category, tmp.Buff, tmp.Value);
                if (this.H.Gold < It.Value)
                {
                    Console.WriteLine("Not enough gold\n");
                }
                else
                {
                    this.H.Gold -= It.Value;
                    this.H.PickItem(It);
                    Console.WriteLine("{0} bought\n", It.Name.Capitalize());
                }
            }
        }
    }

    private void BuyMelee(List<Item> Melee)
    {
        string Weapon;
        int Index = new int();
        while (true)
        {
            Console.WriteLine(
                "Which weapon do you want to buy? (Type ENTER on empty weapon to return)"
            );
            Console.WriteLine("Current gold: {0}\n", this.H.Gold);
            foreach (var weapon in Melee)
                Console.WriteLine(
                    "> {0} - Buying price: {2}",
                    weapon.Name.Capitalize(),
                    weapon.Type,
                    weapon.Value
                );

            Weapon = Console.ReadLine();
            Weapon = Weapon.ToLower();

            if (Weapon.Equals(""))
            {
                Console.Clear();
                return;
            }

            Index = Melee.FindIndex(x => x.Name.Equals(Weapon));

            Console.Clear();
            if (Index < 0)
            {
                Console.WriteLine("Weapon not found\n");
            }
            else
            {
                Item tmp = Melee[Index];
                Item It = new Item(tmp.Name, tmp.Type, tmp.Category, tmp.Buff, tmp.Value);
                if (this.H.Gold < It.Value)
                {
                    Console.WriteLine("Not enough gold\n");
                }
                else
                {
                    this.H.Gold -= It.Value;
                    this.H.PickItem(It);
                    Console.WriteLine("{0} bought\n", It.Name.Capitalize());
                }
            }
        }
    }

    private string ParseWeaponType(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("melee"))
            return "melee";
        else if (Raw.Equals("2") || Raw.Equals("ranged"))
            return "ranged";
        else if (Raw.Equals("3") || Raw.Equals("return"))
            return "return";
        else
            return "";
    }

    private void BuyArmor(List<Item> Armor)
    {
        string ArmorName;
        int Index = new int();
        Console.Clear();
        while (true)
        {
            Console.WriteLine(
                "Which armor do you want to buy? (Type ENTER on empty armor to return)"
            );
            Console.WriteLine("Current gold: {0}\n", this.H.Gold);

            Console.Write(
                "> {0} - Buying price: {1}\t",
                Armor[0].Name.Capitalize(),
                Armor[0].Value,
                Armor[0].Value
            );
            Console.Write(
                "> {0} - Buying price: {1}\n",
                Armor[1].Name.Capitalize(),
                Armor[1].Value
            );
            for (int i = 2; i < Armor.Count; i += 2)
            {
                Console.Write(
                    "> {0} - Buying price: {1}\t\t",
                    Armor[i].Name.Capitalize(),
                    Armor[i].Value
                );
                Console.Write(
                    "> {0} - Buying price: {1}\n",
                    Armor[i + 1].Name.Capitalize(),
                    Armor[i + 1].Value
                );
            }

            ArmorName = Console.ReadLine();
            ArmorName = ArmorName.ToLower();

            if (ArmorName.Equals(""))
            {
                Console.Clear();
                return;
            }

            Index = Armor.FindIndex(x => x.Name.Equals(ArmorName));

            Console.Clear();
            if (Index < 0)
            {
                Console.WriteLine("Weapon not found\n");
            }
            else
            {
                Item tmp = Armor[Index];
                Item It = new Item(tmp.Name, tmp.Type, tmp.Category, tmp.Buff, tmp.Value);
                if (this.H.Gold < It.Value)
                {
                    Console.WriteLine("Not enough gold\n");
                }
                else
                {
                    this.H.Gold -= It.Value;
                    this.H.PickItem(It);
                    Console.WriteLine("{0} bought\n", It.Name.Capitalize());
                }
            }
        }
    }

    private void Buy()
    {
        List<Item> Melee;
        List<Item> Ranged;
        List<Item> Armor;
        string Merchant;
        this.LoadWeapons(out Melee, out Ranged);
        this.LoadArmors(out Armor);

        while (true)
        {
            Console.WriteLine("Select the merchant you want to buy from");
            Console.WriteLine("1. Weapons Merchant");
            Console.WriteLine("2. Armors Merchant");
            Console.WriteLine("3. Consumables Merchant");
            Console.WriteLine("4. Return");

            Merchant = Console.ReadLine();
            Merchant = this.ParseMerchant(Merchant);

            if (Merchant.Equals("weapons"))
            {
                string WeaponType;

                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Which type of weapon do you want to buy?");
                    Console.WriteLine("1. Melee");
                    Console.WriteLine("2. Ranged");
                    Console.WriteLine("3. Return");

                    WeaponType = Console.ReadLine();
                    WeaponType = this.ParseWeaponType(WeaponType);

                    Console.Clear();
                    if (WeaponType.Equals("melee"))
                    {
                        this.BuyMelee(Melee);
                        break;
                    }
                    else if (WeaponType.Equals("ranged"))
                    {
                        this.BuyRanged(Ranged);
                        break;
                    }
                    else if (WeaponType.Equals("return"))
                        break;
                    else
                        Console.WriteLine("Invalid type of weapon\n");
                }
            }
            else if (Merchant.Equals("armors"))
            {
                this.BuyArmor(Armor);
            }
            else if (Merchant.Equals("consumables"))
            {
                Console.Clear();
                Console.WriteLine("Coming soon\n");
            }
            else if (Merchant.Equals("return"))
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid merchant\n");
            }
        }
    }

    public void Sell()
    {
        while (true)
        {
            Console.WriteLine(
                "Which item do you want to sell? (Type ENTER on empty item to return)"
            );
            foreach (var It in H.Bag.Items)
            {
                Console.WriteLine(
                    "> {0} ({1}) - Selling price: {2}",
                    It.Name.Capitalize(),
                    It.Type.Capitalize(),
                    It.Value / 2
                );
            }

            var name = Console.ReadLine().ToLower();
            if (name.Equals(""))
            {
                Console.Clear();
                return;
            }
            Item? Item = H.Bag.Items.FirstOrDefault(x => x.Name.Equals(name));
            Console.Clear();
            if (!Item.HasValue)
            {
                Console.WriteLine("Item not found\n");
            }
            else
            {
                H.DropItem(Item.Value);
                H.Gold += (Item.Value.Value / 2);
                Console.WriteLine("{0} sold\n", Item.Value.Name.Capitalize());
            }
        }
    }

    private string ParseCommand(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("buy"))
            return "buy";
        else if (Raw.Equals("2") || Raw.Equals("sell"))
            return "sell";
        else if (Raw.Equals("3") || Raw.Equals("return"))
            return "return";
        else
            return "";
    }

    public void Shop()
    {
        string Input;

        Console.Clear();
        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Return");

            Input = Console.ReadLine();
            Input = ParseCommand(Input);

            Console.Clear();
            if (Input.Equals("buy"))
            {
                this.Buy();
            }
            else if (Input.Equals("sell"))
            {
                this.Sell();
            }
            else if (Input.Equals("return"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid command\n");
            }
        }
    }
}
