namespace Baldilands;

public class Spell
{
    public int Damage { get; }
    public int Duration { get; }
    public string Description { get; }
    public string School { get; }

    public Spell(int dmg, int dur, string desc, string schl)
    {
        Damage = dmg;
        Duration = dur;
        Description = desc;
        School = schl;
    }
}
