using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "ArkeonData", menuName = "Arkeon Creature/Arkeon Data", order = 2)]
    public class ArkeonData : ScriptableObject
    {
        public int db_id;
        public string originalName;
        public string description;
        public BaseStats baseStats = new BaseStats();
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

        public ArkeonStats GetStatsFromBD(int _lvl)
        {
            return new ArkeonStats();
        }

        public List<ArkeonAttack> GetAttacksFromBD(int _lvl)
        {
            return new List<ArkeonAttack>();
        }

        public void GetBaseStatsFromDB()
        {
            MonsterBase temp = DBAccess.LoadArkeon(db_id);
            baseStats = temp.baseStats;
            originalName = temp.name;
            DBAccess. //TODO: hacer que busque los tipos, luego que se pueda guardar a la BD desde el editor de este script
        }

    }
}
