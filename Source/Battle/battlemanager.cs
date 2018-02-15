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
			return this.c.Strength + this.c.Ability + this.c.Resistance + this.c.Armor + this.c.Firepower;
		}
	}

	private Battling b1;
	private Battling b2;
	private List<Battling> list;
	private BattleLogger BL;
	private bool Ended;
	private bool EnemyDodge;
	public int turn;

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
		this.Ended = false;
		this.EnemyDodge = false;
		this.BL = new BattleLogger();
	}

	private bool CheckDodge(int Buff) {
		int dice = Dice.Roll(100);
		return (dice <= Buff+2 ? true : false);
	}

	public void SaveRunLog(bool HasRun) {
		BL.SaveRunLog(HasRun);
	}

	public void SetTurn(string cmd1, string cmd2) {
		int NextP = (turn+1)%2;
		list[turn].SetCommand(cmd1); 
		list[NextP].SetCommand(cmd2); 
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
		BL.SaveTurnLog(list[turn].c, list[turn].IsPlayer(), cmd, damage, IsCritical, DodgeSuccess);
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

	public string TurnLog {
		get {
			return BL.TurnLog;
		}
	}

	public string CombatLog {
		get {
			return BL.CombatLog;
		}
	}

	public bool HasEnded() {
		return this.Ended;
	}

	public Reward GetReward() {
		int Exp, Gold;
		Item item = null;
		if(b2.StatSum() <= b1.StatSum()/2)
			Exp = 0;
		else if(b2.StatSum() >= 2*b1.StatSum())
			Exp = 2;
		else
			Exp = 1;
		if(Dice.Roll(100) <= 5)
			item = b2.c.Equip.Weapon;
		Gold = Exp*2;
		Reward r = new Reward(item, Exp, Gold);
		return r;
	}

	public int LostExp() {
		int Exp;
		if(b2.StatSum() <= b1.StatSum()/2)
			Exp = 2;
		else if(b2.StatSum() >= 2*b1.StatSum())
			Exp = 1;
		else
			Exp = 1;
		return Exp;
	}
}
