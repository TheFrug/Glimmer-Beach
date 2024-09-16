using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlimmerInteractable : MonoBehaviour
{
    public Dialog dialog;
    private DialogManager dManager;
    private bool playerInRange;

    private void Awake()
    {
        dManager = FindObjectOfType<DialogManager>();
        //Helpful reminder that the script requires a box collider
        if (gameObject.GetComponent<BoxCollider>() == null)
        {
            Debug.Log("Hey! " + transform.parent.name + " does't have a Box Collider! It can't detect if a player is in range without one!");
        }

        dialog.glimmer = transform.parent.gameObject;
    }

    void Update()
    {
        //TODO: Move this command to playerInput script.  By the end, this should just run UseGlimmer();
        if (Input.GetKeyDown(KeyCode.K) && (!dManager.inConversation) && playerInRange)
        {
            TriggerDialog();
            UseGlimmer();
        }
        else if (Input.GetKeyDown(KeyCode.K) && (dManager.inConversation) && playerInRange)
        {
            dManager.NextTextBlock();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            //Debug.Log("Hey! Over here!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            //Debug.Log("See you later!");

            if (dManager.inConversation)
            {
                dManager.EndDialog();
            }
        }
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

    private void UseGlimmer()
    {
        
    }
}
