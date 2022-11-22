using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerscript : MonoBehaviour
{
    void OnMouseOver()
    {
        float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
        if (dist >= 10) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.player.GetComponent<CanvasController>().winnerTrigger();
        }
    }
}
