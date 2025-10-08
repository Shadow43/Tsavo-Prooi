using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string look= "Look";
    //    [SerializeField] private string sprint = "Sprint";

    private InputAction movementAction;
    private InputAction lookAction;
//    private InputAction sprintAction;


    public Vector2 MovementInput { get; private set; }
    public Vector2 lookInput { get; private set; }
//    public bool CrouchTriggered { get; private set; }
//    public bool RunningTriggered { get; private set; }

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);


        movementAction = mapReference.FindAction(movement);
        lookAction = mapReference.FindAction(look);
//        sprintAction = mapReference.FindAction(sprint);


        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        lookAction.performed += inputInfo => lookInput = inputInfo.ReadValue<Vector2>();
        lookAction.canceled += inputInfo => lookInput = Vector2.zero;

//        sprintAction.performed += inputInfo => RunningTriggered = true;
//        sprintAction.canceled += inputInfo => RunningTriggered = false;
    }

    public void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    public void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

}

