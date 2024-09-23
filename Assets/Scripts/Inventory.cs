using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }


    public bool raft = false;
    public bool lantern = false;
    public bool sailcloth = false;
    public bool compass = false;

    public GameObject raftDown = null;
    public TextMeshProUGUI glimmerCount;

    public Dialog raftDialog;
    public Dialog lanternDialog;
    public Dialog sailclothDialog;
    public Dialog compassDialog;

    public float glimmers;

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

        glimmers = 0;
        SetCountText();
    }

    void SetCountText() //Sets glimmer count
    {
        glimmerCount.text = "Glimmers: " + glimmers.ToString();
    }

    //Increases glimmer amount by 1 and updates scoreText element
    public void GetGlimmer()
    {
        glimmers += 1;
        SetCountText();

        if (glimmers == 4)
        {
            //TODO: Dialog can't be progressed or taken off the screen
            Debug.Log("Should pull up dialog now");
            FindObjectOfType<DialogManager>().StartDialog(raftDialog);
            raft = true;
        }
    }
}
