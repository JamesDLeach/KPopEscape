using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public CharacterController controller;

    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;
    public float movementSpeed = 5f;
    public float gravityStrength = -15f;

    public Vector2 currMovement;
    public Vector2 lastMovement;

    public Vector2 currMouse;
    public Vector2 lastMouse;

    private Vector3 velocity;
    private Vector3 rotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Set last variables to previous frame
        lastMovement = currMovement;
        lastMouse = currMouse;

        // Update the mouse movement
        currMouse = Time.deltaTime * new Vector2(Input.GetAxis("Mouse X") * mouseSensitivityX, Input.GetAxis("Mouse Y") * mouseSensitivityY);

        // Update the rotation values
        rotation.x -= currMouse.y;
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        // Rotate the transform
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        GameManager.Instance.player.transform.Rotate(Vector3.up * currMouse.x);

        // Update the player movement
        currMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Move the player
        Vector3 movement = Camera.main.transform.right * currMovement.x + Camera.main.transform.forward * currMovement.y;
        controller.Move(movement * movementSpeed * Time.deltaTime);
        velocity.y += gravityStrength * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
