public static class CharacteristicCheck {

	public static bool Ability(Creature c, string df) {
		int mark = c.Ability;
		System.Random rnd = new System.Random((int)System.DateTime.Now.Ticks);

		if(df.Equals("easy")) {
			mark += (rnd.Next()%2)+2;
		}

		else if(df.Equals("normal")) {
			mark += rnd.Next()%2;
		}

		else if(df.Equals("hard")) {
			mark += (rnd.Next()%3)-3;
		}

		if(mark > 5)
			mark = 5;

		if(Dice.Roll(6) < mark)
			return true;
		else
			return false;
	}
}