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

namespace Mangos
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
        public List<ArkeonSpirit> arkeonTeam = new List<ArkeonSpirit>();
        public List<CombatItem> inventory = new List<CombatItem>();
        [Header("Stats")]
        public int HP = 20;
        public int MP = 20;
        private int MaxMP;
        [Header("Instancias")]
        public List<ArkeonBattleStatus> arkeonsOut = new List<ArkeonBattleStatus>();

        private Animator anim;

        private void Start()
        {
            MaxMP = MP;
            anim = GetComponentInChildren<Animator>();
        }

        //Cosas de battalla
        public void OnTurnStart()
        {
            MP = Mathf.Min(MaxMP, MP+5);
        }

        //Comandos de arkeons
        //Invocar
        public bool InvokeArkeon(int _arkeonTeamId)
        {
            //Esto talvez cambia si decidimos que es mejor instanciar todos los arkeons al inicio de la pelea y mostrarlos al ser invocados

            if (arkeonsOut.Count >= 3 || IsArkeonOut(_arkeonTeamId) || arkeonTeam[_arkeonTeamId].stats.HP <= 0 || _arkeonTeamId > arkeonTeam.Count - 1 || arkeonTeam[_arkeonTeamId].stats.Cost > MP)
            {
                Debug.Log("No se puede invocar ese arkeon, arkeonOutCount: " + arkeonsOut.Count + ", hp: " + arkeonTeam[_arkeonTeamId].stats.HP + ", teamId: " + _arkeonTeamId);
                return false; //Ya no caben, ya esta afuera o esta muerto
            }

            int space = GetNextAvailableSpace();

            Transform point = ManagerStaticBattle.battleManager.arenaPointReference.GetInvokePoint(!enemySide, space); //Obtengo la posición para el arkeon

            GameObject go = Instantiate(arkeonTeam[_arkeonTeamId].modelPrefab, point.position, point.rotation); //Lo Invoco

            //Setup de arkeon
            if (!go.GetComponent<ArkeonInBattle>())
                go.AddComponent<ArkeonInBattle>();

            ArkeonInBattle aib = go.GetComponent<ArkeonInBattle>();
            aib.spirit = arkeonTeam[_arkeonTeamId];
            aib.showOnStart = true;
            aib.isAlly = !enemySide;

            //Actualizando variables
            arkeonsOut.Add(new ArkeonBattleStatus(_arkeonTeamId, aib, false, space));

            MP -= arkeonTeam[_arkeonTeamId].stats.Cost;

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
            if (!arkeonsOut[_arkeonOutId].isOnFront || arkeonsOut[_arkeonOutId].arkeon.spirit.attacks.Count < _attack || arkeonsOut[_arkeonOutId].arkeon.spirit.stats.Cost > MP)
                return false;
            
            arkeonsOut[_arkeonOutId].arkeon.AttackSet(_attack);
            MP -= arkeonsOut[_arkeonOutId].arkeon.spirit.stats.Cost;

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

        public bool ComandNoShield()
        {
            ManagerStaticBattle.battleManager.SetDefender(null);

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
        void GetHit()
        {
            anim.SetTrigger("GetHit");
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