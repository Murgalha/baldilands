public class Equipment {
	public Item? Head { get; private set; }
	public Item? Torso { get; private set; }
	public Item? Leg { get; private set; }
	public Item? Hand { get; private set; }
	public Item? Weapon { get; private set; }
	public int AttackBuff { get; private set; }
	public int DefenseBuff { get; private set; }

	public Equipment() {
		AttackBuff = 0;
		DefenseBuff = 0;
		Head = null;
		Torso = null;
		Leg = null;
		Hand = null;
		Weapon = null;
	}

	public void Equip(Item? it) {
		if(it == null) return;

		if(it.Type.Equals("head")) {
			if(Head != null)
				DefenseBuff -= Head.Buff;
			Head = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("torso")) {
			if(Torso != null)
				DefenseBuff -= Torso.Buff;
			Torso = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("leg")) {
			if(Leg != null)
				DefenseBuff -= Leg.Buff;
			Leg = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("hand")) {
			if(Hand != null)
				DefenseBuff -= Hand.Buff;
			Hand = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("melee") || it.Type.Equals("ranged")) {
			if(Weapon != null)
				AttackBuff -= Weapon.Buff;
			Weapon = it;
			AttackBuff += it.Buff;
		}
	}

	public Item? Remove(string part) {
		Item? aux = null;
		if(part.Equals("head") && Head != null) {
			aux = Head;
			DefenseBuff -= Head.Buff;
			Head = null;
		}

		else if(part.Equals("torso") && Torso != null) {
			aux = Torso;
			DefenseBuff -= Torso.Buff;
			Torso = null;
		}

		else if(part.Equals("leg") && Leg != null) {
			aux = Leg;
			DefenseBuff -= Leg.Buff;
			Leg = null;
		}

		else if(part.Equals("hand") && Hand != null) {
			aux = Hand;
			DefenseBuff -= Hand.Buff;
			Hand = null;
		}

		else if(part.Equals("weapon") && Weapon != null) {
			aux = Weapon;
			AttackBuff -= Weapon.Buff;
			Weapon = null;
		}
		return aux;
	}
}
