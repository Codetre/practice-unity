- 용어
    - 컴포넌트: 게임 오브젝트를 업그레이드 하는 일종의 부품. 스크립트, AudioSource가 컴포넌트의 일종.
    - 컨트롤러 스크립트: 오브젝트의 컴포넌트로서 오브젝트를 움직이는 대본.
    - 제너레이터 스크립트: 게임 플레이 중 나타나는 오브젝트를 생성하는 스크립트.
    - 감독 스크립트: 게임을 관장하며 UI를 조작하거나 진행 상황을 판단하는 스크립트.
    - VSync: 프레임 그리는 속도와 모니터 갱신 속도를 동기화.
    - Sprite: Scene 뷰에 배치한 이미지 리소스
    - 
- 게임 설계 5단계
    1. 화면에 놓을 오브젝트를 모두 나열
    2. 오브젝트를 움직일 수 있는 컨트롤러 스크립트 결정
        1. 움직이는 오브젝트들을 분류
    3. 오브젝트를 자동 생성할 수 있는 제너레이터 스크립트 결정
        1. 게임 플레이 중 생성될 오브젝트 분류
    4. UI를 갱신할 수 있는 감독 스크립트 준비
    5. 스크립트 제작 흐름을 생각
        1. 기본 흐름은 컨트롤러->제너레이터->감독 스크립트 순.

- Roulette 운세 게임 제작 과정
    1. 프로젝트 생성: 2D 플랫폼
        1. VSync 설정: Game 뷰 > Free Aspect > VSync(Game view only)
        2. 동작 플랫폼 설정
            1. File > Build Settings(Cmd + Shift + B)
            2. Platform은 iOS 선택 후 Switch Platform 
        3. 동작 기기에 맞춘 화면 크기 설정: Game 뷰 > Free Aspect에서 선택.
        4. 배경색 설정: 카메라 오브젝트의 Inspector에서 Background 속성값을 'FBFBF2'로 설정.
    2. 리소스 추가: 룰렛과 바늘 이미지
        1. 프로젝트가 관리할 수 있도록 리소스를 프로젝트 뷰에 끌어다 놓는다.
        2. 리소스를 Scene 뷰 혹은 Hierarchy 창에 끌어 놓아 스프라이트로 만든다.
        3. 룰렛 스프라이트는 Position을 (X, Y, Z) = (0, 0, 0)으로 조절. 2D 플랫폼에서 카메라는 Z=-10이므로 이보다 작은 Z값의 스프라이트는 카메라 시야에 보이지 않는다.
        4. 바늘 스프라이트는 Position을 (X, Y, Z) = (0, 3.2, 0)으로 조절.
    3. 스크립트 작성
        1. Project 창의 + 버튼을 눌러 C# Script 제작
        ```C#
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        
        public class RouletteController : MonoBehaviour
        {
            // 1. 룰렛에 속도 속성을 부여.
            float rotSpeed = 0.0f;
            
            void Start()
            {
            }
            
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
        ```
        2. 컨트롤러 스크립트를 룰렛 오브젝트 컴포넌트로 적용
    4. 아이폰에 빌드
        1. File > Build Settings > Player Settings에서 Company Name 설정. `com.<Company Name>.<Product Name>`이 결합하여 유일한 ID가 되야 함.
        2. Build Settings > Scenes In Build에 작성한 Scene을 넣고, 사용할 Scene만 체크(기본 Scene인 'Scenes/SampleScene' 해제).
        3. Build 클릭.
        4. Build 디렉토리 내 Unity-iPhone.xcodeproj를 눌러 xCode 실행.
            ![[xcode.png]]
        5. Unity-iPhone > Signing & Capabilities > Automatically manage signing 체크 후 계정과 사용 기기 등록.
        6. 상단 바 Any iOS Device를 PC에 연결된 기기로 전환. 이 때 앱 구동 기기는 잠금 해제해야 한다.
        7. Unity-iPhone 옆에 있는 ▶︎ 실행 아이콘 클릭
            - 만약 'Could not launch \<app\>이란 실패가 뜨면 아이폰 설정 > 일반 > 기기 관리에서 개발자 등록을 하면 해결.
        