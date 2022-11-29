using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public TMP_Text playerText;
    public GameObject winner;
    public GameObject fridgePuzzleUI;
    public bool solvedFridge;
    public TMP_InputField mainInputField;
    // Start is called before the first frame update
    void Start()
    {
        playerText.SetText("");
        winner.SetActive(false);
        fridgePuzzleUI.SetActive(false);
        solvedFridge = false;
    }
    
    public void updatedText(string input)
    {
        StartCoroutine(refreshText(input));
    }

    public void winnerTrigger()
    {
        StartCoroutine(wingame());
    }

    IEnumerator refreshText(string input)
    {
        playerText.SetText(input);
        yield return new WaitForSeconds(3);
        playerText.SetText("");
    }

    IEnumerator wingame()
    {
        GameManager.Instance.player.GetComponent<CharacterController>().enabled = false;
        winner.SetActive(true);
        yield return new WaitForSeconds(3.5f);
    }
}
