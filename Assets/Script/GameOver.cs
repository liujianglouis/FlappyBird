using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isGameOver && (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Land")))
        {
            Debug.Log("GameOver");
        }
    }
}
