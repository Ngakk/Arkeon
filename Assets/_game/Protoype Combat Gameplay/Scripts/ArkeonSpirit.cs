using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu]
    public class ArkeonSpirit : ScriptableObject
    {
        public GameObject ModelPrefab; //Only for prototyping
        public ArkeonStats Stats;
        public List<ArkeonAttack> Attacks = new List<ArkeonAttack>();
    }
}