using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Inventory {

    /* Create an item file and save it on Inventory folder */
	public static void Make(string name, string type, string category, int buff, int value) {
		string DirPath = "./GameData/Inventory/" + StringModify.FirstToUpper(category) + "/";
		Directory.CreateDirectory(DirPath);

		string[] Tokens = name.Split(' ');
		string FileName = "";

        /* Generating filename string */
		FileName = String.Join("", Tokens);

		FileName = String.Join("", DirPath, FileName, ".itm");

		FileStream Stream = new FileStream(FileName, FileMode.OpenOrCreate,FileAccess.Write);

		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

        /* This key is used only to avoid simple file editing on the enemies stats */
		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEITEMS");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEITEMS");

		CryptoStream CrStream = new CryptoStream(Stream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);

        /* Concatenating item data with comma */
		string Data = name + "," + type + "," + category + "," + buff + "," + value;

		byte[] EncodedData = ASCIIEncoding.ASCII.GetBytes(Data);

        /* Write file */
		CrStream.Write(EncodedData, 0, EncodedData.Length);

		File.SetAttributes(FileName, FileAttributes.ReadOnly);

		CrStream.Close();
		Stream.Close();
	}

    /* Load item based on its name and category */
	public static Item Load(string item, string category) {
        /* Generate path to load item */
		string FullPath = String.Join("", "./GameData/Inventory/", StringModify.FirstToUpper(category), "/", item, ".itm");
		FileStream Stream = new FileStream(FullPath, FileMode.Open,FileAccess.Read);
		DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

        /* This key is used only to avoid simple file editing on the enemies stats */
		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("THEITEMS");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("THEITEMS");

		CryptoStream CrStream = new CryptoStream(Stream,
    		Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);

        /* Read file and split tokens */
		string Data = Reader.ReadToEnd();

		Reader.Close();
		Stream.Close();
		
		string[] Tokens = Data.Split(',');

        /* Create item with tokens */
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
