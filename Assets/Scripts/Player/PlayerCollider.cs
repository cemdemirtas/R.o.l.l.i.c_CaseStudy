using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject rotator;

    public static PlayerCollider playerCollider;
    private void Awake()
    {
        if (playerCollider == null)
        {
            playerCollider = this;
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("FinishLine"))
    //    {
    //        UserInterfaceManager.userInterfaceManager.HideInGameUI();
    //        GameManager.OnLevelCompleted?.Invoke();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            //UserInterfaceManager.userInterfaceManager.FinishGame();
            GameManager.OnLevelCompleted?.Invoke();
            UserInterfaceManager.userInterfaceManager.IsGameCompleted(other.gameObject.GetComponent<CollectArea>().IsGameCompleted());
            other.gameObject.GetComponent<CollectArea>().Animate();
        }

        if (other.gameObject.CompareTag("RotatorActivator"))
        {
            PlayerRotatorActive();
            Destroy(other.gameObject);
        }
    }

    public void PlayerRotatorActive()
    {
        rotator.SetActive(true);
    }
    public void PlayerRotatorDeactive()
    {
        rotator.SetActive(false);
    }
}
