using System.Collections.Generic;

namespace Baldilands;

public class Bag
{
    public int Size => _Items.Count;
    public int Gold { get; set; }
    public IEnumerable<Item> Items => _Items;
    private List<Item> _Items;

    public Bag()
    {
        _Items = new List<Item>();
        Gold = Dice.Roll(6) * 100;
    }

    public void Add(Item it)
    {
        _Items.Add(it);
    }

    public void Remove(Item it)
    {
        _Items.Remove(it);
    }
}
