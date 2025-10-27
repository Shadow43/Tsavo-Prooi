using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootingRepair : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private HUD characterHUD;
    [SerializeField] private Home_Trap hometrap;
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private TMP_Text gun;
    [SerializeField] private GameObject equippedShotGun;

    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject bullet;

    [SerializeField] private string actionMapName = "Weapon";

    [SerializeField] private string action = "Shoot";
    private bool startGame;

    private InputAction interactionAction;
    public bool Actions { get; private set; }

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);
        interactionAction = mapReference.FindAction(action);
        SubscribeActionToInputEvents();
    }

    private void SubscribeActionToInputEvents()
    {
        interactionAction.performed += OnMouseClick;
        interactionAction.canceled -= OnMouseClick;
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        OnDisable();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterHUD.startedGame() && startGame == false)
        {
            OnEnable();
            startGame = true;
        }
    }
    public void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    public void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }
    private void OnMouseClick(InputAction.CallbackContext context)
    {
        if (!context.performed) return; // only count on initial press
        if (equippedShotGun.activeInHierarchy)
        {
            Debug.Log("Gun is equipped. Ready to shoot");
            Onfire();
        }
        else
        {
            if (storyDialogue.killtheLion())
            {
                Debug.Log("Don't have the gun");
            }
        }
    }
    public void Onfire()
    {
        Debug.Log("Spawn bullet");
    }
}
