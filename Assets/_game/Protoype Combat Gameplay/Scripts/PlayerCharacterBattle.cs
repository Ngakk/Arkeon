using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class PlayerCharacterBattle : MonoBehaviour
    {
        public int HP, MP;
        public List<CombatItem> Inventory = new List<CombatItem>();
        public List<ArkeonSpirit> ArkeonTeam = new List<ArkeonSpirit>();
    }
}