using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Menu {

	public SaveManager SM;

	public Menu() {
		this.SM = new SaveManager();
	}

	private string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("new game"))
			return "new game";
		else if(Raw.Equals("2") || Raw.Equals("load game"))
			return "load game";
		else if(Raw.Equals("3") || Raw.Equals("delete save") 
		|| Raw.Equals("delete"))
			return "delete";
		else if(Raw.Equals("4") || Raw.Equals("exit"))
			return "exit";
		else
			return "";
	}

	private string ParseTownCommand(string Raw) {
		Raw = Raw.ToLower();
	
		if(Raw.Equals("1") || Raw.Equals("fight"))
			return "fight";
		else if(Raw.Equals("2") || Raw.Equals("shop"))
			return "shop";
		else if(Raw.Equals("3") || Raw.Equals("manage inventory") 
		|| Raw.Equals("inventory"))
			return "manage inventory";
		else if(Raw.Equals("4") || Raw.Equals("save game") 
		|| Raw.Equals("save"))
			return "save game";
		else if(Raw.Equals("5") || Raw.Equals("exit game") 
		|| Raw.Equals("exit"))
			return "exit";
		else
			return "";
	}

	public void Town() {
		string Input;

		Console.Clear();
		while(true) {
			Console.WriteLine("Where do you want to go now?");
			Console.WriteLine("1. Fight");
			Console.WriteLine("2. Shop");
			Console.WriteLine("3. Manage Inventory");
			Console.WriteLine("4. Save Game");
			Console.WriteLine("5. Exit Game");

			Input = Console.ReadLine();
			Input = this.ParseTownCommand(Input);

			if(Input.Equals("fight")) {
			}
			else if(Input.Equals("shop")) {
			}
			else if(Input.Equals("manage inventory"))
				InventoryController.Manage(DungeonMaster.Hero);
			else if(Input.Equals("save game")) {
				Console.Clear();
				if(DungeonMaster.SaveGame(DungeonMaster.Hero, this.SM.CurrentSlot))
					Console.WriteLine("Game saved!\n");
				else
					Console.WriteLine("Error! Could not save game\n");
			}
			else if(Input.Equals("exit")) {
				Console.Clear();
				return;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid command\n");
			}
		}
	}

	public bool MainMenu() {
		string Input;
		Hero H = null;
		this.SM.CurrentSlot = -1;

		Console.Clear();
		while(true) {
			Console.WriteLine("1. New Game");
			Console.WriteLine("2. Load Game");
			Console.WriteLine("3. Delete Save");
			Console.WriteLine("4. Exit");

			Input = Console.ReadLine();
			Input = this.ParseCommand(Input);

			if(Input.Equals("new game")) {
				this.SM.SetSaveSlot();
				if(this.SM.CurrentSlot != -1)
					H = CharacterCreator.Create();
				else {
					Console.Clear();
					continue;
				}
			}
			else if(Input.Equals("load game")) {
				this.SM.SetLoadSlot();
				if(this.SM.CurrentSlot != -1) {
					H = DungeonMaster.LoadGame(this.SM.CurrentSlot);
				}
				else {
					Console.Clear();
					continue;
				}
			}
			else if(Input.Equals("delete")) {
				Console.Clear();
				this.SM.ClearSlot();
			}
			else if(Input.Equals("exit")) {
				Console.Clear();
				return false;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid command\n");
			}
			if(H != null) {
				DungeonMaster.Hero = H;
				DungeonMaster.SaveGame(H, this.SM.CurrentSlot);
				return true;
			}
		}
	}
}