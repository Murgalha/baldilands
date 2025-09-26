namespace Baldilands;

public class BattleLogger
{
    private string _TurnLog;
    private string _CombatLog;

    public BattleLogger()
    {
        this._TurnLog = "";
        this._CombatLog = "";
    }

    private void _Save(
        ICreature c,
        bool IsPlayer,
        string cmd,
        int damage,
        bool crit,
        bool EnemyDodge
    )
    {
        string WeaponName = (
            c.Equip.Weapon.HasValue ? c.Equip.Weapon.Value.Name : "powerful strike"
        );
        if (IsPlayer)
        {
            if (damage == 0)
            {
                if (
                    cmd.Equals("ranged attack")
                    && ((!c.Equip.Weapon.HasValue) || !c.Equip.Weapon.Value.Type.Equals("ranged"))
                )
                    this._TurnLog += "You do not have a ranged weapon equipped. No damage dealt";
                else if (EnemyDodge)
                    this._TurnLog += "The enemy dodged the attack!";
                else if (cmd.Equals("dodge"))
                    this._TurnLog += "You attempt to dodge";
                else if (cmd.Equals("run"))
                    this._TurnLog += "You prepare to run";
                else
                    this._TurnLog += "The enemy blocked the attack!";
            }
            else if (damage > 0)
            {
                if (cmd.Equals("attack"))
                {
                    this._TurnLog +=
                        "You strike the enemy with your "
                        + WeaponName
                        + ". It loses "
                        + damage
                        + " life point"
                        + (damage > 1 ? "s" : "");
                }
                else if (cmd.Equals("ranged attack"))
                {
                    this._TurnLog +=
                        "You shoot the enemy with your "
                        + c.Equip.Weapon.Value.Name
                        + ". It loses "
                        + damage
                        + " life point"
                        + (damage > 1 ? "s" : "");
                }
                if (crit)
                    this._TurnLog += ". It is a critical hit!";
            }
        }
        else
        {
            if (damage == 0)
            {
                if (
                    cmd.Equals("ranged attack")
                    && ((!c.Equip.Weapon.HasValue) || !c.Equip.Weapon.Value.Type.Equals("ranged"))
                )
                    this._TurnLog +=
                        "The enemy does not have a ranged weapon equipped. No damage dealt";
                if (EnemyDodge)
                    this._TurnLog += "You dodged the attack!";
                else if (cmd.Equals("dodge"))
                    this._TurnLog += "The enemy attempts to dodge";
                else if (cmd.Equals("run"))
                    this._TurnLog += "The enemy prepares to run";
                else
                    this._TurnLog += "You blocked the attack!";
            }
            else if (damage > 0)
            {
                if (cmd.Equals("attack"))
                {
                    this._TurnLog +=
                        "The enemy strikes you with its "
                        + WeaponName
                        + ". You lose "
                        + damage
                        + " life point"
                        + (damage > 1 ? "s" : "");
                }
                else if (cmd.Equals("ranged attack"))
                {
                    this._TurnLog +=
                        "The enemy shoots you with its "
                        + c.Equip.Weapon.Value.Name
                        + ". You lose "
                        + damage
                        + " life point"
                        + (damage > 1 ? "s" : "");
                }
                if (crit)
                    this._TurnLog += ". It is a critical hit!";
            }
        }
        this._TurnLog += "\n";
    }

    public void SaveTurnLog(
        ICreature c1,
        bool IsPlayer1,
        string cmd1,
        int damage1,
        bool crit1,
        bool dodge1
    )
    {
        this._Save(c1, IsPlayer1, cmd1, damage1, crit1, dodge1);
    }

    public void SaveRunLog(bool HasRun)
    {
        if (HasRun)
            this._TurnLog += "You ran away!\n";
        else
            this._TurnLog += "You failed to run away\n";
        this._CombatLog += this._TurnLog;
    }

    public string TurnLog
    {
        get { return this._TurnLog; }
        set { this._TurnLog = value; }
    }

    public string CombatLog
    {
        get { return this._CombatLog; }
        set { this._CombatLog = value; }
    }
}
