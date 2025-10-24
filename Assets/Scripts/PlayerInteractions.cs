using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;


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
}
