using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
    [CreateAssetMenu(fileName = "ArkeonTeam", menuName = "Arkeon Creature/Arkeon Team", order = 0)]
    public class ArkeonTeam : ScriptableObject
    {
        public List<ArkeonSpirit> lightBook = new List<ArkeonSpirit>();
        public List<ArkeonSpirit> darkBook = new List<ArkeonSpirit>();
        public List<ArkeonSpirit> natureBook = new List<ArkeonSpirit>();
    }
}
