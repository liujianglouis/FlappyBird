using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Sprite[] numberAssets;
    public GameObject singleNumberPrefab;
    public Transform scoreDisplayRoot;


    private int score = 0;
    private List<GameObject> numberImageList = new List<GameObject>(); // 当前所有Image预制
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreDisplay(0);
    }

    void UpdateScoreDisplay(int value)
    {
        string scoreString = value.ToString();

        //当前显示位数小于数字位数的话，创建一个新的Image
        while (numberImageList.Count < scoreString.Length) 
        {
            GameObject newDigit = Instantiate(singleNumberPrefab, scoreDisplayRoot);
            numberImageList.Add(newDigit);
        }

        // 更新每位数字的图像
        for (int i = 0; i < scoreString.Length; i++)
        {
            int Number = scoreString[i] - '0'; //字符转化为整型
            Image img = numberImageList[i].GetComponent<Image>(); //
            img.sprite = numberAssets[Number];
            img.SetNativeSize();
            numberImageList[i].SetActive(true);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        UpdateScoreDisplay(score);
    }
}
