using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 1. 장면을 불러오는데 필요하다.

public class clearDirector : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // 2. 새로 시작한다.
        if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
