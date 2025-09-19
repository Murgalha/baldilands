using System;

namespace Baldilands;

[Serializable]
public class EquipmentDto {
    public ItemDto Head;
    public ItemDto Torso;
    public ItemDto Leg;
    public ItemDto Hand;
    public ItemDto Weapon;
    public int AttackBuff;
    public int DefenseBuff;
}
