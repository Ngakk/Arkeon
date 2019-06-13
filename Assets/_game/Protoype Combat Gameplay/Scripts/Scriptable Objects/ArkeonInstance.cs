using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu(fileName = "ArkeonInstance", menuName = "Arkeon Creature/Arkeon Instance", order = 1)]
    public class ArkeonInstance : ScriptableObject
    {
        public string myName;
        public int lvl;
        public float currentHp;
        public ArkeonStats stats;
        public List<ArkeonAttack> attacks = new List<ArkeonAttack>();
        public ArkeonSpirit arkeonData;
    }

    public class ArkeonStats
    {
        public int lvl;
        public int hp;
        public int maxHp;
        public int atk;
        public int def;
        public int cost;
        public ArkeonElement type;
    }
}