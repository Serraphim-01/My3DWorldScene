using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;

    [Header("Animation")]
    public Animator animator;

    private CharacterController controller;
    private PlayerControls controls;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private bool isCrouching;

    private float xRotation = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();

        controls.GamePlay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.GamePlay.Move.canceled += _ => moveInput = Vector2.zero;

        controls.GamePlay.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.GamePlay.Look.canceled += _ => lookInput = Vector2.zero;

        controls.GamePlay.Crouch.performed += _ => ToggleCrouch();
    }

    void OnEnable() => controls.GamePlay.Enable();
    void OnDisable() => controls.GamePlay.Disable();

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float speed = isCrouching ? crouchSpeed : walkSpeed;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        // Update walking animation
        bool isWalking = moveInput.magnitude > 0.1f;
        animator.SetBool("walking", isWalking);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void ToggleCrouch()
    {
        isCrouching = !isCrouching;
        animator.SetTrigger("crouch");

        // Optional: Adjust controller height
        controller.height = isCrouching ? 1f : 2f;
        controller.center = isCrouching ? new Vector3(0, 0.5f, 0) : new Vector3(0, 1f, 0);
    }
}
