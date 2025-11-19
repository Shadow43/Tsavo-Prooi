using TMPro;
using UnityEngine;

public class TrapRepair : MonoBehaviour
{
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD _hud;

    [SerializeField] private GameObject salvage;
    [SerializeField] private TMP_Text textForSalvage;

    [SerializeField] private Home_Trap hometrap;

    public bool _isTriggered;
    public bool buildingSalvaged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isTriggered == true)
        {
            if (buildingSalvaged == false)
            {
                storyDialogue.OnEnable();
                examineTrapBuilding();
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


    public void examineTrapBuilding()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "Press E to salvage Ammo";
            textForSalvage.color = Color.red;
            textForSalvage.text = startTextState;
        }
        if (storyDialogue.trapRepair())
        {
            if (hometrap._guntoolEquipped == true)
            {
                string startTextState = "Mouse click to repair trap";
                textForSalvage.color = Color.red;
                textForSalvage.text = startTextState;
            }
            else
            {
                string startTextState = "I need to get the hammer first.";
                textForSalvage.color = Color.red;
                textForSalvage.text = startTextState;
            }
        }
    }

    public void ResourcedGrabbed()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "There's no more ammo here";
            textForSalvage.color = Color.red;
            textForSalvage.text = startTextState;
        }
        //        if (storyDialogue.trapRepair())
        //        {
        //            string startTextState = "Press E to get the hammer";
        //            textForSalvage.color = Color.red;
        //            textForSalvage.text = startTextState;
        //        }
    }

}
