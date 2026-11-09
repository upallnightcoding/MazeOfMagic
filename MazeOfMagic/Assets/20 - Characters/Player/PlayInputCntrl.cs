
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerInputController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private float inputDeadZone = 0.1f;

    [Header("Gravity Settings")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundedForce = -2f;

    [Header("Animation Settings")]
    [SerializeField] private float animationDampTime = 0.1f;

    private PlayerInputActionsMap playerInputActionMap;
    private CharacterController characterController;
    private Animator animator;

    private Vector2 movementInput;
    private Vector3 movementDirection;

    private float verticalVelocity;

    private static readonly int SpeedHash =
        Animator.StringToHash("Speed");

    private void Awake()
    {
        playerInputActionMap = new PlayerInputActionsMap();

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // CharacterController handles movement, not root motion.
        animator.applyRootMotion = false;

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        playerInputActionMap.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActionMap.Player.Disable();
    }

    private void Update()
    {
        ReadPlayerInput();
        CalculateMovementDirection();
        RotatePlayer();
        MovePlayer();
        UpdateAnimator();
    }

    private void ReadPlayerInput()
    {
        movementInput =
            playerInputActionMap.Player.Move.ReadValue<Vector2>();

        if (movementInput.magnitude < inputDeadZone)
        {
            movementInput = Vector2.zero;
        }

        movementInput = Vector2.ClampMagnitude(
            movementInput, 1f
        );
    }

    private void CalculateMovementDirection()
    {
        if (cameraTransform == null)
        {
            movementDirection = Vector3.zero;
            return;
        }

        // Get camera-relative forward and right directions.
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Remove vertical components.
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // Handle a directly overhead camera.
        if (cameraForward.sqrMagnitude < 0.0001f)
        {
            cameraForward = cameraTransform.up;
            cameraForward.y = 0f;
        }

        cameraForward.Normalize();

        // Keep the right vector perpendicular to forward.
        cameraRight = Vector3.Cross(
            Vector3.up,
            cameraForward
        ).normalized;

        movementDirection =
            cameraForward * movementInput.y +
            cameraRight * movementInput.x;

        movementDirection = Vector3.ClampMagnitude(
            movementDirection, 1f
        );
    }

    private void RotatePlayer()
    {
        if (movementDirection.sqrMagnitude < 0.0001f)
            return;

        Quaternion targetRotation =
            Quaternion.LookRotation(
                movementDirection,
                Vector3.up
            );

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void MovePlayer()
    {
        // Maintain a small downward force while grounded.
        if (characterController.isGrounded &&
            verticalVelocity < 0f)
        {
            verticalVelocity = groundedForce;
        }

        // Apply gravity.
        verticalVelocity += gravity * Time.deltaTime;

        // Calculate horizontal movement.
        Vector3 horizontalMovement =
            movementDirection * moveSpeed;

        // Combine horizontal and vertical movement.
        Vector3 velocity =
            horizontalMovement +
            Vector3.up * verticalVelocity;

        // CharacterController.Move expects displacement.
        characterController.Move(
            velocity * Time.deltaTime
        );
    }

    private void UpdateAnimator()
    {
        float speed = movementInput.magnitude;

        animator.SetFloat(
            SpeedHash,
            speed,
            animationDampTime,
            Time.deltaTime
        );
    }

    private void OnDestroy()
    {
        playerInputActionMap?.Dispose();
    }
}
