using System;

namespace Baldilands;

public class Spell {

	int _Damage;
	int _Duration;
	string _Description;
	string _School;

	public Spell(int dmg, int dur, string desc, string schl) {
		this._Damage = dmg;
		this._Duration = dur;
		this._Description = desc;
		this._School = schl;
	}

	public int Damage {
		get {
			return this._Damage;
		}
	}

	public int Duration {
		get {
			return this._Duration;
		}
	}

	public string Description {
		get {
			return this._Description;
		}
	}

	public string School {
		get {
			return this._School;
		}
	}
}
