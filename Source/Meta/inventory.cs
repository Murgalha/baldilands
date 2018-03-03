using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Inventory {

	public static void Make(string name, string type, string category, int buff, int value) {
		string DirPath = "./Inventory/" + StringModify.FirstToUpper(category) + "/";

		Directory.CreateDirectory(DirPath);

		string[] Tokens = name.Split(' ');
		string FileName = "";

		FileName = String.Join("", Tokens);

		FileName = String.Join("", DirPath, FileName, ".itm");

		FileStream Stream = new FileStream(FileName, FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEITEMS");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEITEMS");

		CryptoStream CrStream = new CryptoStream(Stream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);

		string Data = name + "," + type + "," + category + "," + buff + "," + value;

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

		CrStream.Write(EncodedData, 0, EncodedData.Length);

		File.SetAttributes(FileName, FileAttributes.ReadOnly);

		CrStream.Close();
		Stream.Close();
	}

	public static Item Load(string item, string category) {
		string FullPath = String.Join("", "./Inventory/", StringModify.FirstToUpper(category), item, ".itm");
		FileStream Stream = new FileStream(FullPath, FileMode.Open,FileAccess.Read);
		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEITEMS");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEITEMS");

		CryptoStream CrStream = new CryptoStream(Stream,
    		Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);

		string Data = Reader.ReadToEnd();

		Reader.Close();
		Stream.Close();
		
		string[] Tokens = Data.Split(',');

		int k = 0;
		string Name = Tokens[k++];
		string Type = Tokens[k++];
		string Category = Tokens[k++];
		int Buff = Int32.Parse(Tokens[k++]);
		int Value = Int32.Parse(Tokens[k++]);

		Item I = new Item(Name, Type, Category, Buff, Value);

		return I;
	}
}