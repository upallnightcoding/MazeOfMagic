
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownCameraCntrl : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Camera Position")]
    [SerializeField] private float height = 10f;
    [SerializeField] private float distance = 8f;

    [Range(10f, 90f)]
    [SerializeField] private float angle = 55f;

    [Header("Camera Damping")]
    [SerializeField] private float followDamping = 8f;
    [SerializeField] private float rotationDamping = 12f;

    [Header("Rotation Settings")]
    [SerializeField] private float joystickRotationSpeed = 180f;
    [SerializeField] private float mouseSensitivity = 0.15f;
    [SerializeField] private float joystickDeadZone = 0.15f;

    [Header("Mouse Settings")]
    [SerializeField] private bool requireRightMouseButton = true;

    private PlayerInputActionsMap playerInputActionsMap;

    private float targetYaw;
    private float currentYaw;

    private Vector3 followPosition;

    private void Awake()
    {
        playerInputActionsMap = new PlayerInputActionsMap();
    }

    private void OnEnable()
    {
        playerInputActionsMap.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActionsMap.Player.Disable();
    }

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError(
                "TopDownCameraController: Target not assigned."
            );

            enabled = false;
            return;
        }

        targetYaw = transform.eulerAngles.y;
        currentYaw = targetYaw;

        followPosition = target.position;

        UpdateCameraTransform();
    }

    private void LateUpdate()
    {
        ReadCameraInput();
        UpdateCameraYaw();
        UpdateFollowPosition();
        UpdateCameraTransform();
    }

    private void ReadCameraInput()
    {
        Vector2 lookInput =
            playerInputActionsMap.Player.Look.ReadValue<Vector2>();

        float rotationInput = 0f;

        // Determine which input device is providing Look.
        InputControl activeControl =
            playerInputActionsMap.Player.Look.activeControl;

        bool usingMouse =
            activeControl?.device is Mouse;

        if (usingMouse)
        {
            // Mouse rotation requires right mouse button.
            bool mouseActive =
                !requireRightMouseButton ||
                (Mouse.current != null &&
                 Mouse.current.rightButton.isPressed);

            if (mouseActive)
            {
                // Mouse delta is already frame-based.
                rotationInput =
                    lookInput.x * mouseSensitivity;
            }
        }
        else
        {
            // Joystick input is a continuous axis.
            if (Mathf.Abs(lookInput.x) > joystickDeadZone)
            {
                rotationInput =
                    lookInput.x *
                    joystickRotationSpeed *
                    Time.deltaTime;
            }
        }

        // Yaw changes only when rotation input is received.
        targetYaw += rotationInput;
    }

    private void UpdateCameraYaw()
    {
        float smoothing =
            1f - Mathf.Exp(
                -rotationDamping * Time.deltaTime
            );

        currentYaw = Mathf.LerpAngle(
            currentYaw,
            targetYaw,
            smoothing
        );
    }

    private void UpdateFollowPosition()
    {
        float smoothing =
            1f - Mathf.Exp(
                -followDamping * Time.deltaTime
            );

        followPosition = Vector3.Lerp(
            followPosition,
            target.position,
            smoothing
        );
    }

    private void UpdateCameraTransform()
    {
        // Calculate yaw rotation around the player.
        Quaternion yawRotation =
            Quaternion.Euler(0f, currentYaw, 0f);

        // Horizontal offset from the player.
        Vector3 horizontalOffset =
            yawRotation * Vector3.back * distance;

        // Camera follows without changing orientation.
        transform.position =
            followPosition +
            horizontalOffset +
            Vector3.up * height;

        // Fixed pitch and input-controlled yaw.
        transform.rotation = Quaternion.Euler(
            angle,
            currentYaw,
            0f
        );
    }

    private void OnDestroy()
    {
        playerInputActionsMap?.Dispose();
    }
}
