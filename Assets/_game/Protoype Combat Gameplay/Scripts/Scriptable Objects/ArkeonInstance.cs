using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonInstance", menuName = "Arkeon Creature/Arkeon Instance", order = 1)]
    public class ArkeonInstance : ScriptableObject
    {
        public Sprite sprite;
        public string myName;
        public float currentHp;
        public ArkeonStats stats = new ArkeonStats();
        public List<ArkeonAttack> attacks = new List<ArkeonAttack>();
        public ArkeonData arkeonData;
    }

    [Serializable]
    public class ArkeonStats
    {
        public ArkeonStats(int _lvl, int _maxHp, int _maxMp, int _atk, int _def, int _cost, ArkeonElement _type)
        {
            lvl = _lvl;
            maxHp = _maxHp;
            maxMp = _maxMp;
            atk = _atk;
            def = _def;
            cost = _cost;
            type = _type;
        }

        public ArkeonStats()
        {
            lvl = 0;
            maxHp = 0;
            maxMp = 0;
            atk = 0;
            def = 0;
            cost = 0;
            type = null;
        }

        public int lvl;
        public int maxHp;
        public int maxMp;
        public int atk;
        public int def;
        public int cost;
        public ArkeonElement type;

        public static ArkeonStats operator +(ArkeonStats s1, ArkeonStats s2)
        {
            ArkeonElement final;
            if (s1.type != null)
                final = s1.type;
            else if (s2.type != null)
                final = s2.type;
            else
                final = new ArkeonElement();

            return new ArkeonStats(s1.lvl+s2.lvl, s1.maxHp+s2.maxHp, s1.maxMp+s2.maxMp, s1.atk+s2.atk, s1.def+s2.def, s1.cost+s1.cost, final);
        }
    }
}