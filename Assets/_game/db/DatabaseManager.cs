using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    MonsterBase currMonster;
    public List<MonsterBase> allMonsters;
    int MonsterIndex;

    #region public variables
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
    public InputField HP;
    public Text MaleRatioLabel;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        MaleRatio.minValue = 0; MaleRatio.maxValue = 100;
        Learnset.characterLimit = 0;

        //Cargo el archivo Items.json desde Resources
        string filePath = "pokes.json".Replace(".json", "");
        TextAsset ArchivoTarget = Resources.Load<TextAsset>(filePath);
        string elJson = ArchivoTarget.text;
        Debug.Log(elJson);

        allMonsters = new List<MonsterBase>();

        allMonsters = JsonConvert.DeserializeObject<List<MonsterBase>>(elJson);


        Debug.Log(allMonsters.ToString());

        if (allMonsters == null)
        {
            Debug.LogError("All monsters is null");
            return;
        }

        if (allMonsters.Count < 1) return;

        MonsterIndex = 0;
        currMonster = allMonsters[MonsterIndex];

        SetOnScreen(currMonster);
    }

    void SetOnScreen(MonsterBase m)
    {
        Number.text = "Number: " + m.number.ToString();
        Name.text = m.name;
        Types.text = string.Join(",", Array.ConvertAll(m.types.ToArray(), i => i.ToString()));
        CatchRate.text = m.catchRate.ToString();
        ExpRate.text = m.experienceRate.ToString();
        EVYield.text = string.Join(",", Array.ConvertAll(m.evYield.ToArray(), i => i.ToString()));
        Learnset.text = string.Join(",", Array.ConvertAll(m.learnSet.ToArray(), i => i.ToString()));
        MaleRatio.value = m.maleRatio;
        Atk.text = m.baseStats.atk.ToString();
        Def.text = m.baseStats.def.ToString();
        SpAtk.text = m.baseStats.spAtk.ToString();
        SpDef.text = m.baseStats.spDef.ToString();
        Speed.text = m.baseStats.speed.ToString();
        HP.text = m.baseStats.hp.ToString();
        MaleRatioLabel.text = m.maleRatio.ToString();
    }

    public void NextPoke()
    {
        if (MonsterIndex < allMonsters.Count - 1)
        {
            currMonster = allMonsters[++MonsterIndex];
            SetOnScreen(currMonster);
        }
    }

    MonsterBase ScreenToObj(int newNumber = -1)
    {
        MonsterBase p = new MonsterBase
        {
            number = newNumber > 0 ? newNumber : currMonster.number,
            name = Name.text,
            types = Types.text.Split(',').Select(int.Parse).ToList(),
            baseStats = new BaseStats()
            {
                hp = int.Parse(HP.text),
                atk = int.Parse(Atk.text),
                def = int.Parse(Def.text),
                spAtk = int.Parse(SpAtk.text),
                spDef = int.Parse(SpDef.text),
                speed = int.Parse(Speed.text)
            },
            catchRate = int.Parse(CatchRate.text),
            experienceRate = int.Parse(ExpRate.text),
            learnSet = Learnset.text.Split(',').Select(int.Parse).ToList(),
            evYield = EVYield.text.Split(',').Select(int.Parse).ToList(),
            maleRatio = (int)MaleRatio.value
        };

        return p;
    }

    public void UpdateCurrentPoke()
    {
        currMonster = ScreenToObj();
        allMonsters[MonsterIndex] = currMonster;
        Save();
    }

    public void UpdateMaleRatio()
    {
        float val = MaleRatio.value;
        MaleRatioLabel.text = ((int)val).ToString();
    }

    public void SaveNewPoke()
    {
        MonsterIndex = allMonsters.Count+1;
        MonsterBase newMonster = ScreenToObj(MonsterIndex);
        Number.text = "Number: " + newMonster.number.ToString();
        allMonsters.Add(newMonster);

        Save();
    }

    private void Save()
    {
        string json = JsonConvert.SerializeObject(allMonsters);
        File.WriteAllText("Assets/Resources/pokes.json", json);
    }

    public void PrevPoke()
    {
        if (MonsterIndex > 0)
        {
            currMonster = allMonsters[--MonsterIndex];
            SetOnScreen(currMonster);
        }
    }
}
