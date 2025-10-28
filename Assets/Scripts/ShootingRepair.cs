using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow;


public class ShootingRepair : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private StoryDialogue characterDialogue;
    [SerializeField] private Home_Trap hometrap;
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD characterHud;

    [SerializeField] private TMP_Text gun;
    [SerializeField] private GameObject equippedShotGun;

    [SerializeField] Transform bulletSpawn;
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
        gun.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterDialogue.gameStart() && startGame == false)
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
            if (characterHud.counter != 0)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                characterHud.counter -= 1;
            }
            //            Debug.Log("Gun is equipped. Ready to shoot");
        }
        else
        {
            if (storyDialogue.killtheLion())
            {
//                Debug.Log("Don't have the gun");
                gun.alignment = TextAlignmentOptions.Center;
                string startTextState = "No gun equipped";
                gun.color = Color.red;
                gun.text = startTextState;
                TextTimer();
            }
        }
    }
    public void TextTimer()
    {
        StartCoroutine(TextTimerCoroutine());
    }
    IEnumerator TextTimerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        gun.text = string.Empty;
    }
}
