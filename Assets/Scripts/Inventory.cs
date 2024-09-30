using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }


    public bool raft = false;
    public bool lantern = false;
    public bool compass = false;
    [SerializeField] private float glimmersToRaft;
    [SerializeField] private float glimmersToLantern;
    [SerializeField] private float glimmersToCompass;
    [SerializeField] private iconUI raftIcon;
    [SerializeField] private iconUI lanternIcon;
    [SerializeField] private iconUI compassIcon;

    public bool raftDown = false;
    public TextMeshProUGUI glimmerCount;

    public Dialog raftDialog;
    public Dialog lanternDialog;
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
        
    }

    public void GetRaft()
    {
            Debug.Log("Should pull up dialog now");
            DialogManager.Instance.StartDialog(raftDialog);
            raft = true;

            raftIcon.setIcon(1);
    } 

    public void GetLantern()
    {
        DialogManager.Instance.StartDialog(lanternDialog);
        lanternIcon.setIcon(1);
    }

    public void GetCompass()
    {
        DialogManager.Instance.StartDialog(compassDialog);
        compassIcon.setIcon(1);
    }

    public void toggleRaft()
    {
        Debug.Log("Toggling raft");
        if(raftDown == false)
        {
            Debug.Log("Raft icon should be turning off");
            raftDown = true;
            raftIcon.setIcon(2);
        }
        else if(raftDown == true)
        {
            Debug.Log("Raft icon should be turning on");
            raftDown = false;
            raftIcon.setIcon(1);
        }
    }
}
