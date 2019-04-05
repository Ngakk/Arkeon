using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    MonsterBase currMonster;
    public Monster allMonsters;
    int MonsterIndex;

    public Text Number;
    public InputField Name;
    public InputField Types;
    public InputField CatchRate;
    public InputField ExpRate;
    public InputField EVYield;
    public InputField Learnset;
    public Slider MaleRatio;
    public InputField Atk;
    public InputField Def;
    public InputField SpAtk;
    public InputField SpDef;
    public InputField Speed;
    public Text HP;


    // Start is called before the first frame update
    void Start()
    {
        //Cargo el archivo Items.json desde Resources
        string filePath = "pokes.json".Replace(".json", "");
        TextAsset ArchivoTarget = Resources.Load<TextAsset>(filePath);
        string elJson = "{\"Monsters\":" + ArchivoTarget.text + "}";
        Debug.Log(elJson);

        allMonsters = new Monster();
        allMonsters.Monsters = new List<MonsterBase>();

        allMonsters = JsonUtility.FromJson<Monster>(elJson);

        Debug.Log(allMonsters.ToString());

        if (allMonsters == null)
        {
            Debug.LogError("All monsters is null");
            return;
        }

        if (allMonsters.Monsters == null)
        {
            Debug.LogError("All monsters . monsters is null");
            return;
        }

        if (allMonsters.Monsters.Count < 1) return;

        //MonsterIndex = 0;
        //currMonster = allMonsters.Monsters[MonsterIndex];

        //SetOnScreen(currMonster);
    }

    void SetOnScreen(MonsterBase m)
    {
        Number.text += m.number.ToString();
        Name.text = m.name;
        Types.text = string.Join(",", Array.ConvertAll(m.types.ToArray(), i => i.ToString()));
    }
}
