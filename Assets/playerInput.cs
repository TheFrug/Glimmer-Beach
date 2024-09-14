using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class playerInput : MonoBehaviour

{

    public float speed = 5f;
    public Rigidbody rb;
    Vector3 movement;

    void Start()
    {

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}