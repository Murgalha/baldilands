public static class Descriptor {

	/* Description of 'Strength' on character creation */
	public static string Strength {
		get {
			return "Strength is your capacity to lift weigth, push and pull things, cause damage with punches and weapon strikes.\nIt will be added to your Ability to determine your Attack Power when you are on a melee fight.\nThe more Strength you have, the more damage is dealt";
		}
	}

	/* Description of 'Firepower' on character creation */
	public static string Firepower {
		get {
			return "Firepower measures your capacity of dealing ranged damage.\nAs ocurred with Strength, Firepower is added to your Ability to determine your Attack Power on a ranged attack";
		}
	}

	/* Description of 'Resistance' on character creation */
	public static string Resistance {
		get {
			return "Resistance is the constitution and vigor of your mind and body.\nThe more Resistance, the more injuries you can suffer before dying.\nIt also determines your Health Points (HP) and Magic Points (MP)";
		}
	}

	/* Description of 'Armor' on character creation */
	public static string Armor {
		get {
			return "Armor represents your body protection.\nBesides the name, it does not need to be an actual armor, it can be your own carapace or skin.\nWhen you receive an attack, Armor is added to Ability to determine your Defense Power";
		}
	}

	/* Description of 'Ability' on character creation */
	public static string Ability {
		get {
			return "The most important of the characteristics. It is not recomended for you to have less than 2 points on it.\nAbility corresponds to agility, speed and, in a way, your intelligence.\nAbility is added to Strength to determine your Attack Power on melee attacks, or added to Firepower on ranged attacks.\nIt is also added to Armor to calculate your Defense Power";
		}
	}
}
