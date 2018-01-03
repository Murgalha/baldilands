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
	}

	private Battling b1;
	private Battling b2;
	public int turn;
	private List<Battling> list;
	private string TurnLog;
	private string CombatLog;
	private bool Ended;

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
	}

	public void SetTurn(string cmd1, string cmd2) {
		int NextP = (turn+1)%2;
		list[turn].SetCommand(cmd1); 
		list[NextP].SetCommand(cmd2); 
	}

	private void SaveLog(int damage, bool crit) {
		if(list[turn].IsPlayer())
			TurnLog = "You hit the enemy. It loses "+damage+" life points. ";
		else
			TurnLog = "The enemy hits you. You lose "+damage+" life points. ";
		if(crit)
			TurnLog += "It's a critical hit!";
		CombatLog += TurnLog;
	}

	public void Turn() {
		int NextP = (turn+1)%2;
		Creature temp = list[turn].c;
		string cmd = list[turn].Cmd;
		Attack a = temp.Attack;
		Defense d = list[NextP].c.Defense;
		int damage = a.Dmg - d.Def;

		if(cmd.Equals("attack")) {
			damage = Math.Max(damage, 1);
			list[NextP].c.Damage = damage;
		}

		else if(cmd.Equals("run"))
			damage = 0;

		list[turn].PostTurn();
		if(b1.c.HP == 0 || b2.c.HP == 0)
			this.Ended = true;
		this.SaveLog(damage, a.IsCritical());
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

	public string ShowTurnLog() {
		return this.TurnLog;
	}

	public string ShowFullLog() {
		return this.CombatLog;
	}

	public bool HasEnded() {
		return this.Ended;
	}

}
