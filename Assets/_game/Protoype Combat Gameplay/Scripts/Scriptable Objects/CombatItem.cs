using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu]
    public class CombatItem : ScriptableObject
    {
        public string Name;
        public string Description;

        public int Value;
        public bool AffectsHealth = false;
        public bool AffectMana = false;
    }
}