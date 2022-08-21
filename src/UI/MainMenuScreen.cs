using System;
using System.Collections.Generic;

public class MainMenuScreen {
	private bool mShouldExit;
	private SaveManager mSaveManager;
	private TownScreen mTownScreen;

	public MainMenuScreen(SaveManager saveManager) {
		mShouldExit = false;
		mSaveManager = saveManager;
		mTownScreen = new TownScreen(saveManager);
	}

	public void Go() {
		mSaveManager.CurrentSlot = -1;

		var menuDict = new Dictionary<int, Tuple<string, Action>> {
			[1] = Tuple.Create<string, Action>("New game", _ExecuteNewGame),
			[2] = Tuple.Create<string, Action>("Load game", _ExecuteLoadGame),
			[3] = Tuple.Create<string, Action>("Delete save", _ExecuteDeleteSave),
			[4] = Tuple.Create<string, Action>("Exit", _ExecuteExit)
			};


		Console.Clear();
		while(!mShouldExit) {
			Console.WriteLine("+------------+");
			Console.WriteLine("| Baldilands |");
			Console.WriteLine("+------------+\n");

			foreach(var kvp in menuDict) {
				Console.WriteLine($"{kvp.Key}. {kvp.Value.Item1}");
			}

			string input = Console.ReadLine() ?? string.Empty;
			var menuAction = InputParser.Parse(input, menuDict, _ExecuteInvalid);
			menuAction();
		}
	}

	private void _ExecuteNewGame() {
		mSaveManager.SetSaveSlot();
		if(mSaveManager.CurrentSlot != -1) {
			var hero = CharacterCreator.Create();
			mSaveManager.SaveGame(hero, mSaveManager.CurrentSlot);
		}

		else {
			Console.Clear();
		}
	}

	private void _ExecuteLoadGame() {
		mSaveManager.SetLoadSlot();
		if(mSaveManager.CurrentSlot != -1) {
			_ = mSaveManager.LoadGame(mSaveManager.CurrentSlot);
			mTownScreen.Go();
		}
		else {
			Console.Clear();
		}
	}

	private void _ExecuteDeleteSave() {
		Console.Clear();
		mSaveManager.ClearSlot();
	}

	private void _ExecuteExit() {
		Console.Clear();
		mShouldExit = true;
	}

	private void _ExecuteInvalid() {
		Console.Clear();
		Console.WriteLine("Invalid command\n");
	}
}
