using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    public class InputSimulatorTesting : MonoBehaviour
    {
        public PlayerCharacterBattle player;
        public PlayerCharacterBattle enemy;

        public int allyArkeonChosen = -1;
        public int enemyArkeonChosen = -1;

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Alpha1)) {  }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {  }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {  }

            if (Input.GetKeyDown(KeyCode.Q)) {  }
            if (Input.GetKeyDown(KeyCode.W)) {  }
            if (Input.GetKeyDown(KeyCode.E)) {  }

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
            if (Input.GetKeyDown(KeyCode.M)) { enemy.CommandArkeonShield(0); }*/

        }

        public void InvokeAllyArkeon1() { player.InvokeArkeon(0); }
        public void InvokeAllyArkeon2() { player.InvokeArkeon(1); }
        public void InvokeAllyArkeon3() { player.InvokeArkeon(2); }

        public void ChooseAllyAttacker1() { player.ChooseAttacker(0); }
        public void ChooseAllyAttacker2() { player.ChooseAttacker(1); }
        public void ChooseAllyAttacker3() { player.ChooseAttacker(2); }

        public void CommandAllyAttack1() { player.CommandArkeonAttack(allyArkeonChosen, 0); }
        public void CommandAllyAttack2() { player.CommandArkeonAttack(allyArkeonChosen, 1);}
        public void CommandAllyAttack3() { player.CommandArkeonAttack(allyArkeonChosen, 2);}
        public void CommandAllyAttack4() { player.CommandArkeonAttack(allyArkeonChosen, 3); }

        public void CommandAllyShield1() { player.CommandArkeonShield(0); }
        public void CommandAllyShield2() { player.CommandArkeonShield(1);}
        public void CommandAllyShield3() { player.CommandArkeonShield(2);}

        public void InvokeEnemyArkeon1() { enemy.InvokeArkeon(0); }
        public void InvokeEnemyArkeon2() { enemy.InvokeArkeon(1); }
        public void InvokeEnemyArkeon3() { enemy.InvokeArkeon(2); }

        public void ChooseEnemyAttacker1() { enemy.ChooseAttacker(0); }
        public void ChooseEnemyAttacker2() { enemy.ChooseAttacker(1); }
        public void ChooseEnemyAttacker3() { enemy.ChooseAttacker(2); }

        public void CommandEnemyAttack1() { enemy.CommandArkeonAttack(enemyArkeonChosen, 0); }
        public void CommandEnemyAttack2() { enemy.CommandArkeonAttack(enemyArkeonChosen, 1); }
        public void CommandEnemyAttack3() { enemy.CommandArkeonAttack(enemyArkeonChosen, 2); }
        public void CommandEnemyAttack4() { enemy.CommandArkeonAttack(enemyArkeonChosen, 3); }

        public void CommandEnemyShield1() { enemy.CommandArkeonShield(0); }
        public void CommandEnemyShield2() { enemy.CommandArkeonShield(1); }
        public void CommandEnemyShield3() { enemy.CommandArkeonShield(2); }
    }

    
}