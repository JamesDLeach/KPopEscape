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

        void OnMouseOver()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                Debug.Log("Too Far for key");
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!GameManager.Instance.player.GetComponent<CanvasController>().solvedFridge)
                {
                    aSource.PlayOneShot(padlocked);
                    GameManager.Instance.player.GetComponent<CanvasController>().updatedText(lockText);
                }
                else
                {
                    aSource.PlayOneShot(clickOpen);
                    unlockDoor();
                    Destroy(this);
                }
            }
        }
        public void unlockDoor()
        {
            linkedDoor.GetComponent<opencloseDoor>().unlock();
        }
    }
}
