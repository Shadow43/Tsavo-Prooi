using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private HUD characterHUD;
    [SerializeField] private SalvageBuildings salvageHospital;
    [SerializeField] private Home_Trap homeTent;
    [SerializeField] private SalvageBuildings[] salvageBuildings;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Interactions";

    [Header("Action Name References")]

    [SerializeField] private string action = "Interact";

    private InputAction interactionAction;

    public bool Actions { get; private set; }
    public int textnumber;
    [SerializeField] private bool killLionChosen;
    [SerializeField] private bool repairTrapChosen;

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        interactionAction = mapReference.FindAction(action);

        SubscribeActionToInputEvents();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textnumber = 0;
        checkbooleans();
    }
        // Update is called once per frame
        void Update()
        {

        }
    private void SubscribeActionToInputEvents()
    {
        //        interactionAction.performed += inputInfo => Actions = true;
        //        interactionAction.canceled += inputInfo => Actions = false;
        interactionAction.performed += OnEPressed;
        interactionAction.canceled -= OnEPressed;

    }
    public void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    public void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }
    private void OnEPressed(InputAction.CallbackContext context)
    {
        if (!context.performed) return; // only count on initial press
        textnumber++;

        for (int i = 0; i < salvageBuildings.Length; i++)
        {
            SalvageBuildings script = salvageBuildings[i].GetComponent<SalvageBuildings>();
            bool inthetrigger = script._isTriggered;
            bool salvagedbuilding = script.buildingSalvaged;
            if (inthetrigger == true)
            {

                //if (GameObject.FindGameObjectWithTag("Hospital"))
                //{
                //    Debug.Log("Hospital tent has more resources");
                //    characterHUD.counter++;
                //    characterHUD.counter++;
                //}
                //if (GameObject.FindGameObjectWithTag("Worker Tents"))
                //{
                //    Debug.Log("Worker Tents have less resources");
                //    characterHUD.counter--;
                //}

                characterHUD.counter++;
                script.buildingSalvaged = true;
            }
        }
        if (GameObject.FindWithTag("Hospital"))
        {
            if (salvageHospital._isTriggered == true)
            {
                if (!context.performed) return; // only count on initial press
                characterHUD.counter++;
                characterHUD.counter++;
                salvageHospital.buildingSalvaged = true;
            }
        }
        if (GameObject.FindWithTag("Home Tent"))
            {
            if (homeTent._triggered == true)
            {
                if (!context.performed) return; // only count on initial press
                homeTent.EquippedGun();
                homeTent._buildingSalvaged = true;
            }
        }
    }
    public void SetKillLion(bool value)
    {
        killLionChosen = value;
    }
    public void SetRepairTrap(bool value)
    {
        repairTrapChosen = value;
    }
    public bool killtheLion()
    {
        return killLionChosen;
    }
    public bool trapRepair()
    {
        return repairTrapChosen;
    }
    public void checkbooleans()
    {
        for (int i = 0; i < salvageBuildings.Length; i++)
        {
            SalvageBuildings script = salvageBuildings[i].GetComponent<SalvageBuildings>();
            bool inthetrigger = script._isTriggered;
            bool secondBool = script.buildingSalvaged;
        }
    }
}

