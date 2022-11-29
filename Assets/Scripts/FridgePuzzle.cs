using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class FridgePuzzle : MonoBehaviour
    {
        public GameObject linkedLock;
        public string fridgeText;
        void OnMouseOver()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 3)
            {
                return;
            } 
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText(fridgeText);
                GameManager.Instance.player.GetComponent<CanvasController>().fridgeTrigger();
            }
        }
    }
}
