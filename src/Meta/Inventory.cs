using System;
using System.IO;
using System.Xml.Serialization;

namespace Baldilands;

public static class Inventory
{
    private static string _itemsPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "game data",
        "items"
    );
    private static XmlSerializer _serializer = new(typeof(ItemDto));

    public static bool CreateFile(Item item)
    {
        try
        {
            Directory.CreateDirectory(_itemsPath);

            string itemPath = GetItemPath(item);
            FileStream stream = new(itemPath, FileMode.Create, FileAccess.Write);
            _serializer.Serialize(stream, item.ToDto());

            return true;
        }
        catch
        {
            // TODO: Add logging
            return false;
        }
    }

    public static Item? Load(string file)
    {
        try
        {
            if (!File.Exists(file))
                return null;

            FileStream stream = new(file, FileMode.Open, FileAccess.Read);
            ItemDto itemDto = (ItemDto)_serializer.Deserialize(stream);

            if (itemDto is null)
                return null;

            return itemDto.ToItem();
        }
        catch
        {
            // TODO: Add logging
            return null;
        }
    }

    public static string GetItemPath(Item item)
    {
        return _GetItemPath(item.Name);
    }

    public static string GetItemPath(string itemName)
    {
        return _GetItemPath(itemName);
    }

    private static string _GetItemPath(string itemName)
    {
        var slugName = itemName.Replace(' ', '-').ToLower();
        return Path.Combine(_itemsPath, $"{slugName}.itm");
    }
}
