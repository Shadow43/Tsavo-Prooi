using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float RunMultiplyer;

    [Header("Look parameters")]
    [SerializeField] private float mSensativity;
    [SerializeField] private float lookRange;

    [Header("First Person References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputController playerInputController;

    private Vector3 currentMovement;
    private float lookUpDown;

    private float currentSpeed => walkSpeed + (playerInputController.RunningTriggered ? RunMultiplyer : 1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    private Vector3 calculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputController.MovementInput.x, 0f, playerInputController.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = calculateWorldDirection();
//        currentMovement.x = worldDirection.x * walkSpeed;
//        currentMovement.z = worldDirection.z * walkSpeed;

        currentMovement.x = worldDirection.x * currentSpeed;
        currentMovement.z = worldDirection.z * currentSpeed;

        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalLook(float lookAmountLock)
    {
        transform.Rotate(0, lookAmountLock, 0);
    }
    private void ApplyVerticalLook(float lookAmountLock)
    {
        lookUpDown = Mathf.Clamp(lookUpDown - lookAmountLock, -lookRange, lookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(lookUpDown, 0,0);
    }
    private void HandleLook()
    {
        float mouseXRotation = playerInputController.lookInput.x * mSensativity;
        float mouseYRotation = playerInputController.lookInput.y * mSensativity;
        ApplyHorizontalLook(mouseXRotation);
        ApplyVerticalLook(mouseYRotation);
    }
}
