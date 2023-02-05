using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    // 1. 룰렛에 속도 속성을 부여.
    float rotSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 마우스(화면 탭) 입력은 회전 속도를 늘린다.
        /* GetMouseButtonDown(btn)의 btn 인수는
         * 0: 왼쪽, 1: 오른쪽, 2: 휠로 나뉜다.
         *
         * GetMouseButtonDown: 눌림이 최초 감지된 프레임 동안만
         * GetMouseButtonUp: 뗌이 최초 감지된 프레임 동안만
         * GetMouseButton: 누르고 있는 매 프레임 동안
         */
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
        }
        
        // 3. 실제로 룰렛을 회전시킨다.
        // 양수면 CCW 방향으로 회전. 단위는 degree.
        transform.Rotate(0, 0, this.rotSpeed);

        // 4. 룰렛을 감속시킨다(선형 감속은 부자연스럽다).
        float attenuationCoefficient = 0.96f;
        this.rotSpeed *= attenuationCoefficient;
    }
}
