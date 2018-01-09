public class Hero : Creature {

	protected string _Name;
	protected Bag _Bag;
	protected int _Exp;

	public Hero(int str, int ab, int res, int armr, int firepwr, string name)
	: base(str, ab, res, armr, firepwr) {
		this._Name = name;
		this._Bag = new Bag();
		this._Exp = 0;
	}

	public void ReceiveReward(Reward R) {
		this._Bag.Add(R.Item);
		this._Bag.Gold = R.Gold;
		this._Exp = R.Exp;
	}

	public string Name {
		get {
			return this._Name;
		}
	}

	public int Gold {
		get {
			return this._Bag.Gold;
		}
		set {
			this._Bag.Gold = value;
		}
	}

	public Bag Bag {
		get {
			return this._Bag;
		}
	}

	public int Exp {
		get {
			return this._Exp;
		}
		set {
			this._Exp += value;
		}
	}
}
