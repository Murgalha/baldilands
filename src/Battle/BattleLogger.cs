public class BattleLogger {
	// TODO: Use StringBuilder
	public string TurnLog { get; set; }
	public string CombatLog { get; set; }

	public BattleLogger() {
		this.TurnLog = "";
		this.CombatLog = "";
	}

	private void _Save(Creature c, bool IsPlayer, string cmd, int damage, bool crit, bool EnemyDodge) {
		string WeaponName = (c.Equip.Weapon != null ? c.Equip.Weapon.Name : "powerful strike");
		if(IsPlayer) {
			if(damage == 0) {
				if(cmd.Equals("ranged attack") && (c.Equip.Weapon == null ||
												   !c.Equip.Weapon.Type.Equals("ranged")))
					this.TurnLog += "You do not have a ranged weapon equipped. No damage dealt";
				else if(EnemyDodge)
					this.TurnLog += "The enemy dodged the attack!";
				else if(cmd.Equals("dodge"))
					this.TurnLog += "You attempt to dodge";
				else if(cmd.Equals("run"))
					this.TurnLog += "You prepare to run";
				else
					this.TurnLog += "The enemy blocked the attack!";
			}
			else if(damage > 0) {
				if(cmd.Equals("attack")) {
					this.TurnLog += "You strike the enemy with your " + WeaponName + ". It loses " + damage + " life point" + (damage > 1 ? "s" : "");
				}
				else if(cmd.Equals("ranged attack")) {
					this.TurnLog += "You shoot the enemy with your " + c.Equip.Weapon.Name + ". It loses " + damage + " life point" + (damage > 1 ? "s" : "");
				}
				if(crit)
					this.TurnLog += ". It is a critical hit!";
			}
		}
		else {
			if(damage == 0) {
				if(cmd.Equals("ranged attack") && (c.Equip.Weapon == null ||
												   !c.Equip.Weapon.Type.Equals("ranged")))
					this.TurnLog += "The enemy does not have a ranged weapon equipped. No damage dealt";
				if(EnemyDodge)
					this.TurnLog += "You dodged the attack!";
				else if(cmd.Equals("dodge"))
					this.TurnLog += "The enemy attempts to dodge";
				else if(cmd.Equals("run"))
					this.TurnLog += "The enemy prepares to run";
				else
					this.TurnLog += "You blocked the attack!";
			}
			else if(damage > 0) {
				if(cmd.Equals("attack")) {
					this.TurnLog += "The enemy strikes you with its " + WeaponName + ". You lose " + damage + " life point" + (damage > 1 ? "s" : "");
				}
				else if(cmd.Equals("ranged attack")) {
					this.TurnLog += "The enemy shoots you with its " + c.Equip.Weapon.Name + ". You lose " + damage + " life point" + (damage > 1 ? "s" : "");
				}
				if(crit)
					this.TurnLog += ". It is a critical hit!";
			}
		}
		this.TurnLog += "\n";
	}

	public void SaveTurnLog(Creature c1, bool IsPlayer1, string cmd1, int damage1, bool crit1, bool dodge1) {
		this._Save(c1, IsPlayer1, cmd1, damage1, crit1, dodge1);
	}

	public void SaveRunLog(bool HasRun) {
		if(HasRun)
			this.TurnLog += "You ran away!\n";
		else
			this.TurnLog += "You failed to run away\n";
		this.CombatLog += this.TurnLog;
	}
}
