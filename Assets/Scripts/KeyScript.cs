using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class KeyScript : MonoBehaviour
    {
        //Door key is to unlock
        public GameObject linkedDoor;
        public string lockText;
        void OnMouseDown()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                Debug.Log("Too Far for key");
                return;
            }

            Debug.Log("The box, you opened it, we came.");
            linkedDoor.GetComponent<opencloseDoor>().unlock();
            GameManager.CanvasController.updatedText(lockText);
            Destroy(gameObject);
        }
    }
}