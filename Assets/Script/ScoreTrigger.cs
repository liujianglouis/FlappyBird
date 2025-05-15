using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private ScoreController scoreController;
    // Start is called before the first frame update
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