using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTeleporter : MonoBehaviour
{
    public bool isLocked;
    public GameObject planks;
    public GameObject exit;
    public string teleportMessage;
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
        if (isLocked) return;
        float dist = Vector3.Distance(GameManager.Instance.player.transform.position, transform.position);
        if (dist >= 5) return;
        Debug.Log("Over Object");
        if (Input.GetMouseButtonDown(0)) {
                GameManager.Instance.player.GetComponent<CharacterController>().enabled = false;
                GameManager.Instance.player.GetComponent<CanvasController>().updatedText(teleportMessage);
                GameManager.Instance.player.transform.position = exit.transform.position;
                GameManager.Instance.player.GetComponent<CharacterController>().enabled = true;
                Debug.Log("Attempted Teleport");
        }
    }
    
    // Update is called once per frame
    void Update() {}
}
