using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class WindowKeyScript : MonoBehaviour
    {
        //Door key is to unlock
        public GameObject linkedWindow;
        public string lockText;
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
                linkedWindow.GetComponent<WindowTeleporter>().unlock();
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText(lockText);
                Destroy(gameObject);
            }
        }
    }
}