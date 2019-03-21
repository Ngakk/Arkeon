using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public enum CameraPositions
    {
        COMBAT,
        PLAYER_AND_INV,
        INV_1,
        INV_2,
        INV_3
    }

    public class CombatCameraSystem : MonoBehaviour
    {
        public GameObject mainCam;
        public GameObject combatPos;
        public GameObject playerSetsPos;
        public GameObject invocationPos1;
        public GameObject invocationPos2;
        public GameObject invocationPos3;

        void Start()
        {

        }
        
        void Update()
        {

        }
    }
}