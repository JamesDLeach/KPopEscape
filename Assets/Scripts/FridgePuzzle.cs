using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class FridgePuzzle : MonoBehaviour
    {
        public GameObject linkedLock;
        public string fridgeText;

        private void OnMouseDown()
        {
            float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
            if (dist >= 3)
            {
                return;
            }
            GameManager.CanvasController.updatedText(fridgeText);
        }
    }
}
