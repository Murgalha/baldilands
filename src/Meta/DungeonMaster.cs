namespace Baldilands;

public class DungeonMaster {

	public Hero Hero;

	public void StartGame() {
		/* Loop to remain player on the game
		 * Only exits with explicit exit option */
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
