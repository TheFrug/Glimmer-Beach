using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCrossing : MonoBehaviour
{
    [SerializeField] public Transform pointA;
    [SerializeField] public Transform pointB;
    [SerializeField] public Transform raft;
    public bool onPoint = false;

    void Start()
    {
        pointA = transform.GetChild(0).transform;
        pointB = transform.GetChild(1).transform;
        raft = transform.GetChild(2);
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
