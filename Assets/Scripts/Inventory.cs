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
    [SerializeField] private float glimmersToWin; 

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
        Debug.Log($"Glimmers = {glimmers}");
        if (glimmers == glimmersToWin)
        {
            //TODO: Dialog can't be progressed or taken off the screen
            Debug.Log("Should pull up dialog now");
            DialogManager.Instance.StartDialog(raftDialog);
            raft = true;
        }
    }
}
