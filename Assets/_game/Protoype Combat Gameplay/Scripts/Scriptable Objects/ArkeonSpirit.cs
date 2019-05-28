using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu]
    public class ArkeonSpirit : ScriptableObject
    {
        public string Name;
        public GameObject modelPrefab; //Only for prototyping, perhaps
        public ArkeonStats stats;
        public List<ArkeonAttack> attacks = new List<ArkeonAttack>();

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