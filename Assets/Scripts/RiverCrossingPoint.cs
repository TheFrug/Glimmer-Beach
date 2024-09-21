using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Point //nearest point should be point A
{
    A,
    B
}

public class RiverCrossingPoint : MonoBehaviour
{
    public Point myPoint;
    private bool pointALive = false; //Checks if point has become active or not
    private RiverCrossing rcManager;

    private void Start()
    {
        rcManager = GetComponentInParent<RiverCrossing>(); 
        GetComponent<MeshRenderer>().enabled = false; //No points should be visible at first
    }

    private void Update()
    {
        if (myPoint == Point.A) //Turns points on once player gets raft, but only once
        {
            if (Inventory.Instance.raft && !pointALive)
            {
                GetComponent<MeshRenderer>().enabled = true;
                pointALive = true;
            }
        }
    }

    //Tells parent RiverCrossing what point the player is standing on
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(myPoint == Point.A) {
                rcManager.onPointA = true; }
            if(myPoint == Point.B) {
                rcManager.onPointB = true; }
        }
    }

    //Tells parent RiverCrossing when player steps off point
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (myPoint == Point.A) {
                rcManager.onPointA = false; }
            if (myPoint == Point.B) {
                rcManager.onPointB = false; }
        }
    }
}
