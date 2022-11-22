using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public TMP_Text playerText;
    // Start is called before the first frame update
    void Start()
    {
        playerText.SetText("");
    }
    
    public void updatedText(string input)
    {
        StartCoroutine(refreshText(input));
    }

    IEnumerator refreshText(string input)
    {
        Debug.Log("Tried it");
        playerText.SetText(input);
        yield return new WaitForSeconds(3);
        playerText.SetText("");
    }
}
