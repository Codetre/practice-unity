using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    float remainingTime;
    public int point = 0;

    GameObject timer;
    GameObject score;
    GameObject itemGenerator;

    float lv1UpperTime;
    float lv1LowerTime;
    float lv2LowerTime;
    float lv3LowerTime;
    float lv4LowerTime;
    
    public void CatchApple()
    {
        this.point += 100;
    }

    public void CatchBomb()
    {
        this.point /= 2;
    }

    void Start()
    {   
        this.remainingTime = 30.0f;
        lv1UpperTime = remainingTime;
        lv1LowerTime = 23.0f;
        lv2LowerTime = 12.0f;
        lv3LowerTime = 5.0f;
        lv4LowerTime = 0.0f;

        this.timer = GameObject.Find("Timer");
        this.score = GameObject.Find("Score");
        this.itemGenerator = GameObject.Find("ItemGenerator");
    }

    void Update()
    {
        this.remainingTime -= Time.deltaTime;
        this.timer.GetComponent<Text>().text = this.remainingTime.ToString("F1");
        this.score.GetComponent<Text>().text = $"{this.point} points";

        // 남은 시간에 따라 레벨 변경: 생성 속도, 낙하 속도, 폭탄 비율.
        if (lv1LowerTime <= this.remainingTime && 
                this.remainingTime < lv1UpperTime)  // Lv.1
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParams(1, 0.03f, 2);
        } else if (lv2LowerTime <= this.remainingTime && 
                this.remainingTime < lv1LowerTime)  // Lv.2
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParams(0.8f, 0.04f, 4);
        } else if (lv3LowerTime <= this.remainingTime && 
                this.remainingTime < lv2LowerTime)  // Lv.3
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParams(0.5f, 0.05f, 6);
        } else if (lv4LowerTime <= this.remainingTime && 
                this.remainingTime < lv3LowerTime)  // Lv.4
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParams(0.7f, 0.04f, 3);
        } else  // Game end. Go to the EndScene.
        {
            // this.remainingTime = 0.0f;
            SceneManager.LoadScene("EndScene");
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
