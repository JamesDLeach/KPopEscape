using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTeleporter : MonoBehaviour
{
    public bool isLocked;
    public GameObject planks;
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocked)
        {
            Destroy(planks);
        }
    }
    void OnMouseOver()
    {
        float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
        if (dist >= 5) return;

        if (Input.GetMouseButtonDown(0)) {

            if (!isLocked) {
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText("An open window, I think I can get out here");
                GameManager.Instance.player.transform.position = exit.transform.position;
            } else {
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText("");
            }

        }
    }
    
    // Update is called once per frame
    void Update() {}
}
