namespace Baldilands;

public class Item {

	private string _Name;
	private string _Type;
	private string _Category;
	private int _Buff;
	private int _Value;

	public Item(string name, string type, string category, int buff, int value) {
		this._Name = name;
		this._Type = type;
		this._Category = category;
		this._Buff = buff;
		this._Value = value;
	}

	public Item(Item It) {
		this._Name = It.Name;
		this._Type = It.Type;
		this._Category = It.Category;
		this._Buff = It.Buff;
		this._Value = It.Value;
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

	public string Category {
		get {
			return this._Category;
		}
	}

	public int Value {
		get {
			return this._Value;
		}
	}
}
