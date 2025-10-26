using JetBrains.Annotations;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class Home_Trap : MonoBehaviour
{
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD _hud;

    [SerializeField] private GameObject tool_gun;
    [SerializeField] private TMP_Text getGun_getTool;
    [SerializeField] private GameObject equpped_Gun;
    [SerializeField] private GameObject equpped_tool;

    public bool _triggered;
    public bool _buildingSalvaged;
    public bool _guntoolEquipped;
//    [SerializeField] private bool canGetGunTool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getGun_getTool.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        //if (_hud.counter <= 7)
        //{
        //    canGetGunTool = false;
        //}
        //if (_hud.counter >= 8)
        //{
        //    canGetGunTool = true;
        //}
        if (_triggered == true)
        {
            if (_buildingSalvaged == false)
            {
                storyDialogue.OnEnable();
                examineBuilding();
            }
            if (_buildingSalvaged == true)
            {
                if(_guntoolEquipped == true)
                {
                    gun_toolGrabbed();
                }
                else
                {
                    _buildingSalvaged = false;
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tool_gun.SetActive(true);
            _triggered = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            storyDialogue.OnDisable();
            getGun_getTool.text = string.Empty;
            tool_gun.SetActive(false);
            _triggered = false;
        }
    }
    public void examineBuilding()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "Press E to get the gun";
            getGun_getTool.color = Color.red;
            getGun_getTool.text = startTextState;
        }
        if (storyDialogue.trapRepair())
        {
            string startTextState = "Press E to get the hammer";
            getGun_getTool.color = Color.red;
            getGun_getTool.text = startTextState;
        }
    }
    public void gun_toolGrabbed()
    {
        if (storyDialogue.killtheLion())
        {
            string startTextState = "Already got the gun";
            getGun_getTool.color = Color.red;
            getGun_getTool.text = startTextState;
//            Debug.Log("text for already getting the gun");
        }
        if (storyDialogue.trapRepair())
        {
            string startTextState = "Already got the hammer";
            getGun_getTool.color = Color.red;
            getGun_getTool.text = startTextState;
//            Debug.Log("text for already getting the tool");
        }
    }    
    public void EquippedGun()
    {
        if (_hud.counter <= 7)
        {
            if (storyDialogue.killtheLion())
            {
//                string startTextState = "Need to get salvage the ammo first";
//                getGun_getTool.color = Color.white;
//                getGun_getTool.text = startTextState;
                Debug.Log("Need to get salvage the ammo first");
            }
            if (storyDialogue.trapRepair())
            {
//                string startTextState = "Need to get salvage the resources first";
//                getGun_getTool.color = Color.white;
//                getGun_getTool.text = startTextState;
                Debug.Log("Need to get salvage the resources first");
            }
        }
        else if (_hud.counter >= 8)
        {
            if (storyDialogue.killtheLion())
            {
//                string startTextState = "Got all the availabe ammo.";
//                getGun_getTool.color = Color.white;
//                getGun_getTool.text = startTextState;
                Debug.Log("Got all the ammo.");
//                _guntoolEquipped = true;
            }
            if (storyDialogue.trapRepair())
            {
//                string startTextState = "Got all the availabe resources";
//                getGun_getTool.color = Color.white;
//                getGun_getTool.text = startTextState;
                Debug.Log("Got all the resources.");
//                _guntoolEquipped = true;
            }
        }
    }
}
