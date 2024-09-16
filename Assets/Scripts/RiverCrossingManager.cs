using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCrossingManager : MonoBehaviour
{
    [SerializeField] public GameObject pointA;
    [SerializeField] public GameObject pointB;
    [SerializeField] public GameObject raft;
    public bool onPoint = false; //Keeps track of if player is on one of the points
    public bool raftDown = false;

    private void Start()
    {
        //Store two transforms based on pointA and pointB
        pointA = transform.GetChild(0).gameObject; 
        pointB = transform.GetChild(1).gameObject;
        raft = transform.GetChild(2).gameObject;

        pointB.GetComponent<RiverCrossingPoint>().triggerActive = false;
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
        if ((Input.GetKeyDown(KeyCode.K)) && (onPoint) && (Inventory.Instance.raft)){
            DeployRaft();
        }
    }

    private void DeployRaft()
    {
        if (raftDown != true)
        {
            Debug.Log("deploying");
            raft.SetActive(true);
            raftDown = true;

            pointA.GetComponent<RiverCrossingPoint>().ToggleTrigger();
            pointB.GetComponent<RiverCrossingPoint>().ToggleTrigger();
        }
        else if (raftDown)
        {
            raftDown = false;
            raft.SetActive(false);

            pointA.GetComponent<RiverCrossingPoint>().ToggleTrigger();
            pointB.GetComponent<RiverCrossingPoint>().ToggleTrigger();
        }
    }

}
