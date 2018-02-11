public class Item {
	
	private string _Name;
	private string _Type;
	private int _Buff;
	private int _Value;

	public Item(string name, string type, int buff, int value) {
		this._Name = name;
		this._Type = type;
		this._Buff = buff;
		this._Value = value;
	}

	public int Buff {
		get {
			return this._Buff;
		}
	}

	public string Type {
		get {
			return this._Type;
		}
	}

	public string Name {
		get {
			return this._Name;
		}
	}

	public int Value {
		get {
			return this._Value;
		}
	}
}