namespace Baldilands;

class Program {
    static void Main() {
        // TODO: Check and create items on startup
        // FileCreator.Items();
        DungeonMaster DM = new DungeonMaster();
        DM.StartGame();
    }
}
