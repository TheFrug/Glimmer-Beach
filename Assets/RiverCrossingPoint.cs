using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCrossingPoint : MonoBehaviour
{
    [SerializeField] public Transform pointA;
    [SerializeField] public Transform pointB;
    [SerializeField] public Transform raft;
    public bool onPoint = false; //Keeps track of if player is on one of the points
    private bool raftDown = false;
    private RiverCrossing myRiver;

    private void Start()
    {
        //Store two transforms based on pointA and pointB
        pointA = transform.GetChild(0).transform; 
        pointB = transform.GetChild(1).transform;
        raft = transform.GetChild(2);

        transform.position = pointA.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPoint = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeployRaft();
        }
    }

    private void DeployRaft()
    {
        //TODO: THIS ISN'T WORKING PROPERLY. IF YOU STAND IN ONE PLACE AND SPAM K IT JUST KEEPS MOVING THE TRIGGER FORWARD
        //Since crossPoint is parenting the other points, moving it moves everything as well.  Fuck
        if (!raftDown)
        {
            raft.gameObject.SetActive(true);
            raftDown = true;
            transform.position = pointB.position; //moves trigger volume to other side
        }
        if (raftDown)
        {
            raft.gameObject.SetActive(false);
            raftDown = false;
            transform.position = pointB.position; //moves trigger volume back
        }
    }

}
