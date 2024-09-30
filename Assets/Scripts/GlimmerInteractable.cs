using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlimmerInteractable : MonoBehaviour
{
    public Dialog dialog;
    private DialogManager dManager;
    public bool playerInRange;
    private GameObject player;

    [SerializeField] bool raftPickup;
    [SerializeField] bool lanternPickup;
    [SerializeField] bool compassPickup;
    [SerializeField] bool winGlimmer = false;
    [SerializeField] GameObject WinGlimmer;
    [SerializeField] private GameObject winScreen;

    private void Awake()
    {
        player = GameObject.Find("Player");
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
        if (Input.GetKeyDown(KeyCode.K) && (!dManager.inConversation) && playerInRange) //If not in conversation and player on glimmer, run start dialog
        {
            player.GetComponent<playerInput>().freeMove = false;
            TriggerDialog();
            //UseGlimmer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dManager.glyphPanel.SetActive(true);
            //Debug.Log("Hey! Over here!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dManager.glyphPanel.SetActive(false);
            //Debug.Log("See you later!");

            if (dManager.inConversation)
            {
                dManager.EndDialog();
            }
        }
    }

    public void TriggerDialog()
    {
        dManager.StartDialog(dialog);
    }

    public void UseGlimmer()
    {
        if (raftPickup == true)
        {
            Inventory.Instance.GetRaft();
        }

        if (lanternPickup == true)
        {
            Inventory.Instance.GetLantern();
            if(player.GetComponent<Inventory>().compass == true)
            {
                WinGlimmer.SetActive(true);
            }
        }

        if (compassPickup == true)
        {
            Inventory.Instance.GetCompass();
            if (player.GetComponent<Inventory>().lantern == true)
            {
                WinGlimmer.SetActive(true);
            }
        }

        if(winGlimmer == true)
        {
            Debug.Log("Win the game");
            player.GetComponent<playerInput>().freeMove = false;
            winScreen.SetActive(true);
        }

        Inventory.Instance.GetGlimmer(); //run GetGlimmer to increment glimmer count for player
        Destroy(transform.parent.gameObject); //Removes Glimmer so it can't be seen twice
    }
}
