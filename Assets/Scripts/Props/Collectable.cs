using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            Vector3 direction = other.gameObject.transform.position - transform.position;

            GetComponent<Rigidbody>().AddForce(
                new Vector3(0,0,direction.z) * 2);

            other.gameObject.GetComponent<CollectArea>().IncreaseCollectedCollectableCount();
        }
    }
}
