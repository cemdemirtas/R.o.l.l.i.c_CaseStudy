using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rigidbody rigidbodyComponent;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool x, y, z;

    private Vector3 origin;
    private void Start()
    {
        origin = transform.position;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbodyComponent.AddTorque(new Vector3(
            x ? (speed/10) : 0,
            y ? (speed/10) : 0,
            z ? (speed/10) : 0), ForceMode.VelocityChange);

        rigidbodyComponent.position = origin - rigidbodyComponent.centerOfMass;
    }
}
