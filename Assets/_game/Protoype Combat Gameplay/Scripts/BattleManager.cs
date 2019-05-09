using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Hacr que el ataque haga daño y las animaciones de daño y todo eso

/* Responsibilidades de cada entidad
 * 
 * Arkeon:
 *  - Hacer Animaciones
 *  - Atacar
 *  - Tener Stats
 *  - Tener ataques
 *  
 * Jugador:
 *  - Tener arkeons
 *  - Comandar arkeons
 *  - Invocar arkeons
 *  - usar al familiar
 *  - Tiene stats
 *  
 * Familiar:
 *  - Tiene stats
 *  - Invocar arkeons
 *  - Atacar
 *  - Tiene ataques 
 *  - Hacer animaciones
 *  - Tiene efectos pasivos
 *  
 * BattleManager:
 *  - Decirle a un personaje que hacer
 *  - Esperar eventos de animaciones
 *  - Setearle referencias a los que hacen las cosas
 *  
 * BattleTurnManager:
 *  - Saber en que estado esta
 *  - Cambiar de turnos
 *  - Empezar y terminar peleas
 *  - Decirle al controller si si puede hacer lo que quiere
 *  - Preguntarlo al BattleManager si se puede hacer lo que el controller quiere
 * 
 * Controller:
 *  - Pedirle al turn manager que haga cosas
 *  - decirle al jugador que onda
 * 
 */

namespace Mangos
{
    public class BattleManager : MonoBehaviour
    {
        public enum State
        {
            NOTHING,
            ATTACK_SET,
            DEFENDER_SET,
            BATTLING
        }

        [Header("Setup en editor")]
        public ArenaPointReference ArenaPointReference;
        [Header("Setup Al iniciar escena")]
        public PlayerCharacterBattle PlayerCharacter;
        public PlayerCharacterBattle EnemyCharacter;
        public GameObject SingleEnemy;
        public bool IsSingleEnemy = true;

        //IMPORTANTE: Un id de un arkeon es la posicion del arkeon en su respectivo equipo, empezando por 0. Los equipos se constituyen de todas los arkeons que el jugador trae cargando

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
                //ArkeonDefending = SingleEnemy;
            }
        }

        private void Update()
        {
            /*//Testing
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
                ArkeonSetAttackRequest(true, 0, 0);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                
            }*/
        }

        // ------------------ Batalla ------------------


    }
}
