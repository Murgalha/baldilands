using System;
using System.IO;
using System.Xml.Serialization;

namespace Baldilands;

public class SaveExpert {
    private string _savePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game data", "save");
    private XmlSerializer _serializer = new(typeof(HeroDto));

    public bool SaveGame(Hero H, int slot) {
        try {
            Directory.CreateDirectory(_savePath);

            string slotPath = GetSlotPath(slot);
            FileStream stream = new(slotPath, FileMode.Truncate, FileAccess.Write);
            _serializer.Serialize(stream, H.ToDto());

            return true;
        } catch {
            // TODO: Add logging
            return false;
        }
    }

    public Hero LoadGame(int slot) {
        try {
            string slotPath = GetSlotPath(slot);

            if (!File.Exists(slotPath))
                return null;

            FileStream stream = new(slotPath, FileMode.Open, FileAccess.Read);
            HeroDto heroDto = (HeroDto)_serializer.Deserialize(stream);

            if (heroDto is null)
                return null;

            return heroDto.ToHero();
        } catch {
            // TODO: Add logging
            return null;
        }
    }

    public bool DeleteGame(int slot) {
        try {
            string slotPath = GetSlotPath(slot);
            File.Delete(slotPath);
            return false;
        } catch {
            // TODO: Add logging
            return false;
        }
    }

    public string GetDisplayName(int slot) {
        try {
            string slotPath = GetSlotPath(slot);

            if (!File.Exists(slotPath))
                return string.Empty;

            FileStream stream = new(slotPath, FileMode.Open, FileAccess.Read);
            HeroDto heroDto = (HeroDto)_serializer.Deserialize(stream);

            if (heroDto is null)
                return string.Empty;

            return heroDto.DisplayName;

        } catch {
            // TODO: Add logging
            return string.Empty;
        }
    }

    public string GetSlotPath(int slot) => Path.Combine(_savePath, $"slot{slot}.sav");
}
