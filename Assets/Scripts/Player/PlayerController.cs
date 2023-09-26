using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 movementDirection;
    private PlayerInput inputAction;
    private Rigidbody rb;
    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private float playerSpeed;
    void Start()
    {
        mainCamera = Camera.main;
        inputAction = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        KeepThePlayerOnScreen();
        Movement();
    }



    private void KeepThePlayerOnScreen()
    {
        Vector3 newPosition = transform.position;

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;

        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        else if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }
        transform.position = newPosition;
    }

    private void Movement()
    {
        Vector2 joystickVec = movementJoystick.JoystickVector();
        if(joystickVec.y != 0)
        {
            rb.velocity  = new Vector3(joystickVec.x*playerSpeed , joystickVec.y*playerSpeed , 0);
            float targetAngle  = Mathf.Atan2(joystickVec.y,joystickVec.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-targetAngle,90f,90f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

}
