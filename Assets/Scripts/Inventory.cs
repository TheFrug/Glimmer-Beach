using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public bool raft = false;
    public bool lantern = false;
    public bool sailcloth = false;
    public bool compass = false;

    public Dialog raftDialog;
    public Dialog lanternDialog;
    public Dialog sailclothDialog;
    public Dialog compassDialog;

    public float glimmers = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GetGlimmer()
    {
        glimmers += 1;
        Debug.Log("I've got " + glimmers + " glimmers now. I just have " + (4-glimmers) + " to go!");

        if (glimmers == 4)
        {
            //TODO: Dialog can't be progressed or taken off the screen
            Debug.Log("Should pull up dialog now");
            FindObjectOfType<DialogManager>().StartDialog(raftDialog);
            raft = true;
        }
    }

    
}
