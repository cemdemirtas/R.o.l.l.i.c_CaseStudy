using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectArea : MonoBehaviour
{
    public int collectedCollectableCount;
    public int minimumCollectedCollectableCount;

    public Text collectedCollectableCountText;

    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void IncreaseCollectedCollectableCount()
    {
        collectedCollectableCount++;
        DisplayCollectedCollectableCount();
    }

    private void DisplayCollectedCollectableCount()
    {
        collectedCollectableCountText.text = collectedCollectableCount + " / " + minimumCollectedCollectableCount;
    }

    public void Animate()
    {
        StartCoroutine("AnimateCoroutine");
    }

    IEnumerator AnimateCoroutine()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("isActive");
    }

    public bool IsGameCompleted()
    {

        if (collectedCollectableCount <= minimumCollectedCollectableCount)
        {
            GameManager.OnLevelRestart?.Invoke();
        }
        else if(collectedCollectableCount >= minimumCollectedCollectableCount)
        {
            GameManager.OnLevelNext?.Invoke();

        }
        return true;
    }
}
