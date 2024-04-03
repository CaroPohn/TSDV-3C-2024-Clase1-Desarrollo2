using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, -5);
    public float rotationSpeed = 5;
    public float followSpeed = 5;

    void FixedUpdate()
    {
        //Position
        var offsetBasedOnTarget = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, offsetBasedOnTarget, Time.deltaTime * followSpeed);

        //Rotation
        var desiredRotation = target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);

        //Lerp = Linear Interpolation. Es una linea recta, sirve mejor para posiciones.

        //Slerp = Interpola entre rotaciones, busca puntos dentro de una circunferencia para una rotacion mas "correcta". Es mejor para
        //        rotaciones.
    }
}
