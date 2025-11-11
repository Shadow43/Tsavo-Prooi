using TMPro;
using UnityEngine;


public class SalvageBuildings : MonoBehaviour
{
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD _hud;

//    [SerializeField] private bool salvageResources;
    [SerializeField] private GameObject salvage;
    [SerializeField] private TMP_Text textForSalvage;
//    [SerializeField] private bool _isTriggered;
//    [SerializeField] private bool buildingSalvaged;
    public bool _isTriggered;
    public bool buildingSalvaged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textForSalvage.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTriggered == true)
        {
            if (buildingSalvaged == false)
            {
                storyDialogue.OnEnable();
                examineSalvageBuilding();
            }
            if (buildingSalvaged == true)
            {
                ResourcedGrabbed();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
//            storyDialogue.OnEnable();
             salvage.SetActive(true);
            _isTriggered = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            storyDialogue.OnDisable();
            textForSalvage.text = string.Empty;
            salvage.SetActive(false);
            _isTriggered = false;
        }
    }


    public void examineSalvageBuilding()
    {
        if (storyDialogue.killtheLion())
        {
//            storyDialogue.OnEnable();
            string startTextState = "Press E to salvage Ammo";
            textForSalvage.color = Color.red;
            textForSalvage.text = startTextState;
//            salvageResources = true;
        }
        if (storyDialogue.trapRepair())
        {
//            storyDialogue.OnEnable();
                string startTextState = "Press E to Salvage Wood and Rope";
                textForSalvage.color = Color.red;
                textForSalvage.text = startTextState;
//            salvageResources = true;
        }
    }
    public void ResourcedGrabbed()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "There's no more ammo here";
            textForSalvage.color = Color.white;
            textForSalvage.text = startTextState;
            //Debug.Log("GETTIIN AMMO");
        }
        if (storyDialogue.trapRepair())
        {
            string startTextState = "There's no more Wood and Rope here.";
            textForSalvage.color = Color.white;
            textForSalvage.text = startTextState;
            //Debug.Log("GETTIIN wOOD");
        }
    }
}
