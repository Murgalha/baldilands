public class Item {
	
	private string _Name;
	private string _Type;
	private int _Buff;

	public Item(string name, string type, int buff) {
		this._Name = name;
		this._Type = type;
		this._Buff = buff;
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
}