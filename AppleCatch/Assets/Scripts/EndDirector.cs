using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDirector : MonoBehaviour
{
    GameObject gameDirector;
    GameObject scoreBoard;
    int point;

    void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
        scoreBoard = GameObject.Find("FinalScore");
        point = gameDirector.GetComponent<GameDirector>().point;
        scoreBoard.GetComponent<Text>().text = $"Score: {point}";   
        
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Destroy(gameDirector);
            SceneManager.LoadScene("GameScene");
       }
    }
}
