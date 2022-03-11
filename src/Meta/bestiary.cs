using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Bestiary {

	/* Create a simple encrypted beast file and store it on the 'Bestiary' folder */
	public static void Make(string spec, int s, int ab, int r, int a, int fp, bool ranged) {
		/* Create folder if it does not exist */
		FileInfo Dir = new System.IO.FileInfo("./GameData/Bestiary/");
		Dir.Directory.Create();

		string[] Tokens = spec.Split(' ');
		string FileName = "";

		/* Join a monster name for the filename */
		foreach (var Token in Tokens)
			FileName = String.Join("", FileName, Token.ToLower());

		FileName = String.Join("", "./GameData/Bestiary/", FileName, ".mon");

		/* Open a new file */
		FileStream Stream = new FileStream(FileName, FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		/* This key is used only to avoid simple file editing on the enemies stats */
		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEBEAST");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEBEAST");

		CryptoStream CrStream = new CryptoStream(Stream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);

		/* Join enemy stats using commas */
		string Data = spec + "," + s + "," + ab + "," + r + "," + a + "," + fp + ",";

		/* Adding standard beast weapon */
		if(ranged)
			Data += "1," + "wood bow,ranged,weapon,0,50";
		else
			Data += "1," + "wood sword,melee,weapon,0,50";

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

		/* Write data on the file */
		CrStream.Write(EncodedData, 0, EncodedData.Length);

		File.SetAttributes(FileName, FileAttributes.ReadOnly);

		/* Close everything */
		CrStream.Close();
		Stream.Close();
	}

	/* load a beast file based on the given filename string */
	public static Enemy Load(string File) {
		/* Open and load the file */
		string FullPath = String.Join("", "./GameData/Bestiary/", File, ".mon");
		FileStream Stream = new FileStream(FullPath, FileMode.Open,FileAccess.Read);
		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEBEAST");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEBEAST");

		CryptoStream CrStream = new CryptoStream(Stream,
			Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);

		/* Read all data from file */
		string Data = Reader.ReadToEnd();

		Reader.Close();
		Stream.Close();

		/* Split data, as it was written separating
		 * the stats with comma */
		string[] Tokens = Data.Split(',');

		int Strength, Ability, Resistance, Armor, Firepower;
		int k = 0;

		/* Reading basic characteristics */
		string Species = Tokens[k++];
		Strength = Int32.Parse(Tokens[k++]);
		Ability = Int32.Parse(Tokens[k++]);
		Resistance = Int32.Parse(Tokens[k++]);
		Armor = Int32.Parse(Tokens[k++]);
		Firepower = Int32.Parse(Tokens[k++]);

		/* Create creature */
		Enemy E = new Enemy(Strength, Ability, Resistance, Armor, Firepower, Species);

		Item Weapon = null;

		/* Read weapon	*/
		if(Tokens[k++].Equals("1")) {
			string Name = Tokens[k++];
			string Type = Tokens[k++];
			string Category = Tokens[k++];
			int Buff = Int32.Parse(Tokens[k++]);
			int Value = Int32.Parse(Tokens[k++]);
			Weapon = new Item(Name, Type, Category, Buff, Value);
		}

		/* Equip weapon and return the monster */
		E.Equip.Equip(Weapon);

		return E;
	}
}
