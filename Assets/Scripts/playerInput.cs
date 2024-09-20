using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class playerInput : MonoBehaviour
{
    [SerializeField] private DialogManager dManager;

    public bool freeMove; //Can player move

    public float speed = 5f;
    public Rigidbody rb;
    [HideInInspector] public Vector3 movement;

    void Start()
    {
        freeMove = true;
    }

    void Update()
    {
        if (freeMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.K) && (dManager.inConversation)){
            dManager.NextTextBlock();
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}