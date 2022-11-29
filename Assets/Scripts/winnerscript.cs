using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class winnerscript : MonoBehaviour
    {
        public bool foundWrench;
        public bool foundHammer;

        public GameObject wrench;
        public GameObject hammer;

        void Start()
        {
            foundWrench = false;
            foundHammer = false;
        }

        void OnMouseOver()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 10) return;

            if (Input.GetMouseButtonDown(0))
            {
                if (foundWrench && foundHammer)
                {
                    GameManager.Instance.player.GetComponent<CanvasController>().winnerTrigger();
                }
                else
                {
                    if (!foundHammer && !foundWrench)
                    {
                        GameManager.Instance.player.GetComponent<CanvasController>().updatedText("Looks like its broken. I'll need a hammer and wrench to fix it. I think there were some in timmy's apartment");
                        wrench.GetComponent<wrenchScript>().lightOn();
                        hammer.GetComponent<hammerScript>().lightOn();
                    } else if(!foundHammer)
                    {
                        GameManager.Instance.player.GetComponent<CanvasController>().updatedText("I still need a hammer");
                    } else if (!foundWrench)
                    {
                        GameManager.Instance.player.GetComponent<CanvasController>().updatedText("I still need a wrench");
                    } else
                    {
                        GameManager.Instance.player.GetComponent<CanvasController>().updatedText("The developers set up the triggers wrong, you should win here");
                    }
                }
            }
        }
    }
}
