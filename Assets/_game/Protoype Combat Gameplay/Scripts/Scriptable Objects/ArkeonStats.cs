using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu]
    public class ArkeonStats : ScriptableObject
    {
        public int LVL;
        public int HP;
        public int MaxHP;
        public int Atk;
        public int Def;
        public int Cost;
        public ArkeonElement Type;
    }
}
