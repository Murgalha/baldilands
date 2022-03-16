public class Enemy : Creature {
	public readonly string Species;

	public Enemy(int str, int ab, int res, int armr, int firepwr, string spec)
		: base(str, ab, res, armr, firepwr) {
		Species = spec;
	}
}
