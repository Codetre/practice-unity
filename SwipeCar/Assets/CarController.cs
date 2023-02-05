using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // 1. 자동차는 처음에 정지된 상태로 시작한다.
    float speed = 0;
    Vector2 startPos;

    void Start()
    {
    }

    void Update()
    {   
        // 2. 스와이프 거리를 계산한다.
        // 2.1. 시작 지점을 얻는다.
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        
        } 
        // 2.2 종료 지점을 얻는다.
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            
            // 2.3. 두 지점 사이 거리에 비례하여 속력을 얻는다.
            float swipeLength = endPos.x - startPos.x;
            this.speed = swipeLength / 500.0f;

            // 4. AudioSource 컴포넌트에 입력한 음원을 재생한다.
            GetComponent<AudioSource>().Play();
        }
        
        // 3. x axis를 따라 오브젝트를 현재 위치에서 `this.speed`만큼 움직인다.
        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
    }
}
