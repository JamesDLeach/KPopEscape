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

    public void fridgeTrigger()
    {
        StartCoroutine(fridgeGame());
    }

    public void fridgeEnd()
    {
        StartCoroutine(fridgeCheck());
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

    IEnumerator fridgeGame()
    {
        GameManager.Instance.player.GetComponent<CharacterController>().enabled = false;
        fridgePuzzleUI.SetActive(true);
        Debug.Log("Tried to set active");
        mainInputField.ActivateInputField();
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator fridgeCheck()
    {
        mainInputField.DeactivateInputField();
        string s = mainInputField.text;
        s.ToLower();
        if(s[0].Equals('e'))
        {
            GameManager.Instance.player.GetComponent<CanvasController>().updatedText("This seems like it will fit");
            solvedFridge = true;

        } else
        {
            GameManager.Instance.player.GetComponent<CanvasController>().updatedText("This doesn't seem like the right shaped magnet");
        }
        GameManager.Instance.player.GetComponent<CharacterController>().enabled = true;
        fridgePuzzleUI.SetActive(false);
        yield return new WaitForSeconds(.5f);
    }
}
