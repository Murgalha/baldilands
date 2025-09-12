namespace Baldilands;

public static class Descriptor {
	/// <summary>
	/// Description of 'Strength' on character creation
	/// </summary>
	public static string Strength => "Strength is your capacity to lift weigth, push and pull things, cause damage with punches and weapon strikes.\nIt will be added to your Ability to determine your Attack Power when you are on a melee fight.\nThe more Strength you have, the more damage is dealt";

	/// <summary>
	/// Description of 'Firepower' on character creation
	/// </summary>
	public static string Firepower => "Firepower measures your capacity of dealing ranged damage.\nAs ocurred with Strength, Firepower is added to your Ability to determine your Attack Power on a ranged attack";

	/// <summary>
	/// Description of 'Resistance' on character creation
	/// </summary>
	public static string Resistance => "Resistance is the constitution and vigor of your mind and body.\nThe more Resistance, the more injuries you can suffer before dying.\nIt also determines your Health Points (HP) and Magic Points (MP)";


	/// <summary>
	/// Description of 'Armor' on character creation
	/// </summary>
	public static string Armor => "Armor represents your body protection.\nBesides the name, it does not need to be an actual armor, it can be your own carapace or skin.\nWhen you receive an attack, Armor is added to Ability to determine your Defense Power";

	/// <summary>
	/// Description of 'Ability' on character creation
	/// </summary>
	public static string Ability => "The most important of the characteristics. It is not recomended for you to have less than 2 points on it.\nAbility corresponds to agility, speed and, in a way, your intelligence.\nAbility is added to Strength to determine your Attack Power on melee attacks, or added to Firepower on ranged attacks.\nIt is also added to Armor to calculate your Defense Power";
}
