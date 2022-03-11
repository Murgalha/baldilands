class main {
	static void Main() {
		FileCreator.CreateItems();
		FileCreator.CreateMonsters();
		DungeonMaster DM = new DungeonMaster();
		DM.StartGame();
	}
}
