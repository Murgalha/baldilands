using System;
using System.IO;
using System.Xml.Serialization;

namespace Baldilands;

public static class Bestiary
{
    private static string _monsterPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "game data",
        "monsters"
    );
    private static XmlSerializer _serializer = new(typeof(EnemyDto));

    public static bool CreateFile(Enemy enemy)
    {
        try
        {
            Directory.CreateDirectory(_monsterPath);

            string monsterPath = GetMonsterPath(enemy);
            FileStream stream = new(monsterPath, FileMode.Create, FileAccess.Write);
            _serializer.Serialize(stream, enemy.ToDto());

            return true;
        }
        catch
        {
            // TODO: Add logging
            return false;
        }
    }

    public static Enemy Load(string file)
    {
        try
        {
            if (!File.Exists(file))
                return null;

            FileStream stream = new(file, FileMode.Open, FileAccess.Read);
            EnemyDto enemyDto = (EnemyDto)_serializer.Deserialize(stream);

            if (enemyDto is null)
                return null;

            return enemyDto.ToEnemy();
        }
        catch
        {
            // TODO: Add logging
            return null;
        }
    }

    public static string GetMonsterPath(Enemy enemy)
    {
        string slugName = enemy.Species.ToLower().Replace(' ', '-');
        return Path.Combine(_monsterPath, $"{slugName}.mon");
    }
}
