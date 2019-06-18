using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public string Name;
        public string Description;

        public int Value;
        public bool AffectsHealth = false;
        public bool AffectMana = false;
    }
}