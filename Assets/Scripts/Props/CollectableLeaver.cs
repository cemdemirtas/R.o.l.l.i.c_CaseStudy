using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLeaver : MonoBehaviour
{
    [SerializeField]
    private Vector3[] points;

    [SerializeField]
    private GameObject collectablePrefab;

    [SerializeField]
    private Transform muzzle;

    [SerializeField]
    private float speed;

    private int pointIndex;

    [SerializeField]
    private float nextCollectableTime;
    private float nextTimeToCollectable;

    private void Start()
    {
        transform.position = points[0]; //begin pos
    }

    private void Update()
    {
        if (pointIndex < points.Length)
        {
            transform.DOMove(points[pointIndex], speed);
            if (Vector3.Distance(transform.position, points[pointIndex]) < 0.5f)
            {
                pointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }


        if (nextTimeToCollectable < Time.time)
        {
            nextTimeToCollectable = Time.time + nextCollectableTime;
            Instantiate(collectablePrefab, muzzle.position, Quaternion.identity);
        }
    }
}
