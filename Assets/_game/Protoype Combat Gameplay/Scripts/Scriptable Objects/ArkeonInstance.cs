﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonInstance", menuName = "Arkeon Creature/Arkeon Instance", order = 1)]
    public class ArkeonInstance : ScriptableObject
    {
        public string myName;
        public float currentHp;
        public ArkeonStats stats = new ArkeonStats();
        public List<ArkeonAttack> attacks = new List<ArkeonAttack>();
        public ArkeonData arkeonData;
    }

    [Serializable]
    public class ArkeonStats
    {
        public int lvl;
        public int maxHp;
        public int maxMp;
        public int atk;
        public int def;
        public int cost;
        public ArkeonElement type;
    }
}