public class Enemy : Creature {

	protected string _Species;

	public Enemy(int str, int ab, int res, int armr, int firepwr, string spec)
		: base(str, ab, res, armr, firepwr) {
		this._Species = spec;
	}

	public string Species {
		get {
			return this._Species;
		}
	}
}
