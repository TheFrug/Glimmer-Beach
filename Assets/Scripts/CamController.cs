using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;


    public void moveCamera(Transform targetPos)
    {
        transform.position = targetPos.position;


    }
}
