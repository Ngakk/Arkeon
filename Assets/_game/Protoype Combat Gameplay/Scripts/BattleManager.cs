using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class BattleManager : MonoBehaviour
    {
        public PlayerCharacterBattle Player;
        public ArkeonSpirit SingleEnemy;
        public PlayerCharacterBattle EnemyCharacter;
        public bool IsSingleEnemy = true;

        //Se puede:
        //Invocar
        //Atacar
        //Usar Items
        //Escapar

        public void InvokeArkeonRequest(int _id)
        {

        }

        private void InvokeArkeon(int _id)
        {

        }

        public void ArkeonAttackRequest(int _arkeonId, int _attackId)
        {

        }

        private void ArkeonAttack(int _arkeonId, int _attackId)
        {

        }

        public void UseItemRequest(int _itemId)
        {

        }

        private void UseItem(int _itemId)
        {

        }

        public void RunRequest()
        {

        }

        private void Run()
        {

        }

        //TODO: Terminar animaciones prototipo, calarlas con animator y luego hacer eventos para llamarlos y la madre
    }
}