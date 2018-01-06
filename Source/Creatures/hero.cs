public class Hero : Creature {

	protected string _Name;
	protected Bag _Bag;

	public Hero(int str, int ab, int res, int armr, int firepwr, string name)
	: base(str, ab, res, armr, firepwr) {
		this._Name = name;
		this._Bag = new Bag();
	}

	public string Name {
		get {
			return this._Name;
		}
	}
}
