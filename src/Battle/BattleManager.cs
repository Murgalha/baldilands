using System;
using System.Collections.Generic;

namespace Baldilands;

public class BattleManager {
    private class Battling {
        public ICreature Creature;
        public bool ActionSet;
        public string Cmd;
        public bool Run;
        public bool Dodge;
        private string _BattleD;
        private bool _IsPlayer;

        public Battling(ICreature c, string bd, bool p) {
            this.Creature = c;
            this.ActionSet = false;
            this.Cmd = "";
            this.Run = false;
            this.Dodge = false;
            this._BattleD = bd;
            this._IsPlayer = p;
        }

        public bool SetCommand(string cmd) {
            Cmd = cmd;
            ActionSet = true;

            if (Cmd.Equals("run"))
                Run = true;
            return true;
        }

        public void PostTurn() {
            Run = false;
            ActionSet = false;
            Cmd = "";
        }

        public bool RunAttempt() {
            if (CharacteristicCheck.Ability(this.Creature, this._BattleD))
                return true;
            return false;
        }

        public bool IsPlayer() { return this._IsPlayer; }

        public int StatSum() {
            return this.Creature.Strength + this.Creature.Ability + this.Creature.Resistance +
                   this.Creature.Armor + this.Creature.Firepower;
        }
    }

    private Battling b1;
    private Battling b2;
    private List<Battling> list;
    private BattleLogger BL;
    private bool Ended;
    public int turn;
    private bool _RunEnded;

    private int RollIniciative(ICreature c) { return Dice.Roll(6) + c.Ability; }

