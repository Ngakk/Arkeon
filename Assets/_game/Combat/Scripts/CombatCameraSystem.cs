using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace Mangos
{
    /// <summary> Este es el manager de la cámara en escena de combate
    /// Playable Directors
    /// [0] Vista completa del escenario. Escena básica de combate.
    /// [1] Vista al jugador y sus invocaciones.
    /// [2] Transición de escena desde la vista de Combate a Jugador.
    /// [3] Transición de escene desde la vista de Jugador a Combate.
    /// [4] Vista al enemigo y sus invocaciones.
    /// [5] Transición de escena desde la vista de Combate a Enemigo.
    /// [6] Vista de lado del enemigo
    /// [7] Vista de lado del jugador
    /// </summary>

    public class CombatCameraSystem : MonoBehaviour
    {
        public List<PlayableDirector> playableDirectors;
        public GameObject enemy;
        public GameObject player;

        public CinemachineVirtualCamera[] CM_VCamerasToPlayer;
        public CinemachineVirtualCamera[] CM_VCamerasToEnemy;

        void Start()
        {
            //Empieza con la cámara viendo al personaje en tercera persona y el enemigo de frente
            playableDirectors[0].Play();
        }

        public void CombatView()
        {
            //Método para mover la vista del Jugador a la cámara de combate
            for (int i = 0; i < playableDirectors.Count; i++)
                playableDirectors[i].Stop();
            if (playableDirectors[1].state == PlayState.Playing)
            {
                playableDirectors[3].Play();
                StartCoroutine("FinishCombatViewFromPlayer");
            } else if (playableDirectors[4].state == PlayState.Playing)
            {
                playableDirectors[0].Play();
            }
        }

        public void ChangeViewToPlayerInv()
        {
            //Método para mover la vista de Combate a la cámara del Jugador
            for (int i = 0; i < playableDirectors.Count; i++)
                playableDirectors[i].Stop();
            playableDirectors[2].Play();
            StartCoroutine("FinishPlayerViewFromCombat");
        }

        public void ChangeViewToEnemyInv()
        {
            //Método para mover la vista de Combate a la cámara del Enemigo
            for (int i = 0; i < playableDirectors.Count; i++)
                playableDirectors[i].Stop();
            playableDirectors[5].Play();
            StartCoroutine("FinishEnemyViewFromCombat");
        }

        public void ChangeViewToCombatFromEnemy()
        {
            //Método para mover la vista del Jugador a la cámara de combate
            for (int i = 0; i < playableDirectors.Count; i++)
                playableDirectors[i].Stop();
            playableDirectors[0].Play();
            //StartCoroutine("FinishCombatViewFromPlayer");
        }

        public void ChangeViewToTPPlayer()
        {
            //Se pone la cámara en tercera persona del lado del jugador
            playableDirectors[7].Play();
        }

        public void ChangeViewToTPEnemy()
        {
            //Se pone la cámara en tercera persona del lado del enemigo
            playableDirectors[6].Play();
        }

        //Debajo de esta sección, son métodos para redirigir el focus de las cámaras.

        public void FocusEnemy()
        {
            for (int i = 0; i < CM_VCamerasToEnemy.Length; i++)
            {
                CM_VCamerasToEnemy[i].LookAt = enemy.transform;
            }
        }

        public void FocusPlayer()
        {
            for (int i = 0; i < CM_VCamerasToPlayer.Length; i++)
            {
                CM_VCamerasToPlayer[i].LookAt = player.transform;
            }
        }

        //Coroutines para hacer las transiciones de cámaras

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

        IEnumerator FinishCombatViewFromEnemy()
        {
            yield return new WaitForSeconds((float)playableDirectors[3].duration);
            playableDirectors[3].Stop();

            if (playableDirectors[3].state != PlayState.Playing)
            {
                playableDirectors[0].Play();
            }
        }

        IEnumerator FinishEnemyViewFromCombat()
        {
            yield return new WaitForSeconds((float)playableDirectors[5].duration);
            playableDirectors[5].Stop();

            if (playableDirectors[5].state != PlayState.Playing)
            {
                Debug.Log("Se cambió exitosamente a enemigo");
                playableDirectors[4].Play();
            }
        }
    }
}