using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DBAccess
{
    public static MonsterBase LoadArkeon(int number)
    {
        var monsters = LoadArkeons();

        for (int i =0; i< monsters.Count; i++)
        {
            if (monsters[i].number == number)
                return monsters[i];
        }

        return null;
    }

    public static List<MonsterBase> LoadArkeons()
    {
        //Cargo el archivo Items.json desde Resources
        string filePath = "pokes.json".Replace(".json", "");
        TextAsset ArchivoTarget = Resources.Load<TextAsset>(filePath);
        string elJson = ArchivoTarget.text;

        return JsonConvert.DeserializeObject<List<MonsterBase>>(elJson);
    }

    public static List<AttackBase> LoadAttacks()
    {
        string filePath = "attaks.json".Replace(".json", "");
        TextAsset ArchivoTarget = Resources.Load<TextAsset>(filePath);
        string elJson = ArchivoTarget.text;

        return JsonConvert.DeserializeObject<List<AttackBase>>(elJson);
    }

    public static AttackBase LoadAttack(int atk)
    {
        var atks = LoadAttacks();
        for (int i = 0; i < atks.Count; i++)
        {
            if (atks[i].id == atk)
            {
                return atks[i];
            }
        }

        return null;
    }

    /// <summary>
    /// Recibe un Monsterbase, lo inserta en la base de datos y devuelve el <code>numero</code> correspondiente al arkeon recien insertado
    /// </summary>
    /// <returns></returns>
    public static int AddNewArkeon(MonsterBase m, bool AutoCalculateNumber = true)
    {
        var allArks = LoadArkeons();

        if (AutoCalculateNumber)
        {
            m.number = allArks.Count + 1;
        }

        allArks.Add(m);

        return UpdateAllArkeons(allArks);
    }

    /// <summary>
    /// Recibe una lista de <code>MosterBase</code>, borra toda la BD y guarda esa lista en su lugar
    /// </summary>
    /// <param name="monsters"></param>
    /// <returns></returns>
    public static int UpdateAllArkeons(List<MonsterBase> monsters)
    {
        string json = JsonConvert.SerializeObject(monsters);
        File.WriteAllText("Assets/Resources/pokes.json", json);

        return monsters.Count;
    }

    /// <summary>
    /// Recibe un AttackBase, lo inserta en la base de datos y devuelve el <code>id</code> correspondiente al ataque recien insertado
    /// </summary>
    /// <returns></returns>
    public static int AddNewAttack(AttackBase a, bool AutoCalculateId = true)
    {
        var allAtks = LoadAttacks();

        if (AutoCalculateId)
        {
            a.id = allAtks.Count + 1;
        }

        allAtks.Add(a);

        return UpdateAllAttacks(allAtks);
    }

    /// <summary>
    /// Recibe una lista de <code>AttackBase</code>, borra toda la BD y guarda esa lista en su lugar
    /// </summary>
    /// <returns></returns>
    public static int UpdateAllAttacks(List<AttackBase> attacks)
    {
        string json = JsonConvert.SerializeObject(attacks);
        File.WriteAllText("Assets/Resources/attaks.json", json);

        return attacks.Count;
    }
}
