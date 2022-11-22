using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    public float speed;
    public float maxDist;

    private Animator animator;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = GameManager.Instance.player.transform.position;
        Vector3 targetPostition = new Vector3(currPos.x, transform.position.y, currPos.z);
        Vector3 diff = targetPostition - transform.position;

        if (diff.magnitude > maxDist)
        {
            animator.Play("Z_Idle");
            return;
        }
        animator.Play("Z_Walk_InPlace");

        transform.LookAt(targetPostition);

        characterController.Move(diff.normalized * speed * Time.deltaTime);
    }
}
