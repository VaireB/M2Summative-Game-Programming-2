using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Camera Settings")]
    [SerializeField] private float cameraHeightOffset = 3f;
    [SerializeField] private float cameraBackwardOffset = 0f;
    [SerializeField] private float cameraLerpSpeed = 5f;

    private bool isGrounded;
    private Rigidbody rb;
    private Camera playerCamera;
    private Transform cameraTransform;

    // Add a reference to the Job class to handle different class abilities
    private Job characterClass;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        cameraTransform = playerCamera.transform;

        // Initialize the character class based on selection
        characterClass = GetComponent<Job>(); // Assuming the character class script is attached to the player GameObject
    }

    void Update()
    {
        Move();
        RotateWithMouse();
        Jump();
        UpdateCameraFollow();

        // Check for player inputs for class actions
        HandleClassActions();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0f;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void UpdateCameraFollow()
    {
        // Calculate target position for the camera
        Vector3 targetPosition = transform.position + (Vector3.up * cameraHeightOffset) - (transform.forward * cameraBackwardOffset);

        // Smoothly move the camera to the target position
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, targetPosition, Time.deltaTime * cameraLerpSpeed);

        // Make the camera look at the player character
        playerCamera.transform.LookAt(transform.position + Vector3.up);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void HandleClassActions()
    {
        // Check for input corresponding to class actions
        if (Input.GetMouseButtonDown(0)) // Left click for attack
        {
            characterClass.Attack();
        }
        else if (Input.GetMouseButton(1)) // Right click for defend
        {
            characterClass.Defend();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)) // Left Shift for evade
        {
            characterClass.Evade();
        }
        else if (Input.GetKeyDown(KeyCode.R)) // R for special ability
        {
            characterClass.SpecialAbility();
        }
    }
}
