using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        isGameStarted = true;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
