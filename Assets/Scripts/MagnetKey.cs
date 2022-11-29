using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class MagnetKey : MonoBehaviour
    {
        public GameObject gameLock;

        void OnMouseDown()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 5)
            {
                Debug.Log("Too Far for key");
                return;
            }

            Debug.Log("The box, you opened it, we came.");
            gameLock.GetComponent<PuzzleLockScript>().unlock();
            GameManager.CanvasController.updatedText("Got the E magnet");
            Destroy(gameObject);
        }
    }
}
