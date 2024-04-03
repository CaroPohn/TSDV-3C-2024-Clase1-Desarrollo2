using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;

    public float speed = 1;
    public float rotationSpeed = 1;
    private Vector3 _desiredDirection;
    [SerializeField] private Rigidbody rBody;

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
        
        var camera = Camera.main;
        if (camera != null)
        {
            localTransform = camera.transform;
        }
        var characterLocalDirection = transform.TransformDirection(direction);
        characterLocalDirection.y = 0;
        _desiredDirection = characterLocalDirection;

        animator.SetBool("isRunning", true);

        if (direction == Vector3.zero) 
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Update()
    {
        //transform.position += _desiredDirection * speed * Time.deltaTime;

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
            rBody.AddForce(_desiredDirection * speed, ForceMode.Force);
        }
    }
}
