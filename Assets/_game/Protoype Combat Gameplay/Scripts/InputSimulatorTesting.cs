using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class InputSimulatorTesting : MonoBehaviour
    {
        public PlayerCharacterBattle player;
        public PlayerCharacterBattle enemy;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { player.InvokeArkeon(0); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { player.InvokeArkeon(1); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { player.InvokeArkeon(2); }

            if (Input.GetKeyDown(KeyCode.Q)) { player.ChooseAttacker(0); }
            if (Input.GetKeyDown(KeyCode.W)) { player.ChooseAttacker(1); }
            if (Input.GetKeyDown(KeyCode.E)) { player.ChooseAttacker(2); }

            if (Input.GetKeyDown(KeyCode.A)) { player.CommandArkeonAttack(0, 0); }
            if (Input.GetKeyDown(KeyCode.S)) { player.CommandArkeonAttack(1, 0); }
            if (Input.GetKeyDown(KeyCode.D)) { player.CommandArkeonAttack(2, 0); }

            if (Input.GetKeyDown(KeyCode.Z)) { player.CommandArkeonShield(0); }
            if (Input.GetKeyDown(KeyCode.X)) { player.CommandArkeonShield(0); }
            if (Input.GetKeyDown(KeyCode.C)) { player.CommandArkeonShield(0); }

            if (Input.GetKeyDown(KeyCode.Alpha8)) { enemy.InvokeArkeon(0); }
            if (Input.GetKeyDown(KeyCode.Alpha9)) { enemy.InvokeArkeon(1); }
            if (Input.GetKeyDown(KeyCode.Alpha0)) { enemy.InvokeArkeon(2); }

            if (Input.GetKeyDown(KeyCode.I)) { enemy.ChooseAttacker(0); }
            if (Input.GetKeyDown(KeyCode.O)) { enemy.ChooseAttacker(1); }
            if (Input.GetKeyDown(KeyCode.P)) { enemy.ChooseAttacker(2); }

            if (Input.GetKeyDown(KeyCode.J)) { enemy.CommandArkeonAttack(0, 0); }
            if (Input.GetKeyDown(KeyCode.K)) { enemy.CommandArkeonAttack(1, 0); }
            if (Input.GetKeyDown(KeyCode.L)) { enemy.CommandArkeonAttack(2, 0); }

            if (Input.GetKeyDown(KeyCode.B)) { enemy.CommandArkeonShield(0); }
            if (Input.GetKeyDown(KeyCode.N)) { enemy.CommandArkeonShield(0); }
            if (Input.GetKeyDown(KeyCode.M)) { enemy.CommandArkeonShield(0); }

        }
    }
}