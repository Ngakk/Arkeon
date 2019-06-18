using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonData", menuName = "Arkeon Creature/Arkeon Data", order = 2)]
    public class ArkeonData : ScriptableObject
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