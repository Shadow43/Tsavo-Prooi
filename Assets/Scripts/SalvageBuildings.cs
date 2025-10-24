using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Subsystems;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class SalvageBuildings : MonoBehaviour
{
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD _hud;

    [SerializeField] private bool salvageResources;
    [SerializeField] private GameObject salvage;
    [SerializeField] private TMP_Text textforSalvage;
    [SerializeField] private bool _isTriggered;
    [SerializeField] private bool buildingSalvaged;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textforSalvage.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTriggered == true)
        {
            storyDialogue.OnEnable();
            if (salvageResources == false)
            {
                examineSalvageBuilding();
            }
            else
            {
                ResroucesGrabbed();
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
            textforSalvage.text = string.Empty;
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
            textforSalvage.color = Color.red;
            textforSalvage.text = startTextState;
//            _hud.PickUpCounter();
//            salvageResources = true;
        }
        if (storyDialogue.trapRepair())
        {
//            storyDialogue.OnEnable();
            string startTextState = "Press E to Salvage Wood and Rope";
            textforSalvage.color = Color.red;
            textforSalvage.text = startTextState;
//            _hud.PickUpCounter();
//            salvageResources = true;
        }
    }
    public void ResroucesGrabbed()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "There's no more ammo here";
            textforSalvage.color = Color.white;
            textforSalvage.text = startTextState;
        }
        if (storyDialogue.trapRepair())
        {
            string startTextState = "There's no more Wood and Rope here.";
            textforSalvage.color = Color.white;
            textforSalvage.text = startTextState;
        }
    }
}
