using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTeleporter : MonoBehaviour
{
    public bool isLocked;
    public GameObject planks;
    public GameObject exit;
    public string teleportMessage;
    public string pathMessage;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocked)
        {
            Destroy(planks);
        }
    }
    void OnMouseDown()
    {
        float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
        if (dist >= 5) return;
        if (isLocked)
        {
            GameManager.Instance.player.GetComponent<CanvasController>().updatedText(pathMessage);
            return;
        }

        GameManager.Instance.player.GetComponent<CharacterController>().enabled = false;
        GameManager.CanvasController.updatedText(teleportMessage);
        GameManager.Instance.player.transform.position = exit.transform.position;
        GameManager.Instance.player.transform.rotation = exit.transform.rotation;
        GameManager.Instance.player.GetComponent<CharacterController>().enabled = true;
        Debug.Log("Attempted Teleport");
    }

    public void unlock()
    {
        Destroy(planks);
        isLocked = false;
    }
}
