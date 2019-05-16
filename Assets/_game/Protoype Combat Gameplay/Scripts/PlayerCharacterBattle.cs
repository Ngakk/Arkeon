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
        public struct ArkeonBattleStatus
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
        public List<ArkeonBattleStatus> ArkeonsOut = new List<ArkeonBattleStatus>();

        //Comandos de arkeons
        //Invocar
        public bool InvokeArkeon(int _arkeonTeamId)
        {
            //Esto talvez cambia si decidimos que es mejor instanciar todos los arkeons al inicio de la pelea y mostrarlos al ser invocados

            if (ArkeonsOut.Count >= 3 || IsArkeonOut(_arkeonTeamId))
                return false; //Ya no caben o ya esta afuera

            Transform point = ManagerStaticBattle.battleManager.arenaPointReference.GetInvokePoint(!enemySide, ArkeonsOut.Count); //Obtengo la posición para el arkeon

            GameObject go = Instantiate(arkeonTeam[_arkeonTeamId].modelPrefab, point.position, point.rotation); //Lo Invoco

            //Setup de arkeon
            if (!go.GetComponent<ArkeonInBattle>())
                go.AddComponent<ArkeonInBattle>();

            ArkeonInBattle aib = go.GetComponent<ArkeonInBattle>();
            aib.spirit = arkeonTeam[_arkeonTeamId];
            aib.showOnStart = true;
            aib.isAlly = !enemySide;

            //Actualizando variables
            ArkeonsOut.Add(new ArkeonBattleStatus(_arkeonTeamId, aib, false));

            return true;
        }

        //Mandar para enfrete
        public bool ChooseAttacker(int _arkeonOutId)
        {
            //TODO: checar si otro esta enfrente para no mandar este y regresar falso

            if (ArkeonsOut.Count <= _arkeonOutId)
                return false;

            ArkeonsOut[_arkeonOutId].arkeon.GoForward();

            return true;
        }

        //atacar
        public bool CommandArkeonAttack(int _arkeonOutId, int _attack)
        {
            if (ArkeonsOut[_arkeonOutId].isOnFront || ArkeonsOut[_arkeonOutId].arkeon.spirit.attacks.Count < _attack)
                return false;
            
            ArkeonsOut[_arkeonOutId].arkeon.AttackSet(_attack);

            return true;
        }

        //defender
        public bool CommandArkeonShield(int _arkeonOutId)
        {
            if (ArkeonsOut[_arkeonOutId].isOnFront)
                return false;

            ManagerStaticBattle.battleManager.SetDefender(ArkeonsOut[_arkeonOutId].arkeon);

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
            for(int i = 0; i < ArkeonsOut.Count; i++)
            {
                if (ArkeonsOut[i].teamId == _arkeon)
                    return true;
            }

            return false;
        }
    }
}