using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Bestiary {

	public static void Make(string spec, int s, int ab, int r, int a, int fp, bool ranged) {
		FileInfo Dir = new System.IO.FileInfo("./Bestiary/");
		Dir.Directory.Create();

		string[] Tokens = spec.Split(' ');
		string FileName = "";

		foreach (var Token in Tokens)
			FileName = String.Join("", FileName, Token.ToLower());

		FileName = String.Join("", "./Bestiary/", FileName, ".mon");

		FileStream Stream = new FileStream(FileName, FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEBEAST");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEBEAST");

		CryptoStream CrStream = new CryptoStream(Stream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);

		string Data = spec + "," + s + "," + ab + "," + r + "," + a + "," + fp + ",";

		if(ranged)
			Data += "1," + "broken bow,ranged,0,50"; 
		else
			Data += "1," + "broken sword,melee,0,50"; 

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

		CrStream.Write(EncodedData, 0, EncodedData.Length);

		File.SetAttributes(FileName, FileAttributes.ReadOnly);

		CrStream.Close();
		Stream.Close();
	}

	public static Enemy Load(string File) {
		string FullPath = String.Join("", "./Bestiary/", File, ".mon");
		FileStream Stream = new FileStream(FullPath, FileMode.Open,FileAccess.Read);
		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEBEAST");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEBEAST");

		CryptoStream CrStream = new CryptoStream(Stream,
    		Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);

		string Data = Reader.ReadToEnd();

		Reader.Close();
		Stream.Close();
		
		string[] Tokens = Data.Split(',');

		int Strength, Ability, Resistance, Armor, Firepower;
		int k = 0;
		string Species = Tokens[k++];
		Strength = Int32.Parse(Tokens[k++]);
		Ability = Int32.Parse(Tokens[k++]);
		Resistance = Int32.Parse(Tokens[k++]);
		Armor = Int32.Parse(Tokens[k++]);
		Firepower = Int32.Parse(Tokens[k++]);

		Enemy E = new Enemy(Strength, Ability, Resistance, Armor, Firepower, Species);

		Item Weapon = null;

		if(Tokens[k++].Equals("1")) {
			string Name = Tokens[k++];
			string Type = Tokens[k++];
			int Buff = Int32.Parse(Tokens[k++]);
			int Value = Int32.Parse(Tokens[k++]);
			Weapon = new Item(Name, Type, Buff, Value);
		}

		E.Equip.Equip(Weapon);

		return E;
	}
}