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
            public ArkeonBattleStatus(int _teamId, ArkeonInBattle _arkeon, bool _isOnFront)
            {
                teamId = _teamId;
                arkeon = _arkeon;
                isOnFront = _isOnFront;
            }

            public int teamId;
            public ArkeonInBattle arkeon;
            public bool isOnFront;
        }

        [Header("Setup")]
        public bool enemySide = false; //Para saber de que lado del escenario esta
        public List<ArkeonSpirit> arkeonTeam = new List<ArkeonSpirit>();
        public List<CombatItem> inventory = new List<CombatItem>();
        [Header("Stats")]
        public int HP = 20;
        public int MP = 20;
        [Header("Instancias")]
        public List<ArkeonBattleStatus> arkeonsOut = new List<ArkeonBattleStatus>();

        //Comandos de arkeons
        //Invocar
        public bool InvokeArkeon(int _arkeonTeamId)
        {
            //Esto talvez cambia si decidimos que es mejor instanciar todos los arkeons al inicio de la pelea y mostrarlos al ser invocados

            if (arkeonsOut.Count >= 3 || IsArkeonOut(_arkeonTeamId))
                return false; //Ya no caben o ya esta afuera

            Transform point = ManagerStaticBattle.battleManager.arenaPointReference.GetInvokePoint(!enemySide, arkeonsOut.Count); //Obtengo la posición para el arkeon

            GameObject go = Instantiate(arkeonTeam[_arkeonTeamId].modelPrefab, point.position, point.rotation); //Lo Invoco

            //Setup de arkeon
            if (!go.GetComponent<ArkeonInBattle>())
                go.AddComponent<ArkeonInBattle>();

            ArkeonInBattle aib = go.GetComponent<ArkeonInBattle>();
            aib.spirit = arkeonTeam[_arkeonTeamId];
            aib.showOnStart = true;
            aib.isAlly = !enemySide;

            //Actualizando variables
            arkeonsOut.Add(new ArkeonBattleStatus(_arkeonTeamId, aib, false));

            Debug.Log("Succesfully invoked arkeon");
            return true;

            1 = 0;

            //TODO: ponerle vida al arkeon instanceado
        }

        //Mandar para enfrete
        public bool ChooseAttacker(int _arkeonOutId)
        {
            //TODO: checar si otro esta enfrente para no mandar ;este y regresar falso
            Debug.Log("ArkeonsOut count = " + arkeonsOut.Count);
            if (arkeonsOut.Count <= _arkeonOutId)
                return false;

            arkeonsOut[_arkeonOutId].arkeon.GoForward();

            Debug.Log("Succesfully choosed attacker");
            return true;
        }

        //atacar
        public bool CommandArkeonAttack(int _arkeonOutId, int _attack)
        {
            if (arkeonsOut[_arkeonOutId].isOnFront || arkeonsOut[_arkeonOutId].arkeon.spirit.attacks.Count < _attack)
                return false;
            
            arkeonsOut[_arkeonOutId].arkeon.AttackSet(_attack);
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

        //Cosas de batalla
        //TODO

        //Comandos de familiar
        //atacar
        public void CommandFamiliarAttack(int _attack)
        {

        }

        // ----------------------- Animaciones -----------------------

        //TODO

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
    }
}