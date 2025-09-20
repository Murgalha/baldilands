namespace Baldilands;

class Program {
    static void Main() {
        FileCreator.EnsureMonsterFilesExist();
        FileCreator.EnsureItemFilesExist();

        DungeonMaster dungeonMaster = new DungeonMaster();
        dungeonMaster.StartGame();
    }
}
