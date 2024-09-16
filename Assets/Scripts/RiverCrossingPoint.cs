using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCrossingPoint : MonoBehaviour
{
    private RiverCrossingManager rcManager;
    public bool triggerActive = true;

    private void Start()
    {
        rcManager = GetComponentInParent<RiverCrossingManager>();
    }

    private void Update()
    {
        if (triggerActive)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else if (!triggerActive)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerActive)
            {
                rcManager.onPoint = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rcManager.onPoint = false;
        }
    }

    //TODO Make this toggle mesh and not trigger. Mesh should appear on same side as player.  Trigger should not go away and trap the player
    public void ToggleTrigger()
    {
        if (triggerActive) {
            Debug.Log("Fuck");
            //triggerActive = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
        else if (!triggerActive) {
            triggerActive = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
