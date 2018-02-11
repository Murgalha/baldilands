using System;
using System.IO;

public static class Menu {

	private static string ParseCommand(string Raw) {
		Raw = Raw.ToLower();

		if(Raw.Equals("1") || Raw.Equals("new game"))
			return "new game";
		else if(Raw.Equals("2") || Raw.Equals("load game"))
			return "load game";
		else if(Raw.Equals("3") || Raw.Equals("exit"))
			return "exit";
		else
			return "";
	}

	public static void MainMenu() {
		string Input;
		Hero H = null;

		Console.Clear();
		while(true) {
			Console.WriteLine("1. New Game");
			Console.WriteLine("2. Load Game");
			Console.WriteLine("3. Exit");

			Input = Console.ReadLine();
			Input = Menu.ParseCommand(Input);

			if(Input.Equals("new game")) {
				H = CharacterCreator.Create();
			}
			else if(Input.Equals("load game")) {
				if(File.Exists("./Save/game.sav")) {
					H = DungeonMaster.LoadGame();
				}
				else {
					string Ans;
					Console.Clear();
					Console.WriteLine("No save file detected\n");
					while(true) {
						Console.WriteLine("Do you wish to start a new game?");
						Console.WriteLine("1. Yes");
						Console.WriteLine("2. No");

						Ans = Console.ReadLine();
						Ans = YesNoInput.Parse(Ans);

						if(Ans.Equals("yes")) {
							H = CharacterCreator.Create();
							break;
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
			else if(Input.Equals("exit")) {
				Console.Clear();
				return;
			}
			else {
				Console.Clear();
				Console.WriteLine("Invalid command\n");
			}
			if(H != null) {
				DungeonMaster.Hero = H;
				DungeonMaster.SaveGame(H);
				return;
			}
		}
	}
}