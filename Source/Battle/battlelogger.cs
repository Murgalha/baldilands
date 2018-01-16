public class BattleLogger {
	
	private string _TurnLog;
	private string _CombatLog;

	public BattleLogger() {
		this._TurnLog = "";
		this._CombatLog = "";
	}

	public void SaveTurnLog(Creature c, bool IsPlayer, string cmd, int damage, bool crit, bool dodge) {
		this._TurnLog = "";
		if(IsPlayer) {
			if(dodge)
				this._TurnLog += "The enemy dodged your attack!";
			else if(cmd.Equals("run")) {
				this._TurnLog += "You prepare to run";
			}
			else if(damage != 0) {
				this._TurnLog += "You hit the enemy. It loses " + damage + " life point" + (damage > 1 ? "s" : "");
				if(crit)
					this._TurnLog += ".It is a critical hit!";
			}
			else if(cmd.Equals("dodge")) {
				this._TurnLog += "You attempt to dodge";
			}
			else if((c.Weapon == null || c.Weapon.Type == "melee") && cmd.Equals("ranged attack")) {
				this._TurnLog += "You do not have a ranged weapon equipped. No damage dealt";
			}
		}
		else {
			if(dodge) {
				this._TurnLog += "You dodged the attack!";
			}
			else if(cmd.Equals("run")) {
				this._TurnLog += "The enemy prepares to run";
			}
			if(damage != 0) {
				this._TurnLog += "The enemy hits you. You lose " + damage + " life point" + (damage > 1 ? "s" : "");
				if(crit)
					this._TurnLog += ".It is a critical hit!";
			}
			else if(cmd.Equals("dodge")) {
				this._TurnLog += "The enemy attempts to dodge.";
			}
			else if((c.Weapon == null || c.Weapon.Type == "melee") && cmd.Equals("ranged attack")) {
				this._TurnLog += "The enemy does not have a ranged weapon equipped. No damage dealt";
			}
		}
		this._TurnLog += "\n";
		this._CombatLog += TurnLog;
	}

	public void SaveRunLog(bool HasRun) {
		if(HasRun)
			this._TurnLog = "You ran away!\n";
		else
			this._TurnLog = "You failed to run away\n";
		this._CombatLog += this._TurnLog;
	}

	public string TurnLog {
		get {
			return this._TurnLog;
		}
		set {
			this._TurnLog = value;
		}
	}

	public string CombatLog {
		get {
			return this._CombatLog;
		}
		set {
			this._CombatLog = value;
		}
	}
}