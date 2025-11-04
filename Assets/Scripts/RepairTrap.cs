using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class RepairTrap : MonoBehaviour
{
    [SerializeField] private Transform hammer;
    [SerializeField] private Transform target;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private Quaternion originalRotation;

    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Quaternion targetRotation;

    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private StoryDialogue characterDialogue;
    [SerializeField] private Home_Trap hometrap;
    [SerializeField] private PlayerInteractions storyDialogue;
    [SerializeField] private HUD characterHud;
    [SerializeField] private Dialogue debugDialogue;

    [SerializeField] private TMP_Text hammerText;
    [SerializeField] private GameObject equippedHammer;

    [SerializeField] private TMP_Text trapCountDownText;
    [SerializeField] private AILionPatrol lionPatrol;
    [SerializeField] GameObject theLion;

    [SerializeField] private string actionMapName = "Weapon";

    [SerializeField] private string action = "Shoot";
    private bool startGame;
    [SerializeField] private bool hammermoving;

    private float timer;
    private bool trapcountdown;
    private bool lioncaught;

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
        hammerText.text = string.Empty;
        lioncaught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterDialogue.gameStart() && startGame == false)
        {
            OnEnable();
            startGame = true;
        }
        if (trapcountdown == true && lioncaught == false)
        {
            OnDisable();
            trapCountDownText.alignment = TextAlignmentOptions.Center;
            trapCountDownText.color = Color.red;
            countdowntimer(timer);
//            string startTextState = "Time to catch lion " + timer;
//            trapCountDownText.text = startTextState;
            timer -= Time.deltaTime;
        if (timer < 0)
        {
            trapCountDownText.text = string.Empty;
            debugDialogue.LionTrapped();
            lioncaught = true;
            lionPatrol.setPaused(true);
            theLion.SetActive(false);
            }
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
        if (equippedHammer.activeInHierarchy)
        {
            if (characterHud.counter != 0)
            {
//                if (GameObject.FindWithTag("Lion Trap"))
//                {
                    characterHud.counter -= 1;
//                }
                if (hammermoving == false)
                {
                    MoveToTargetAndBack();
                    hammermoving = true;
                }
            }
            if (characterHud.counter == 0)
            {
                timer = Random.Range(31, 62);
                trapcountdown = true;
            }
        }
        else
        {
            if (storyDialogue.trapRepair())
            {
                hammerText.alignment = TextAlignmentOptions.Center;
                string startTextState = "No hammer equipped";
                hammerText.color = Color.red;
                hammerText.text = startTextState;
                TextTimer();
            }
        }
    }

    public void MoveToTargetAndBack()
    {
        hammermoving = true;
        StartCoroutine(MoveAndRotateCoroutine(targetPosition, targetRotation, moveSpeed, rotateSpeed));
    }
    private IEnumerator MoveAndRotateCoroutine(Vector3 newPosition, Quaternion newRotation, float mSpeed, float rSpeed)
    {
        // Move to target
        float timeElapsed = 0;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(originalPosition, newPosition, timeElapsed);
            transform.rotation = Quaternion.Slerp(originalRotation, newRotation, timeElapsed);
            timeElapsed += Time.deltaTime * mSpeed; // Use mSpeed for position and rotation alike for simplicity here
            yield return null;
        }
        transform.position = newPosition; // Ensure final position
        transform.rotation = newRotation; // Ensure final rotation

        // Move back to original
        timeElapsed = 0;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(newPosition, originalPosition, timeElapsed);
            transform.rotation = Quaternion.Slerp(newRotation, originalRotation, timeElapsed);
            timeElapsed += Time.deltaTime * mSpeed; // Use mSpeed for position and rotation alike for simplicity here
            yield return null;
        }
        transform.position = originalPosition; // Ensure final position
        transform.rotation = originalRotation; // Ensure final rotation
        hammermoving = false;
    }
    public void TextTimer()
    {
        StartCoroutine(TextTimerCoroutine());
    }
    IEnumerator TextTimerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        hammerText.text = string.Empty;
    }
    public void countdowntimer(float timer)
    {
        if (timer < 0)
            {
            timer = 0;
            }

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        trapCountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
