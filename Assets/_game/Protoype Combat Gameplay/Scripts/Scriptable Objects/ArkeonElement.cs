using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonElement", menuName = "Arkeon Element", order = 0)]
    public class ArkeonElement : ScriptableObject
    {
        public int db_id;
        public Sprite sprite;
        public List<ArkeonElement> defeatedBy;
    }
}