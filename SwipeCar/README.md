- 프로젝트 진행(2D, VSync, Build Settings for iOS, bgcolor=DEDBD2)
    1. 리소스 나열: car, flag, ground, UI text(distance), Director
        1. 리소스를 프로젝트 내로 불러온다.
        2. 컨트롤러가 필요한 리소스를 구분한다: car
        3. 리소스를 Scene 뷰에 배치
            1. ground: Position = (0, -5, 0), Scale = (18, 1, 1)
            2. car: Position = (-7, 3.7, 0)
            3. flag: Position = (7.5, -3.5, 0)
            4. Distance: UI > Legacy > Text에서 찾을 수 있다. 생성 시 Canvas 하위 리소스로 Text란 이름으로 만들어진다.
                - Position = (0, 0, 0)
                - (Width, Height) = (700, 80)
                - Font Size = 64
                - Alignment = (세로: 중앙, 가로: 중앙)
                - 
    2. 컨트롤러 스크립트: CarController
        - 스와이프 거리에 따라 속력을 설정한다.
        - 움직이기 시작하면 소리를 출력한다
            1. AudioSource 컴포넌트 추가
            2. 음원을 AudioClip 속성에 드래그해서 놓기.
            3. Play On Awake 해제.
        - 움직인다.
    3. 제너레이터 스크립트: 없음
    4. 감독 스크립트: GameDirector
        - 역할: 자동차와 깃발 간 거리를 계산하고 그 거리를 UI 텍스트로 출력한다.
        - 감독 오브젝트가 필요(UI 리소스는 감독이 될 수 없다): 빈 오브젝트를 생성해 감독 스크립트를 컴포넌트로 결합시킨다.
    5. 스크립트 제작 흐름을 생각:
        - 컨트롤러 -> 감독 스크립트

- 문법
    - 컴포넌트 접근

- 용어
    - 월드 좌표계: 오브젝트가 게임판 내 어디 위치하는지 나타낸다.
    - 로컬 좌표계: 게임 오브젝트마다 지니는 좌표계. 오브젝트가 회전한다든지 하면 좌표계도 따라서 회전하는 등, 오브젝트 상태에 종속적이다.
    - UI: 게임의 상태나 진행 상황을 나타내는 게임 요소.
    - EventSystem: UI Text를 추가하면 자동으로 Hierarchy 창에 생성되는 리소스. 사용자 입력과 UI 리소스를 이어준다(=이벤트에 반응하도록 만든다). 
    - Transform: 위치, 회전, 크기 등 움직임과 관련된 속성, 메소드를 모아놓은 오브젝트 컴포넌트.
    - AudioSource: 소리와 관련한 컴포넌트.
    - Rect Transform: 피벗과 앵커 + Transform 컴포넌트.
    - 피벗: 회전 또는 확대/축소의 중심축
    - 앵커: UI 리소스 배치 시 기준 위치.
    - Play On Awake (AudioSource): 게임 시작과 동시에 음원 재생.

- CarController.cs
```C#
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
```
- GameDirector.cs
```C#
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
        float flagPos = this.flag.transform.position.x;
        float carPos = this.car.transform.position.x;
        float length = flagPos - carPos;
        
        // 5. 계산된 거리를 UI 텍스트로 띄운다
        // 5.1. 깃발을 지나치면 경고 문구를 띄운다.
        string info;
        if (length > 0)
        {
            /* 소수점 둘째 자리까지 출력.
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
```