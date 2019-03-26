using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;

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
        public CameraPositions CameraPositions;
        public List<TimelineAsset> timelines;
        public GameObject combatPos;
        public GameObject playerPos;
        public GameObject invocationPos1;
        public GameObject invocationPos2;
        public GameObject invocationPos3;

        public CinemachineVirtualCamera[] CM_VCameras;
        public GameObject currentObjective;

        void Start()
        {
            CameraPositions = CameraPositions.COMBAT;
        }
        
        void Update()
        {

        }
    }
}