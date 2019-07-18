using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseStats
{
    public int hp { get; set; }
    public int atk { get; set; }
    public int def { get; set; }
    public int spAtk { get; set; }
    public int spDef { get; set; }
    public int speed { get; set; }
}

public class MonsterBase
{
    public int number { get; set; }
    public string name { get; set; }
    public List<int> types { get; set; }
    public BaseStats baseStats { get; set; }
    public int catchRate { get; set; }
    public int experienceRate { get; set; }
    public List<int> learnSet { get; set; }
    public List<int> evYield { get; set; }
    public int maleRatio { get; set; }
}
