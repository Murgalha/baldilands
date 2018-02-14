public class DungeonMaster {

	public Hero Hero;

	public void StartGame() {
		while(true) {
			Menu M = new Menu(this);
			if(M.MainMenu()) {
				M.Town();
			}
			else {
				return;
			}
		}
	}
}
