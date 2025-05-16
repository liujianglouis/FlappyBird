using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Transform scoreDisplayRoot;
    public static ScoreController Instance;
    public Sprite[] numberAssets; //数字1-9的图片

    public GameObject singleNumberPrefab;
    private List<GameObject> numberImageList = new List<GameObject>(); // 当前所有Image预制
    private int score;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    public void InitGame()
    {
        foreach (Transform child in scoreDisplayRoot)
        {
            Destroy(child.gameObject);
        }
        numberImageList.Clear();
        score = 0;
        UpdateScore(score);
    }

    public void AddScore(int addScore)
    {
        SoundManager.Instance.Playscore();
        score += addScore;
        UpdateScore(score);
    }

    public void UpdateScore(int score)
    {
        string scoreString = score.ToString();

        //当前显示位数小于数字位数的话，创建一个新的Image
        while (numberImageList.Count < scoreString.Length)
        {
            GameObject newsingleNumber = Instantiate(singleNumberPrefab, scoreDisplayRoot);
            numberImageList.Add(newsingleNumber);
        }

        // 更新每位数字的图像
        for (int i = 0; i < scoreString.Length; i++)
        {
            int number = scoreString[i] - '0'; //字符转化为整型
            Image img = numberImageList[i].GetComponent<Image>(); //
            img.sprite = numberAssets[number];
            img.SetNativeSize();
            numberImageList[i].SetActive(true);
        }
    }
    
}
