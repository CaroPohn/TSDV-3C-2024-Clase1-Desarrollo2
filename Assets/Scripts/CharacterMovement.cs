using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    private Vector3 _desiredDirection;

    public void Move(Vector3 direction)
    {
        _desiredDirection = direction;
    }

    private void Update()
    {
        transform.position += _desiredDirection * speed * Time.deltaTime;

        float angle = Vector3.SignedAngle(transform.forward, _desiredDirection, transform.up); //Necesitamos el angulo mas corto para rotar, por eso usamos SignedAngle
        transform.Rotate(transform.up, angle * Time.deltaTime * rotationSpeed);
    }
}
