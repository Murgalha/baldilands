using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveExpert {

	private Item LoadItem(string[] Tokens, int k) {
		string Name = Tokens[k];
		string Type = Tokens[k+1];
		string Category = Tokens[k+2];
		int Buff = Int32.Parse(Tokens[k+3]);
		int Value = Int32.Parse(Tokens[k+4]);
		Item It = new Item(Name, Type, Category, Buff, Value);
		return It;
	}

	public bool SaveGame(Hero H, int slot) {
		FileInfo FileDir = new System.IO.FileInfo("./Save/");
		FileDir.Directory.Create();
		string Slot;
			
		Slot = "./Save/slot" + slot + ".sav";

		if(File.Exists(Slot)) {
			File.Delete(Slot);
		}
		
		FileStream Stream = new FileStream(Slot, FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

		CryptoStream CrStream = new CryptoStream(Stream,
		   Crypto.CreateEncryptor(),CryptoStreamMode.Write);


		string Data = H.Name + "," + H.Race + "," + H.Strength + "," + H.Ability + "," + H.Resistance + "," + H.Armor + "," + H.Firepower + "," + H.Exp + "," + H.Gold + "," + H.Bag.Size + ",";

		foreach (var It in H.Bag.Inventory)
			Data += It.Name + "," + It.Type + "," + It.Category + "," + It.Buff + "," + It.Value + ",";

		if(H.Equip.Head != null) {
			Data += "1,";
			Data += H.Equip.Head.Name + "," + H.Equip.Head.Type + "," + H.Equip.Head.Buff + "," + H.Equip.Head.Value + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Torso != null) {
			Data += "1,";
			Data += H.Equip.Torso.Name + "," + H.Equip.Torso.Type + "," + H.Equip.Torso.Buff + "," + H.Equip.Torso.Value + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Hand != null) {
			Data += "1,";
			Data += H.Equip.Hand.Name + "," + H.Equip.Hand.Type + "," + H.Equip.Hand.Buff + "," + H.Equip.Hand.Value + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Leg != null) {
			Data += "1,";
			Data += H.Equip.Leg.Name + "," + H.Equip.Leg.Type + "," + H.Equip.Leg.Buff + "," + H.Equip.Leg.Value + ",";
		}
		else
			Data += "0,";

		if(H.Weapon != null) {
			Data += "1,";
			Data += H.Equip.Weapon.Name + "," + H.Equip.Weapon.Type + "," + H.Equip.Weapon.Buff + "," + H.Equip.Weapon.Value;
		}
		else
			Data += "0";

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

		CrStream.Write(EncodedData, 0, EncodedData.Length);

		CrStream.Close();
		Stream.Close();

		return true;
	}

	public Hero LoadGame(int slot) {
		string Slot;

		Slot = String.Join("", "./Save/slot", slot, ".sav");

		if(!File.Exists(Slot))
			return null;

		FileStream Stream = new FileStream(Slot, FileMode.Open,FileAccess.Read);
		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

		CryptoStream CrStream = new CryptoStream(Stream,
    		Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);
		string Data = Reader.ReadToEnd();
		
		Reader.Close();
		Stream.Close();
		
		string[] Tokens = Data.Split(',');

		int Strength, Ability, Resistance, Armor, Firepower;
		int Exp, Gold, i, k = 0;
		string Name = Tokens[k++];
		string Race = Tokens[k++];
		Strength = Int32.Parse(Tokens[k++]);
		Ability = Int32.Parse(Tokens[k++]);
		Resistance = Int32.Parse(Tokens[k++]);
		Armor = Int32.Parse(Tokens[k++]);
		Firepower = Int32.Parse(Tokens[k++]);

		Hero H = new Hero(Strength, Ability, Resistance, Armor, Firepower, Name, Race);

		Exp = Int32.Parse(Tokens[k++]);
		Gold = Int32.Parse(Tokens[k++]);

		H.Exp = Exp;
		H.Gold = Gold;

		int Size = Int32.Parse(Tokens[k++]);
		for(i = 0; i < Size; i++) {
			Item It = LoadItem(Tokens, k);
			k += 5;
			H.PickItem(It);
		}

		for(i = 0; i < 5; i++) {
			if(Tokens[k++] == "1") {
				Item It = LoadItem(Tokens, k);
				k += 4;
				H.PickItem(It);
				H.EquipFromBag(It.Name);
			}
		}

		return H;
	}

	public void DeleteGame(int slot) {
		string Slot = String.Join("", "./Save/slot", slot, ".sav");
		File.Delete(Slot);
	}
}