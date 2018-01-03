public static class Dice {

	public static int Roll(int faces) {
		System.Random rnd = new System.Random((int)System.DateTime.Now.Ticks);
		return (rnd.Next()%faces)+1;
	}

	public static int[] MultiRoll(int faces, int times) {

		if(faces < 4)
			throw new System.ArgumentException("Enter a number of faces larger than 3");

		if(times < 2)
			throw new System.ArgumentException("Enter a number of times larger than 1");

		int[] result = new int[times];
		System.Random rnd = new System.Random((int)System.DateTime.Now.Ticks);

		for(int i = 0; i < times; i++)
			result[i] = (rnd.Next()%faces)+1;

		return result;
	}
}