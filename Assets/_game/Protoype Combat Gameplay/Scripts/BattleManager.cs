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
        public ArenaPointReference arenaPointReference;
        public bool IsSingleEnemy = true;

        private List<int> allyArkeonsOut = new List<int> ();
        private List<int> enemyArkeonsOut = new List<int> ();

        //Se puede:
        //Invocar
        //Atacar
        //Usar Items
        //Escapar

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                InvokeArkeonRequest(true, 0);
            }
        }

        /// <summary>
        /// Invoca un arkeon desde el equipo del jugador, _id = el numero del arkeon en el arreglo de equipo. No hace nada si la invocación no se puede hacer.
        /// </summary>
        /// <param name="_id"></param>
        public void InvokeArkeonRequest(bool _ally, int _id)
        {
            //Checa si se puede
            PlayerCharacterBattle summoner = _ally ? Player : EnemyCharacter;

            if((_ally && allyArkeonsOut.Count >= 3 && !allyArkeonsOut.Contains(_id)) || (!_ally && enemyArkeonsOut.Count >= 3 && !enemyArkeonsOut.Contains(_id)))
            {
                Debug.Log("Ya estan llenos todos los espacios de invocación");
                return;
            }

            if(summoner.ArkeonTeam.Count > _id)
            {
                if (summoner.ArkeonTeam[_id].Stats.HP > 0 && summoner.ArkeonTeam[_id].Stats.Cost <= summoner.MP)
                    InvokeArkeon(_ally, _id);
                else
                    Debug.Log("No se puede invocar ese arkeon");
            }
            else
            {
                Debug.Log("Estas intentando invocar un arkeon con id que sobrepasa el tamaño del equipo: id = " + _id);
            }
        }

        private void InvokeArkeon(bool _ally, int _id)
        {
            GameObject _spawned = SpawnArkeon(_ally, _id);
            _spawned.GetComponent<Animator>().SetTrigger("Show");
            allyArkeonsOut.Add(_id);
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

        // ------------------ Funcionalidades ------------------
        private GameObject SpawnArkeon(bool _ally, int _id)
        {
            PlayerCharacterBattle summoner = _ally ? Player : EnemyCharacter;
            Transform point = arenaPointReference.GetInvokePoint(true, allyArkeonsOut.Count);
            allyArkeonsOut.Add(_id);

            GameObject go = Instantiate(summoner.ArkeonTeam[_id].ModelPrefab, point.position, Quaternion.identity);
            go.transform.LookAt(go.transform.position + (_ally ? Vector3.forward : Vector3.back));

            return go;
        }
    }
}

//TODO: arreglar animacines, hacer que no se invoque si ya esta afuera