using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller values")]
    public CharacterController playerCtrlr;
    [Space(10)]
    [Tooltip("Modify the base speed of the player")]
    [SerializeField] private float speed = 0.0f;
    [Tooltip("Modify the 'sprint' modifier effect")]
    [SerializeField] private float sprint = 1.0f;

    public static PlayerController playerScript;

    private void Awake()
    {
        playerCtrlr.detectCollisions = false;
    }

    void Update()
    {
        PlayerMovementVariable();
    }

    private void PlayerMovementVariable()
    {
        float horizontalMvmt = Input.GetAxisRaw("Horizontal");
        float verticalMvmt = Input.GetAxisRaw("Vertical");

        if (Input.GetKey("left shift"))
        {
            sprint = 2.0f;
        }
        else
        {
            sprint = 1.0f;
        }

        // Calculates the 'move' parameter for the movement size and direction
        Vector3 move = transform.forward * verticalMvmt + transform.right * horizontalMvmt;

        // Calculates together the base movement, speed, sprint modifier and time, making movement smooth
        playerCtrlr.Move(speed * sprint * Time.deltaTime * move);
    }
}
