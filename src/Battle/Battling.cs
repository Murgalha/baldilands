namespace Baldilands;

public class Battling {
    public ICreature Creature;
    public bool ActionSet;
    public string Cmd;
    public bool Run;
    public bool Dodge;
    private string _BattleD;

    public bool IsPlayer { get; }

    public Battling(ICreature c, string bd, bool p) {
        this.Creature = c;
        this.ActionSet = false;
        this.Cmd = "";
        this.Run = false;
        this.Dodge = false;
        this._BattleD = bd;
        IsPlayer = p;
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

    public int StatSum() {
        return this.Creature.Strength + this.Creature.Ability + this.Creature.Resistance +
               this.Creature.Armor + this.Creature.Firepower;
    }
}
