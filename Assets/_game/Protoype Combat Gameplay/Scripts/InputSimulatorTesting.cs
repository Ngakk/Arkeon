using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class InputSimulatorTesting : MonoBehaviour
    {
        public PlayerCharacterBattle player;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { player.InvokeArkeon(0); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { player.InvokeArkeon(1); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { player.InvokeArkeon(2); }

            if (Input.GetKeyDown(KeyCode.Q)) { player.ChooseAttacker(0); }
            if (Input.GetKeyDown(KeyCode.W)) { player.ChooseAttacker(1); }
            if (Input.GetKeyDown(KeyCode.E)) { player.ChooseAttacker(2); }

        }
    }
}