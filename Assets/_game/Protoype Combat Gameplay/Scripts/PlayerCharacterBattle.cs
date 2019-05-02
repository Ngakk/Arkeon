using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class PlayerCharacterBattle : MonoBehaviour
    {
        public int HP = 20, MP;
        public List<CombatItem> Inventory = new List<CombatItem>();
        public List<ArkeonSpirit> ArkeonTeam = new List<ArkeonSpirit>();

        public void SendArkeonForward(int _arkeonId, GameObject _arkeon)
        {
            _arkeon.GetComponent<Animator>().SetTrigger("GoForward");
        }

        public void ArkeonAttackAnimation(int _arkeonId, int _arkeonAttack, GameObject _arkeon)
        {
            //TODO: que haga diferente animacion dependiendo del ataque
            _arkeon.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}