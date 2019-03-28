using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Mangos
{
    public enum InterfaceState : int
    {
        MAIN,
        ATTACK,
        ITEM
    }

    public struct PlayerCombatAction
    {
        public int GliphId;
        public UnityAction Action;
        public InterfaceState WorksOn; //On wich state can this action be called
    }

    public class PlayerBattleControler : MonoBehaviour
    {
        public List<PlayerCombatAction> MyActions = new List<PlayerCombatAction>();

        private InterfaceState CurrentState;

        public void CallActionByGliph(int _id)
        {
            for(int i = 0; i < MyActions.Count; i++)
            {
                if(MyActions[i].GliphId == _id && MyActions[i].WorksOn == CurrentState)
                {
                    //Call action
                }
            }
        }
        //TODO: que haga algo si no encuentra nada, hacer la lista de acciones
    }
}