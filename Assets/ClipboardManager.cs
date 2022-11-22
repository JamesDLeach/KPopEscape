using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClipboardManager : MonoBehaviour
{

    public TextMeshPro text;
    public float cameraDist;
    public float maxDist;
    private bool isClicked;
    private Vector3 oldPos;
    private Quaternion oldRotation;

    // Start is called before the first frame update
    void Start()
    {
        text = text == null ? GetComponentInChildren<TextMeshPro>() : text;
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            LookAtCamera();
            if ((GameManager.Instance.player.transform.position - oldPos).magnitude > maxDist)
            {
                EndLook();
            }
        }
    }

    private void InitiateLook()
    {
        isClicked = true;
        oldPos = transform.position;
        oldRotation = transform.rotation;
    }

    private void EndLook()
    {
        isClicked = false;
        transform.position = oldPos;
        transform.rotation = oldRotation;
    }

    private void LookAtCamera()
    {
        transform.position = Camera.main.transform.position + (cameraDist * Camera.main.transform.forward);
        transform.LookAt(Camera.main.transform.position);
        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }

    private void OnMouseDown()
    {
        if (isClicked)
        {
            return;
        }
        InitiateLook();
        LookAtCamera();
    }

    private void OnMouseUp()
    {
        if (!isClicked)
        {
            return;
        }
        EndLook();
    }
}
