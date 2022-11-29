using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class PuzzleLockScript : MonoBehaviour
    {
        public GameObject linkedDoor;
        public string lockText;
        public AudioSource aSource;
        public AudioClip padlocked;
        public AudioClip clickOpen;

        private void OnMouseDown()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                Debug.Log("Too Far for key");
                return;
            }
            if (!GameManager.CanvasController.solvedFridge)
            {
                aSource.PlayOneShot(padlocked);
                GameManager.CanvasController.updatedText(lockText);
            }
            else
            {
                aSource.PlayOneShot(clickOpen);
                unlockDoor();
                Destroy(this);
            }
        }

        public void unlockDoor()
        {
            linkedDoor.GetComponent<opencloseDoor>().unlock();
        }
    }
}
