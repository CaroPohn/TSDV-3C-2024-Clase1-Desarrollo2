using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class JumpBehaviour : MonoBehaviour
{
    private Rigidbody rigidB;
    [SerializeField] private float force = 6f;
    [SerializeField] private float groundedDistance = 0.01f;
    [SerializeField] private LayerMask floor;
    [SerializeField] private Transform feetPivot;
    public bool _wantsToJump = false;

    private void Reset()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        if(!rigidB)
        {
            rigidB = GetComponent<Rigidbody>();
        }
    }

    public void Jump()
    {
        Debug.Log($"{name}: Jumped!");
        _wantsToJump = true;
    }

    private void FixedUpdate()
    {
        if (_wantsToJump && CanJump())
        {
            rigidB.AddForce(Vector3.up * force, ForceMode.Impulse);
            _wantsToJump = false;
        }
    }

    private bool CanJump()
    {
        if (Physics.Raycast(feetPivot.position, Vector3.down, out var hit, groundedDistance, floor)) //out var hit es una variable donde guarda la informacion que me da el raycast
        {
            return true;
        }

        return false;
    }
}
