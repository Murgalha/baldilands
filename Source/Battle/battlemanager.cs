using System;
using System.Collections.Generic;

public class BattleManager {

	private class Battling {
		public Creature c;
		public bool ActionSet;
		public string Cmd;
		public bool Run;
		private string BattleD;
		private bool _P;

		public Battling(Creature c, string bd, bool p) {
			this.c = c;
			this.ActionSet = false;
			this.Cmd = "";
			this.Run = false;
			this.BattleD = bd;
			this._P = p;
		}

		public bool SetCommand(string cmd) {
			Cmd = cmd;
			Run = false;

			if(Cmd.Equals("run"))
				Run = true;
			ActionSet = true;
			return true;
		}

		public void PostTurn() {
			ActionSet = false;
			Cmd = "";
		}

		public bool RunAttempt() {
			if(CharacteristicCheck.Ability(c, BattleD))
				return true;
			return false;
		}

		public bool IsPlayer() {
			return _P;
		}

		public int StatSum() {
			return this.c.Strength + this.c.Ability + this.c.Resistance + this.c.Armor + this.c.FirePower;
		}
	}

	private Battling b1;
	private Battling b2;
	public int turn;
	private List<Battling> list;
	private string TurnLog;
	private string CombatLog;
	private bool Ended;
	private bool EnemyDodge;

	private int RollIniciative(Creature c) {
		return Dice.Roll(6) + c.Ability;
	}

	public BattleManager(Creature a, Creature b) {
		string bda;
		string bdb;

		if(a.Ability > b.Ability) {
			bda = "easy";
			bdb = "hard";
		}

		else if(a.Ability < b.Ability) {
			bda = "hard";
			bdb = "easy";
		}

		else {
			bda = "normal";
			bdb = "normal";
		}
		this.b1 = new Battling(a, bda, true);
		this.b2 = new Battling(b, bdb, false);
		list = new List<Battling>();

		if(RollIniciative(a) > RollIniciative(b)) {
			list.Add(b1);
			list.Add(b2);
		}
		else {
			list.Add(b2);
			list.Add(b1);
		}
		this.turn = 0;
		this.TurnLog = "";
		this.CombatLog = "";
		this.Ended = false;
		this.EnemyDodge = false;
	}

	private bool CheckDodge(int Buff) {
		int dice = Dice.Roll(100);
		return (dice <= Buff+2 ? true : false);
	}

	public void SaveRunLog(bool HasRun) {
		if(HasRun)
			TurnLog = "You ran away!";
		else
			TurnLog = "You failed to run away";
		TurnLog += "\n";
		CombatLog += TurnLog;
	}

	public void SetTurn(string cmd1, string cmd2) {
		int NextP = (turn+1)%2;
		list[turn].SetCommand(cmd1); 
		list[NextP].SetCommand(cmd2); 
	}

	private void SaveLog(string cmd, int damage, bool crit, bool dodge) {
		TurnLog = "";
		if(list[turn].IsPlayer()) {
			if(dodge)
				TurnLog += "The enemy dodged your attack!";
			else {
				if(cmd.Equals("run")) {
					TurnLog += "You prepare to run";
				}
				if(damage != 0) {
					TurnLog += "You hit the enemy. It loses " + damage + " life point";
					if(damage > 1)
						TurnLog += "s";
					if(crit)
						TurnLog += "It is a critical hit!";
				}
			}
			if(cmd.Equals("dodge")) {
				TurnLog += "You attempt to dodge";
			}
			if((list[turn].c.Weapon == null || list[turn].c.Weapon.Type == "weapon") && cmd.Equals("ranged attack")) {
				TurnLog += "You do not have a ranged weapon equipped. No damage dealt";
			}
		}
		else {
			if(dodge) {
				TurnLog += "You dodged the attack!";
			}
			else {
				if(cmd.Equals("run")) {
					TurnLog += "The enemy prepares to run";
				}
				if(damage != 0) {
					TurnLog += "The enemy hits you. You lose " + damage + " life point";
					if(damage > 1)
						TurnLog += "s";
					if(crit)
						TurnLog += "It is a critical hit!";
				}
			}
			if(cmd.Equals("dodge")) {
				TurnLog += "The enemy attempts to dodge.";
			}
			if((list[turn].c.Weapon == null || list[turn].c.Weapon.Type == "weapon") && cmd.Equals("ranged attack")) {
				TurnLog += "The enemy does not have a ranged weapon equipped. No damage dealt";
			}
		}

		TurnLog += "\n";
		CombatLog += TurnLog;
	}

	public void Turn() {
		int NextP = (turn+1)%2;
		Creature temp = list[turn].c;
		string cmd = list[turn].Cmd;
		Defense d = list[NextP].c.Defense;
		int damage = 0;
		bool IsCritical = false;
		int DodgeBuff = 0;
		bool DodgeSuccess = false;

		if(cmd.Equals("attack")) {
			MeleeAttack a = temp.Melee;
			damage = a.Dmg - d.Def;
			damage = Math.Max(damage, 1);
			IsCritical = a.IsCritical();
		}

		else if(cmd.Equals("ranged attack")) {
			RangedAttack ra = temp.Ranged;
			damage = ra.Dmg - d.Def;
			damage = Math.Max(damage, 0);
			IsCritical = ra.IsCritical();
		}

		else if(cmd.Equals("run"))
			damage = 0;
		
		if(this.EnemyDodge)
			DodgeBuff = 50;
		DodgeSuccess = CheckDodge(DodgeBuff);
		damage = (DodgeSuccess ? 0 : damage);
		this.EnemyDodge = false;

		list[NextP].c.Damage = damage;

		
		if(cmd.Equals("dodge")) {
			this.EnemyDodge = true;
		}

		list[turn].PostTurn();
		if(b1.c.HP == 0 || b2.c.HP == 0)
			this.Ended = true;
		this.SaveLog(cmd, damage, IsCritical, DodgeSuccess);
		turn = NextP;
	}

	public bool CheckRun() {
		Battling B = list[turn];
		if(B.Run && B.RunAttempt()) {
			this.Ended = true;
			return true;
		}
		return false;
	}

	public bool TriedRun() {
		Battling B = list[turn];
		if(B.Run)
			return true;
		return false;
	}

	public string ShowTurnLog() {
		return this.TurnLog;
	}

	public string ShowFullLog() {
		return this.CombatLog;
	}

	public bool HasEnded() {
		return this.Ended;
	}

	public Reward GetReward() {
		int Exp, Gold = 0;
		Item item;
		if(b2.StatSum() <= b1.StatSum()/2)
			Exp = 0;
		else if(b2.StatSum() >= 2*b1.StatSum())
			Exp = 2;
		else
			Exp = 1;
		item = null;
		Reward r = new Reward(item, Exp, Gold);
		return r;
	}

}
