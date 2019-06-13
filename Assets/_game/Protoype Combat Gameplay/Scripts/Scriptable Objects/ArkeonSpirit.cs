using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu(fileName = "ArkeonData", menuName = "Arkeon Creature/Arkeon Data", order = 2)]
    public class ArkeonSpirit : ScriptableObject
    {
        public string originalName;
        public GameObject modelPrefab; //Only for prototyping, perhaps

        private Animator anim;

        public Animator GetAnimator()
        {
            if(!anim)
            {
                anim = modelPrefab.GetComponent<Animator>();
            }

            return anim;
        }
    }
}