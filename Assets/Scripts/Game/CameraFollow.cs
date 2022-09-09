using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y - offset.y,
            target.transform.position.z - offset.z);
    }
}
