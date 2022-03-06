public class Reward {

	protected Item _Item;
	protected int _Exp;
	protected int _Gold;

	public Reward(Item it, int exp, int gold) {
		this._Item = it;
		this._Exp = exp;
		this._Gold = gold;
	}

	public int Exp {
		get {
			return this._Exp;
		}
	}

	public int Gold {
		get {
			return this._Gold;
		}
	}

	public Item Item {
		get {
			return this._Item;
		}
	}
}
