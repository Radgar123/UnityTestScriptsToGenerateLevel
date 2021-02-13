using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10f;
    public float jumpStrenght = 10f;
    public float timeToJumpInAir = 0.1f;
    private float lastGroundedTime = 0;

    [Header("Look")]
    public Transform eyes = null;
    public float sensivity = 0.1f;
    public float maxVecticalDegrees = 80;

    [Header("Gravity")]
    public float gravity = 9.81f;
    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    // Unity components
    private InputMaster inputSystem;
    private Transform transformSystem;
    private CharacterController controllerSystem;

    private void Awake()
    {
        // Cursor setup
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Unity Variables
        inputSystem = new InputMaster();
        transformSystem = transform;
        controllerSystem = GetComponent<CharacterController>();
        // Input Actions
        inputSystem.Player.Fire.performed += ctx => Fire();
        inputSystem.Player.Aim.performed += ctx => Aim();
        inputSystem.Player.Jump.performed += ctx => Jump();
        // Check Varibles
        if (eyes == null) 
            eyes = transform.Find("Eyes");
    }

    private void Update()
    {
        Movement(inputSystem.Player.Movement.ReadValue<Vector2>());
        Look(inputSystem.Player.Look.ReadValue<Vector2>());
        CheckGrounded();
        Gravity();
    }

    private void Movement(Vector2 direction)
    {
        var forwardPosition = transformSystem.forward * direction.y * movementSpeed;
        var rightPosition = transformSystem.right * direction.x * movementSpeed;

        var movePosition = (forwardPosition + rightPosition) * Time.deltaTime;

        controllerSystem.Move(movePosition);
    }

    private void Look(Vector2 direction)
    {
        RotateBody(direction.x * sensivity);
        LookVertical(-direction.y * sensivity);
    }
    private void RotateBody(float rotationValue)
    {
        transformSystem.Rotate(new Vector3(0, rotationValue, 0));
    }
    private void LookVertical(float rotationValue)
    {
        Vector3 newRotation = eyes.eulerAngles + new Vector3(rotationValue, 0, 0);

        if (newRotation.x < 360 - maxVecticalDegrees && newRotation.x > 180) newRotation.x = 360 - maxVecticalDegrees;
        else if (newRotation.x > maxVecticalDegrees && newRotation.x < 180) newRotation.x = maxVecticalDegrees;

        eyes.eulerAngles = newRotation;
    }

    private void Gravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controllerSystem.Move(velocity * Time.deltaTime);
        }
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (isGrounded) lastGroundedTime = Time.time;
    }

    private void Jump()
    {
        if (!isGrounded && lastGroundedTime < Time.time - timeToJumpInAir) return;

        velocity.y = jumpStrenght;
    }

    private void Fire()
    {
        print("Pow");
    }

    private void Aim()
    {
        print("Aim");
    }

    // On/Off Input System
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }
}


