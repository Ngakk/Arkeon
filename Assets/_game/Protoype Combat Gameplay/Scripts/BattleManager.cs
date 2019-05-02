using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class BattleManager : MonoBehaviour
    {
        public PlayerCharacterBattle PlayerCharacter;
        public ArkeonSpirit SingleEnemy;
        public PlayerCharacterBattle EnemyCharacter;
        public ArenaPointReference ArenaPointReference;
        public bool IsSingleEnemy = true;

        //Un id de un arkeon es la posicion del arkeon en su respectivo equipo, empezando por 0
        private List<int> AllyArkeonsOutId = new List<int> (); //Las ids de los arkeons aliados que ya estan afuera
        private List<int> EnemyArkeonsOutId = new List<int> (); //Los ids de los arkeons enemigos que ya estan afuera

        private List<GameObject> AllyArkeonsOut = new List<GameObject>();
        private List<GameObject> EnemyArkeonsOut = new List<GameObject>();

        //Valores que se mantienen para usarse en funciones llamadas por eventos de animacion
        private bool IsPlayerTurn = true;
        private ArkeonSpirit ArkeonInFront = null;
        private ArkeonSpirit ArkeonDefending = null;
        private ArkeonAttack LastArkeonAttack = null;

        //Se puede:
        //Invocar
        //Seleccionar arkeon
        //Atacar
        //Usar Items
        //Escapar

        private void Awake()
        {
            ManagerStaticBattle.battleManager = this;
        }

        private void Start()
        {
            for(int i = 0; i < PlayerCharacter.ArkeonTeam.Count; i++)
            {
                AllyArkeonsOut.Add(null);
            }

            if (!IsSingleEnemy)
            {
                for (int i = 0; i < EnemyCharacter.ArkeonTeam.Count; i++)
                {
                    EnemyArkeonsOut.Add(null);
                }
            }
            else
            {
                ArkeonDefending = SingleEnemy;
            }
        }

        private void Update()
        {
            //Testing
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                InvokeArkeonRequest(true, 0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                InvokeArkeonRequest(true, 1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                InvokeArkeonRequest(true, 2);
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                CallForthArkeonRequest(true, 0);
            }

            if(Input.GetKeyDown(KeyCode.W))
            {
                ArkeonAttackRequest(true, 0, 0);
            }
        }

        // ------------------------ Invocaciones ------------------------

        /// <summary>
        /// Se hace una peticion para invocar un arkeon desde el equipo del jugador, _ally = si es el jugador o el enemigo, _id = el numero del arkeon en el arreglo de equipo. No hace nada si la invocación no se puede hacer.
        /// </summary>
        /// <param name="_id"></param>
        public void InvokeArkeonRequest(bool _ally, int _id)
        {
            //Checa si se puede
            PlayerCharacterBattle summoner = _ally ? PlayerCharacter : EnemyCharacter;

            //Checa si el invocador ya tiene lleno los espacios de invocacion
            if((_ally && (AllyArkeonsOutId.Count >= 3 || AllyArkeonsOutId.Contains(_id))) || (!_ally && (EnemyArkeonsOutId.Count >= 3 || EnemyArkeonsOutId.Contains(_id))))
            {
                Debug.Log("Ya estan llenos todos los espacios de invocación");
                return;
            }

            if(summoner.ArkeonTeam.Count > _id)
            {
                if (summoner.ArkeonTeam[_id].Stats.HP > 0 && summoner.ArkeonTeam[_id].Stats.Cost <= summoner.MP)
                {
                    /*Debug.Log("Can summon: ");
                    Debug.Log("Ally arkeons out are: " + AllyArkeonsOutId.Count);
                    Debug.Log("Arkeon team count: " + summoner.ArkeonTeam.Count);
                    Debug.Log("Arkeon to summon's hp: " + summoner.ArkeonTeam[_id].Stats.HP);
                    Debug.Log("Summoner MP vs Arkeon Cost: " + summoner.MP + " vs " + summoner.ArkeonTeam[_id].Stats.Cost);*/

                    InvokeArkeon(_ally, _id);
                    
                }
                else
                { Debug.Log("No se puede invocar ese arkeon"); }
            }
            else
            {
                Debug.Log("Estas intentando invocar un arkeon con id que sobrepasa el tamaño del equipo: id = " + _id);
            }
        }

        /// <summary>
        /// Funcion privada que es llamada por InvokeArkeonRequest si es que los parametros que le mandaron son correctos
        /// </summary>
        /// <param name="_ally"></param>
        /// <param name="_id"></param>
        private void InvokeArkeon(bool _ally, int _id)
        {
            GameObject _spawned = SpawnArkeon(_ally, _id);
            _spawned.GetComponent<Animator>().SetTrigger("Show");
            AllyArkeonsOutId.Add(_id); 
        }

        // ------------------------ Preparaciones ------------------------

        /// <summary>
        /// Se hace una peticion para hacer un arkeon hacia enfrente para que pueda atacar, _ally = si es el jugador o el enemigo, _id = el numero del arkeon en el arreglo de equipo. No hace nada si la invocación no se puede hacer.
        /// </summary>
        /// <param name="_ally"></param>
        /// <param name="_is"></param>
        public void CallForthArkeonRequest(bool _ally, int _id)
        {
            List<int> arkeonsOut = _ally ? AllyArkeonsOutId : EnemyArkeonsOutId;

            if (arkeonsOut.Contains(_id))
            {
                //El arkeon si esta afuera
                CallForthArkeon(_ally, _id);
            }
            else
            {
                Debug.Log("You are trying to move an arkeon that is not out");
            }
        }

        /// <summary>
        /// Funcion privada que es llamada por CallForthArkeonRequest cuando los parametros mandados son correctos
        /// </summary>
        /// <param name="_ally"></param>
        /// <param name="_id"></param>
        private void CallForthArkeon(bool _ally, int _id)
        {
            PlayerCharacterBattle mage = _ally ? PlayerCharacter : EnemyCharacter;

            IsPlayerTurn = _ally;
            ArkeonInFront = mage.ArkeonTeam[_id];

            GameObject arkeon = _ally ? AllyArkeonsOut[_id] : EnemyArkeonsOut[_id];

            mage.SendArkeonForward(_id, arkeon);
        }

        /// <summary>
        /// TODO summary
        /// </summary>
        private void CallShieldArkeonRequest(bool _ally, int _id)
        {
            if (!IsSingleEnemy && !_ally)
            {
                Debug.Log("There is not an enemy mage that would call a shield arkeon");
                return;
            }

            List<int> arkeonsOut = _ally ? AllyArkeonsOutId : EnemyArkeonsOutId;

            if(arkeonsOut.Contains(_id))
            {
                //El arkeon si esta afuera
                CallShieldArkeon(_ally, _id);
            }
            else
            {
                Debug.Log("Intentaste escudar con un arkeon que no esta afuera, arkeon id: " + _id);
            }
        }

        /// <summary>
        /// TODO summary
        /// </summary>
        private void CallShieldArkeon(bool _ally, int _id)
        {
            PlayerCharacterBattle mage = _ally ? PlayerCharacter : EnemyCharacter;
            List<GameObject> arkeonsOut = _ally ? AllyArkeonsOut : EnemyArkeonsOut;

            ArkeonDefending = mage.ArkeonTeam[_id];

            mage.SendArkeonForward(_id, arkeonsOut[_id]);
        }

        // ------------------------ Ataques ------------------------

        /// <summary>
        /// Hace una peticion para que un arkeon de algun equipo ataque, _ally = si es arkeon de aliado o enemigo, _arkeonId = La posicion en el equipo del arkeon, _attackId = la posición del ataque del arkeon
        /// </summary>
        /// <param name="_ally"></param>
        /// <param name="_arkeonId"></param>
        /// <param name="_attackId"></param>
        public void ArkeonAttackRequest(bool _ally, int _arkeonId, int _attackId)
        {
            PlayerCharacterBattle mage = _ally ? PlayerCharacter : EnemyCharacter;

            if (ArkeonInFront)
            {
                //El arkeon si es el de enfrente
                if(mage.ArkeonTeam[_arkeonId].Attacks.Count > _attackId)
                {
                    //El arkeon si tiene ese ataque
                    ArkeonAttack(_ally, _arkeonId, _attackId);
                }
                else
                {
                    Debug.Log("That arkeon doesn't have that attack");
                }
            }
            else
            {
                Debug.Log("You are trying to Attack with an arkeon that is not in front");
            }
        }

        /// <summary>
        /// Esto es llamado por ArkeonAttackRequest cuando si se puede atacar, las variables significan lo mismo
        /// </summary>
        /// <param name="_ally"></param>
        /// <param name="_arkeonId"></param>
        /// <param name="_attackId"></param>
        private void ArkeonAttack(bool _ally, int _arkeonId, int _attackId)
        {
            PlayerCharacterBattle mage = _ally ? PlayerCharacter : EnemyCharacter;

            LastArkeonAttack = ArkeonInFront.Attacks[_attackId];

            GameObject arkeon = _ally ? AllyArkeonsOut[_arkeonId] : EnemyArkeonsOut[_arkeonId];

            

            mage.ArkeonAttackAnimation(_arkeonId, _attackId, arkeon);
        }

        public void FamiliarAttackRequest(bool _ally, int _attackId)
        {

        }

        public void SingleEnemyArkeonAttackRequest(int _attackId)
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

        // ------------------ Llamadas desde eventos de animacion ------------------
        

        // ------------------ Funcionalidades ------------------
        private GameObject SpawnArkeon(bool _ally, int _id)
        {
            PlayerCharacterBattle summoner = _ally ? PlayerCharacter : EnemyCharacter;
            Transform point = ArenaPointReference.GetInvokePoint(true, AllyArkeonsOutId.Count);

            GameObject go = Instantiate(summoner.ArkeonTeam[_id].ModelPrefab, point.position, Quaternion.identity);
            go.transform.LookAt(go.transform.position + (_ally ? Vector3.forward : Vector3.back));

            if (_ally){ AllyArkeonsOut[_id] = go; }
            else{ EnemyArkeonsOut[_id] = go; }

            return go;
        }
    }
}

//TODO: Hacr que el ataque haga daño y las animaciones de daño y todo eso