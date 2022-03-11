public class Item {
	public readonly string Name;
	public readonly string Type;
	public readonly string Category;
	public readonly int Buff;
	public readonly int Value;

	public Item(string name, string type, string category, int buff, int value) {
		Name = name;
		Type = type;
		Category = category;
		Buff = buff;
		Value = value;
	}

	public Item(Item It) {
		Name = It.Name;
		Type = It.Type;
		Category = It.Category;
		Buff = It.Buff;
		Value = It.Value;
	}
}
