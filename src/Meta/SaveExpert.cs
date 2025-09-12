using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Baldilands;

public class SaveExpert {

    /* receive the parsed string and return created item */
    private Item LoadItem(string[] Tokens, int k) {
        string Name = Tokens[k];
        string Type = Tokens[k + 1];
        string Category = Tokens[k + 2];
        int Buff = Int32.Parse(Tokens[k + 3]);
        int Value = Int32.Parse(Tokens[k + 4]);
        Item It = new Item(Name, Type, Category, Buff, Value);
        return It;
    }

    /* Save current game state */
    public bool SaveGame(Hero H, int slot) {
        /* Create 'Save' folder if not already created */
        FileInfo FileDir = new System.IO.FileInfo("./GameData/Save/");
        FileDir.Directory.Create();
        string Slot;

        /* Generating slot filename */
        Slot = "./GameData/Save/slot" + slot + ".sav";

        if (File.Exists(Slot)) {
            File.Delete(Slot);
        }

        /* Open a new filestream */
        FileStream Stream = new FileStream(Slot, FileMode.OpenOrCreate, FileAccess.Write);

        DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

        /* Key only used to avoid simple editing of save file */
        Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
        Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

        CryptoStream CrStream =
            new CryptoStream(Stream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);

        /* String 'Data' receives every information that needs to be saved for a
         * later load */
        /* Append player characteristics separating with comma */
        string Data = H.Name + "," + H.Race + "," + H.Strength + "," + H.Ability + "," +
                      H.Resistance + "," + H.Armor + "," + H.Firepower + "," + H.Exp + "," +
                      H.Level + "," + H.Gold + "," + H.Bag.Size + ",";

        /* Saving every inventory item */
        foreach (var It in H.Bag.Items)
            Data +=
                It.Name + "," + It.Type + "," + It.Category + "," + It.Buff + "," + It.Value + ",";

        /* Saving every equipped item on save file */
        if (H.Equip.Head.HasValue) {
            Data += "1,";
            Data += H.Equip.Head.Value.Name + "," + H.Equip.Head.Value.Type + "," +
                    H.Equip.Head.Value.Category + "," + H.Equip.Head.Value.Buff + "," +
                    H.Equip.Head.Value.Value + ",";
        } else
            Data += "0,";

        if (H.Equip.Torso.HasValue) {
            Data += "1,";
            Data += H.Equip.Torso.Value.Name + "," + H.Equip.Torso.Value.Type + "," +
                    H.Equip.Torso.Value.Category + "," + H.Equip.Torso.Value.Buff + "," +
                    H.Equip.Torso.Value.Value + ",";
        } else
            Data += "0,";

        if (H.Equip.Hand.HasValue) {
            Data += "1,";
            Data += H.Equip.Hand.Value.Name + "," + H.Equip.Hand.Value.Type + "," +
                    H.Equip.Hand.Value.Category + "," + H.Equip.Hand.Value.Buff + "," +
                    H.Equip.Hand.Value.Value + ",";
        } else
            Data += "0,";

        if (H.Equip.Leg.HasValue) {
            Data += "1,";
            Data += H.Equip.Leg.Value.Name + "," + H.Equip.Leg.Value.Type + "," +
                    H.Equip.Leg.Value.Category + "," + H.Equip.Leg.Value.Buff + "," +
                    H.Equip.Leg.Value.Value + ",";
        } else
            Data += "0,";

        if (H.GetWeapon().HasValue) {
            Data += "1,";
            Data += H.Equip.Weapon.Value.Name + "," + H.Equip.Weapon.Value.Type + "," +
                    H.Equip.Weapon.Value.Category + "," + H.Equip.Weapon.Value.Buff + "," +
                    H.Equip.Weapon.Value.Value;
        } else
            Data += "0";

        /* Write the string 'Data' into file */
        byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

        CrStream.Write(EncodedData, 0, EncodedData.Length);

        CrStream.Close();
        Stream.Close();

        return true;
    }

    /* Load game based on the slot chosen */
    public Hero LoadGame(int slot) {
        string Slot;

        Slot = String.Join("", "./GameData/Save/slot", slot, ".sav");

        /* if file exists, can't be loaded */
        if (!File.Exists(Slot))
            return null;

        FileStream Stream = new FileStream(Slot, FileMode.Open, FileAccess.Read);
        DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

        /* Key only used to avoid simple editing of save file */
        Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
        Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

        CryptoStream CrStream =
            new CryptoStream(Stream, Crypto.CreateDecryptor(), CryptoStreamMode.Read);

        StreamReader Reader = new StreamReader(CrStream);

        /* Get every file on a string, to then be split with ',' */
        string Data = Reader.ReadToEnd();

        Reader.Close();
        Stream.Close();

        /* Splitting data and setting characteristics */
        string[] Tokens = Data.Split(',');

        int Strength, Ability, Resistance, Armor, Firepower;
        int Exp, Gold, Level, i, k = 0;
        string Name = Tokens[k++];
        string Race = Tokens[k++];
        Strength = Int32.Parse(Tokens[k++]);
        Ability = Int32.Parse(Tokens[k++]);
        Resistance = Int32.Parse(Tokens[k++]);
        Armor = Int32.Parse(Tokens[k++]);
        Firepower = Int32.Parse(Tokens[k++]);

        Hero H = new Hero(Strength, Ability, Resistance, Armor, Firepower, Name, Race);

        /* Setting player status */
        Exp = Int32.Parse(Tokens[k++]);
        Level = Int32.Parse(Tokens[k++]);
        Gold = Int32.Parse(Tokens[k++]);

        H.Exp = Exp;
        H.Level = Level;
        H.Gold = Gold;

        /* Loading every item from inventory */
        int Size = Int32.Parse(Tokens[k++]);
        for (i = 0; i < Size; i++) {
            Item It = LoadItem(Tokens, k);
            k += 5;
            H.PickItem(It);
        }

        /* loading every equipped item */
        for (i = 0; i < 5; i++) {
            if (Tokens[k++] == "1") {
                Item It = LoadItem(Tokens, k);
                k += 5;
                H.PickItem(It);
                H.EquipFromBag(It.Name);
            }
        }

        return H;
    }

    /* Delete game */
    public void DeleteGame(int slot) {
        /* Simply finds and deletes game slot */
        string Slot = String.Join("", "./GameData/Save/slot", slot, ".sav");
        File.Delete(Slot);
    }
}