    public BattleManager(ICreature a, ICreature b) {
        string bda;
        string bdb;

        if (a.Ability > b.Ability) {
            bda = "easy";
            bdb = "hard";
        }

        else if (a.Ability < b.Ability) {
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

        if (RollIniciative(a) > RollIniciative(b)) {
            list.Add(b1);
            list.Add(b2);
        } else {
            list.Add(b2);
            list.Add(b1);
        }
        this.turn = 0;
        this.Ended = false;
        this._RunEnded = false;
        this.BL = new BattleLogger();
    }

    private bool DodgeAttempt(int Buff) {
        int dice = Dice.Roll(100);
        return (dice <= Buff + 2);
    }

    public void SaveRunLog(bool HasRun) { BL.SaveRunLog(HasRun); }

    public void SetTurn(string cmd1, string cmd2, params Spell[] CastSpell) {
        int Next = (turn + 1) % 2;
        if (list[turn].IsPlayer()) {
            list[turn].SetCommand(cmd1);
            list[Next].SetCommand(cmd2);
        } else {
            list[Next].SetCommand(cmd1);
            list[turn].SetCommand(cmd2);
        }
    }

    public bool Turn() {
        int CurrentDamage = 0;
        bool CurrentCrit = false;
        ICreature CurrentCreature = list[turn].Creature;
        int CurrentDodgeBuff = 0;
        bool CurrentRun = false;
        bool CurrentDodgeSuccess = false;
        string CurrentCMD = list[turn].Cmd;
        Defense CurrentDefense = CurrentCreature.GetDefense();

        // check spells

        // save log

        if (CurrentCMD.Equals("attack")) {
            MeleeAttack MA = CurrentCreature.GetMeleeAttack();
            CurrentDamage = MA.Points;
            CurrentCrit = MA.IsCritical;
        }

        else if (CurrentCMD.Equals("ranged attack")) {
            RangedAttack RA = CurrentCreature.GetRangedAttack();
            CurrentDamage = RA.Points;
            CurrentCrit = RA.IsCritical;
        }

        else if (CurrentCMD.Equals("spell")) {
            // spell mechanics
        }

        else if (CurrentCMD.Equals("dodge")) {
            CurrentDodgeBuff = 20;
        }

        else if (CurrentCMD.Equals("run")) {
            CurrentRun = true;
        }

        int Next = (turn + 1) % 2;
        int NextDamage = 0;
        bool NextCrit = false;
        ICreature NextCreature = list[Next].Creature;
        int NextDodgeBuff = 0;
        bool NextRun = false;
        bool NextDodgeSuccess = false;
        string NextCMD = list[Next].Cmd;
        Defense NextDefense = NextCreature.GetDefense();

        if (NextCMD.Equals("attack")) {
            MeleeAttack MA = NextCreature.GetMeleeAttack();
            NextDamage = MA.Points;
            NextCrit = MA.IsCritical;
        }

        else if (NextCMD.Equals("ranged attack")) {
            RangedAttack RA = NextCreature.GetRangedAttack();
            NextDamage = RA.Points;
            NextCrit = RA.IsCritical;
        }

        else if (NextCMD.Equals("spell")) {
            // spell mechanics
        }

        else if (NextCMD.Equals("dodge")) {
            NextDodgeBuff = 20;
        }

        else if (NextCMD.Equals("run")) {
            NextRun = true;
        }

        if (this.DodgeAttempt(CurrentDodgeBuff)) {
            CurrentDodgeSuccess = true;
            NextDamage = 0;
        }

        if (this.DodgeAttempt(NextDodgeBuff)) {
            NextDodgeSuccess = true;
            CurrentDamage = 0;
        }

        CurrentDamage =
            (CurrentDamage - NextDefense.Points < 0 ? 0 : CurrentDamage - NextDefense.Points);

        NextCreature.TakeDamage(CurrentDamage);

        this.BL.TurnLog = "";

        this.BL.SaveTurnLog(CurrentCreature, list[turn].IsPlayer(), CurrentCMD, CurrentDamage,
                            CurrentCrit, NextDodgeSuccess);

        if (NextCreature.HP == 0) {
            this.BL.CombatLog += TurnLog;
            this.Ended = true;
            return false;
        }

        NextDamage =
            (NextDamage - CurrentDefense.Points < 0 ? 0 : NextDamage - CurrentDefense.Points);

        CurrentCreature.TakeDamage(NextDamage);

        this.BL.SaveTurnLog(NextCreature, list[Next].IsPlayer(), NextCMD, NextDamage, NextCrit,
                            CurrentDodgeSuccess);

        this.BL.CombatLog += TurnLog;

        if (CurrentCreature.HP == 0) {
            this.Ended = true;
            return false;
        }

        if (CurrentRun) {
            bool RunSuccess = this.CheckRun(list[turn]);
            this.SaveRunLog(RunSuccess);
            if (RunSuccess) {
                this._RunEnded = true;
                return false;
            } else
                return true;
        }
        if (NextRun) {
            bool RunSuccess = this.CheckRun(list[Next]);
            this.SaveRunLog(RunSuccess);
            if (RunSuccess) {
                this._RunEnded = true;
                return false;
            } else
                return true;
        }

        if (CurrentCreature.HP == 0 || NextCreature.HP == 0)
            this.Ended = true;

        list[turn].PostTurn();
        list[Next].PostTurn();

        return true;
    }

    private bool CheckRun(Battling B) {
        if (B.Run && B.RunAttempt()) {
            this.Ended = true;
            return true;
        }
        return false;
    }

    public bool TriedRun() {
        Battling B = list[turn];
        if (B.Run)
            return true;
        return false;
    }

    public string TurnLog {
        get { return BL.TurnLog; }
    }

    public string CombatLog {
        get { return BL.CombatLog; }
    }

    public bool HasEnded() { return this.Ended; }

    public Reward GetReward() {
        int Exp, Gold;
        Item? item = null;
        if (b2.StatSum() <= b1.StatSum() / 2)
            Exp = 0;
        else if (b2.StatSum() >= 2 * b1.StatSum())
            Exp = 2;
        else
            Exp = 1;
        if (Dice.Roll(100) <= 5)
            item = b2.Creature.Equip.Weapon;
        Gold = Exp * 2;
        Reward r = new Reward(item, Exp, Gold);
        return r;
    }

    public int LostExp() {
        int Exp;
        if (b2.StatSum() <= b1.StatSum() / 2)
            Exp = 2;
        else if (b2.StatSum() >= 2 * b1.StatSum())
            Exp = 1;
        else
            Exp = 1;
        return Exp;
    }

    public bool RunEnded {
        get { return this._RunEnded; }
    }
}
