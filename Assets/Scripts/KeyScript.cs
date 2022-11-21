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
                Debug.Log("The box, you opened it, we came.");
                linkedDoor.GetComponent<opencloseDoor>().unlock();
                Destroy(gameObject);
            }
        }
    }
}