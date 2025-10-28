using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class StoryDialogue : MonoBehaviour
{
    [SerializeField] private PlayerInteractions storyDialogue;
    public TMP_Text dialogueText;
    public TMP_Text eToContinue;
    public GameObject whiteImage;
    public Button repairTrap;
    public Button killLion;
    [SerializeField] GameObject repairTrapButton;
    [SerializeField] GameObject killLionButton;
    [SerializeField] private AILionPatrol lionPatrol;
    [SerializeField] private bool startedGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lionPatrol.setPaused(true);
        whiteImage.SetActive(true);
        dialogueText.text = string.Empty;
        eToContinue.text = string.Empty;
        StartText();
    }

    // Update is called once per frame
    void Update()
    {
        if (storyDialogue.textnumber == 1)
        {
            FirstTextLine();
        }
        if (storyDialogue.textnumber == 2)
        {
            SecondTextLine();
        }
        if (storyDialogue.textnumber == 3)
        {
            ThirdTextLine();
        }
        if (storyDialogue.textnumber == 4)
        {
            ForthdTextLine();
        }
        if (storyDialogue.textnumber == 4)
        {
            FifthTextLine();
        }
        if (storyDialogue.textnumber == 5)
        {
            SixthTextLine();
        }
        if (storyDialogue.textnumber == 6)
        {
            SeventhTextLine();
        }
        if (storyDialogue.textnumber == 7)
        {
            EigthTextLine();
        }
        if (storyDialogue.textnumber == 8)
        {
            NinthTextLine();
        }
    }
    public void StartText()
    {
        dialogueText.alignment = TextAlignmentOptions.Center;
        string startTextState = "Please Press E to Start Story Narration";
        dialogueText.text = startTextState;
    }
    public void FirstTextLine()
    {
        dialogueText.alignment = TextAlignmentOptions.Left;
        string startTextState = "<color=black>You are suddenly startled awake at the sound of a lion growling then roaring extremely close.</color>";
        dialogueText.text = startTextState;
        eToContinue.color = Color.blue;
        string continueE = "Press E to continue";
        eToContinue.text = continueE;
        eToContinue.alignment = TextAlignmentOptions.Center;

    }
    public void SecondTextLine()
    {
        string startTextState = "<color=red>\"That blasted lion.\"</color><color=black> You mutter to yourself. </color><color=red>\"The two have killed or driven off all the workers that were to help build the village.\"</color>";
        dialogueText.text = startTextState;
    }
    public void ThirdTextLine()
    {
        string startTextState = "<color=black>You stretch and start to sit up. </color><color=red>\"I'm glad I was able to get rid of that first lion though. Nearly got me though.\"</color>";
        dialogueText.text = startTextState;
    }
    public void ForthdTextLine()
    {
        string startTextState = "<color=black>You start to get changed. </color><color=red>\"I'm going to have to either trap or kill this last lion like I did the first lion.\"</color>";
        dialogueText.text = startTextState;
    }
    public void FifthTextLine()
    {
        string startTextState = "</color><color=red>\"Which should I do? Kill the lion or try to repair the trap to trap the maneater.\"</color>";
        dialogueText.text = startTextState;
        repairTrapButton.SetActive(true);
        killLionButton.SetActive(true);
        eToContinue.text = string.Empty;
        killLion.onClick.AddListener(() => OnButtonClick("Kill Lion"));
        repairTrap.onClick.AddListener(() => OnButtonClick("Repair Trap"));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        storyDialogue.OnDisable();
    }
    public void OnButtonClick(string buttonName)
    {
//        Debug.Log("Button Clicked " + buttonName);
        if (buttonName == "Kill Lion")
        {
            storyDialogue.SetKillLion(true);
            repairTrapButton.SetActive(false);
            killLionButton.SetActive(false);
            storyDialogue.OnEnable();
        }
        if (buttonName == "Repair Trap")
        {
            storyDialogue.SetRepairTrap(true);
            repairTrapButton.SetActive(false);
            killLionButton.SetActive(false);
            storyDialogue.OnEnable();
        }
    }
    public void SixthTextLine()
    {
           if (storyDialogue.killtheLion())
        {
            string startTextState = "</color><color=red>\"I will kill the man-eating lion. But I'll need to salvage the ammo from the ruined buildings first\"</color>";
            dialogueText.text = startTextState;
            string continueE = "Press E to continue";
            eToContinue.color = Color.blue;
            eToContinue.text = continueE;
        }
           if (storyDialogue.trapRepair())
        {
            string startTextState = "</color><color=red>\"I will trap the lion. But first I will need to repair the trap. The resources should be in the ruined buildings in the area.\"</color>";
            dialogueText.text = startTextState;
            string continueE = "Press E to continue";
            eToContinue.color = Color.blue;
            eToContinue.text = continueE;
        }
    }
    public void SeventhTextLine()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "</color><color=red>\"Then I can come back here and get the shotgun.\"</color>";
            dialogueText.text = startTextState;
            string continueE = "Press E to continue";
            eToContinue.color = Color.blue;
            eToContinue.text = continueE;
        }
        if (storyDialogue.trapRepair())
        {
            string startTextState = "</color><color=red>\"Then I can come back here and get the hammer.\"</color>";
            dialogueText.text = startTextState;
            string continueE = "Press E to continue";
            eToContinue.color = Color.blue;
            eToContinue.text = continueE;
        }
    }
    public void EigthTextLine()
    {
        dialogueText.alignment = TextAlignmentOptions.Center;
        dialogueText.color = Color.blue;
        string startTextState = "Please Press E to Begin Game";
        dialogueText.text = startTextState;

    }
    public void NinthTextLine()
    {
        eToContinue.text = string.Empty;
        dialogueText.text = string.Empty;
        whiteImage.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        storyDialogue.OnDisable();
        startedGame = true;
//        lionPatrol.setPaused(false);
    }
    public void OnMouseUpAsButton()
    {
        storyDialogue.textnumber++;
    }
    public bool gameStart()
    {
        return startedGame;
    }

}
