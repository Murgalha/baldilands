using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveManager {
	public Hero Hero { get; private set; }
	public int SlotsNum;
	public int CurrentSlot;
	public string[] SlotState;
	private SaveExpert SE;

	public SaveManager() {
		Hero = Hero.Empty;
		SlotsNum = 20;
		CurrentSlot = -1;
		SlotState = new string[SlotsNum+1];
		SE = new SaveExpert();

		string Data = "";
		for(int i = 1; i <= SlotsNum; i++) {
			string SlotFile = String.Join("", "./GameData/Save/slot", i, ".sav");
			if(!File.Exists(SlotFile))
				SlotState[i] = "empty";
			else {
				if(LoadSlotData(i, ref Data))
					SlotState[i] = "full";
				else
					SlotState[i] = "empty";
			}
		}
	}

	private bool LoadSlotData(int slot, ref string data) {
		string Slot;
		Slot = String.Join("", "./GameData/Save/slot", slot, ".sav");

		FileStream Stream = new FileStream(Slot, FileMode.Open,FileAccess.Read);
		var Crypto = DES.Create();

		Crypto.Key = ASCIIEncoding.ASCII.GetBytes("MURGALHA");
		Crypto.IV = ASCIIEncoding.ASCII.GetBytes("MURGALHA");

		CryptoStream CrStream = new CryptoStream(Stream,
			Crypto.CreateDecryptor(),CryptoStreamMode.Read);

		StreamReader Reader = new StreamReader(CrStream);
		string Data = "";
		try {
			Data = Reader.ReadToEnd();
		}
		catch(FormatException) {
			return false;
		}
		string[] Tokens = Data.Split(',');
		Reader.Close();
		Stream.Close();

		data = String.Join(", the ", Tokens[0], Tokens[1]);

		return true;
	}

	public void SetLoadSlot() {
		string Data = "";
		string Num;
		int Value;

		Console.Clear();
		while(true) {
			Console.WriteLine("Which slot would you like to load? (Type ENTER on empty slot to return)");
			for(int i = 1; i <= SlotsNum; i++) {
				string SlotFile = String.Join("", "./GameData/Save/slot", i, ".sav");
				Console.Write("> {0}", i);
				if(!File.Exists(SlotFile)) {
					Console.Write(" - Empty\n");
				}
				else {
					if(LoadSlotData(i, ref Data)) {
						Console.Write(" - {0}\n", Data);
					}
					else {
						Console.Write(" - Empty\n");
					}
				}
			}
			Num = Console.ReadLine() ?? string.Empty;
			if(Num.Equals(""))
				return;
			try {
				Value = Int32.Parse(Num);
			}
			catch(FormatException) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(Value < 1 || Value > SlotsNum) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(SlotState[Value].Equals("full")) {
				CurrentSlot = Value;
				return;
			}
			else {
				Console.Clear();
				Console.WriteLine("Empty slot\n");
				continue;
			}
		}
	}

	public int SetSaveSlot() {
		string Num;
		int Value = 0;
		string Data = "";

		Console.Clear();
		while(true) {
			Console.WriteLine("Which slot do you want to save in? (Type ENTER on empty slot to return)");
			for(int i = 1; i <= SlotsNum; i++) {
				string SlotFile = String.Join("", "./GameData/Save/slot", i, ".sav");
				Console.Write("> {0}", i);
				if(!File.Exists(SlotFile)) {
					Console.Write(" - Empty\n");
				}
				else {
					if(LoadSlotData(i, ref Data)) {
						Console.Write(" - {0}\n", Data);
					}
					else {
						Console.Write(" - Empty\n");
					}
				}
			}
			Num = Console.ReadLine() ?? string.Empty;
			if(Num.Equals(""))
				return -1;
			try {
				Value = Int32.Parse(Num);
			}
			catch(FormatException) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(Value < 1 || Value > 20) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(SlotState[Value].Equals("empty")) {
				SlotState[Value] = "full";
				CurrentSlot = Value;
				return Value;
			}
			else {
				Console.Clear();
				string Ans;

				while(true) {
					Console.WriteLine("This slot is already full");
					Console.WriteLine("Do you wish to overwrite it?");
					Console.WriteLine("1. Yes");
					Console.WriteLine("2. No");

					Ans = Console.ReadLine() ?? string.Empty;
					Ans = YesNoInput.Parse(Ans);

					if(Ans.Equals("yes")) {
						SlotState[Value] = "full";
						CurrentSlot = Value;
						return Value;
					}
					else if(Ans.Equals("no")) {
						Console.Clear();
						break;
					}
					else {
						Console.Clear();
						Console.WriteLine("Invalid command\n");
					}
				}
			}
		}
	}

	public void ClearSlot() {
		string Data = "";
		string Num;
		int Value = 0;

		Console.Clear();
		while(true) {
			Console.WriteLine("Which slot would you like to delete? (Type ENTER on empty slot to return)");
			for(int i = 1; i <= SlotsNum; i++) {
				string SlotFile = String.Join("", "./GameData/Save/slot", i, ".sav");
				Console.Write("> {0}", i);
				if(!File.Exists(SlotFile)) {
					Console.Write(" - Empty\n");
				}
				else {
					if(LoadSlotData(i, ref Data)) {
						Console.Write(" - {0}\n", Data);
					}
					else {
						Console.Write(" - Empty\n");
					}
				}
			}
			Num = Console.ReadLine() ?? string.Empty;
			if(Num.Equals("")) {
				Console.Clear();
				return;
			}
			try {
				Value = Int32.Parse(Num);
			}
			catch(FormatException) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(Value < 1 || Value > SlotsNum) {
				Console.Clear();
				Console.WriteLine("Invalid slot number\n");
				continue;
			}
			if(SlotState[Value].Equals("full")) {
				Console.Clear();
				SE.DeleteGame(Value);
				SlotState[Value] = "empty";
				Console.WriteLine("Slot {0} deleted\n", Value);
			}
			else {
				Console.Clear();
				Console.WriteLine("Empty slot\n");
			}
		}
	}

	public bool SaveGame(Hero H, int slot) {
		return SE.SaveGame(H, slot);
	}

	public Hero LoadGame(int slot) {
		Hero = SE.LoadGame(slot);
		return Hero;
	}
}