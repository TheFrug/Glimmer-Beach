using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCrossing : MonoBehaviour
{
    private Inventory player;
    [SerializeField] public GameObject pointA;
    [SerializeField] public GameObject pointB;
    [SerializeField] public GameObject raft;
    [SerializeField] public GameObject bounds;
    public bool onPointA = false; //Keeps track of if player is on one of the points
    public bool onPointB = false;
    public Dialog noRaftDialog;

    private void Start()
    {
        //Store two transforms based on pointA and pointB
        pointA = transform.GetChild(0).gameObject;
        pointB = transform.GetChild(1).gameObject;
        raft = transform.GetChild(2).gameObject;
        player = FindObjectOfType<Inventory>();

        //pointB.GetComponent<RiverCrossingPoint>().triggerActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPointA = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPointA = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.K)) && (onPointA || onPointB) && (Inventory.Instance.raft)){
            Debug.Log("Working?");
            DeployRaft();
        }
    }

    //Puts raft down and lifts it up
    private void DeployRaft()
    {
        if (player.raftDown != true)
        {
            Debug.Log("deploying");
            AudioManager.instance.Play("raftDownSound");
            raft.SetActive(true);
            player.toggleRaft();

            if (bounds != null)
            {
                bounds.SetActive(false);
            }

            pointA.SetActive(true);
            pointB.SetActive(true);
            pointA.GetComponent<ParticleSystem>().Play();
            pointB.GetComponent<ParticleSystem>().Play();
        }
        else if (player.raftDown == true)
        {
            if (raft.activeInHierarchy == true)
            {
                AudioManager.instance.Play("raftUpSound");
                player.toggleRaft();
                raft.SetActive(false);

                if (bounds != null)
                {
                    bounds.SetActive(true);
                }

                if (onPointA)
                {
                    pointA.SetActive(true);
                    pointB.SetActive(false);

                }
                if (onPointB)
                {
                    Debug.Log("Activating from point B");
                    pointA.SetActive(false);
                    pointB.SetActive(true);

                }
            }
            else
            {
                DialogManager.Instance.StartDialog(noRaftDialog);
            }
        }
    }
}
