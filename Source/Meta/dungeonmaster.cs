using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class DungeonMaster {

	public static Hero Hero;

	private static Item LoadItem(string[] Tokens, int k) {
		string Name = Tokens[k];
		string Type = Tokens[k+1];
		int Buff = Int32.Parse(Tokens[k+2]);
		int Value = Int32.Parse(Tokens[k+3]);
		Item It = new Item(Name, Type, Buff, Value);
		return It;
	}

	public static void SaveGame(Hero H) {
		FileInfo File = new System.IO.FileInfo("./Save/");
		File.Directory.Create();

		FileStream Stream = new FileStream("./Save/game.sav", FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

		CryptoStream CrStream = new CryptoStream(Stream,
		   Crypto.CreateEncryptor(),CryptoStreamMode.Write);


		string Data = H.Name + "," + H.Race + "," + H.Strength + "," + H.Ability + "," + H.Resistance + "," + H.Armor + "," + H.Firepower + "," + H.Exp + "," + H.Gold + "," + H.Bag.Size + ",";

		foreach (var It in H.Bag.Inventory)
			Data += It.Name + "," + It.Type + "," + It.Buff + "," + It.Value + ",";

		if(H.Equip.Head != null) {
			Data += "1,";
			Data += H.Equip.Head.Name + "," + H.Equip.Head.Type + "," + H.Equip.Head.Buff + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Torso != null) {
			Data += "1,";
			Data += H.Equip.Torso.Name + "," + H.Equip.Torso.Type + "," + H.Equip.Torso.Buff + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Hand != null) {
			Data += "1,";
			Data += H.Equip.Hand.Name + "," + H.Equip.Hand.Type + "," + H.Equip.Hand.Buff + ",";
		}
		else
			Data += "0,";

		if(H.Equip.Leg != null) {
			Data += "1,";
			Data += H.Equip.Leg.Name + "," + H.Equip.Leg.Type + "," + H.Equip.Leg.Buff + ",";
		}
		else
			Data += "0,";

		if(H.Weapon != null) {
			Data += "1,";
			Data += H.Equip.Weapon.Name + "," + H.Equip.Weapon.Type + "," + H.Equip.Weapon.Buff;
		}
		else
			Data += "0";

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

		CrStream.Write(EncodedData, 0, EncodedData.Length);

		CrStream.Close();
		Stream.Close();
	}

	public static Hero LoadGame() {
		FileStream Stream = new FileStream("./Save/game.sav",
                              FileMode.Open,FileAccess.Read);
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
			k += 4;
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


	public static void StartGame() {
		if(Menu.MainMenu()) {
			Menu.Town();
		}
	}
}
