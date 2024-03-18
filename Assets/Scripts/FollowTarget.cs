using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, -5);

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
