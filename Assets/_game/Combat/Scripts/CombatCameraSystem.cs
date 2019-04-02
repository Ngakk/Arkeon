using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace Mangos
{

    public class CombatCameraSystem : MonoBehaviour
    {
        public List<PlayableDirector> playableDirectors;
        public GameObject enemy;
        public GameObject player;
        public GameObject invocationPos1;
        public GameObject invocationPos2;
        public GameObject invocationPos3;
        public GameObject familiar;

        public CinemachineVirtualCamera[] CM_VCameras;

        void Start()
        {
            playableDirectors[0].Play();
            Debug.Log(playableDirectors[3].duration);
        }

        public void CombatView()
        {
            playableDirectors[1].Stop();
            playableDirectors[3].Play();
            StartCoroutine("FinishCombatViewFromPlayer");
        }

        public void ChangeViewToPlayerInv()
        {
            playableDirectors[0].Stop();
            playableDirectors[2].Play();
            StartCoroutine("FinishPlayerViewFromCombat");
        }

        public void FocusPlayer()
        {
            for (int i = 0; i < CM_VCameras.Length; i++)
            {
                CM_VCameras[i].LookAt = player.transform;
            }
        }

        public void FocusInv1()
        {
            for (int i = 0; i < CM_VCameras.Length; i++)
            {
                CM_VCameras[i].LookAt = invocationPos1.transform;
            }
        }

        public void FocusInv2()
        {
            for (int i = 0; i < CM_VCameras.Length; i++)
            {
                CM_VCameras[i].LookAt = invocationPos2.transform;
            }
        }

        public void FocusInv3()
        {
            for (int i = 0; i < CM_VCameras.Length; i++)
            {
                CM_VCameras[i].LookAt = invocationPos3.transform;
            }
        }

        public void FocusFamiliar()
        {
            for (int i = 0; i < CM_VCameras.Length; i++)
            {
                CM_VCameras[i].LookAt = familiar.transform;
            }
        }

        IEnumerator FinishCombatViewFromPlayer()
        {
            yield return new WaitForSeconds((float)playableDirectors[3].duration);
            playableDirectors[3].Stop();

            if (playableDirectors[3].state != PlayState.Playing)
            {
                playableDirectors[0].Play();
            }
        }

        IEnumerator FinishPlayerViewFromCombat()
        {
            yield return new WaitForSeconds((float)playableDirectors[2].duration);
            playableDirectors[2].Stop();

            if (playableDirectors[2].state != PlayState.Playing)
            {
                playableDirectors[1].Play();
            }
        }
    }
}