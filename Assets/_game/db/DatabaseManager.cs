using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    MonsterBase currMonster;
    List<MonsterBase> allMonsters;
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
        string elJson = ArchivoTarget.text;

        allMonsters = JsonUtility.FromJson<List<MonsterBase>>(elJson);

        if (allMonsters.Count < 1) return;

        MonsterIndex = 0;
        currMonster = allMonsters[MonsterIndex];

        SetOnScreen(currMonster);
    }

    void SetOnScreen(MonsterBase m)
    {
        Number.text += m.number.ToString();
        Name.text = m.name;
        //Types.text = string.Join(",", m.types.ToArray());
    }
}
