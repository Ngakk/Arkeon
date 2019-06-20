using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Jugador:
 *  - Tener arkeons
 *  - Comandar arkeons
 *  - Invocar arkeons
 *  - usar al familiar
 *  - Tiene stats
*/

namespace ArkeonBattle
{
    public class PlayerCharacterBattle : MonoBehaviour
    {
        public class ArkeonBattleStatus
        {
            public ArkeonBattleStatus(int _teamId, ArkeonInBattle _arkeon, bool _isOnFront, int _spaceId)
            {
                teamId = _teamId;
                arkeon = _arkeon;
                isOnFront = _isOnFront;
                spaceId = _spaceId;
            }

            public int teamId;
            public ArkeonInBattle arkeon;
            public bool isOnFront;
            public int spaceId;
        }

        [Header("Setup")]
        public bool enemySide = false; //Para saber de que lado del escenario esta
        public ArkeonTeam arkeonTeam;
        public List<Item> inventory = new List<Item>();
        public ArkeonInstance familiar;
        [Header("Stats")]
        public ArkeonStats stats;
        public int currentHp;
        public int currentMp;
        [Header("Instancias")]
        public List<ArkeonBattleStatus> arkeonsOut = new List<ArkeonBattleStatus>();
        public ArkeonInBattle familiarOut;

        public Animator anim;

        private void Start()
        {
            currentHp = stats.maxHp;
            currentMp = stats.maxMp;

            InvokeFamiliar();
        }

        //Cosas de battalla
        public void OnTurnStart()
        {
            currentMp = Mathf.Min(stats.maxMp, currentMp + 5);
        }

        public bool InvokeFamiliar()
        {
            if(familiar == null)
            {
                return false;
            }

            Transform point = enemySide ? ManagerStaticBattle.battleManager.arenaPointReference.EnemyFamiliar : ManagerStaticBattle.battleManager.arenaPointReference.AllyFamiliar; //Obtengo la posición para el arkeon

            GameObject go = Instantiate(familiar.arkeonData.modelPrefab, point.position, point.rotation); //Lo Invoco

            if (!go.GetComponent<ArkeonInBattle>())
                go.AddComponent<ArkeonInBattle>();

            ArkeonInBattle aib = go.GetComponent<ArkeonInBattle>();
            aib.myInstance = familiar;
            aib.showOnStart = true;
            aib.isAlly = !enemySide;
            aib.myInstance = familiar;

            return true;
        }

        //Comandos de arkeons
        //Invocar

        public bool InvokeArkeon(int _arkeonTeamId)
        {
            //Esto talvez cambia si decidimos que es mejor instanciar todos los arkeons al inicio de la pelea y mostrarlos al ser invocados

            if (arkeonsOut.Count >= 3 || IsArkeonOut(_arkeonTeamId) || arkeonTeam[_arkeonTeamId].currentHp <= 0 || _arkeonTeamId > arkeonTeam.Count - 1 || arkeonTeam[_arkeonTeamId].stats.cost > currentMp)
            {
                Debug.Log("No se puede invocar ese arkeon, arkeonOutCount: " + arkeonsOut.Count + ", hp: " + arkeonTeam[_arkeonTeamId].currentHp + ", teamId: " + _arkeonTeamId);
                return false; //Ya no caben, ya esta afuera o esta muerto
            }

            int space = GetNextAvailableSpace();

            Transform point = ManagerStaticBattle.battleManager.arenaPointReference.GetInvokePoint(!enemySide, space); //Obtengo la posición para el arkeon

            GameObject go = Instantiate(arkeonTeam[_arkeonTeamId].arkeonData.modelPrefab, point.position, point.rotation); //Lo Invoco

            //Setup de arkeon
            if (!go.GetComponent<ArkeonInBattle>())
                go.AddComponent<ArkeonInBattle>();

            ArkeonInBattle aib = go.GetComponent<ArkeonInBattle>();
            aib.myInstance = arkeonTeam[_arkeonTeamId];
            aib.showOnStart = true;
            aib.isAlly = !enemySide;
            aib.myInstance = arkeonTeam[_arkeonTeamId];

            //Actualizando variables
            arkeonsOut.Add(new ArkeonBattleStatus(_arkeonTeamId, aib, false, space));

            currentMp -= arkeonTeam[_arkeonTeamId].stats.cost;

            Debug.Log("Succesfully invoked arkeon");
            return true;
        }

        //Mandar para enfrete
        public bool ChooseAttacker(int _arkeonOutId)
        {
            //TODO: checar si otro esta enfrente para no mandar ;este y regresar falso
            Debug.Log("ArkeonsOut count = " + arkeonsOut.Count);
            if (!IsArkeonOut(arkeonsOut[_arkeonOutId].teamId))
                return false;

            arkeonsOut[_arkeonOutId].isOnFront = true;
            arkeonsOut[_arkeonOutId].arkeon.GoForward();

            Debug.Log("Succesfully choosed attacker");
            return true;
        }

        //Mandar hacia atras
        public bool StepBackAttacker()
        {
            Debug.Log("Stepping back");
            for(int i = 0; i < arkeonsOut.Count; i++)
            {
                if (arkeonsOut[i].isOnFront)
                {
                    Debug.Log("Entered step back on " + i);
                    arkeonsOut[i].arkeon.StepBack();
                    arkeonsOut[i].isOnFront = false;
                }
            }

            return true;
        }

        //atacar
        public bool CommandArkeonAttack(int _arkeonOutId, int _attack)
        {
            if (!arkeonsOut[_arkeonOutId].isOnFront || arkeonsOut[_arkeonOutId].arkeon.myInstance.attacks.Count < _attack || arkeonsOut[_arkeonOutId].arkeon.myInstance.stats.cost > currentMp)
                return false;
            
            arkeonsOut[_arkeonOutId].arkeon.AttackSet(_attack);
            currentMp -= arkeonsOut[_arkeonOutId].arkeon.myInstance.stats.cost;

            Debug.Log("Succesfully commanded arkeon attack");
            return true;
        }

        //defender
        public bool CommandArkeonShield(int _arkeonOutId)
        {
            if (arkeonsOut[_arkeonOutId].isOnFront)
                return false;

            ManagerStaticBattle.battleManager.SetDefender(arkeonsOut[_arkeonOutId].arkeon);
            Debug.Log("Succesfully shielded with arkeon");
            return true;
        }

        public bool CommandNoShield()
        {
            ManagerStaticBattle.battleManager.SetCharacterDefender(this);

            return true;
        }


        //Usar items
        public void UseItem(int _item)
        {

        }

        //Comandos de familiar
        //atacar
        public void CommandFamiliarAttack(int _attack)
        {

        }

        //Animaciones propias
        public void Squeal()
        {
            anim.SetTrigger("GetHit");
        }

        public void Dodge()
        {

        }

        public void Laugh()
        {

        }

        //funcionalidades
        private bool IsArkeonOut(int _arkeon)
        {
            for(int i = 0; i < arkeonsOut.Count; i++)
            {
                if (arkeonsOut[i].teamId == _arkeon)
                    return true;
            }

            return false;
        }

        private int GetNextAvailableSpace()
        {
            List<int> spaces = new List<int>() { 0, 1, 2 };

            for(int i = 0; i < arkeonsOut.Count; i++)
            {
                spaces.Remove(arkeonsOut[i].spaceId);
            }

            return spaces[0];
        }
    }
}