using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!hasScored && other.gameObject.CompareTag("Player"))
        {   
            hasScored = true;
            ScoreController.Instance.AddScore(1);
        }
    }
}