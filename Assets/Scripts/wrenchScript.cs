using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class wrenchScript : MonoBehaviour
    {
        public GameObject chopper;
        public GameObject light;

        void Start()
        {
            light.SetActive(false);
        }

        public void lightOn()
        {
            light.SetActive(true);
        }

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
                chopper.GetComponent<winnerscript>().foundWrench = true;
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText("Got the wrench");
                Destroy(gameObject);
            }
        }
    }
}
