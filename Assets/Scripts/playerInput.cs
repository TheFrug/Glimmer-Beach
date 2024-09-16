using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public enum PlayerState
{
    free,
    inConversation
}

public class playerInput : MonoBehaviour
{

    public static playerInput Instance { get; private set; }

    public float speed = 5f;
    public Rigidbody rb;
    Vector3 movement;

    public PlayerState playerState;

    void Start()
    {
        playerState = PlayerState.free;
    }

    void Update()
    {
        if (playerState == PlayerState.free)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
        }
    }

    public void SwapState(PlayerState state)
    {
        playerState = state;
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}