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
        public bool isLocked;
        public GameObject lockframe;

        void Start()
        {
            isLocked = true;
        }

        private void OnMouseDown()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                Debug.Log("Too Far for key");
                return;
            }
            if (isLocked)
            {
                aSource.PlayOneShot(padlocked);
                GameManager.CanvasController.updatedText(lockText);
            }
        }

        public void unlock()
        {
            isLocked = false;
            aSource.PlayOneShot(clickOpen);
            unlockDoor();
            Destroy(lockframe);
        }

        public void unlockDoor()
        {
            linkedDoor.GetComponent<opencloseDoor>().unlock();
        }
    }
}
