using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;

    public float speed = 1;
    public float rotationSpeed = 1;
    [SerializeField] private float acceleration = 15;
    private Vector3 _desiredDirection;
    [SerializeField] private Rigidbody rBody;
    private bool _shouldBreak = false;
    [SerializeField] private float breakMultiplier = 0.75f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        if(rBody == null) 
        {
            rBody = GetComponent<Rigidbody>();
        }
    }

    public void Move(Vector3 direction)
    {
        Transform localTransform = transform;
        _desiredDirection = direction;
        
        var camera = Camera.main;
        if (camera != null)
        {
            localTransform = camera.transform;
        }

        _desiredDirection = localTransform.TransformDirection(_desiredDirection);
        _desiredDirection.y = 0;

        animator.SetBool("isRunning", true);

        if (direction == Vector3.zero) 
        {
            animator.SetBool("isRunning", false);
        }

        if (direction.magnitude < 0.0001f)
        {
            _shouldBreak = true;
        }
    }

    private void Update()
    {
        float angle = Vector3.SignedAngle(transform.forward, _desiredDirection, transform.up); //Necesitamos el angulo mas corto para rotar, por eso usamos SignedAngle
        transform.Rotate(transform.up, angle * Time.deltaTime * rotationSpeed);
    }

    private void FixedUpdate()
    {
        var currentVelocity = rBody.velocity;
        currentVelocity.y = 0;

        var currentSpeed = rBody.velocity.magnitude;
        if (currentSpeed < speed)
        {
            rBody.AddForce(_desiredDirection.normalized * acceleration, ForceMode.Force);
        }

        if (_shouldBreak)
        {
            rBody.AddForce(currentVelocity * breakMultiplier, ForceMode.Impulse);
            _shouldBreak = false;
        }
    }
}
