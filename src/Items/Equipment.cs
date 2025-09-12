using System;

namespace Baldilands;

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

	public void Equip(Item it) {
		if(it.Type.Equals("head")) {
			if(Head.HasValue)
				DefenseBuff -= Head.Value.Buff;
			Head = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("torso")) {
			if(Torso.HasValue)
				DefenseBuff -= Torso.Value.Buff;
			Torso = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("leg")) {
			if(Leg.HasValue)
				DefenseBuff -= Leg.Value.Buff;
			Leg = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("hand")) {
			if(Hand.HasValue)
				DefenseBuff -= Hand.Value.Buff;
			Hand = it;
			DefenseBuff += it.Buff;
		}

		else if(it.Type.Equals("melee") || it.Type.Equals("ranged")) {
			if(Weapon.HasValue)
				AttackBuff -= Weapon.Value.Buff;
			Weapon = it;
			AttackBuff += it.Buff;
		}
	}

	public Item? Remove(string part) {
		Item? aux = null;
		if(part.Equals("head") && Head != null) {
			aux = Head;
			DefenseBuff -= Head.Value.Buff;
			Head = null;
		}

		else if(part.Equals("torso") && Torso != null) {
			aux = Torso;
			DefenseBuff -= Torso.Value.Buff;
			Torso = null;
		}

		else if(part.Equals("leg") && Leg != null) {
			aux = Leg;
			DefenseBuff -= Leg.Value.Buff;
			Leg = null;
		}

		else if(part.Equals("hand") && Hand != null) {
			aux = Hand;
			DefenseBuff -= Hand.Value.Buff;
			Hand = null;
		}

		else if(part.Equals("weapon") && Weapon != null) {
			aux = Weapon;
			AttackBuff -= Weapon.Value.Buff;
			Weapon = null;
		}
		return aux;
	}
}
