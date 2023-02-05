using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 1. 이동 거리 결정.
    float moveAmount = 3.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 방향키에 따라 이동.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RButtonDown();
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LButtonDown();
        }
    }

    // 3. 버튼 눌림 이벤트에 연결될 동작 정의.
    public void LButtonDown()
    {
        transform.Translate(-moveAmount, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(moveAmount, 0, 0);
    }
}
