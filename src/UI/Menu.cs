using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

public class Menu {
	public MainMenuScreen mMainMenuScreen;
	public SaveManager SM;
	public DungeonMaster DM;

	public Menu(DungeonMaster dm) {
		SM = new SaveManager();
		DM = dm;
		mMainMenuScreen = new MainMenuScreen(SM);
	}

	public void MainMenu() {
		mMainMenuScreen.Go();
	}

}
