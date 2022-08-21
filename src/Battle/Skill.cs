public class Skill {
	protected string Name { get; }
	protected string School { get; }
	protected string Duration { get; }
	protected string Range { get; }
	protected int Cost { get; }

	public Skill(string name, string school, string duration, string range, int cost) {
		Name = name;
		School = school;
		Duration = duration;
		Range = range;
		Cost = cost;
	}
}
