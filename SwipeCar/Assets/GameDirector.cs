using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. UI를 사용하기 위한 조건.
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // 2. Scene에 올라가 있는 sprites를 참조할 변수들.
    GameObject car;
    GameObject flag;
    GameObject distance;

    void Start()
    {
        // 3. 스프라이트들을 이름으로 찾아 대입.
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    void Update()
    {
        // 4. 자동차와 깃발 거리를 계산한다.
        // transform은 자주 쓰이므로 특별히 GetComponent<Transform>()의 shortcut으로 접근
        float flagPos = this.flag.transform.position.x;
        float carPos = this.car.transform.position.x;
        float length = flagPos - carPos;

        // 5. 계산된 거리를 UI 텍스트로 띄운다
        // 5.1. 깃발을 지나치면 경고 문구를 띄운다.
        string info;
        if (length > 0)
        {
            /* fixed width: 소수점 둘째 자리까지 출력.
             * `(456).ToString("D5")` -> 00456
             * `(12.3456).ToString("F3")` -> 12.345
             */
            info = $"목표 지점까지 " + length.ToString("F2") + " m";
        }
        // 5.2. 지나치지 않았다면 남은 거리를 표시한다.
        else
        {
            info = "게임 오버!";
        }
        /* object.GetComponent<Component>().property
         * `Component`에는 `AudioSource`, `Transform`, 작성한 스크립트 등을 지정 가능.
         */
        this.distance.GetComponent<Text>().text = info;
    }
}
