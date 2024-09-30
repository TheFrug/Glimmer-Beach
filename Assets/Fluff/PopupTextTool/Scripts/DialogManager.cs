using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public static DialogManager Instance { get; private set; }

    [Header("UI Panels")]
    [Tooltip("Insert the UI panel that parents the main text of your dialog")]
    public GameObject bodyTextPanel;
    [Tooltip("Insert the UI panel that parents the name of the speaker")]
    public GameObject speakerNamePanel;
    public GameObject glyphPanel;

    [Header("UI Objects")]
    [Tooltip("Insert the text element that renders the main text you want in the dialog box")]
    public TextMeshProUGUI bodyText;
    [Tooltip("Insert the text element that renders the speaker's name in the name box")]
    public TextMeshProUGUI speakerNameText;
    [Tooltip("Insert the image element that renders the sprite for the speaker's portrait")]

    public GameObject currentGlimmer;
    private Dialog dialogTemp;
    private AudioSource audioSource;
    [HideInInspector] public AudioClip clip;
    [HideInInspector] public string text;
    //TODO: Move inConversation from DialogManager to Player state machine.
    public bool inConversation = false;
    [SerializeField] private float typingSpeed;

    private Queue<string> textBlocksToShow; //This stores the text blocks that are loaded and have yet to be shown
    private Queue<AudioClip> soundClipsToPlay; //This stores the audio clips that are loaded and have yet to be shown

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    void Start()
    {

        //If the object has an audio source, get reference to it.  If not, create a generic one.
        if (gameObject.GetComponent<AudioSource>() == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else if (gameObject.GetComponent<AudioSource>() != null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        textBlocksToShow = new Queue<string>();
        soundClipsToPlay = new Queue<AudioClip>();
    }

    public void StartDialog(Dialog dialog)
    {
        glyphPanel.SetActive(false);

        //freeze player movement
        FindObjectOfType<playerInput>().movement.x = 0;
        FindObjectOfType<playerInput>().movement.z = 0;

        dialogTemp = dialog;

        if (dialog.glimmer != null) {
            Debug.Log("Currently playing: " + dialog);

            currentGlimmer = dialog.glimmer;
        }

        bodyTextPanel.SetActive(true); //Makes body text panel appear

        //Makes name panel appear if there is one.  
        if (dialog.name != "")
        {
            speakerNamePanel.SetActive(true);
            speakerNameText.text = dialog.name;
        }

        inConversation = true;

        //These two lines clear any remaining audio/text clips
        textBlocksToShow.Clear();
        soundClipsToPlay.Clear();

        //Fills these two queues with text and sounds from the arrays of text and sounds stored in the dialog component of the speaker
        foreach (string text in dialog.textBlocks)
        {
            if(dialog.textBlocks != null) 
            {
                textBlocksToShow.Enqueue(text);
            }
        }

        foreach (AudioClip sound in dialog.soundClips)
        {
            if (dialog.soundClips != null)
            {
                soundClipsToPlay.Enqueue(sound);
            }
        }
        NextTextBlock();
    }

    public void NextTextBlock()
    {
        //If there is no text in the queue, run EndDialog
        if (textBlocksToShow.Count == 0)
        {
            EndDialog();
            Destroy(currentGlimmer);

            return;
        }
        //Moves the text queue down
        if (textBlocksToShow.Count != 0)
        {
            text = textBlocksToShow.Dequeue(); //Moves down queue of dialog
            StopAllCoroutines();
            StartCoroutine(TypeText(text));
        }

        //Moves the sound queue down and then plays that sound clip
        if (soundClipsToPlay != null)
        {
            if (soundClipsToPlay.Count != 0)
            {
                clip = soundClipsToPlay.Dequeue();
            }
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }

    //Animates text one character at a time for smoother presentation
    IEnumerator TypeText(string text)
    {
        bodyText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            bodyText.text += letter;
            AudioManager.instance.Play("dialogBlip");
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Closes relative panels
    public void EndDialog()
    {
        Debug.Log("Shutting Up now");

        player.GetComponent<playerInput>().freeMove = true;

        //Sets each panel inactive
        bodyTextPanel?.SetActive(false);
        speakerNamePanel?.SetActive(false);

        //Resets all values that were stored for the interaction
        inConversation = false;
        dialogTemp = null;
        clip = null;

        if (currentGlimmer != null)
        {
            currentGlimmer.GetComponentInChildren<GlimmerInteractable>().UseGlimmer();
        }

        //Play sound when dialog interface closes
        //AudioManager.instance.Play("raftDownSound");
    }

    public void glyphPanelToggle(){
        Debug.Log("glyph toggling");

        if (!glyphPanel.activeInHierarchy){
            glyphPanel.SetActive(true);
        }
        if (glyphPanel.activeInHierarchy){
            glyphPanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Debug.Log("Working");
        Application.Quit();
    }
}
