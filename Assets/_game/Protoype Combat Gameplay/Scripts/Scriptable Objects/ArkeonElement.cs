using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu(fileName = "ArkeonElement", menuName = "Arkeon Element", order = 0)]
    public class ArkeonElement : ScriptableObject
    {
        public List<ArkeonElement> defeatedBy;
    }
}